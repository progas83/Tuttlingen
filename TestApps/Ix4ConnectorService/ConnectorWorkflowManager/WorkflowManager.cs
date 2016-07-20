using CompositionHelper;
using Ix4Connector;
using Ix4Models;
using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
using Ix4Models.SettingsManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace ConnectorWorkflowManager
{
    public class WorkflowManager
    {
        private static WorkflowManager _manager;
        private static object _padlock = new object();
        private static readonly long RElapsedEvery = 10000;

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
        private IProxyIx4WebService _ix4ServiceConnector;
        private System.IO.StreamWriter _streamWriterFile;

        protected Timer _timer = new Timer(RElapsedEvery);
        
        public void Start()
        {

            try
            {
                if (_streamWriterFile == null)
                {
                    _streamWriterFile = new StreamWriter(new FileStream("C:\\Ilya\\TestXmlFolder\\testService.log", System.IO.FileMode.Append));
                }

                _streamWriterFile.WriteLine(string.Format("Service has been started at {0} | {1}", DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString()));

                _customerInfo = XmlConfigurationManager.Instance.GetCustomerInformation();

                _ix4ServiceConnector = Ix4ConnectorManager.Instance.GetRegisteredIx4WebServiceInterface(_customerInfo.ClientID, _customerInfo.UserName, _customerInfo.Password);
            }
            catch (Exception ex)
            {
                _streamWriterFile.WriteLine(ex);// string.Format("Service has been started at {0} | {1}", DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString()));
            }
            finally
            {
                _streamWriterFile.Flush();
            }

            _timer.Enabled = true;
            _timer.AutoReset = false;// true;
            _timer.Elapsed += OnTimedEvent;

        }
       

        private bool SendLicsRequestToIx4(LICSRequest request, string fileName)
        {
            bool result = false;
            try
            {
                if (_ix4ServiceConnector != null)
                {
                    XmlSerializer serializator = new XmlSerializer(typeof(LICSRequest));
                    Stream st = new FileStream("C:\\Ilya\\ServiceProgram\\tmp.xml", FileMode.OpenOrCreate);// Stream();
                    serializator.Serialize(st, request);
                    byte[] bytes = ReadToEnd(st);
                    string resp = _ix4ServiceConnector.ImportXmlRequest(bytes, fileName);

                }
            }
            catch(Exception ex)
            {
                WrightLog(ex.ToString());
            }

           

            return result;
        }

        private byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        //   IProxyIx4WebService

        private void WrightLog(string message)
        {
            if (_streamWriterFile != null)
            {
                _streamWriterFile.WriteLine(message);

                _streamWriterFile.Flush();
            }
        }


    

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            // CheckXmlOrdersFolder();
            //    CheckMsSqlArticles();
            CheckMsSqlDeliveriew();
        }

        private void CheckMsSqlDeliveriew()
        {
            int currentClientID = _customerInfo.ClientID;
            LICSRequest request = new LICSRequest();
            request.ClientId = currentClientID;
            // List<LICSRequestArticle> articlesRequest = new List<LICSRequestArticle>();
            LICSRequestDelivery[] deliveries = CustomerDataComposition.Instance.GetRequestDeliveries();
            if (deliveries.Length == 0)
            {
                return;
            }
            foreach (LICSRequestDelivery delivery in deliveries)
            {
                delivery.ClientNo = currentClientID;
            }
            request.DeliveryImport = new LICSRequestDelivery[] { deliveries[0], deliveries[1], deliveries[2] };

            var res = SendLicsRequestToIx4(request, "deliveryFile.xml");
        }

        private void CheckMsSqlArticles()
        {
            int currentClientID = _customerInfo.ClientID;
            LICSRequest request = new LICSRequest();
            request.ClientId = currentClientID;
           // List<LICSRequestArticle> articlesRequest = new List<LICSRequestArticle>();
            LICSRequestArticle[] articles = CustomerDataComposition.Instance.GetRequestArticles();
            if(articles.Length == 0)
            {
                return;
            }
            foreach (LICSRequestArticle article in articles)
            {
                article.ClientNo = currentClientID;
            }
            request.ArticleImport = articles;

            var res = SendLicsRequestToIx4(request, "articleFile.xml");

        }



        private void CheckXmlOrdersFolder()
        {
            try
            {
                if (_customerInfo == null)
                {
                    return;
                }

                // string[] xmlSourceFiles = Directory.GetFiles("C:\\Ilya\\TestXmlFolder\\XmlSource");// _customerInfo.PluginSettings.XmlSettings.SourceFolder);
                // ICustomerDataConnector xmlDataConnector = CustomerDataComposition.Instance.GetDataConnector(CustomDataSourceTypes.Xml);
                string[] xmlSourceFiles = Directory.GetFiles(_customerInfo.PluginSettings.XmlSettings.SourceFolder);
                if (xmlSourceFiles.Length > 0)
                {
                    foreach (string file in xmlSourceFiles)
                    {
                        _streamWriterFile.WriteLine(string.Format("Filename:  {0}", file));

                        LICSRequest request = CustomerDataComposition.Instance.GetCustomerDataFromXml(file);// xmlDataConnector.GetCustomerDataFromXml(file);
                        request.ClientId = _customerInfo.ClientID;
                        SendLicsRequestToIx4(request, Path.GetFileName(file));
                    }
                }


                string mes1 = string.Format("Service Timer has been elapsed at {0} | {1}", DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString());
                string mes2 = string.Format("Count of files in the folder {0} = {1}", _customerInfo.PluginSettings.XmlSettings.SourceFolder, xmlSourceFiles.Length);
                WrightLog(mes1);
                WrightLog(mes2);


                //foreach (string file in xmlSourceFiles)
                //{


                //}
            }
            catch (Exception ex)
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
