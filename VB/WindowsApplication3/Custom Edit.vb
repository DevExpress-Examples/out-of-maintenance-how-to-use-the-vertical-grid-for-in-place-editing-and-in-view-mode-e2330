Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing
Imports System.Reflection
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Rows
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel

Namespace WindowsApplication3
	'The attribute that points to the registration method
	<UserRepositoryItem("RegisterCustomEdit")> _
	Public Class RepositoryItemCustomEdit
		Inherits RepositoryItem

		'The static constructor which calls the registration method
		Shared Sub New()
			RegisterCustomEdit()
		End Sub

		Friend Const RowHeight As Integer = 21
		Friend Const RowHeaderWidth As Integer = 50
		Friend Const RecordWidth As Integer = 80



		'Initialize new properties
		Public Sub New()
		End Sub

		'The unique name for the custom editor
		Public Const CustomEditName As String = "CustomEdit"

		'Return the unique name
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return CustomEditName
			End Get
		End Property

		'Register the editor
		Public Shared Sub RegisterCustomEdit()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomEdit), GetType(RepositoryItemCustomEdit), GetType(BaseEditViewInfo), New CustomPainter(), True, SystemIcons.WinLogo.ToBitmap()))
		End Sub

		Friend Function ParseValues(ByVal editValue As Object) As String()
			Dim values() As String = { }
			If editValue IsNot Nothing AndAlso (Not editValue.Equals(String.Empty)) Then
				values = editValue.ToString().Split("/"c)
			End If
			Return values
		End Function

		Friend Function GetRowCaptions() As String()
			Dim captions(4) As String
			For i As Integer = 0 To 4
				captions(i) = String.Format("Line {0}", i + 1)
			Next i
			Return captions
		End Function
	End Class

	Public Class CustomEdit
		Inherits BaseEdit


		'The static constructor which calls the registration method
		Shared Sub New()
			RepositoryItemCustomEdit.RegisterCustomEdit()
		End Sub

		Private grid As VGridControl


		'Initialize the new instance
		Public Sub New()
			grid = New VGridControl()

			grid.OptionsBehavior.DragRowHeaders = False
			grid.OptionsBehavior.ResizeHeaderPanel = False
			grid.OptionsBehavior.ResizeRowHeaders = False
			grid.OptionsBehavior.ResizeRowValues = False
			grid.Dock = DockStyle.Fill
			grid.RowHeaderWidth = RepositoryItemCustomEdit.RowHeaderWidth
			grid.RecordWidth = RepositoryItemCustomEdit.RecordWidth
			AddHandler grid.CellValueChanged, AddressOf OnCellValueChanged
			AddHandler grid.CellValueChanging, AddressOf OnCellValueChanging

			CreateRows()

			Controls.Add(grid)
		End Sub

		Private Sub OnCellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
			If (Not IsModified) Then
				IsModified = True
			End If
		End Sub

		Public Overrides Property EditValue() As Object
			Get
				Return MyBase.EditValue
			End Get
			Set(ByVal value As Object)
				MyBase.EditValue = value
				If needPopulateRows Then
					grid.Rows.Clear()
					CreateRows()
					PopulateRows()
				End If
			End Set
		End Property
		Private Sub CreateRows()
			Dim captions() As String = Properties.GetRowCaptions()
			For i As Integer = 0 To 4
				Dim row As New EditorRow(captions(i))
				row.Properties.UnboundType = DevExpress.Data.UnboundColumnType.String
				row.Properties.Caption = captions(i)
				row.Height = RepositoryItemCustomEdit.RowHeight
				grid.Rows.Add(row)
			Next i
		End Sub
		Private Sub PopulateRows()
			Dim values() As String = Properties.ParseValues(EditValue)
			For i As Integer = 0 To values.Length - 1
				grid.Rows(i).Properties.Value = values(i)
			Next i
		End Sub


		Private needPopulateRows As Boolean = True
		Private Sub OnCellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
			Dim editValue As String = String.Empty
			For i As Integer = 0 To grid.Rows.Count - 1
				Dim val As Object = grid.Rows(i).Properties.Value
				If val Is Nothing Then
					editValue &= "/"
				Else
					editValue &= val.ToString() & "/"
				End If
			Next i
			If editValue.Length > grid.Rows.Count Then
				editValue = editValue.TrimEnd("/"c)
			End If
			needPopulateRows = False
			Try
				Me.EditValue = editValue
			Finally
				needPopulateRows = True
			End Try
		End Sub


		Public Overrides ReadOnly Property IsEditorActive() As Boolean
			Get
				Dim container As IContainerControl = GetContainerControl()
				If container Is Nothing Then
					Return EditorContainsFocus
				End If
				Return container.ActiveControl Is Me OrElse container.ActiveControl Is grid
			End Get
		End Property

		Public Overrides Function DoValidate() As Boolean
			If grid.ActiveEditor IsNot Nothing AndAlso grid.ActiveEditor.IsModified Then
				grid.PostEditor()
			End If
			Return MyBase.DoValidate()
		End Function

		'Return the unique name
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemCustomEdit.CustomEditName
			End Get
		End Property

		'Override the Properties property
		'Simply type-cast the object to the custom repository item type
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemCustomEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemCustomEdit)
			End Get
		End Property
	End Class

	Public Class CustomPainter
		Inherits BaseEditPainter
		Public Sub New()
			MyBase.New()
		End Sub

		Friend Function GetRowHeaderColor() As Color
			Dim skin As Skin = VGridSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel)
			Dim elem As SkinElement = skin(VGridSkins.SkinRow)
			Return elem.Color.BackColor
		End Function

		Friend Function GetGridLineColor() As Color
			Dim skin As Skin = VGridSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel)
			Dim elem As SkinElement = skin(VGridSkins.SkinGridLine)
			Return elem.Color.BackColor
		End Function

		Friend Function GetGridBorderColor() As Color
			Dim skin As Skin = VGridSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel)
			Dim elem As SkinElement = skin(VGridSkins.SkinBorder)
			Return elem.Color.ForeColor
		End Function

		Protected Overrides Sub DrawContent(ByVal info As ControlGraphicsInfoArgs)
			MyBase.DrawContent(info)
			Dim viewInfo As BaseEditViewInfo = TryCast(info.ViewInfo, BaseEditViewInfo)
			Dim item As RepositoryItemCustomEdit = TryCast(viewInfo.Item, RepositoryItemCustomEdit)
			Dim values() As String = item.ParseValues(viewInfo.EditValue)
			Dim captions() As String = item.GetRowCaptions()
			Dim rowHeaderColor As Color = GetRowHeaderColor()
			Dim gridLineColor As Color = GetGridLineColor()
			Dim gridBorderColor As Color = GetGridBorderColor()
			For i As Integer = 0 To 4
				Dim rowHeaderRect As New Rectangle(info.Bounds.X + 1, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i + 1, RepositoryItemCustomEdit.RowHeaderWidth, RepositoryItemCustomEdit.RowHeight)
				Dim recordRect As New Rectangle(rowHeaderRect.Right + 2, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i, RepositoryItemCustomEdit.RecordWidth, RepositoryItemCustomEdit.RowHeight)
				info.Graphics.DrawLine(New Pen(gridLineColor), info.Bounds.X, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i, recordRect.Right + 3, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i)
				If values.Length > i Then
					info.Graphics.DrawString(values(i), info.ViewInfo.PaintAppearance.Font, info.ViewInfo.PaintAppearance.GetForeBrush(info.Cache), recordRect.Location)
				End If
				info.Graphics.FillRectangle(New SolidBrush(rowHeaderColor), rowHeaderRect)

				Dim format As New StringFormat()
				format.Alignment = StringAlignment.Far
				info.Graphics.DrawString(captions(i), info.ViewInfo.PaintAppearance.Font, info.ViewInfo.PaintAppearance.GetForeBrush(info.Cache), rowHeaderRect, format)
			Next i
			info.Graphics.DrawLine(New Pen(gridLineColor), info.Bounds.X, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5, info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + RepositoryItemCustomEdit.RecordWidth + 3, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5)
			info.Graphics.DrawLine(New Pen(gridLineColor), info.Bounds.X, info.Bounds.Y, info.Bounds.X, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5)
			info.Graphics.DrawLine(New Pen(gridLineColor), info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + RepositoryItemCustomEdit.RecordWidth + 5, info.Bounds.Y, info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + RepositoryItemCustomEdit.RecordWidth + 5, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5)
			info.Graphics.DrawLine(New Pen(gridLineColor), info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + 1, info.Bounds.Y, info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + 1, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5)
		End Sub
	End Class
End Namespace

