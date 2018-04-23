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
        public void InitData() {
            for(int i = 0;i < 5;i++) {
                dataSet11.Tables[0].Rows.Add(new object[] { i, "a/b/c/d", i, imageList1.Images[i], DateTime.Today });
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitData();
            RepositoryItemCustomEdit edit = new RepositoryItemCustomEdit();
            gridControl1.RepositoryItems.Add(edit);
            colFirstName.ColumnEdit = edit;
        }
    }
}
