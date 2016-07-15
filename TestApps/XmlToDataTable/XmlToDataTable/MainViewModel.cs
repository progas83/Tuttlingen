using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace XmlToDataTable
{
    public class MainViewModel : INotifyPropertyChanged, ICommand
    {

        private DataView _dataGridItems = new DataView();

        public DataView DataGridItems
        {
            get { return _dataGridItems; }
            set { _dataGridItems = value; OnPropertyChanged("DataGridItems"); }
        }


        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //testXmlMethod();

            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\Ilya\Ix4_Interface_1.2_v1.7\Beispieldateien\LICSRequest.xml");

            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            // dt.ReadXml()
           // dt.ReadXml(@"C:\Ilya\Ix4_Interface_1.2_v1.7\Beispieldateien\LICSRequest.xml");
            DataGridItems = dt.DefaultView;
        }

        private void testXmlMethod()
        {
            //DataTable tabl = new DataTable("mytable");
            //tabl.Columns.Add(new DataColumn("id", typeof(int)));
            //for (int i = 0; i < 10; i++)
            //{
            //    DataRow row = tabl.NewRow();
            //    row["id"] = i;
            //    tabl.Rows.Add(row);
            //}
            //tabl.WriteXml("f.xml", XmlWriteMode.WriteSchema);
            DataTable newt = new DataTable();
            newt.ReadXml("f.xml");
            //DataGridItems = tabl.DefaultView;// newt.DefaultView;
            DataGridItems = newt.DefaultView;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
