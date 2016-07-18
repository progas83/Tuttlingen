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

        private bool _isActivated;

        public bool IsActivated
        {
            get { return _isActivated; }
            set { _isActivated = value;
                OnPropertyChanged("IsActivated");
            }
        }

        private string _xmlSourceFolder;

        public string XmlSourceFolder
        {
            get { return _xmlSourceFolder; }
            set { _xmlSourceFolder = value;
                OnPropertyChanged("XmlSourceFolder");
            }
        }

        private string _xmlProcessedFilesFolder;

        public string XmlProcessedFilesFolder
        {
            get { return _xmlProcessedFilesFolder; }
            set { _xmlProcessedFilesFolder = value;
                OnPropertyChanged("XmlProcessedFilesFolder");
            }
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            XmlFolderTypes folderName = (XmlFolderTypes)parameter;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            switch(folderName)
            {
                case XmlFolderTypes.SourceFolder:
                    XmlSourceFolder = dialog.SelectedPath;
                    break;
                case XmlFolderTypes.ProcessedFolder:
                    XmlProcessedFilesFolder = dialog.SelectedPath;
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
