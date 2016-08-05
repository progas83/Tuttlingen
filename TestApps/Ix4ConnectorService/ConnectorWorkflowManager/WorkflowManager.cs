using CompositionHelper;
using Ix4Connector;
using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.SettingsManager;
using SimplestLogger;
using System;
using System.IO;
using System.Timers;
using System.Xml.Serialization;

namespace ConnectorWorkflowManager
{
    public class WorkflowManager
    {
        private static WorkflowManager _manager;
        private CustomerInfo _customerInfo;
        private CustomerDataComposition _dataCompositor;
        private IProxyIx4WebService _ix4ServiceConnector;

        protected Timer _timer = new Timer(RElapsedEvery);
        private static object _padlock = new object();
        private static readonly long RElapsedEvery = 60000;

        private static Logger _loger = Logger.GetLogger();

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

        public void Start()
        {

            try
            {
                if (_timer == null)
                {
                    _timer = new Timer(RElapsedEvery);
                }

                _loger.Log("Service has been started at");

                _customerInfo = XmlConfigurationManager.Instance.GetCustomerInformation();
                _dataCompositor = new CustomerDataComposition(_customerInfo.PluginSettings);
                _ix4ServiceConnector = Ix4ConnectorManager.Instance.GetRegisteredIx4WebServiceInterface(_customerInfo.ClientID, _customerInfo.UserName, _customerInfo.Password);
                _timer.Enabled = true;
                _timer.AutoReset = true;
                _timer.Elapsed += OnTimedEvent;
            }
            catch (Exception ex)
            {
                _loger.Log(ex);
                _loger.Log(_customerInfo, "_customerInfo");
                _loger.Log(_ix4ServiceConnector, "_ix4ServiceConnector");
            }
        }

        public void Pause()
        {
            if (_timer != null && _timer.Enabled)
            {
                _timer.Enabled = false;
            }
        }

        public void Continue()
        {
            if (_timer != null && !_timer.Enabled)
            {
                _timer.Enabled = true;
            }
        }

        public void Stop()
        {
            _timer.Stop();
            _timer.Enabled = false;
            _timer.Dispose();
            _timer = null;
            WrightLog("Service has stopped");
        }


        private static object _o = new object();
        private bool SendLicsRequestToIx4(LICSRequest request, string fileName)
        {
            bool result = false;
            lock (_o)
            {
                try
                {
                    if (_ix4ServiceConnector != null)
                    {
                        XmlSerializer serializator = new XmlSerializer(typeof(LICSRequest));
                        Stream st = new FileStream("C:\\ix4\\tmp.xml", FileMode.OpenOrCreate);
                        serializator.Serialize(st, request);
                        byte[] bytes = ReadToEnd(st);
                        string resp = _ix4ServiceConnector.ImportXmlRequest(bytes, fileName);
                        _loger.Log(resp);
                        st.Flush();
                        st.Dispose();
                        File.Delete("C:\\ix4\\tmp.xml");

                    }
                }
                catch (Exception ex)
                {
                    WrightLog(ex.ToString());
                }
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

        private void WrightLog(string message)
        {
            _loger.Log(message);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CheckPreparedRequest(CustomDataSourceTypes.Xml, Ix4RequestProps.Orders);
            // CheckXmlOrdersFolder();
            WrightLog("Timer has elapsed");
            //    CheckMsSqlArticles();
            //    CheckMsSqlDeliveriew();
        }

        private void CheckPreparedRequest(CustomDataSourceTypes dataSourceType, Ix4RequestProps ix4Property)
        {
            LICSRequest[] requests = _dataCompositor.GetPreparedRequests(dataSourceType,ix4Property);
            if(requests.Length>0)
            {

            }
        }

        private void CheckDeliveries()
        {
            try
            {
                int currentClientID = _customerInfo.ClientID;
                LICSRequest request = new LICSRequest();
                request.ClientId = currentClientID;
                LICSRequestDelivery[] deliveries = _dataCompositor.GetRequestDeliveries();
                _loger.Log(deliveries, "deliveries");
                if (deliveries.Length == 0)
                {
                    return;
                }
                foreach (LICSRequestDelivery delivery in deliveries)
                {
                    delivery.ClientNo = currentClientID;
                }
                request.DeliveryImport = deliveries;

                var res = SendLicsRequestToIx4(request, "deliveryFile.xml");
            }
            catch (Exception ex)
            {
                _loger.Log(ex);
            }

        }

        private void CheckArticles()
        {
            try
            {
                int currentClientID = _customerInfo.ClientID;
                LICSRequest request = new LICSRequest();
                request.ClientId = currentClientID;
                LICSRequestArticle[] articles = _dataCompositor.GetRequestArticles();
                _loger.Log(articles, "articles");
                if (articles == null || articles.Length == 0)
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
            catch (Exception ex)
            {
                _loger.Log(ex);
            }


        }

        private void CheckOrders()
        {
            try
            {
                if (_customerInfo == null)
                {
                    return;
                }

                string[] xmlSourceFiles = Directory.GetFiles(_customerInfo.PluginSettings.XmlSettings.XmlOrdersSourceFolder);
                if (xmlSourceFiles.Length > 0)
                {
                    foreach (string file in xmlSourceFiles)
                    {
                        LICSRequest request = new LICSRequest();

                        LICSRequestOrder[] requestOrders = _dataCompositor.GetRequestOrders();
                        request.OrderImport = requestOrders;
                        request.ClientId = _customerInfo.ClientID;
                        SendLicsRequestToIx4(request, Path.GetFileName(file));
                    }
                }


                string mes1 = string.Format("Service Timer has been elapsed at {0} | {1}", DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString());
                string mes2 = string.Format("Count of files in the folder {0} = {1}", _customerInfo.PluginSettings.XmlSettings.XmlArticleSourceFolder, xmlSourceFiles.Length);
                WrightLog(mes1);
                WrightLog(mes2);
            }
            catch (Exception ex)
            {
                WrightLog(ex.Message);
            }
        }
    }
}
