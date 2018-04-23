Imports Microsoft.VisualBasic
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
	Public Class MyCheckedComboBoxEditViewInfo
		Inherits ButtonEditViewInfo
		Implements IHeightAdaptable
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)

		End Sub

		Protected Overrides Overloads Sub CalcTextSize(ByVal g As Graphics, ByVal useDisplayText As Boolean)
			MyBase.CalcTextSize(g, True)
		End Sub

		#Region "IHeightAdaptable Members"

		Private Function CalcHeight(ByVal cache As DevExpress.Utils.Drawing.GraphicsCache, ByVal width As Integer) As Integer Implements IHeightAdaptable.CalcHeight
			CalcTextSize(cache.Graphics)
			Return TextSize.Height
		End Function

		#End Region
	End Class
End Namespace
