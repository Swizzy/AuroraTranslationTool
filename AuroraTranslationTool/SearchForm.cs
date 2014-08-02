namespace AuroraTranslationTool {
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class SearchForm: Form {
        private readonly Main _mainfrm;

        public SearchForm(Main mainfrm) {
            InitializeComponent();
            _mainfrm = mainfrm;
        }

        private void OkbtnClick(object sender, EventArgs e) {
            _mainfrm.LastSearch = this;
            var lst = new List<ListViewItem>();
            foreach(ListViewItem item in _mainfrm.listview.Items) {
                var cnt = lst.Count;

                #region Contains

                if(containsbox.Checked) {
                    if(searchnamebox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[0].Text.ToLower().Contains(searchtermbox.Text.ToLower()))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[0].Text.Contains(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                    if(searchorigbox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[1].Text.ToLower().Contains(searchtermbox.Text.ToLower()))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[1].Text.Contains(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                    if(searchtransbox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[2].Text.ToLower().Contains(searchtermbox.Text.ToLower()))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[2].Text.Contains(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                }

                #endregion

                #region Starts With

                if(startswithbox.Checked) {
                    if(searchnamebox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[0].Text.StartsWith(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[0].Text.StartsWith(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                    if(searchorigbox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[1].Text.StartsWith(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[1].Text.StartsWith(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                    if(searchtransbox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[2].Text.StartsWith(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[2].Text.StartsWith(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                }

                #endregion

                #region Ends With

                if(endswithbox.Checked) {
                    if(searchnamebox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[0].Text.EndsWith(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[0].Text.EndsWith(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                    if(searchorigbox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[1].Text.EndsWith(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[1].Text.EndsWith(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                    if(searchtransbox.Checked) {
                        if(ignorecasebox.Checked) {
                            if(item.SubItems[2].Text.EndsWith(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                                lst.Add(item);
                        }
                        else {
                            if(item.SubItems[2].Text.EndsWith(searchtermbox.Text))
                                lst.Add(item);
                        }
                        if(cnt != lst.Count)
                            continue;
                    }
                }

                #endregion

                #region Equals

                if(!equalsbox.Checked)
                    continue;
                if(searchnamebox.Checked) {
                    if(ignorecasebox.Checked) {
                        if(item.SubItems[0].Text.Equals(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                            lst.Add(item);
                    }
                    else {
                        if(item.SubItems[0].Text.Equals(searchtermbox.Text))
                            lst.Add(item);
                    }
                    if(cnt != lst.Count)
                        continue;
                }
                if(searchorigbox.Checked) {
                    if(ignorecasebox.Checked) {
                        if(item.SubItems[1].Text.Equals(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                            lst.Add(item);
                    }
                    else {
                        if(item.SubItems[1].Text.Equals(searchtermbox.Text))
                            lst.Add(item);
                    }
                    if(cnt != lst.Count)
                        continue;
                }
                if(!searchtransbox.Checked)
                    continue;
                if(ignorecasebox.Checked) {
                    if(item.SubItems[2].Text.Equals(searchtermbox.Text, StringComparison.CurrentCultureIgnoreCase))
                        lst.Add(item);
                }
                else {
                    if(item.SubItems[2].Text.Equals(searchtermbox.Text))
                        lst.Add(item);
                }

                #endregion
            }
            _mainfrm.listview.Items.Clear();
            _mainfrm.listview.Items.AddRange(lst.ToArray());
            _mainfrm.UpdateStats();
            Close();
        }

        private void abortbtn_Click(object sender, EventArgs e) { Close(); }

        private void searchtermbox_TextChanged(object sender, EventArgs e) { okbtn.Enabled = !string.IsNullOrEmpty(searchtermbox.Text); }
    }
}