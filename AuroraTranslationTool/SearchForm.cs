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
            if(searchAll.Checked) {
                foreach(var tobj in _mainfrm.TranslationObjects) {
                    var lvi = new ListViewItem {
                                                   Tag = tobj.Id,
                                                   Text = tobj.Name
                                               };
                    lvi.SubItems.Add(tobj.Original);
                    lvi.SubItems.Add(tobj.Translation);
                    CheckItem(lvi, ref lst);
                }
            }
            else {
                foreach(ListViewItem item in _mainfrm.listview.Items)
                    CheckItem(item, ref lst);
            }
            _mainfrm.listview.Items.Clear();
            _mainfrm.listview.Items.AddRange(lst.ToArray());
            _mainfrm.UpdateStats();
            Close();
        }

        private void CheckItem(ListViewItem item, ref List<ListViewItem> lst) {
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
                        return;
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
                        return;
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
                        return;
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
                        return;
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
                        return;
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
                        return;
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
                        return;
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
                        return;
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
                        return;
                }
            }

            #endregion

            #region Equals

            if(!equalsbox.Checked)
                return;
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
                    return;
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
                    return;
            }
            if(!searchtransbox.Checked)
                return;
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

        private void abortbtn_Click(object sender, EventArgs e) { Close(); }

        private void searchtermbox_TextChanged(object sender, EventArgs e) { okbtn.Enabled = !string.IsNullOrEmpty(searchtermbox.Text); }
    }
}