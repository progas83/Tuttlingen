namespace IX4InterfaceExample
{
    partial class frmExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExample));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAuth = new System.Windows.Forms.TabPage();
            this.gbCredentials = new System.Windows.Forms.GroupBox();
            this.uiTestConnection = new System.Windows.Forms.Button();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.tbEndpoint = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tpSend = new System.Windows.Forms.TabPage();
            this.gbXMLResponse = new System.Windows.Forms.GroupBox();
            this.rtbXMLResponse = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.gbXMLRequest = new System.Windows.Forms.GroupBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.tpGet = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbExportDataResponse = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExportDataAsync = new System.Windows.Forms.Button();
            this.btnExportData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbParam0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbExportDataType = new System.Windows.Forms.TextBox();
            this.butClear = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpAuth.SuspendLayout();
            this.gbCredentials.SuspendLayout();
            this.tpSend.SuspendLayout();
            this.gbXMLResponse.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbXMLRequest.SuspendLayout();
            this.tpGet.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAuth);
            this.tabControl1.Controls.Add(this.tpSend);
            this.tabControl1.Controls.Add(this.tpGet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 564);
            this.tabControl1.TabIndex = 0;
            // 
            // tpAuth
            // 
            this.tpAuth.Controls.Add(this.gbCredentials);
            this.tpAuth.Location = new System.Drawing.Point(4, 22);
            this.tpAuth.Name = "tpAuth";
            this.tpAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuth.Size = new System.Drawing.Size(628, 538);
            this.tpAuth.TabIndex = 2;
            this.tpAuth.Text = "Authentication";
            this.tpAuth.UseVisualStyleBackColor = true;
            // 
            // gbCredentials
            // 
            this.gbCredentials.Controls.Add(this.uiTestConnection);
            this.gbCredentials.Controls.Add(this.lblEndpoint);
            this.gbCredentials.Controls.Add(this.tbEndpoint);
            this.gbCredentials.Controls.Add(this.lblComment);
            this.gbCredentials.Controls.Add(this.tbClientId);
            this.gbCredentials.Controls.Add(this.lblClientId);
            this.gbCredentials.Controls.Add(this.tbPassword);
            this.gbCredentials.Controls.Add(this.tbUsername);
            this.gbCredentials.Controls.Add(this.lblPassword);
            this.gbCredentials.Controls.Add(this.lblUsername);
            this.gbCredentials.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCredentials.Location = new System.Drawing.Point(3, 3);
            this.gbCredentials.Name = "gbCredentials";
            this.gbCredentials.Size = new System.Drawing.Size(622, 160);
            this.gbCredentials.TabIndex = 9;
            this.gbCredentials.TabStop = false;
            // 
            // uiTestConnection
            // 
            this.uiTestConnection.Location = new System.Drawing.Point(131, 123);
            this.uiTestConnection.Name = "uiTestConnection";
            this.uiTestConnection.Size = new System.Drawing.Size(112, 23);
            this.uiTestConnection.TabIndex = 16;
            this.uiTestConnection.Text = "Select File";
            this.uiTestConnection.UseVisualStyleBackColor = true;
            this.uiTestConnection.Click += new System.EventHandler(this.uiTestConnection_Click);
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(71, 100);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(52, 13);
            this.lblEndpoint.TabIndex = 15;
            this.lblEndpoint.Text = "Endpoint:";
            // 
            // tbEndpoint
            // 
            this.tbEndpoint.Location = new System.Drawing.Point(131, 97);
            this.tbEndpoint.Name = "tbEndpoint";
            this.tbEndpoint.Size = new System.Drawing.Size(389, 20);
            this.tbEndpoint.TabIndex = 14;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(371, 16);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(245, 13);
            this.lblComment.TabIndex = 9;
            this.lblComment.Text = "* This static values you get from LogistikBroker AG";
            // 
            // tbClientId
            // 
            this.tbClientId.Location = new System.Drawing.Point(131, 19);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.Size = new System.Drawing.Size(100, 20);
            this.tbClientId.TabIndex = 8;
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(78, 22);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(45, 13);
            this.lblClientId.TabIndex = 7;
            this.lblClientId.Text = "ClientId:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(131, 71);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(131, 45);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 20);
            this.tbUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(69, 74);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(67, 48);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // tpSend
            // 
            this.tpSend.Controls.Add(this.gbXMLResponse);
            this.tpSend.Controls.Add(this.groupBox1);
            this.tpSend.Controls.Add(this.gbXMLRequest);
            this.tpSend.Location = new System.Drawing.Point(4, 22);
            this.tpSend.Name = "tpSend";
            this.tpSend.Padding = new System.Windows.Forms.Padding(3);
            this.tpSend.Size = new System.Drawing.Size(628, 538);
            this.tpSend.TabIndex = 0;
            this.tpSend.Text = "Send XMLRequest";
            this.tpSend.UseVisualStyleBackColor = true;
            // 
            // gbXMLResponse
            // 
            this.gbXMLResponse.Controls.Add(this.rtbXMLResponse);
            this.gbXMLResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbXMLResponse.Location = new System.Drawing.Point(3, 150);
            this.gbXMLResponse.Name = "gbXMLResponse";
            this.gbXMLResponse.Size = new System.Drawing.Size(622, 385);
            this.gbXMLResponse.TabIndex = 10;
            this.gbXMLResponse.TabStop = false;
            this.gbXMLResponse.Text = "XMLResponse";
            // 
            // rtbXMLResponse
            // 
            this.rtbXMLResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbXMLResponse.Location = new System.Drawing.Point(3, 16);
            this.rtbXMLResponse.Name = "rtbXMLResponse";
            this.rtbXMLResponse.Size = new System.Drawing.Size(616, 366);
            this.rtbXMLResponse.TabIndex = 3;
            this.rtbXMLResponse.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butClear);
            this.groupBox1.Controls.Add(this.btnSendRequest);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 62);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send";
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(11, 19);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(112, 23);
            this.btnSendRequest.TabIndex = 5;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // gbXMLRequest
            // 
            this.gbXMLRequest.Controls.Add(this.btnValidate);
            this.gbXMLRequest.Controls.Add(this.tbFilename);
            this.gbXMLRequest.Controls.Add(this.btnLoadFromFile);
            this.gbXMLRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbXMLRequest.Location = new System.Drawing.Point(3, 3);
            this.gbXMLRequest.Name = "gbXMLRequest";
            this.gbXMLRequest.Size = new System.Drawing.Size(622, 85);
            this.gbXMLRequest.TabIndex = 7;
            this.gbXMLRequest.TabStop = false;
            this.gbXMLRequest.Text = "XML Request";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(11, 48);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(112, 23);
            this.btnValidate.TabIndex = 3;
            this.btnValidate.Text = "Schema Validation";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(131, 21);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(494, 20);
            this.tbFilename.TabIndex = 2;
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(11, 19);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(112, 23);
            this.btnLoadFromFile.TabIndex = 1;
            this.btnLoadFromFile.Text = "Select File";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // tpGet
            // 
            this.tpGet.Controls.Add(this.groupBox3);
            this.tpGet.Controls.Add(this.groupBox2);
            this.tpGet.Location = new System.Drawing.Point(4, 22);
            this.tpGet.Name = "tpGet";
            this.tpGet.Padding = new System.Windows.Forms.Padding(3);
            this.tpGet.Size = new System.Drawing.Size(628, 538);
            this.tpGet.TabIndex = 1;
            this.tpGet.Text = "Get Data (Export)";
            this.tpGet.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbExportDataResponse);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(622, 432);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ExportDataResponse";
            // 
            // rtbExportDataResponse
            // 
            this.rtbExportDataResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbExportDataResponse.Location = new System.Drawing.Point(3, 16);
            this.rtbExportDataResponse.Name = "rtbExportDataResponse";
            this.rtbExportDataResponse.Size = new System.Drawing.Size(616, 413);
            this.rtbExportDataResponse.TabIndex = 4;
            this.rtbExportDataResponse.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnFormat);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnExportDataAsync);
            this.groupBox2.Controls.Add(this.btnExportData);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbParam0);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbExportDataType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "* (default types): Stock / IncomingGoods / OutgoingGoods";
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(460, 70);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.TabIndex = 22;
            this.btnFormat.Text = "XML Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(541, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExportDataAsync
            // 
            this.btnExportDataAsync.Location = new System.Drawing.Point(99, 71);
            this.btnExportDataAsync.Name = "btnExportDataAsync";
            this.btnExportDataAsync.Size = new System.Drawing.Size(92, 23);
            this.btnExportDataAsync.TabIndex = 20;
            this.btnExportDataAsync.Text = "Get Data Async";
            this.btnExportDataAsync.UseVisualStyleBackColor = true;
            this.btnExportDataAsync.Click += new System.EventHandler(this.btnExportDataAsync_Click);
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(6, 71);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(87, 23);
            this.btnExportData.TabIndex = 19;
            this.btnExportData.Text = "Get Data";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Param[0]:";
            // 
            // tbParam0
            // 
            this.tbParam0.Location = new System.Drawing.Point(258, 19);
            this.tbParam0.Name = "tbParam0";
            this.tbParam0.Size = new System.Drawing.Size(125, 20);
            this.tbParam0.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Type:";
            // 
            // tbExportDataType
            // 
            this.tbExportDataType.Location = new System.Drawing.Point(55, 19);
            this.tbExportDataType.Name = "tbExportDataType";
            this.tbExportDataType.Size = new System.Drawing.Size(125, 20);
            this.tbExportDataType.TabIndex = 15;
            this.tbExportDataType.Text = "Stock";
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(522, 16);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 26);
            this.butClear.TabIndex = 22;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 564);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExample";
            this.Text = "IX4 Interface Example";
            this.Load += new System.EventHandler(this.frmExample_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpAuth.ResumeLayout(false);
            this.gbCredentials.ResumeLayout(false);
            this.gbCredentials.PerformLayout();
            this.tpSend.ResumeLayout(false);
            this.gbXMLResponse.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbXMLRequest.ResumeLayout(false);
            this.gbXMLRequest.PerformLayout();
            this.tpGet.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSend;
        private System.Windows.Forms.GroupBox gbXMLResponse;
        private System.Windows.Forms.RichTextBox rtbXMLResponse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.GroupBox gbXMLRequest;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.TabPage tpGet;
        private System.Windows.Forms.TabPage tpAuth;
        private System.Windows.Forms.GroupBox gbCredentials;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.TextBox tbEndpoint;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox tbClientId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExportDataAsync;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbParam0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbExportDataType;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbExportDataResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiTestConnection;
        private System.Windows.Forms.Button butClear;
    }
}

