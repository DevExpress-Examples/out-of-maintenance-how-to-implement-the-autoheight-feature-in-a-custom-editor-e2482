using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace WindowsApplication1
{
    public class MyCheckedComboBoxEditViewInfo : ButtonEditViewInfo, IHeightAdaptable
    {
        public MyCheckedComboBoxEditViewInfo(RepositoryItem item)
            : base(item)
        {

        }

        protected override void CalcTextSize(Graphics g, bool useDisplayText)
        {
            base.CalcTextSize(g, true);
        }

        #region IHeightAdaptable Members

        int IHeightAdaptable.CalcHeight(DevExpress.Utils.Drawing.GraphicsCache cache, int width)
        {
            CalcTextSize(cache.Graphics);
            return TextSize.Height;
        }

        #endregion
    }
}
