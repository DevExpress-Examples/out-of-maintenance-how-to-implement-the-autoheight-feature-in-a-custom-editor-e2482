Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.ViewInfo

Namespace WindowsApplication1
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form

		Private _Ri As RepositoryItemMyCheckedComboBoxEdit
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(475, 382)
			Me.gridControl1.TabIndex = 2
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(475, 382)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Public Function CreateTable() As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Names", GetType(String))
			tbl.Rows.Add("Value1" & vbCrLf)
			tbl.Rows.Add("Value1" & vbCrLf & "Value2")
			tbl.Rows.Add("Value1" & vbCrLf & "Value2" & vbCrLf & "Value3")
			tbl.Rows.Add("Value1" & vbCrLf & "Value2" & vbCrLf & "Value3" & vbCrLf & "Value4")
			Return tbl
		End Function


		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			gridControl1.DataSource = CreateTable()
			gridView1.OptionsView.RowAutoHeight = True
			_Ri = New RepositoryItemMyCheckedComboBoxEdit()
			gridView1.Columns(0).ColumnEdit = _Ri
			AddHandler _Ri.EditValueChanged, AddressOf ri_EditValueChanged
			_Ri.Items.Add("Value1")
			_Ri.Items.Add("Value2")
			_Ri.Items.Add("Value3")
			_Ri.Items.Add("Value4")
		End Sub

		Private Sub ri_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			gridView1.PostEditor()
			gridView1.UpdateCurrentRow()
		End Sub
	End Class
End Namespace
