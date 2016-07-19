using Ix4Models.SettingsDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XmlDataExtractor.Settings.ViewModel
{
    public class XamlFolderSettingsViewModel : INotifyPropertyChanged, ICommand
    {
        private XmlPluginSettings _xmlPluginSettings;
        public XamlFolderSettingsViewModel(XmlPluginSettings xmlPluginSettings)
        {
            _xmlPluginSettings = xmlPluginSettings;
        }
        public XmlPluginSettings GetXmlPluginSettings
        {
            get { return _xmlPluginSettings; }
        }
        public bool IsActivated
        {
            get { return _xmlPluginSettings.IsActivated; }
            set
            {
                _xmlPluginSettings.IsActivated = value;
                OnPropertyChanged("IsActivated");
            }
        }

        public string XmlSourceFolder
        {
            get { return _xmlPluginSettings.SourceFolder; }
            set
            {
                _xmlPluginSettings.SourceFolder = value;
                OnPropertyChanged("XmlSourceFolder");
            }
        }

        public string XmlProcessedFilesFolder
        {
            get { return _xmlPluginSettings.ProcessedFilesFolder; }
            set
            {
                _xmlPluginSettings.ProcessedFilesFolder = value;
                OnPropertyChanged("XmlProcessedFilesFolder");
            }
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public string XmlIx4RequestFilesFolder
        {
            get { return _xmlPluginSettings.Ix4RequestFilesFolder; }
            set { _xmlPluginSettings.Ix4RequestFilesFolder = value;
                OnPropertyChanged("XmlIx4RequestFilesFolder");
            }
        }

        public void Execute(object parameter)
        {
            XmlFolderTypes folderName = (XmlFolderTypes)parameter;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            switch (folderName)
            {
                case XmlFolderTypes.SourceFolder:
                    XmlSourceFolder = dialog.SelectedPath;
                    break;
                case XmlFolderTypes.ProcessedFolder:
                    XmlProcessedFilesFolder = dialog.SelectedPath;
                    break;
                case XmlFolderTypes.Ix4RequestFolder:
                    XmlIx4RequestFilesFolder = dialog.SelectedPath;
                    break;


                default:
                    break;
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
