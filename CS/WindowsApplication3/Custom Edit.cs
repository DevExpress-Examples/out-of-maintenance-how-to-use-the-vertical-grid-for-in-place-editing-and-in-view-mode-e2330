using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace WindowsApplication3 {
    //The attribute that points to the registration method
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomEdit: RepositoryItem {

        //The static constructor which calls the registration method
        static RepositoryItemCustomEdit() { RegisterCustomEdit(); }

        internal const int RowHeight = 21;
        internal const int RowHeaderWidth = 50;
        internal const int RecordWidth = 80;

       
       
        //Initialize new properties
        public RepositoryItemCustomEdit() {
        }

        //The unique name for the custom editor
        public const string CustomEditName = "CustomEdit";

        //Return the unique name
        public override string EditorTypeName { get { return CustomEditName; } }

        //Register the editor
        public static void RegisterCustomEdit() {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(CustomEdit), typeof(RepositoryItemCustomEdit),
              typeof(BaseEditViewInfo), new CustomPainter(), true, null));
        }

        internal string [] ParseValues(object editValue) {
            string[] values = new string[] { };
            if(editValue != null && !editValue.Equals(string.Empty)) {
                values = editValue.ToString().Split('/');
            }
            return values;
        }

        internal string [] GetRowCaptions() {
            string [] captions = new string[5];
            for(int i = 0;i < 5;i++) {
                captions[i] = string.Format("Line {0}", i + 1);
            }
            return captions;
        }
    }

    public class CustomEdit: BaseEdit {

       
        //The static constructor which calls the registration method
        static CustomEdit() { RepositoryItemCustomEdit.RegisterCustomEdit(); }

        VGridControl grid;

      
        //Initialize the new instance
        public CustomEdit() {
            grid = new VGridControl();

            grid.OptionsBehavior.DragRowHeaders = false;
            grid.OptionsBehavior.ResizeHeaderPanel = false;
            grid.OptionsBehavior.ResizeRowHeaders = false;
            grid.OptionsBehavior.ResizeRowValues = false;
            grid.Dock = DockStyle.Fill;
            grid.RowHeaderWidth = RepositoryItemCustomEdit.RowHeaderWidth;
            grid.RecordWidth = RepositoryItemCustomEdit.RecordWidth;
            grid.CellValueChanged += OnCellValueChanged;
            grid.CellValueChanging += OnCellValueChanging;

            CreateRows();

            Controls.Add(grid);
        }

        void OnCellValueChanging(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) {
            if(!IsModified)
                IsModified = true;
        }

        public override object EditValue {
            get {
                return base.EditValue;
            }
            set {
                base.EditValue = value;
                if(needPopulateRows) {
                    grid.Rows.Clear();
                    CreateRows();
                    PopulateRows();
                }
            }
        }
        private void CreateRows() {
            string [] captions = Properties.GetRowCaptions();
            for(int i = 0;i < 5;i++) {
                EditorRow row = new EditorRow(captions[i]);
                row.Properties.UnboundType = DevExpress.Data.UnboundColumnType.String;
                row.Properties.Caption = captions[i];
                row.Height = RepositoryItemCustomEdit.RowHeight;
                grid.Rows.Add(row);
            }
        }
        private void PopulateRows() {
            string[] values = Properties.ParseValues(EditValue);
            for(int i = 0;i < values.Length;i++) {
                grid.Rows[i].Properties.Value = values[i];
            }
        }
       

        bool needPopulateRows = true;
        void OnCellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) {
            string editValue = string.Empty;
            for(int i = 0;i < grid.Rows.Count;i++) {
                object val = grid.Rows[i].Properties.Value;
                if(val == null)
                    editValue += "/";
                else
                    editValue += val.ToString() + "/";
            }
            if(editValue.Length > grid.Rows.Count)
                editValue = editValue.TrimEnd('/');
            needPopulateRows = false;
            try {
                EditValue = editValue;
            }
            finally {
                needPopulateRows = true;
            }
        }

       
        public override bool IsEditorActive {
            get {
                IContainerControl container = GetContainerControl();
                if(container == null) return EditorContainsFocus;
                return container.ActiveControl == this || container.ActiveControl == grid;
            }
        }

        public override bool DoValidate() {
            if(grid.ActiveEditor != null && grid.ActiveEditor.IsModified)
                grid.PostEditor();
            return base.DoValidate();
        }

        //Return the unique name
        public override string EditorTypeName {
            get {
                return
RepositoryItemCustomEdit.CustomEditName;
            }
        }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomEdit Properties {
            get { return base.Properties as RepositoryItemCustomEdit; }
        }
    }

    public class CustomPainter: BaseEditPainter {
        public CustomPainter() : base() { }

        internal Color GetRowHeaderColor() {
            Skin skin = VGridSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel);
            SkinElement elem = skin[VGridSkins.SkinRow];
            return elem.Color.BackColor;
        }

        internal Color GetGridLineColor() {
            Skin skin = VGridSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel);
            SkinElement elem = skin[VGridSkins.SkinGridLine];
            return elem.Color.BackColor;
        }

        internal Color GetGridBorderColor() {
            Skin skin = VGridSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel);
            SkinElement elem = skin[VGridSkins.SkinBorder];
            return elem.Color.ForeColor;
        }

        protected override void DrawContent(ControlGraphicsInfoArgs info) {
            base.DrawContent(info);
            BaseEditViewInfo viewInfo = info.ViewInfo as BaseEditViewInfo;
            RepositoryItemCustomEdit item = viewInfo.Item as RepositoryItemCustomEdit;
            string[] values = item.ParseValues(viewInfo.EditValue);
            string[] captions = item.GetRowCaptions();
            Color rowHeaderColor = GetRowHeaderColor();
            Color gridLineColor = GetGridLineColor();
            Color gridBorderColor = GetGridBorderColor();
            for(int i = 0;i < 5;i++) {
                Rectangle rowHeaderRect = new Rectangle(info.Bounds.X + 1, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i + 1, 
                    RepositoryItemCustomEdit.RowHeaderWidth, RepositoryItemCustomEdit.RowHeight);
                Rectangle recordRect = new Rectangle(rowHeaderRect.Right + 2, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i,
                    RepositoryItemCustomEdit.RecordWidth, RepositoryItemCustomEdit.RowHeight);
                info.Graphics.DrawLine(new Pen(gridLineColor), info.Bounds.X, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i,
                    recordRect.Right + 3, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * i + i);
                if(values.Length > i)
                    info.Graphics.DrawString(values[i], info.ViewInfo.PaintAppearance.Font,
                        info.ViewInfo.PaintAppearance.GetForeBrush(info.Cache), recordRect.Location);
                info.Graphics.FillRectangle(new SolidBrush(rowHeaderColor), rowHeaderRect);
                
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Far;
                info.Graphics.DrawString(captions[i], info.ViewInfo.PaintAppearance.Font,
                    info.ViewInfo.PaintAppearance.GetForeBrush(info.Cache), rowHeaderRect, format);
            }
            info.Graphics.DrawLine(new Pen(gridLineColor), info.Bounds.X, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5,
                    info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + RepositoryItemCustomEdit.RecordWidth + 3,
                    info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5);
            info.Graphics.DrawLine(new Pen(gridLineColor), info.Bounds.X, info.Bounds.Y,
                    info.Bounds.X, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5);
            info.Graphics.DrawLine(new Pen(gridLineColor), info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + RepositoryItemCustomEdit.RecordWidth + 5,
                info.Bounds.Y, info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + RepositoryItemCustomEdit.RecordWidth + 5,
                info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5);
            info.Graphics.DrawLine(new Pen(gridLineColor), info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + 1, info.Bounds.Y,
                    info.Bounds.X + RepositoryItemCustomEdit.RowHeaderWidth + 1, info.Bounds.Y + RepositoryItemCustomEdit.RowHeight * 5 + 5);
        }
    }
}

