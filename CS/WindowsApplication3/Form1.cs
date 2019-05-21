using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WindowsApplication3 {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e) {
            DataHelper helper = new DataHelper(imageList1);
            DataSet dataSet1 = new DataSet();
            dataSet1.Tables.Add(helper.CreateTable());
            dataSet1.Tables.Add(helper.CreateEmptyTable());
            DataColumn keyColumn = dataSet1.Tables[0].Columns["CustomerID"];
            DataColumn foreignKeyColumn = dataSet1.Tables[1].Columns["CustomerID"];
            dataSet1.Relations.Add("CustomerInfo_CustomerInfo1", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet1.Tables[0];

            RepositoryItemCustomEdit edit = new RepositoryItemCustomEdit();
            gridControl1.RepositoryItems.Add(edit);
            colFirstName.ColumnEdit = edit;
           
        }

        
    }
}
