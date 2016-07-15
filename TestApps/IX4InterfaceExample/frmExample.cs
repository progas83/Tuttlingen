using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using System.Net;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Reflection;
using System.Xml.Linq;
using IX4InterfaceExample.ix4WebService;

namespace IX4InterfaceExample
{
    public partial class frmExample : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public frmExample()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Read default values config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExample_Load(object sender, EventArgs e)
        {
            try
            {
                //Load from secured settings
                tbClientId.Text = "1000001";
                tbUsername.Text = "adminbio";
                tbPassword.Text = "rhSjQFWB";
                tbEndpoint.Text = @"https://mackschuehle.logistic-cloud.com/system/webservices/wspickpublic.asmx";
            }
            catch
            {
                MessageBox.Show("Failed to read configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Properties/Fields

        /// <summary>
        /// Namespace of LICSRequest
        /// </summary>
        private const string nsLICSRequest = "http://logistikbroker.com/LICSRequest.xsd";

        /// <summary>
        /// XSD of LICSRequest
        /// </summary>
        private const string xsdLICSRequest = "IX4InterfaceExample.Schema.LICSRequest.xsd";

        #endregion

        #region SendRequest

        /// <summary>
        /// Load a LICSRequest from xml-file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "*.xml|*.xml";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbFilename.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Send the LICSXMLRequest to the WCF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendRequest_Click(object sender, EventArgs e)
        {

            try
            {
                //Validate
                int clientId;
                if (!int.TryParse(tbClientId.Text, out clientId))
                {
                    MessageBox.Show("Failed to parse clientId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(tbFilename.Text))
                {
                    MessageBox.Show("Selected file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Get xml response
                rtbXMLResponse.Text = GetXMLResponse(clientId, tbUsername.Text, tbPassword.Text, tbFilename.Text);

                /* 
                 * How to convert to object
                 * 
                 * 1. Use xsd tool (.NET) to generate c# objects from schema LICSResponse.xsd
                 * 2. Use XmlSerializer to parse the response into object
                 * 
                 */
                XmlSerializer ResponseSerializer = new XmlSerializer(typeof(LICSResponse));
                LICSResponse objResponse;
                using (TextReader tr = new StringReader(rtbXMLResponse.Text))
                {
                    objResponse = (LICSResponse)ResponseSerializer.Deserialize(tr);
                }

                //Validate the results
                if (objResponse.ArticleImport != null && objResponse.ArticleImport.CountOfFailed > 0)
                {
                    //Handle ArticleImportErrors
                }

                if (objResponse.DeliveryImport != null && objResponse.DeliveryImport.CountOfFailed > 0)
                {
                    //Handle DeliveryImportErrors
                }

                if (objResponse.OrderImport != null && objResponse.OrderImport.CountOfFailed > 0)
                {
                    //Handle OrderImportErrors
                }

                MessageBox.Show("Request done.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// Send the interface request and get the response
        /// </summary>
        /// <param name="clientId">Your ClientId</param>
        /// <param name="username">WCFUsername</param>
        /// <param name="password">WCFUserpassword</param>
        /// <param name="file">RequestFile</param>
        /// <returns></returns>
        private string GetXMLResponse(int clientId, string username, string password, string file)
        {
            //Get bytes of file
            byte[] fileContent = File.ReadAllBytes(file);

            //Service proxy
            if (string.IsNullOrEmpty(tbEndpoint.Text))
            {
                MessageBox.Show("Invalid Endpoint adress.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Failed";
            }

            //Webservice
            ix4WebReference.ix4PublicInterface wsProxy = new ix4WebReference.ix4PublicInterface();
            wsProxy.Url = tbEndpoint.Text;


            //Authentication
            ix4WebReference.LBSoapAuthenticationHeader head = new ix4WebReference.LBSoapAuthenticationHeader();
            head.UserName = "wsbio";// tbUsername.Text;
            head.Password = "bon8s2a5w2";// tbPassword.Text;
            head.ClientId = 1000001;
            //head.ClientId = int.Parse(tbClientId.Text);
            //head.UserName = tbUsername.Text;
            //head.Password = tbPassword.Text;
            wsProxy.LBSoapAuthenticationHeaderValue = head;

            //Call
            return wsProxy.LICSImportXMLRequest(fileContent, Path.GetFileName(file));

        }

        #endregion

        #region SchemaValidation

        private void btnValidate_Click(object sender, EventArgs e)
        {
            //Open Schema
            if (string.IsNullOrEmpty(tbFilename.Text))
            {
                MessageBox.Show("Please select a xml file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            validateXMLShema(tbFilename.Text, nsLICSRequest, xsdLICSRequest);
        }

        private void validateXMLShema(string xmlFile, string ns, string embeddedSchemaFile)
        {
            try
            {
                using (XmlTextReader tr = new XmlTextReader(xmlFile))
                {
                    Assembly execAssembly = Assembly.GetExecutingAssembly();
                    XmlReaderSettings rs = new XmlReaderSettings();
                    Stream _FileStream = execAssembly.GetManifestResourceStream(embeddedSchemaFile);
                    rs.Schemas.Add(ns, new XmlTextReader(_FileStream));
                    rs.ValidationType = ValidationType.Schema;
                    rs.ValidationEventHandler += new ValidationEventHandler(validationEventsHandling);
                    using (XmlReader vr = XmlReader.Create(tr, rs))
                    {
                        while (vr.Read()) ;
                    }
                }
                MessageBox.Show("Schema Validation successful.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Schema Validation Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validationEventsHandling(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                MessageBox.Show("Schema Validation WARNING: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                MessageBox.Show("Invalid Shema. " + e.Severity + "/Msg: " + e.Message);
            }
        }

        #endregion

        #region Export

       

        private string[] getParameter()
        {
            if (!string.IsNullOrEmpty(tbParam0.Text))
            {
                return new string[] { tbParam0.Text };
            }
            return null;
        }

      

        private delegate void SetText(string text);

        private void SetRTBText(string text)
        {
            if (rtbExportDataResponse.InvokeRequired)
            {
                rtbExportDataResponse.Invoke(new SetText(SetRTBText), new object[] { text });
            }
            else
            {
                rtbExportDataResponse.Text = text;
            }
        }
        private void btnExportDataAsync_Click(object sender, EventArgs e)
        {
            try
            {
                ix4WebReference.ix4PublicInterface ws = new ix4WebReference.ix4PublicInterface();

                ix4WebReference.LBSoapAuthenticationHeader header = new ix4WebReference.LBSoapAuthenticationHeader();
                header.UserName = "wsbio";// tbUsername.Text;
                header.Password = "bon8s2a5w2";// tbPassword.Text;
                header.ClientId = 1000001;// i;// int.Parse(tbClientId.Text);
                ws.LBSoapAuthenticationHeaderValue = header;

                ws.ExportDataCompleted += Ws_ExportDataCompleted;
                    //+= ws_ExportDataCompleted;

                ws.ExportDataAsync(tbExportDataType.Text, getParameter());

            }
            catch (Exception exc)
            {
                rtbExportDataResponse.Text = exc.Message;
            }
        }

        private void Ws_ExportDataCompleted(object sender, ix4WebReference.ExportDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetRTBText("Error: " + e.Error.Message);
            }
            else
            {
                XmlNode n = e.Result;
                SetRTBText(n.OuterXml);
            }
        }

       private ix4WebReference.LBSoapAuthenticationHeader GetHeader(bool automatic = true)
        {
            ix4WebReference.LBSoapAuthenticationHeader header = new ix4WebReference.LBSoapAuthenticationHeader();

                       if(automatic)
            {
                header.UserName = tbUsername.Text;
                header.Password = tbPassword.Text;
                header.ClientId = int.Parse(tbClientId.Text);
            }
            else
            {
                header.UserName = "wsbio"; //"bionisys";// 
                header.Password = "bon8s2a5w2";
                header.ClientId = 1000001;

            }

            return header;
        }
        private void btnExportData_Click(object sender, EventArgs e)
        {
            try
            {

                ix4WebReference.ix4PublicInterface ws = new ix4WebReference.ix4PublicInterface();
                ws.LBSoapAuthenticationHeaderValue = GetHeader(false);

                XmlNode n = ws.ExportData(tbExportDataType.Text, getParameter());
                // WSPickPublic.ix4PublicInterface ws = new WSPickPublic.ix4PublicInterface();
                // //ws.Url = @"https://mackschuehle.logistic-cloud.com/Default.aspx";
                // // WSPickPublic.LBSoapAuthenticationHeader head = new WSPickPublic.LBSoapAuthenticationHeader();
                //ix4WebService.LBSoapAuthenticationHeader head = new ix4WebService.LBSoapAuthenticationHeader();
                // head.UserName = "adminbio";// tbUsername.Text;
                // head.Password = "rhSjQFWB";// tbPassword.Text;
                // head.ClientId = 1000001;// i;// int.Parse(tbClientId.Text);
                // //ws.LBSoapAuthenticationHeaderValue = head;

                //ix4WebService.ExportDataRequest exportDataRequest = new ix4WebService.ExportDataRequest(head, tbExportDataType.Text, getParameter());
                //ix4WebService.ExportDataResponse exportDataResponse = new ix4WebService.ExportDataResponse();

                //ix4WebService.LICSImportXMLRequestResponse xmlResponse = new ix4WebService.LICSImportXMLRequestResponse();
                ////   ix4WebService.LBAuthenticatedChannel .LBAuthenticated lbAuth = null;

                //ix4WebService.LICSImportXMLRequestRequest xmlRequest = new ix4WebService.LICSImportXMLRequestRequest();
                ////exportDataResponse.ExportDataResult 

                //XmlNode n = ws.ExportData(tbExportDataType.Text, getParameter());
                //     MessageBox.Show(string.Format("There is a valid Client ID = {0} ",i.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetRTBText(n.OuterXml);

                //WSPickPublic.ix4PublicInterface ws = new WSPickPublic.ix4PublicInterface();

                //WSPickPublic.LBSoapAuthenticationHeader head = new WSPickPublic.LBSoapAuthenticationHeader();
                //head.UserName = tbUsername.Text;
                //head.Password = tbPassword.Text;
                //head.ClientId = int.Parse(tbClientId.Text);
                //ws.LBSoapAuthenticationHeaderValue = head;
                //ws.Url = @"https://mackschuehle.logistic-cloud.com/system/webservices/wspickpublic.asmx";
                //XmlNode n = ws.ExportData(tbExportDataType.Text, getParameter());
                //SetRTBText(n.OuterXml);
            }
            catch (Exception exc)
            {
                SetRTBText(exc.Message);
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument doc = XDocument.Parse(rtbExportDataResponse.Text);
                doc.Declaration = new XDeclaration("1.0", "utf-8", null);
                StringWriter writer = new Utf8StringWriter();
                doc.Save(writer, SaveOptions.None);
                SetRTBText(writer.ToString());
            }
            catch (Exception exc)
            {
                SetRTBText("Format failed. " + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbExportDataResponse.Clear();
        }


        #endregion

        private void uiTestConnection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000000; i++)
            {
                try
                {
                    ix4WebReference.ix4PublicInterface ws = new ix4WebReference.ix4PublicInterface();

                    ix4WebReference.LBSoapAuthenticationHeader header = new ix4WebReference.LBSoapAuthenticationHeader();
                    header.UserName = "adminbio";// tbUsername.Text;
                    header.Password = "rhSjQFWB";// tbPassword.Text;
                    header.ClientId = 1000001;// i;// int.Parse(tbClientId.Text);

                    ws.LBSoapAuthenticationHeaderValue = header;

                    XmlNode n = ws.ExportData(tbExportDataType.Text, getParameter());
                   // WSPickPublic.ix4PublicInterface ws = new WSPickPublic.ix4PublicInterface();
                   // //ws.Url = @"https://mackschuehle.logistic-cloud.com/Default.aspx";
                   // // WSPickPublic.LBSoapAuthenticationHeader head = new WSPickPublic.LBSoapAuthenticationHeader();
                   //ix4WebService.LBSoapAuthenticationHeader head = new ix4WebService.LBSoapAuthenticationHeader();
                   // head.UserName = "adminbio";// tbUsername.Text;
                   // head.Password = "rhSjQFWB";// tbPassword.Text;
                   // head.ClientId = 1000001;// i;// int.Parse(tbClientId.Text);
                   // //ws.LBSoapAuthenticationHeaderValue = head;

                    //ix4WebService.ExportDataRequest exportDataRequest = new ix4WebService.ExportDataRequest(head, tbExportDataType.Text, getParameter());
                    //ix4WebService.ExportDataResponse exportDataResponse = new ix4WebService.ExportDataResponse();

                    //ix4WebService.LICSImportXMLRequestResponse xmlResponse = new ix4WebService.LICSImportXMLRequestResponse();
                    ////   ix4WebService.LBAuthenticatedChannel .LBAuthenticated lbAuth = null;

                    //ix4WebService.LICSImportXMLRequestRequest xmlRequest = new ix4WebService.LICSImportXMLRequestRequest();
                    ////exportDataResponse.ExportDataResult 

                    //XmlNode n = ws.ExportData(tbExportDataType.Text, getParameter());
               //     MessageBox.Show(string.Format("There is a valid Client ID = {0} ",i.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetRTBText(n.OuterXml);


                }
                catch (Exception exc)
                {
                   SetRTBText(exc.Message);
                }
            }


        }

        private void uiTestConnection_ClickTest(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000000; i++)
            {
                try
                {

                    //ix4WebService.LICSImportXMLRequestRequest importXMLRequest = new ix4WebService.LICSImportXMLRequestRequest()

                    testLogCloudPublicInterfaceService.LBAuthenticatedClient lbAuthenticatedClient = new testLogCloudPublicInterfaceService.LBAuthenticatedClient();





                    WSPickPublic.ix4PublicInterface ws = new WSPickPublic.ix4PublicInterface();
                    ws.Url = @"https://mackschuehle.logistic-cloud.com/Default.aspx";
                    WSPickPublic.LBSoapAuthenticationHeader head = new WSPickPublic.LBSoapAuthenticationHeader();
                    head.UserName = "adminbio";// tbUsername.Text;
                    head.Password = "rhSjQFWB";// tbPassword.Text;
                    head.ClientId = i;// int.Parse(tbClientId.Text);
                    ws.LBSoapAuthenticationHeaderValue = head;

                    XmlNode n = ws.ExportData(tbExportDataType.Text, getParameter());
                    MessageBox.Show(string.Format("There is a valid Client ID = {0} ", i.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetRTBText(n.OuterXml);


                }
                catch (Exception)
                {
                    //SetRTBText(exc.Message);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbXMLResponse.Text = string.Empty;
        }
    }

    public class TestInterf : ix4WebService.LBAuthenticated
    {
        public ArticleImportCSVRequestResponse ArticleImportCSVRequest(ArticleImportCSVRequestRequest request)
        {
            throw new NotImplementedException();
        }

        public DeliveryImportCSVRequestResponse DeliveryImportCSVRequest(DeliveryImportCSVRequestRequest request)
        {
            throw new NotImplementedException();
        }

        public ExportDataResponse ExportData(ExportDataRequest request)
        {
            throw new NotImplementedException();
        }

        public LICSImportXMLRequestResponse LICSImportXMLRequest(LICSImportXMLRequestRequest request)
        {
            throw new NotImplementedException();
        }

        public OrderImportCSVRequestResponse OrderImportCSVRequest(OrderImportCSVRequestRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
