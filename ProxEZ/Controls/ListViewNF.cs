using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProxEZ.Controls
{
    class ListViewNF : ListView
    {
        private bool _AllowColumnResize = true;
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        public ListViewNF()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        public bool AllowColumnResize
        {
            get { return _AllowColumnResize; }
            set { _AllowColumnResize = value; }
        }
        public void ScrollToEnd()
        {
            Items[Items.Count - 1].EnsureVisible();
        }
        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            if (!AllowColumnResize)
            {
                e.NewWidth = Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            }
            base.OnColumnWidthChanging(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(Handle, "Explorer", null);
            base.OnHandleCreated(e);
        }

        public void SetHeight(int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(1, height);
            SmallImageList = imgList;
        }
    }
}
