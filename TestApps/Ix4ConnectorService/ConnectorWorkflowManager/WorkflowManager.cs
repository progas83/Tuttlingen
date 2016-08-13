using CompositionHelper;
using Ix4Connector;
using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.SettingsManager;
using SimplestLogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Xml.Serialization;
using System.Linq;
using Ix4Models.Converters;

namespace ConnectorWorkflowManager
{
    public class WorkflowManager
    {
        private static WorkflowManager _manager;
        private CustomerInfo _customerInfo;
        private CustomerDataComposition _dataCompositor;
        private IProxyIx4WebService _ix4ServiceConnector;

        protected Timer _timer;// = new Timer(RElapsedEvery);
        private static object _padlock = new object();
        private static readonly long RElapsedEvery = 60000;
        private static readonly int _articlesPerRequest = 20;


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
                    _timer.AutoReset = true;
                    _timer.Elapsed += OnTimedEvent;
                }

                _loger.Log("Service has been started at");

                _customerInfo = XmlConfigurationManager.Instance.GetCustomerInformation();
                _dataCompositor = new CustomerDataComposition(_customerInfo.PluginSettings);
                _ix4ServiceConnector = Ix4ConnectorManager.Instance.GetRegisteredIx4WebServiceInterface(_customerInfo.ClientID, _customerInfo.UserName, _customerInfo.Password, _customerInfo.ServiceEndpoint);
                //   _loger.Log("CUSTOMER INFO = "+ _customerInfo.ToString());


                _timer.Enabled = true;
            }
            catch (Exception ex)
            {
                _loger.Log(ex);
                _loger.Log(_customerInfo, "_customerInfo");
                _loger.Log(_ix4ServiceConnector, "_ix4ServiceConnector");
            }
        }
        private long _articlesLastUpdate = 0;
        private long _ordersLastUpdate = 0;
        private long _deliveriesLastUpdate = 0;

        private long GetTimeStamp()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            try
            {

                // CheckPreparedRequest(CustomDataSourceTypes.MsSql, Ix4RequestProps.Articles);
                //CheckArticles();
                WrightLog("Timer has elapsed");
                //WrightLog("-------------------------------------Check Articles--MsSQL--------------------------------");

                CheckArticles();
                //WrightLog("-------------------------------------Check ORDERS- XML----------------------------------");
                //CheckPreparedRequest(CustomDataSourceTypes.Xml, Ix4RequestProps.Orders);
                //WrightLog("-------------------------------------Check Deliveries--MSSQL---------------------------------");
                //CheckDeliveries();
            }
            catch (Exception ex)
            {
                _loger.Log(ex.Message);
            }
            finally
            {
                _timer.Enabled = true;
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
            if (_timer != null)
            {
                _timer.Elapsed -= OnTimedEvent;
                _timer.Stop();
                _timer.Enabled = false;
                _timer.Dispose();
                _timer = null;
            }

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
                        using (Stream st = new FileStream(CurrentServiceInformation.TemporaryXmlFileName, FileMode.OpenOrCreate))
                        {
                            serializator.Serialize(st, request);
                            byte[] bytesRequest = ReadToEnd(st);
                            string resp = _ix4ServiceConnector.ImportXmlRequest(bytesRequest, fileName);
                            _loger.Log(resp);
                        }
                        File.Delete(CurrentServiceInformation.TemporaryXmlFileName);
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    WrightLog(ex.ToString());
                }
                finally
                {
                    //File.Delete(CurrentServiceInformation.TemporaryXmlFileName);
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



        private void CheckPreparedRequest(CustomDataSourceTypes dataSourceType, Ix4RequestProps ix4Property)
        {
            _loger.Log("============================ CheckPreparedRequest============================================");
            try
            {
                // if(_ordersLastUpdate == 0 || (GetTimeStamp() - _ordersLastUpdate) >60)
                // {
                LICSRequest[] requests = _dataCompositor.GetPreparedRequests(dataSourceType, ix4Property);
                _loger.Log(string.Format("Count of available {0} = {1}", ix4Property, requests.Length));
                if (requests.Length > 0)
                {
                    foreach (var item in requests)
                    {
                        item.ClientId = _customerInfo.ClientID;
                        var res = SendLicsRequestToIx4(item, "deliveryFile.xml");
                        _loger.Log(string.Format("{0} result: {1}", ix4Property, res));
                    }
                }
                //     _ordersLastUpdate = GetTimeStamp();
                //}

            }
            catch (Exception ex)
            {
                _loger.Log(ex);
            }
        }

        private void CheckDeliveries()
        {
            try
            {
                if (_deliveriesLastUpdate == 0 || (GetTimeStamp() - _deliveriesLastUpdate) > 7200)
                {
                    if (_cachedArticles == null)
                    {
                        _loger.Log("There is no cheched articles for filling deliveries");
                        CheckArticles();
                        if (_cachedArticles == null)
                        {
                            _loger.Log("WE CANNOT GET DELIVERIES WITHOUT ARTICLES");
                            return;
                        }
                    }
                    int currentClientID = _customerInfo.ClientID;
                    LICSRequest request = new LICSRequest();
                    request.ClientId = currentClientID;
                    LICSRequestDelivery[] deliveries = _dataCompositor.GetRequestDeliveries();
                    List<LICSRequestArticle> articlesByDelliveries = new List<LICSRequestArticle>();
                    _loger.Log(deliveries, "deliveries");
                    if (deliveries.Length == 0)
                    {
                        _loger.Log("There is no deliveries");
                        return;
                    }
                    foreach (LICSRequestDelivery delivery in deliveries)
                    {
                        bool deliveryHasErrors = false;
                        articlesByDelliveries = new List<LICSRequestArticle>();
                        delivery.ClientNo = currentClientID;
                        request.DeliveryImport = new LICSRequestDelivery[] { delivery };
                        foreach (var position in delivery.Positions)
                        {
                            LICSRequestArticle findArticle = GetArticleByNumber(position.ArticleNo);
                            if (findArticle == null)
                            {
                                _loger.Log("Cannot find article with no:  " + position.ArticleNo);
                                _loger.Log("Delivery with wrong article position:  " + delivery);
                                deliveryHasErrors = true;
                            }
                            else
                            {
                                articlesByDelliveries.Add(findArticle);
                            }
                        }
                        if (deliveryHasErrors)
                        {
                            _loger.Log("Delivery " + delivery + "WAS NOT SEND");
                            continue;
                        }
                        else
                        {
                            request.ArticleImport = articlesByDelliveries.ToArray();
                            _loger.Log("Delivery before sending: ");
                            foreach (LICSRequestDelivery item in request.DeliveryImport)
                            {
                                _loger.Log(item.SerializeObjectToString<LICSRequestDelivery>());
                            }

                            var res = SendLicsRequestToIx4(request, "deliveryFile.xml");
                            _loger.Log("Delivery result: " + res);
                        }

                    }
                    _deliveriesLastUpdate = GetTimeStamp();
                }

            }
            catch (Exception ex)
            {
                _loger.Log(ex);
            }

        }

        private LICSRequestArticle GetArticleByNumber(string articleNo)
        {
            if (_cachedArticles != null)
                return _cachedArticles.FirstOrDefault(item => item.ArticleNo.Equals(articleNo));
            else
            {
                _loger.Log("There is no CACHED ARTICLES!!!!!!!!!!");
                return null;
            }

        }
        LICSRequestArticle[] _cachedArticles;
        private void CheckArticles()
        {
            int countA = 0;
            try
            {

                if (_articlesLastUpdate == 0 || (GetTimeStamp() - _articlesLastUpdate) > 43200)
                {


                    int currentClientID = _customerInfo.ClientID;
                    LICSRequest request = new LICSRequest();
                    request.ClientId = currentClientID;
                    LICSRequestArticle[] articles = _dataCompositor.GetRequestArticles();
                    _loger.Log(string.Format("Got ARTICLES {0}", articles != null ? articles.Length : 0));

                    if (articles == null || articles.Length == 0)
                    {
                        _loger.Log("There is no available articles");
                        return;
                    }

                    List<LICSRequestArticle> tempAtricles = new List<LICSRequestArticle>();

                    for(int i=0;i< articles.Length;i++)
                    {
                        articles[i].ClientNo = currentClientID;
                        tempAtricles.Add(articles[i]);
                        if (tempAtricles.Count >= _articlesPerRequest || i==articles.Length-1)
                        {
                            request.ArticleImport = tempAtricles.ToArray();
                            var resSent = SendLicsRequestToIx4(request, "articleFile.xml");
                            if (resSent)
                            {
                                countA++;
                                _loger.Log(string.Format("Was sent {0} request with {1} articles", countA, tempAtricles.Count));
                                tempAtricles = new List<LICSRequestArticle>();
                            }
                        }
                    }

                    //foreach (LICSRequestArticle article in articles)
                    //{
                    // //   article.ClientNo = currentClientID;
                    // //   tempAtricles.Add(article);
                    //    //if (tempAtricles.Count > 20)
                    //    //{
                    //    //    request.ArticleImport = tempAtricles.ToArray();
                    //    //    var resSent = SendLicsRequestToIx4(request, "articleFile.xml");
                    //    //    if (resSent)
                    //    //    {
                    //    //        countA++;
                    //    //        _loger.Log(string.Format("Was sent {0}", countA));
                    //    //        tempAtricles = new List<LICSRequestArticle>();
                    //    //    }
                    //    //}
                    //}
                    //  request.ArticleImport = articles;

                    //     var res = SendLicsRequestToIx4(request, "articleFile.xml");
                    //if (res)
                    //{
                    //    _cachedArticles = articles;
                    //    _articlesLastUpdate = GetTimeStamp();
                    //}
                    //   _loger.Log("Articles result: " + res);
                }
            }
            catch (Exception ex)
            {
                _loger.Log(ex);
                _loger.Log("Inner excep " + ex.InnerException);
                _loger.Log("Inner excep MESSAGE" + ex.InnerException.Message);
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
                        var res = SendLicsRequestToIx4(request, Path.GetFileName(file));
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
