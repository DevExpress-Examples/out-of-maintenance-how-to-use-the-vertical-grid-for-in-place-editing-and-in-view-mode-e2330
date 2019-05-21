Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Namespace WindowsApplication3
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Dim helper As New DataHelper(imageList1)
			Dim dataSet1 As New DataSet()
			dataSet1.Tables.Add(helper.CreateTable())
			dataSet1.Tables.Add(helper.CreateEmptyTable())
			Dim keyColumn As DataColumn = dataSet1.Tables(0).Columns("CustomerID")
			Dim foreignKeyColumn As DataColumn = dataSet1.Tables(1).Columns("CustomerID")
			dataSet1.Relations.Add("CustomerInfo_CustomerInfo1", keyColumn, foreignKeyColumn)
			gridControl1.DataSource = dataSet1.Tables(0)

			Dim edit As New RepositoryItemCustomEdit()
			gridControl1.RepositoryItems.Add(edit)
			colFirstName.ColumnEdit = edit

		End Sub


	End Class
End Namespace
