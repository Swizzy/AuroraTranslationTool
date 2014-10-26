//#define NO_ICON_SAVE // Disable icon saving
namespace AuroraTranslationTool {
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Windows.Forms;
    using System.Xml;
    using AuroraTranslationTool.Properties;

    public partial class TranslationPackData: Form {
        private const string DefaultVers = "0.3";
        private const int SpriteWidth = 64, SpriteHeight = 64;
        private readonly DataContractJsonSerializer _json = new DataContractJsonSerializer(typeof(LanguagePackData));
        internal string LangFile;
        private Image _customImage;
        private byte[] _customImageData;
        private LanguagePackData _packData = new LanguagePackData();

        public TranslationPackData() {
            InitializeComponent();
            _packData.Index = 0;
            pictureBox1.Location = new Point(groupBox1.Width / 2 - 32, pictureBox1.Location.Y);
            button4.Location = new Point(Width / 2 - (button4.Width / 2), button4.Location.Y);
            CheckForIllegalCrossThreadCalls = false;
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, args) => {
                             var langList = CultureInfo.GetCultures(CultureTypes.AllCultures).Select(cinfo => new LangList(cinfo)).ToList();
                             langList.Sort(LangListCompare);
                             comboBox2.Items.AddRange(langList.ToArray());
                             foreach(var lang in comboBox2.Items.Cast<LangList>().Where(lang => lang.CultureInfo.Equals(CultureInfo.CurrentCulture))) {
                                 comboBox2.SelectedItem = lang;
                                 break;
                             }
                             var sprites = Resources.sprites;
                             foreach(var line in Resources.spritesdata.Split(Environment.NewLine.ToCharArray())) {
                                 if(string.IsNullOrEmpty(line))
                                     continue;
                                 //Console.WriteLine(line);
                                 var x = line.Substring(line.IndexOf("x=", StringComparison.OrdinalIgnoreCase) + 2);
                                 x = x.Substring(0, x.IndexOf(" ", StringComparison.Ordinal));
                                 //Console.WriteLine("X: {0}", x);
                                 comboBox1.Items.Add(
                                                     new FlagList(
                                                         sprites.Clone(
                                                                       new Rectangle(int.Parse(x), int.Parse(line.Substring(line.IndexOf("y=", StringComparison.OrdinalIgnoreCase) + 2)), SpriteWidth,
                                                                                     SpriteHeight), sprites.PixelFormat), line.Substring(3, line.LastIndexOf("\"", StringComparison.Ordinal) - 3)));
                                 if(comboBox1.Items.Count == 1)
                                     comboBox1.SelectedIndex = 0;
                             }
                             comboBox1.Items.Add(new FlagList(null, "Custom"));
                         };
            bw.RunWorkerAsync();
            translatorbox.Text = Environment.UserName;
        }

        private static int LangListCompare(LangList list1, LangList list2) { return String.Compare(list1.ToString(), list2.ToString(), StringComparison.OrdinalIgnoreCase); }

        private static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight) {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            var bmp = new Bitmap(newImage);

            return bmp;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var flag = ((FlagList)comboBox1.SelectedItem).Flag;
            if(flag == null) {
                _packData.Index = -1;
                pictureBox1.Image = _customImage ?? new Bitmap(SpriteWidth, SpriteHeight);
                return;
            }
            _packData.Index = comboBox1.SelectedIndex;
            pictureBox1.Image = flag;
        }

        private void LoadDat(string file) {
            using(Stream s = File.OpenRead(file))
                _packData = (LanguagePackData)_json.ReadObject(s);
            if(_packData.Index != -1)
                comboBox1.SelectedIndex = _packData.Index;
            else
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            langbox.Text = _packData.Displayname;
            langcodebox.Text = _packData.Languagecode;
            translatorbox.Text = _packData.Translator;
            EnableCompileBtn();
        }

        private void EnableCompileBtn() { button4.Enabled = true; }

        private void SaveDat(string file, string version) {
            _packData.Translator = translatorbox.Text;
            _packData.Displayname = langbox.Text;
            _packData.Languagecode = langcodebox.Text;
            _packData.Version = version;
            using(Stream s = File.OpenWrite(file))
                _json.WriteObject(s, _packData);
#if !NO_ICON_SAVE
            // ReSharper disable AssignNullToNotNullAttribute
            var icopath = Path.Combine(Path.GetDirectoryName(file), "icon.png");
            // ReSharper restore AssignNullToNotNullAttribute
            if(_packData.Index == -1)
                File.WriteAllBytes(icopath, _customImageData);
            else
                ((FlagList)comboBox1.Items[_packData.Index]).Flag.Save(icopath, ImageFormat.Png);
#endif
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            var cinfo = ((LangList)comboBox2.SelectedItem).CultureInfo;
            langbox.Text = cinfo.NativeName;
            langcodebox.Text = cinfo.Name;
        }

        private void button3_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                                             FileName = "language.dat"
                                         };
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            LoadDat(ofd.FileName);
        }

        private void button1_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                                             Filter = @"Image Files|*.bmp;*.jpg;*.jpeg;*.tiff;*.png"
                                         };
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            var data = File.ReadAllBytes(ofd.FileName);
            using(var ms = new MemoryStream(data)) {
                var tmp = ScaleImage(Image.FromStream(ms), SpriteWidth, SpriteHeight);
                using(var ms2 = new MemoryStream()) {
                    tmp.Save(ms2, ImageFormat.Png);
                    _customImageData = ms2.ToArray();
                    _customImage = Image.FromStream(ms2);
                }
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog {
                                             FileName = "language.dat"
                                         };
            if(sfd.ShowDialog() != DialogResult.OK)
                return;
            SaveDat(sfd.FileName, DefaultVers);
        }

        private static string GetBinPath(string file) {
            if(File.Exists("bin\\" + file))
                return Path.Combine(Directory.GetCurrentDirectory(), "bin\\" + file);
            if(File.Exists("C:\\Program Files (x86)\\Microsoft Xbox 360 SDK\\bin\\win32\\" + file))
                return "C:\\Program Files (x86)\\Microsoft Xbox 360 SDK\\bin\\win32\\" + file;
            if(File.Exists("C:\\Program Files\\Microsoft Xbox 360 SDK\\bin\\win32\\" + file))
                return "C:\\Program Files\\Microsoft Xbox 360 SDK\\bin\\win32\\" + file;
            return null;
        }

        private void button4_Click(object sender, EventArgs e) {
            var xuipkg = GetBinPath("xuipkg.exe");
            if(!File.Exists(xuipkg)) {
                MessageBox.Show(@"xuipkg.exe not found!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resxloc = GetBinPath("resxloc.exe");
            if(!File.Exists(GetBinPath("resxloc.exe"))) {
                MessageBox.Show(@"resxloc.exe not found!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resx2Bin = GetBinPath("resx2bin.exe");
            if(!File.Exists(GetBinPath("resx2bin.exe"))) {
                MessageBox.Show(@"resx2bin.exe not found!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CompileLangPack(LangFile, xuipkg, resx2Bin, resxloc);
        }

        private void CompileLangPack(string src, string xuipkg, string resx2Bin, string resxloc) {
            var dir = Path.Combine(Path.GetTempPath(), "aurora_tmp");
            if(Directory.Exists(dir))
                Directory.Delete(dir, true); // Make sure it's clean!
            Directory.CreateDirectory(dir);
            File.Copy(src, Path.Combine(dir, "lang.xml"));
            SaveDat(Path.Combine(dir, "language.dat"), GetVersion(src));
            var proc = new Process {
                                       StartInfo = new ProcessStartInfo {
                                                                            Arguments = "/NOLOGO lang.xml",
                                                                            WorkingDirectory = dir,
                                                                            FileName = resxloc
                                                                        }
                                   };
            proc.Start();
            proc.WaitForExit();
            proc.StartInfo = new ProcessStartInfo {
                                                      Arguments = "/NOLOGO /I DynamicStrings.resx",
                                                      WorkingDirectory = dir,
                                                      FileName = resx2Bin
                                                  };
            proc.Start();
            proc.WaitForExit();
            File.Delete(Path.Combine(dir, "DynamicStrings.resx"));
            File.Move(Path.Combine(dir, "DynamicStrings.xus"), Path.Combine(dir, "Aurora_Strings.xus"));
            proc.StartInfo = new ProcessStartInfo {
                                                      Arguments = "/NOLOGO *.resx",
                                                      WorkingDirectory = dir,
                                                      FileName = resx2Bin
                                                  };
            proc.Start();
            proc.WaitForExit();
            foreach(var file in Directory.GetFiles(dir, "*.resx").Where(file => file.EndsWith(".resx")))
                File.Delete(file);
            File.Delete(Path.Combine(dir, "lang.xml"));
            proc.StartInfo = new ProcessStartInfo {
                                                      Arguments = "/NOLOGO /R /O ..\\Default.xzp *.*",
                                                      WorkingDirectory = dir,
                                                      FileName = xuipkg
                                                  };
            proc.Start();
            proc.WaitForExit();
            var outfile = Path.Combine(dir, "..\\Default.xzp");
            if(!File.Exists(outfile))
                return;
            // ReSharper disable AssignNullToNotNullAttribute
            var tmp = Path.Combine(Path.GetDirectoryName(src), Path.GetFileNameWithoutExtension(src) + ".xzp");
            // ReSharper restore AssignNullToNotNullAttribute
            if (File.Exists(tmp))
                File.Delete(tmp);
            File.Move(outfile, tmp);
        }

        private static string GetVersion(string src) {
            using(var xml = XmlReader.Create(src)) {
                var isVersion = false;
                while(xml.Read()) {
                    if(!xml.IsStartElement())
                        continue;
                    switch(xml.Name.ToLower()) {
                        case "data":
                            var s = xml["name"];
                            if(s != null)
                                isVersion = s.EndsWith("LOCALE_VERSION", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "value":
                            if(!isVersion)
                                break;
                            xml.Read();
                            return xml.Value;
                    }
                }
            }
            return DefaultVers;
        }

        private class FlagList {
            public readonly Image Flag;
            private readonly string _name;

            public FlagList(Image flag, string name) {
                Flag = flag;
                _name = name;
            }

            public override string ToString() { return _name; }
        }

        private class LangList {
            public readonly CultureInfo CultureInfo;

            public LangList(CultureInfo cultureInfo) { CultureInfo = cultureInfo; }

            public override string ToString() { return string.Format("{0} [{1}] [{2}]", CultureInfo.NativeName, CultureInfo.EnglishName, CultureInfo.Name); }
        }

        private void TranslationPackData_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }

    [DataContract] public class LanguagePackData {
        [DataMember(Name = "displayname", Order = 0)] public string Displayname;
        [DataMember(Name = "index", Order = int.MaxValue)] public int Index;
        [DataMember(Name = "languagecode", Order = 1)] public string Languagecode;
        [DataMember(Name = "translator", Order = 2)] public string Translator;
        [DataMember(Name = "version", Order = 3)] public string Version;
    }
}