﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ix4Modes;
using System.Reflection;
using System.Collections.ObjectModel;

namespace EfTestWpf.ManualMapping.ViewModel
{
    public class ManualMapperViewModel : INotifyPropertyChanged
    {

        public ManualMapperViewModel()
        {
            MappedDictionary = new Dictionary<string, string>();
            int i = 0;
            foreach(var item in Ix4ComplexModel.GetPropertiesList())
            {
                MappedDictionary.Add(item.Name, i.ToString());
                i++;
            }
            Ix4Properties = Ix4ComplexModel.GetPropertiesList();
            SourceMapCollection = new ObservableCollection<DataSourceInfo>((new TableHeaderExplorer(ConstVarData.ConnectionStringToChips)).GetTabelHeader("Chips"));

            //lst[0].Name
            //foreach (var prp in lst)
            //{

            //}

        }

        private DataSourceInfo _SelItem;

        public DataSourceInfo SelItemValue
        {
            get { return _SelItem; }
            set { _SelItem = value; }
        }

        private string _SelVal;

        public string SelVal
        {
            get { return _SelVal; }
            set
            {
                _SelVal = value;
                ServeMappedDictionary(_selKey, _SelVal);

            }
        }
        private void ServeMappedDictionary(string key,string val)
        {
            MappedDictionary[key] = val;
            SourceMapCollection.Remove(_SelItem);
        }
        private string _selKey;

        public string SelectedKey
        {
            get { return _selKey; }
            set { _selKey = value; }
        }

        public Dictionary<string,string> MappedDictionary { get; set; }

         public PropertyInfo[] Ix4Properties
        {
            get; private set;
        }

        public ObservableCollection<DataSourceInfo> SourceMapCollection
        {
            get; private set;
        }

        private DataSourceInfo _selectedMappedData;
        public DataSourceInfo SelectedMappedData
        {
            get { return _selectedMappedData; }
            set { _selectedMappedData = value; }
        }
        private ObservableCollection<DataSourceInfo> AlreadyMappedItems = new ObservableCollection<DataSourceInfo>();
        
        private void ServeDataSourceInfoCollection(DataSourceInfo selectedMappedData)
        {
            //AlreadyMappedItems.Add
            SourceMapCollection = (ObservableCollection<DataSourceInfo>)SourceMapCollection.Except(AlreadyMappedItems);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
