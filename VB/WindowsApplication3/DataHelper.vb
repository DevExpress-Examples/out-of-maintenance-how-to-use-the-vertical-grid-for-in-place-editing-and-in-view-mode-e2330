Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace WindowsApplication3
	Friend Class DataHelper
		Private imageList As ImageList = Nothing
		Public Sub New(ByVal list As ImageList)
			imageList = list
		End Sub

		Private Function GetImage(ByVal index As Integer) As Image
			Return imageList.Images(index)
		End Function

		Public Function CreateTable() As DataTable
			Dim i As Integer = 0
			Dim table As New DataTable()
			Dim dataRow As DataRow
			table.Columns.Add("CustomerID", GetType(System.Int32))
			table.Columns.Add("FirstName", GetType(System.String))
			table.Columns.Add("LastName", GetType(System.String))
			table.Columns.Add("Image", GetType(System.Drawing.Image))
			table.Columns.Add("Column1", GetType(Date))
			dataRow = table.NewRow()
			dataRow("CustomerID") = 0
			dataRow("FirstName") = "a/b/c/d"
			dataRow("LastName") = "0"
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: dataRow["Image"] = GetImage(i++);
			dataRow("Image") = GetImage(i)
			i += 1
			dataRow("Column1") = Date.Parse("5/21/2019 12:00:00 AM")
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("CustomerID") = 1
			dataRow("FirstName") = "a/b/c/d"
			dataRow("LastName") = "1"
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: dataRow["Image"] = GetImage(i++);
			dataRow("Image") = GetImage(i)
			i += 1
			dataRow("Column1") = Date.Parse("5/21/2019 12:00:00 AM")
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("CustomerID") = 2
			dataRow("FirstName") = "a/b/c/d"
			dataRow("LastName") = "2"
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: dataRow["Image"] = GetImage(i++);
			dataRow("Image") = GetImage(i)
			i += 1
			dataRow("Column1") = Date.Parse("5/21/2019 12:00:00 AM")
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("CustomerID") = 3
			dataRow("FirstName") = "a/b/c/d"
			dataRow("LastName") = "3"
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: dataRow["Image"] = GetImage(i++);
			dataRow("Image") = GetImage(i)
			i += 1
			dataRow("Column1") = Date.Parse("5/21/2019 12:00:00 AM")
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("CustomerID") = 4
			dataRow("FirstName") = "a/b/c/d"
			dataRow("LastName") = "4"
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: dataRow["Image"] = GetImage(i++);
			dataRow("Image") = GetImage(i)
			i += 1
			dataRow("Column1") = Date.Parse("5/21/2019 12:00:00 AM")
			table.Rows.Add(dataRow)

			Return table
		End Function

		Public Function CreateEmptyTable() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("CustomerID", GetType(System.Int32))
			table.Columns.Add("FirstName", GetType(System.String))
			Return table
		End Function
	End Class
End Namespace
