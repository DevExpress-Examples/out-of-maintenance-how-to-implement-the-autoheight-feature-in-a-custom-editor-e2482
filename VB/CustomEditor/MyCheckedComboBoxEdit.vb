Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator

Namespace WindowsApplication1
	''' <summary>
	''' MyCheckedComboBoxEdit is a descendant from CheckedComboBoxEdit.
	''' It displays a dialog form below the text box when the edit button is clicked.
	''' </summary>
	Public Class MyCheckedComboBoxEdit
		Inherits CheckedComboBoxEdit
		Shared Sub New()
			RepositoryItemMyCheckedComboBoxEdit.Register()
		End Sub



		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMyCheckedComboBoxEdit.EditorName
			End Get
		End Property
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMyCheckedComboBoxEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMyCheckedComboBoxEdit)
			End Get
		End Property

		Public Overrides Property EditValue() As Object
			Get
'INSTANT VB NOTE: The local variable editValue was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
				Dim editValue_Renamed As Object = MyBase.EditValue
				If isParsing Then
					editValue_Renamed = Properties.MyFormatEditValue(editValue_Renamed)
				End If
				Return editValue_Renamed
			End Get
			Set(ByVal value As Object)
				MyBase.EditValue = value
			End Set
		End Property

		Private isParsing As Boolean

		Protected Overrides Sub DoSynchronizeEditValueWithCheckedItems()
			isParsing = True
			MyBase.DoSynchronizeEditValueWithCheckedItems()
			isParsing = False
		End Sub

	End Class
End Namespace
