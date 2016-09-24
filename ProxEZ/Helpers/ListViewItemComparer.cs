using System;
using System.Collections;
using System.Windows.Forms;

namespace ProxEZ.Helpers
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            var returnVal = string.CompareOrdinal(((ListViewItem)x).SubItems[col].Text,
                ((ListViewItem)y).SubItems[col].Text);
            return returnVal;
        }
    }
}