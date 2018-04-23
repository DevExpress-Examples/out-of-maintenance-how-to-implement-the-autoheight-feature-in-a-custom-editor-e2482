using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;

namespace WindowsApplication1 {
	/// <summary>
	/// MyCheckedComboBoxEdit is a descendant from CheckedComboBoxEdit.
	/// It displays a dialog form below the text box when the edit button is clicked.
	/// </summary>
	public class MyCheckedComboBoxEdit : CheckedComboBoxEdit {
		static MyCheckedComboBoxEdit() {
			RepositoryItemMyCheckedComboBoxEdit.Register();
		}



		public override string EditorTypeName { 
			get { return RepositoryItemMyCheckedComboBoxEdit.EditorName; } 
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemMyCheckedComboBoxEdit Properties { 
			get { return base.Properties as RepositoryItemMyCheckedComboBoxEdit; } 
		}

        public override object EditValue
        {
            get
            {
                object editValue = base.EditValue;
                if (isParsing)
                    editValue = Properties.MyFormatEditValue(editValue);
                return editValue;
            }
            set
            {
                base.EditValue = value;
            }
        }

        bool isParsing;

        protected override void DoSynchronizeEditValueWithCheckedItems()
        {
            isParsing = true;
            base.DoSynchronizeEditValueWithCheckedItems();
            isParsing = false;
        }

	}
}
