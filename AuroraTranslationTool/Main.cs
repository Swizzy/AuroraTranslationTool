namespace AuroraTranslationTool {
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml;

    public sealed partial class Main: Form {
        internal readonly List<TranslationObject> TranslationObjects = new List<TranslationObject>();
        private readonly List<SectionFilter> _sectionFilters = new List<SectionFilter>();
        private readonly TranslationPackData _tpd = new TranslationPackData();
        internal SearchForm LastSearch;
        private TranslationObject _currObj;
        private TranslationObject _locverObj;
        private bool _origLoaded;
        private string _savepath;

        public Main() {
            InitializeComponent();
            var ver = Assembly.GetAssembly(typeof(Main)).GetName().Version;
            Text = string.Format(Text, ver.Major, ver.Minor, ver.Build);
            Main_SizeChanged(null, null);
            MakeSectionsFilter();
            UpdateStats();
            MouseWheel += OnMouseWheel;
        }

        private void OnMouseWheel(object sender, MouseEventArgs e) {
            if(ModifierKeys != Keys.Control)
                return;
            if(e.Delta > 0) {
                var font = new Font(origbox.Font.Name, origbox.Font.SizeInPoints + 0.1F);
                origbox.Font = font;
                transbox.Font = font;
                listview.Font = new Font(listview.Font.Name, listview.Font.SizeInPoints + 0.1F);
            }
            else {
                if(origbox.Font.SizeInPoints < 7.8F)
                    return;
                var font = new Font(origbox.Font.Name, origbox.Font.SizeInPoints - 0.1F);
                origbox.Font = font;
                transbox.Font = font;
                listview.Font = new Font(listview.Font.Name, listview.Font.SizeInPoints - 0.1F);
            }
        }

        internal void UpdateStats() {
            var finished = 0;
            var numeric = 0;
            var empty = 0;
            foreach(var translationObject in TranslationObjects) {
                if(translationObject.Finished)
                    finished++;
                if(translationObject.Numerical)
                    numeric++;
                if(translationObject.IsEmpty)
                    empty++;
            }
            if(_sectionFilters.Count <= 0) {
                _sectionFilters.Add(new SectionFilter("All", true));
                sections.Items.AddRange(_sectionFilters.ToArray());
                sections.SelectedIndex = 0;
            }
            statslabel.Text = string.Format("{0} Strings loaded {1} Strings translated {2} Numerical values {3} Empty entries {4} Shown entries {5} Sections", TranslationObjects.Count, finished,
                                            numeric, empty, listview.Items.Count, _sectionFilters.Count - 1);
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys) {
            if(keys == (Keys.F | Keys.Control)) {
                if(listview.Items.Count > 0 || TranslationObjects.Count > 0) {
                    if(LastSearch == null)
                        LastSearch = new SearchForm(this);
                    if(listview.Items.Count <= 1) {
                        LastSearch.searchAll.Checked = true;
                        LastSearch.searchAll.Enabled = false;
                    }
                    else
                        LastSearch.searchAll.Enabled = true;

                    LastSearch.ShowDialog();
                    return true;
                }
            }
            if(keys == (Keys.Shift | Keys.A | Keys.Control)) {
                if(!savecurlinebtn.Enabled)
                    return base.ProcessCmdKey(ref message, keys);
                var orig = _currObj.Original;
                var trans = transbox.Text.Replace(Environment.NewLine, "\\n");
                if(
                    MessageBox.Show(string.Format("Are you sure you want to set all instances of {2}{0}{2}to{2}{1}{2}?", orig, trans, Environment.NewLine), @"Are you sure?",
                                    MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                    return true;
                foreach(var translationObject in TranslationObjects) {
                    if(translationObject.Original != orig)
                        continue;
                    translationObject.Translation = trans;
                    translationObject.SetFinished();
                }
                var list = listview.Items.Cast<ListViewItem>().Where(lvi => lvi.SubItems[1].Text == orig).ToList();
                foreach(var lvi in list)
                    listview.Items.Remove(lvi);
                UpdateStats();
                return true;
            }
            if(keys == (Keys.S | Keys.Shift | Keys.Control))
                savetransbtn_Click(null, null);
            if(keys == (Keys.C | Keys.Shift | Keys.Control))
                compilebtn_Click(null, null);
            if(keys != (Keys.S | Keys.Control))
                return base.ProcessCmdKey(ref message, keys);
            if(!savecurlinebtn.Enabled)
                return base.ProcessCmdKey(ref message, keys);
            savecurlinebtn_Click(null, null);
            return true;
        }

        private void Main_SizeChanged(object sender, EventArgs e) {
            origgbox.Width = (Width - 46) / 2;
            if(origgbox.Width < 304)
                origgbox.Width = 304;
            transgbox.Width = (Width - 46) / 2;
            if(transgbox.Width < 304)
                transgbox.Width = 304;
            transgbox.Location = new Point(origgbox.Width + 18, origgbox.Location.Y);
        }

        private void loadorigbtn_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                                             Title = @"Select Original",
                                             Filter = @"Aurora Translation file(s) (*.xml)|*.xml|All Files|*.*"
                                         };
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            Parsexml(ofd.FileName, true);
            _origLoaded = true;
            UpdateStats();
        }

        private void loadtransbtn_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                                             Title = @"Select Translation",
                                             Filter = @"Aurora Translation file(s) (*.xml)|*.xml|All Files|*.*"
                                         };
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            Parsexml(ofd.FileName, false);
            UpdateStats();
        }

        private void copybtn_Click(object sender, EventArgs e) {
            if(_currObj.Original != null)
                transbox.Text = _currObj.Original.Replace("\\n", Environment.NewLine);
            savecurlinebtn.Enabled = true;
        }

        private void savecurlinebtn_Click(object sender, EventArgs e) {
            if(_currObj == null)
                return;
            foreach(var translationObject in TranslationObjects) {
                if(translationObject.Id != _currObj.Id)
                    continue;
                translationObject.Translation = transbox.Text.Replace(Environment.NewLine, "\\n");
                translationObject.SetFinished();
                _currObj.Translation = translationObject.Translation;
                transbox.Text = "";
                origbox.Text = "";
                savetransbtn.Enabled = true;
                savecurlinebtn.Enabled = false;
                copybtn.Enabled = false;
                break;
            }
            var currItem = listview.Items.Cast<ListViewItem>().FirstOrDefault(lvi => lvi.Text == _currObj.Name);
            if(currItem != null && hidefinishedbox.Checked)
                listview.Items.Remove(currItem);
            else if(currItem != null)
                listview.Items[listview.Items.IndexOf(currItem)].SubItems[2].Text = _currObj.Translation;
            _currObj = null;
            UpdateStats();
        }

        private void Setviewitems() {
            listview.Items.Clear();
            foreach(var translationObject in TranslationObjects) {
                if(!((SectionFilter)sections.SelectedItem).All) {
                    var tmp = translationObject.Name.Substring(0, translationObject.Name.IndexOf(".", StringComparison.Ordinal));
                    if(!tmp.Equals(((SectionFilter)sections.SelectedItem).Value, StringComparison.CurrentCultureIgnoreCase))
                        continue;
                }
                if(hidenumbox.Checked && translationObject.Numerical)
                    continue;
                if(hideemptybox.Checked && translationObject.IsEmpty)
                    continue;
                if(hidefinishedbox.Checked && translationObject.Finished)
                    continue;
                var lvi = new ListViewItem(translationObject.Name);
                lvi.SubItems.Add(translationObject.Original);
                lvi.SubItems.Add(translationObject.Translation);
                lvi.Tag = translationObject.Id.ToString(CultureInfo.InvariantCulture);
                listview.Items.Add(lvi);
            }
            UpdateStats();
        }

        private void Parsexml(string file, bool orig) {
            var name = "";
            var exists = false;
            using(var xml = XmlReader.Create(file)) {
                while(xml.Read()) {
                    if(!xml.IsStartElement())
                        continue;
                    switch(xml.Name.ToLower()) {
                        case "data":
                            name = xml["name"];
                            break;
                        case "value":
                            TranslationObject tobj = null;
                            foreach(var translationObject in TranslationObjects) {
                                if(translationObject.Name != name)
                                    continue;
                                tobj = translationObject;
                                exists = true;
                                break;
                            }
                            if(tobj == null)
                                tobj = new TranslationObject(TranslationObjects.Count, name);
                            xml.Read();
                            var value = xml.Value;
                            if(!exists) {
                                if(orig)
                                    tobj.Original = value.Replace("\n", "\\n");
                                else
                                    tobj.Translation = value.Replace("\n", "\\n");
                                TranslationObjects.Add(tobj);
                            }
                            else {
                                if(TranslationObjects.Any(translationObject => translationObject.Id == tobj.Id)) {
                                    if(orig)
                                        tobj.Original = value.Replace("\n", "\\n");
                                    else
                                        tobj.Translation = value.Replace("\n", "\\n");
                                }
                            }
                            exists = false;
                            break;
                    }
                }
            }
            MakeSectionsFilter();
            Setviewitems();
            clearbtn.Enabled = true;
        }

        private void MakeSectionsFilter() {
            _sectionFilters.Clear();
            _sectionFilters.Add(new SectionFilter(null, true));
            foreach(var translationObject in TranslationObjects) {
                try {
                    var section = translationObject.Name.Substring(0, translationObject.Name.IndexOf(".", StringComparison.Ordinal));
                    var exists = _sectionFilters.Any(sectionFilter => section == sectionFilter.Value);
                    if(!exists)
                        _sectionFilters.Add(new SectionFilter(section));
                }
                catch {}
            }
            var index = sections.SelectedIndex;
            sections.Items.Clear();
            sections.Items.AddRange(_sectionFilters.ToArray());
            if(index < 0 || index > sections.Items.Count)
                sections.SelectedIndex = 0;
            else
                sections.SelectedIndex = index;
        }

        private void Savexml(string file) {
            var settings = new XmlWriterSettings {
                                                     OmitXmlDeclaration = true,
                                                     ConformanceLevel = ConformanceLevel.Fragment,
                                                     Encoding = Encoding.UTF8
                                                 };
            using(var xml = XmlWriter.Create(file, settings)) {
                xml.WriteStartElement("root");
                xml.WriteWhitespace("\n");
                foreach(var item in TranslationObjects) {
                    if(item.Original == null && _origLoaded)
                        continue;
                    xml.WriteStartElement("data");
                    xml.WriteStartAttribute("name");
                    xml.WriteValue(item.Name);
                    string value;
                    if(!string.IsNullOrEmpty(item.Translation))
                        value = item.Translation.Replace("\\n", "\n");
                    else
                        value = item.Original != null ? item.Original.Replace("\\n", "\n") : "";
                    xml.WriteElementString("value", value);
                    xml.WriteEndElement();
                    xml.WriteWhitespace("\n");
                }
                xml.WriteEndElement();
            }
        }

        private void transbox_TextChanged(object sender, EventArgs e) {
            if(_currObj == null)
                return;
            if(transbox.Text != origbox.Text && transbox.Text.Length > 0)
                savecurlinebtn.Enabled = true;
            else
                savecurlinebtn.Enabled = false;
        }

        private void clearbtn_Click(object sender, EventArgs e) {
            clearbtn.Enabled = false;
            _origLoaded = false;
            savecurlinebtn.Enabled = false;
            copybtn.Enabled = false;
            savetransbtn.Enabled = false;
            TranslationObjects.Clear();
            _currObj = null;
            origbox.Text = "";
            transbox.Text = "";
            listview.Items.Clear();
            _sectionFilters.Clear();
            sections.Items.Clear();
            UpdateStats();
        }

        private void listview_DoubleClick(object sender, EventArgs e) {
            if(savecurlinebtn.Enabled && _currObj != null) {
                var res = MessageBox.Show(@"Are you sure you want to load a new value without saving the current one?", @"Are you sure?", MessageBoxButtons.YesNoCancel);
                if(res != DialogResult.Yes)
                    return;
            }
            _currObj = null;
            var id = int.Parse(listview.SelectedItems[0].Tag.ToString());
            foreach(var translationObject in TranslationObjects) {
                if(translationObject.Id != id)
                    continue;
                _currObj = translationObject;
                break;
            }
            if(_currObj == null)
                return; // Dafuq did you do?!
            transbox.Text = "";
            origbox.Text = "";
            if(_currObj.Translation != null)
                transbox.Text = _currObj.Translation.Replace("\\n", Environment.NewLine);
            if(_currObj.Original != null)
                origbox.Text = _currObj.Original.Replace("\\n", Environment.NewLine);
            copybtn.Enabled = true;
            savecurlinebtn.Enabled = transbox.Text.Length > 0;
        }

        private void savetransbtn_Click(object sender, EventArgs e) {
            if(!IsLocaleMatch()) {
                if(
                    MessageBox.Show(string.Format("Do you want to update the Locale Version from {0} to {1}?", _locverObj.Translation, _locverObj.Original),
                                    @"Do you want to update the locale version?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    _locverObj.Translation = _locverObj.Original;
            }
            if(!keepsavepathbox.Checked || string.IsNullOrEmpty(_savepath)) {
                var sfd = new SaveFileDialog {
                                                 AddExtension = true,
                                                 DefaultExt = "xml",
                                                 Filter = @"Aurora Translation file(s) (*.xml)|*.xml|All Files|*.*"
                                             };
                if(sfd.ShowDialog() != DialogResult.OK)
                    return;
                Savexml(sfd.FileName);
                if(keepsavepathbox.Checked)
                    _savepath = sfd.FileName;
            }
            else
                Savexml(_savepath);
            savetransbtn.Enabled = false;
        }

        private bool IsLocaleMatch() {
            foreach(var obj in TranslationObjects) {
                if(!obj.Name.EndsWith("LOCALE_VERSION", StringComparison.CurrentCultureIgnoreCase))
                    continue;
                _locverObj = obj;
                return obj.Original == obj.Translation;
            }
            return true; // Let's just say it matches, we didn't find it... so... nothing to update anyways..
        }

        private void compilebtn_Click(object sender, EventArgs e) {
            DialogResult res;
            if(savetransbtn.Enabled) {
                res = MessageBox.Show(@"Do you want to save the current changes before compiling?", @"Save before compiling?", MessageBoxButtons.YesNoCancel);
                if(res == DialogResult.Yes)
                    savetransbtn_Click(sender, e);
                if(res == DialogResult.Cancel)
                    return;
            }
            _tpd.LangFile = _savepath;
            if(!keepsavepathbox.Checked || string.IsNullOrEmpty(_savepath) || !File.Exists(_savepath)) {
                var ofd = new OpenFileDialog {
                                                 Title = @"Select Language source",
                                                 Filter = @"Aurora Translation file(s) (*.xml)|*.xml"
                                             };
                res = ofd.ShowDialog();
                if(res != DialogResult.OK)
                    return;
                _tpd.LangFile = ofd.FileName;
                if(keepsavepathbox.Checked)
                    _savepath = _tpd.LangFile;
            }
            _tpd.Show();
        }

        private void FilterChanged(object sender, EventArgs e) { Setviewitems(); }

        private void setFinishedToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach(ListViewItem sel in listview.SelectedItems) {
                var id = int.Parse(sel.Tag.ToString());
                foreach(var translationObject in TranslationObjects) {
                    if(translationObject.Id != id)
                        continue;
                    translationObject.SetFinished();
                    break;
                }
                var currItem = listview.Items.Cast<ListViewItem>().FirstOrDefault(lvi => lvi.Tag == sel.Tag);
                if(currItem != null)
                    listview.Items.Remove(currItem);
            }
            UpdateStats();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            if(MessageBox.Show(@"Are you sure you want to reset the selected translation(s)?", @"Are you sure?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                return;
            foreach(ListViewItem sel in listview.SelectedItems) {
                var id = int.Parse(sel.Tag.ToString());
                foreach(var translationObject in TranslationObjects) {
                    if(translationObject.Id != id)
                        continue;
                    translationObject.SetFinished(false);
                    translationObject.Translation = null;
                    //Setviewitems();
                    break;
                }
                foreach(ListViewItem lvi in listview.Items) {
                    if(lvi.Tag != sel.Tag)
                        continue;
                    listview.Items[lvi.Index].SubItems[2].Text = "";
                    break;
                }
            }
            UpdateStats();
        }

        private void listview_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button != MouseButtons.Right)
                return;
            if(listview.FocusedItem.Bounds.Contains(e.Location))
                listviewContext.Show(Cursor.Position);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            if(savetransbtn.Enabled || savecurlinebtn.Enabled) {
                if(MessageBox.Show(@"Are you sure you want to exit without saving?", @"Are you sure?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                    return;
            }
            e.Cancel = false;
        }

        private void sections_SelectedIndexChanged(object sender, EventArgs e) { Setviewitems(); }

        private void setSimilarFinishedToolStripMenuItem_Click(object sender, EventArgs e) {
            var list = new List<ListViewItem>();
            foreach(ListViewItem sel in listview.SelectedItems) {
                var orig = sel.SubItems[1].Text;
                foreach(var translationObject in TranslationObjects) {
                    if(translationObject.Original != orig)
                        continue;
                    translationObject.SetFinished();
                }
                foreach(ListViewItem lvi in listview.Items) {
                    if(lvi.SubItems[1].Text == orig && !list.Contains(lvi))
                        list.Add(lvi);
                }
            }
            foreach(var lvi in list)
                listview.Items.Remove(lvi);
            //Setviewitems();
            UpdateStats();
        }

        private void keepsavepathbox_CheckedChanged(object sender, EventArgs e) {
            if(!keepsavepathbox.Checked)
                _savepath = "";
        }

        private void listview_ColumnClick(object sender, ColumnClickEventArgs e) {
            if(listview.ListViewItemSorter == null || ((ListViewColumnSorter)listview.ListViewItemSorter).Column != e.Column)
                listview.ListViewItemSorter = new ListViewColumnSorter(e.Column, true);
            else
                listview.ListViewItemSorter = new ListViewColumnSorter(e.Column, !((ListViewColumnSorter)listview.ListViewItemSorter).Ascending);
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e) { Clipboard.SetText(listview.SelectedItems[0].Text); }

        private class SectionFilter {
            internal readonly bool All;
            internal readonly string Value;

            public SectionFilter(string value, bool all = false) {
                Value = value;
                All = all;
            }

            public override string ToString() { return !All ? Value : "All"; }
        }

        internal class TranslationObject {
            internal readonly int Id;
            internal readonly string Name;
            internal string Original;
            internal string Translation;
            private bool _finished;

            public TranslationObject(int id, string name) {
                Id = id;
                Name = name;
            }

            internal bool Finished {
                get {
                    if(_finished)
                        return _finished;
                    if(Translation != null && Original != null)
                        return (!Translation.Equals(Original));
                    return false;
                }
            }

            public bool IsEmpty { get { return string.IsNullOrEmpty(Original) && string.IsNullOrEmpty(Translation); } }

            internal bool Numerical {
                get {
                    if(Original == null && Translation == null)
                        return true;
                    return Regex.IsMatch(Original ?? Translation, "^(-|\\.|,|[0-9])+");
                }
            }

            internal void SetFinished(bool finished = true) { _finished = finished; }
        }
    }
}