Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo

Namespace WindowsApplication1
	<UserRepositoryItem("Register")>
	Public Class RepositoryItemMyCheckedComboBoxEdit
		Inherits RepositoryItemCheckedComboBoxEdit

		Shared Sub New()
			Register()
		End Sub
		Public Sub New()
		End Sub

		Friend Const EditorName As String = "MyCheckedComboBoxEdit"

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MyCheckedComboBoxEdit), GetType(RepositoryItemMyCheckedComboBoxEdit), GetType(MyCheckedComboBoxEditViewInfo), New MyButtonEditPainter(), True))
        End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property

		Public Overridable Function MyFormatEditValue(ByVal value As Object) As Object
			If value Is Nothing Then
				Return value
			End If
			Return value.ToString().Replace(Environment.NewLine, String.Format("{0} ", SeparatorChar))
		End Function

		Public Overridable Function MyParseEditValue(ByVal value As Object) As Object
			If value Is Nothing Then
				Return value
			End If
			Return value.ToString().Replace(String.Format("{0} ", SeparatorChar), Environment.NewLine)
		End Function



				Protected Overrides Sub RaiseFormatEditValue(ByVal e As ConvertEditValueEventArgs)
			MyBase.RaiseFormatEditValue(e)
			e.Value = MyFormatEditValue(e.Value)
			e.Handled = True
				End Sub



		Protected Overrides Sub RaiseParseEditValue(ByVal e As ConvertEditValueEventArgs)
			MyBase.RaiseParseEditValue(e)
			e.Value = MyParseEditValue(e.Value)
			e.Handled = True
		End Sub

	End Class
End Namespace