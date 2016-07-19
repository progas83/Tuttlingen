using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.SettingsManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConnectorWorkflowManager
{
    public class WorkflowManager
    {
        private static WorkflowManager _manager;
        private static object _padlock = new object();

        private WorkflowManager()
        {

        }

        public static WorkflowManager Instance
        {
            get
            {
                if (_manager == null)
                {
                    lock (_padlock)
                    {
                        if (_manager == null)
                        {
                            _manager = new WorkflowManager();
                        }
                    }
                }
                    
                return _manager;
            }
        }
        private CustomerInfo _customerInfo;
        protected System.Timers.Timer _timer = new System.Timers.Timer(RElapsedEvery);
        private static readonly long RElapsedEvery = 10000;
        public void Start()
        {
            _streamWriterFile = new StreamWriter(new FileStream("C:\\Ilya\\TestXmlFolder\\testService.log", System.IO.FileMode.Append));
            _streamWriterFile.WriteLine(string.Format("Service has been started at {0} | {1}", DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString()));
            _streamWriterFile.Flush();

            _customerInfo = XmlConfigurationManager.Instance.GetCustomerInformation();
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimedEvent;

        }
        private System.IO.StreamWriter _streamWriterFile;
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                //if (_customerInfo == null)
                //{
                //    return;
                //}

                // string[] xmlSourceFiles = Directory.GetFiles("C:\\Ilya\\TestXmlFolder\\XmlSource");// _customerInfo.PluginSettings.XmlSettings.SourceFolder);

                string[] xmlSourceFiles = Directory.GetFiles(_customerInfo.PluginSettings.XmlSettings.SourceFolder);
                if (_streamWriterFile != null)
                {
                    _streamWriterFile.WriteLine(string.Format("Service Timer has been elapsed at {0} | {1}", DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString()));
                    _streamWriterFile.WriteLine(string.Format("Count of files in the folder {0} = {1}", _customerInfo.PluginSettings.XmlSettings.SourceFolder,
                       xmlSourceFiles.Length));
                    foreach (string file in xmlSourceFiles)
                    {
                        _streamWriterFile.WriteLine(string.Format("Filename:  {0}", file));
                    }
                    _streamWriterFile.Flush();
                }


                //foreach (string file in xmlSourceFiles)
                //{


                //}
            }
            catch(Exception ex)
            {
                _streamWriterFile.WriteLine(ex);
            }
            finally
            {
                _streamWriterFile.Flush();
            }
          
        }
    }
}
