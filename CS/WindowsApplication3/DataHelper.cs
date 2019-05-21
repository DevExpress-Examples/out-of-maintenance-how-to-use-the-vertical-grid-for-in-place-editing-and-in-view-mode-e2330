using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication3
{
    class DataHelper
    {
        ImageList imageList = null;
        public DataHelper(ImageList list)
        {
            imageList = list;
        }

        Image GetImage(int index)
        {
            return imageList.Images[index];
        }

        public DataTable CreateTable()
        {
            int i = 0;
            DataTable table = new DataTable();
            DataRow dataRow;
            table.Columns.Add("CustomerID", typeof(System.Int32));
            table.Columns.Add("FirstName", typeof(System.String));
            table.Columns.Add("LastName", typeof(System.String));
            table.Columns.Add("Image", typeof(System.Drawing.Image));
            table.Columns.Add("Column1", typeof(System.DateTime));
            dataRow = table.NewRow();
            dataRow["CustomerID"] = 0;
            dataRow["FirstName"] = "a/b/c/d";
            dataRow["LastName"] = "0";
            dataRow["Image"] = GetImage(i++);
            dataRow["Column1"] = DateTime.Parse("5/21/2019 12:00:00 AM");
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["CustomerID"] = 1;
            dataRow["FirstName"] = "a/b/c/d";
            dataRow["LastName"] = "1";
            dataRow["Image"] = GetImage(i++);
            dataRow["Column1"] = DateTime.Parse("5/21/2019 12:00:00 AM");
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["CustomerID"] = 2;
            dataRow["FirstName"] = "a/b/c/d";
            dataRow["LastName"] = "2";
            dataRow["Image"] = GetImage(i++);
            dataRow["Column1"] = DateTime.Parse("5/21/2019 12:00:00 AM");
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["CustomerID"] = 3;
            dataRow["FirstName"] = "a/b/c/d";
            dataRow["LastName"] = "3";
            dataRow["Image"] = GetImage(i++);
            dataRow["Column1"] = DateTime.Parse("5/21/2019 12:00:00 AM");
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["CustomerID"] = 4;
            dataRow["FirstName"] = "a/b/c/d";
            dataRow["LastName"] = "4";
            dataRow["Image"] = GetImage(i++);
            dataRow["Column1"] = DateTime.Parse("5/21/2019 12:00:00 AM");
            table.Rows.Add(dataRow);

            return table;
        }

        public DataTable CreateEmptyTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CustomerID", typeof(System.Int32));
            table.Columns.Add("FirstName", typeof(System.String));
            return table;
        }
    }
}
