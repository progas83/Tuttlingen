using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDictionary
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            SourceMapCollection = new List<string>();
            SmartDict = new ObservableCollection<MappedItem>();
            for (int i=0;i<10;i++)
            {
                SourceMapCollection.Add(string.Format("Source {0}", i.ToString()));
                SmartDict.Add(new MappedItem(string.Format("key {0}", i.ToString()), string.Format("value {0}", i.ToString())));
            }

            MappedItem.InitializeMapCollection(SourceMapCollection);
        }

        private string _selectedItemValue;
        public string SelItemValue
        {
            get
            {
                return _selectedItemValue;
            }
            set
            {
                _selectedItemValue = value;
                //Service();
            }
        }

        private string _selValue;

        public string SelValue
        {
            get { return _selValue; }
            set { _selValue = value; }
        }

        //private void Service()
        //{
        //    var res = SmartDict.FirstOrDefault(p => p.BaseValue.Equals(_selKey));
        //    if(res!=null)
        //    {
        //        res.MappedValue = _selectedItemValue;
        //    }

        //}

        private string _selKey;

        public string SelectedKey
        {
            get { return _selKey; }
            set { _selKey = value; }
        }


        public List<string> SourceMapCollection { get; set; }
        public ObservableCollection<MappedItem> SmartDict
        {
            get;set;
        } 
    }
}
