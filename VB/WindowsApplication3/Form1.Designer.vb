Namespace WindowsApplication3
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colFirstName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colLastName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colImage = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
			Me.colColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' imageList1
			' 
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			Me.imageList1.Images.SetKeyName(0, "1.jpg")
			Me.imageList1.Images.SetKeyName(1, "2.jpg")
			Me.imageList1.Images.SetKeyName(2, "3.jpg")
			Me.imageList1.Images.SetKeyName(3, "4.jpg")
			Me.imageList1.Images.SetKeyName(4, "5.jpg")
			Me.imageList1.Images.SetKeyName(5, "6.jpg")
			Me.imageList1.Images.SetKeyName(6, "7.jpg")
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemPictureEdit1})
			Me.gridControl1.Size = New System.Drawing.Size(727, 494)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colCustomerID, Me.colFirstName, Me.colLastName, Me.colImage, Me.colColumn1})
			Me.gridView1.CustomizationFormBounds = New System.Drawing.Rectangle(805, 596, 0, 167)
			Me.gridView1.DetailHeight = 284
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.RowHeight = 97
			' 
			' colCustomerID
			' 
			Me.colCustomerID.FieldName = "CustomerID"
			Me.colCustomerID.MinWidth = 15
			Me.colCustomerID.Name = "colCustomerID"
			Me.colCustomerID.Width = 56
			' 
			' colFirstName
			' 
			Me.colFirstName.FieldName = "FirstName"
			Me.colFirstName.MinWidth = 15
			Me.colFirstName.Name = "colFirstName"
			Me.colFirstName.Visible = True
			Me.colFirstName.VisibleIndex = 0
			Me.colFirstName.Width = 56
			' 
			' colLastName
			' 
			Me.colLastName.FieldName = "LastName"
			Me.colLastName.MinWidth = 15
			Me.colLastName.Name = "colLastName"
			Me.colLastName.Visible = True
			Me.colLastName.VisibleIndex = 1
			Me.colLastName.Width = 56
			' 
			' colImage
			' 
			Me.colImage.ColumnEdit = Me.repositoryItemPictureEdit1
			Me.colImage.FieldName = "Image"
			Me.colImage.MinWidth = 15
			Me.colImage.Name = "colImage"
			Me.colImage.Width = 56
			' 
			' repositoryItemPictureEdit1
			' 
			Me.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1"
			' 
			' colColumn1
			' 
			Me.colColumn1.FieldName = "Column1"
			Me.colColumn1.MinWidth = 15
			Me.colColumn1.Name = "colColumn1"
			Me.colColumn1.Width = 56
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(727, 494)
			Me.Controls.Add(Me.gridControl1)
			Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region
		Private imageList1 As System.Windows.Forms.ImageList
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colCustomerID As DevExpress.XtraGrid.Columns.GridColumn
		Private colFirstName As DevExpress.XtraGrid.Columns.GridColumn
		Private colLastName As DevExpress.XtraGrid.Columns.GridColumn
		Private colImage As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
		Private colColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
	End Class
End Namespace

