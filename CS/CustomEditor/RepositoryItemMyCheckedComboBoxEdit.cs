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
    [UserRepositoryItem("Register")]
    public class RepositoryItemMyCheckedComboBoxEdit : RepositoryItemCheckedComboBoxEdit
    {
        static RepositoryItemMyCheckedComboBoxEdit()
        {
            Register();
        }
        public RepositoryItemMyCheckedComboBoxEdit() { }

        internal const string EditorName = "MyCheckedComboBoxEdit";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(MyCheckedComboBoxEdit),
                typeof(RepositoryItemMyCheckedComboBoxEdit), typeof(MyCheckedComboBoxEditViewInfo),
                new MyButtonEditPainter(), true, null));
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        public virtual object MyFormatEditValue(object value)
        {
            if (value == null)
                return value;
            return value.ToString().Replace(Environment.NewLine, String.Format("{0} ", SeparatorChar));
        }

        public virtual object MyParseEditValue(object value)
        {
            if (value == null)
                return value;
            return value.ToString().Replace(String.Format("{0} ", SeparatorChar), Environment.NewLine);
        }


       
                protected override void RaiseFormatEditValue(ConvertEditValueEventArgs e) {
            base.RaiseFormatEditValue(e);
            e.Value = MyFormatEditValue(e.Value);
            e.Handled = true;
        }



        protected override void RaiseParseEditValue(ConvertEditValueEventArgs e) {
            base.RaiseParseEditValue(e);
            e.Value = MyParseEditValue(e.Value);
            e.Handled = true;
        }

        }
}