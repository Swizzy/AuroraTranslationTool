namespace AuroraTranslationTool {
    using System;
    using System.Collections;
    using System.Windows.Forms;

    internal class ListViewColumnSorter: IComparer {
        private readonly bool _ascending;
        private readonly int _col;

        public ListViewColumnSorter(int column, bool ascending) {
            _col = column;
            _ascending = ascending;
        }

        public int Column { get { return _col; } }

        public bool Ascending { get { return _ascending; } }

        public int Compare(object x, object y) {
            return _ascending
                       ? String.CompareOrdinal(((ListViewItem)x).SubItems[_col].Text, ((ListViewItem)y).SubItems[_col].Text)
                       : String.CompareOrdinal(((ListViewItem)y).SubItems[_col].Text, ((ListViewItem)x).SubItems[_col].Text);
        }
    }
}