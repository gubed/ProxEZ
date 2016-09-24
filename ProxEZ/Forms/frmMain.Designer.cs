namespace ProxEZ.Forms
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.numLimit = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbProxEZ = new System.Windows.Forms.RadioButton();
            this.tbCustomSources = new System.Windows.Forms.TextBox();
            this.btnSourceBrowse = new System.Windows.Forms.Button();
            this.btnScrape = new System.Windows.Forms.Button();
            this.tap = new System.Windows.Forms.TabPage();
            this.btnStopCheck = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCustom = new System.Windows.Forms.CheckBox();
            this.tbCustom = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.tbSSL = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbCustomURLCheck = new System.Windows.Forms.CheckBox();
            this.cbSSLCheck = new System.Windows.Forms.CheckBox();
            this.numPing = new System.Windows.Forms.NumericUpDown();
            this.cbPingCheck = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTransCheck = new System.Windows.Forms.CheckBox();
            this.cbAnonCheck = new System.Windows.Forms.CheckBox();
            this.cbEliteCheck = new System.Windows.Forms.CheckBox();
            this.cbHighEliteCheck = new System.Windows.Forms.CheckBox();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnSaveC = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProxies = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importProxiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importProxiesFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeAllProxiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvProxies = new ProxEZ.Controls.ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tap.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPing)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cmsProxies.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 466);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lStatus
            // 
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(73, 17);
            this.lStatus.Text = "Status: Idle...";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tap);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 169);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnScrape);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(962, 143);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scraper";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbLimit);
            this.groupBox4.Controls.Add(this.numLimit);
            this.groupBox4.Location = new System.Drawing.Point(411, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(295, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // cbLimit
            // 
            this.cbLimit.AutoSize = true;
            this.cbLimit.Location = new System.Drawing.Point(19, 21);
            this.cbLimit.Name = "cbLimit";
            this.cbLimit.Size = new System.Drawing.Size(133, 17);
            this.cbLimit.TabIndex = 1;
            this.cbLimit.Text = "Limit Proxy Count:";
            this.cbLimit.UseVisualStyleBackColor = true;
            // 
            // numLimit
            // 
            this.numLimit.Location = new System.Drawing.Point(158, 20);
            this.numLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLimit.Name = "numLimit";
            this.numLimit.Size = new System.Drawing.Size(120, 21);
            this.numLimit.TabIndex = 0;
            this.numLimit.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCustom);
            this.groupBox1.Controls.Add(this.rbProxEZ);
            this.groupBox1.Controls.Add(this.tbCustomSources);
            this.groupBox1.Controls.Add(this.btnSourceBrowse);
            this.groupBox1.Location = new System.Drawing.Point(20, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy Sources";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(28, 43);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(92, 17);
            this.rbCustom.TabIndex = 4;
            this.rbCustom.Text = "Custom List";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rbProxEZ
            // 
            this.rbProxEZ.AutoSize = true;
            this.rbProxEZ.Checked = true;
            this.rbProxEZ.Location = new System.Drawing.Point(28, 20);
            this.rbProxEZ.Name = "rbProxEZ";
            this.rbProxEZ.Size = new System.Drawing.Size(89, 17);
            this.rbProxEZ.TabIndex = 3;
            this.rbProxEZ.TabStop = true;
            this.rbProxEZ.Text = "ProxEZ List";
            this.rbProxEZ.UseVisualStyleBackColor = true;
            // 
            // tbCustomSources
            // 
            this.tbCustomSources.Location = new System.Drawing.Point(55, 66);
            this.tbCustomSources.Name = "tbCustomSources";
            this.tbCustomSources.Size = new System.Drawing.Size(208, 21);
            this.tbCustomSources.TabIndex = 1;
            // 
            // btnSourceBrowse
            // 
            this.btnSourceBrowse.Location = new System.Drawing.Point(269, 64);
            this.btnSourceBrowse.Name = "btnSourceBrowse";
            this.btnSourceBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSourceBrowse.TabIndex = 2;
            this.btnSourceBrowse.Text = "Browse...";
            this.btnSourceBrowse.UseVisualStyleBackColor = true;
            this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
            // 
            // btnScrape
            // 
            this.btnScrape.Location = new System.Drawing.Point(837, 100);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(107, 28);
            this.btnScrape.TabIndex = 0;
            this.btnScrape.Text = "Scrape";
            this.btnScrape.UseVisualStyleBackColor = true;
            this.btnScrape.Click += new System.EventHandler(this.btnScrape_Click);
            // 
            // tap
            // 
            this.tap.Controls.Add(this.btnStopCheck);
            this.tap.Controls.Add(this.groupBox3);
            this.tap.Controls.Add(this.groupBox2);
            this.tap.Controls.Add(this.btnCheck);
            this.tap.Location = new System.Drawing.Point(4, 22);
            this.tap.Name = "tap";
            this.tap.Padding = new System.Windows.Forms.Padding(3);
            this.tap.Size = new System.Drawing.Size(962, 143);
            this.tap.TabIndex = 1;
            this.tap.Text = "Checker";
            this.tap.UseVisualStyleBackColor = true;
            // 
            // btnStopCheck
            // 
            this.btnStopCheck.Location = new System.Drawing.Point(846, 78);
            this.btnStopCheck.Name = "btnStopCheck";
            this.btnStopCheck.Size = new System.Drawing.Size(107, 28);
            this.btnStopCheck.TabIndex = 11;
            this.btnStopCheck.Text = "Stop";
            this.btnStopCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbCustom);
            this.groupBox3.Controls.Add(this.tbCustom);
            this.groupBox3.Location = new System.Drawing.Point(301, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 100);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Custom URL Check";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "use this option to test connection with a specific website\r\ne.g. reddit.com, nike" +
    ".com, google.com";
            // 
            // cbCustom
            // 
            this.cbCustom.AutoSize = true;
            this.cbCustom.Location = new System.Drawing.Point(16, 28);
            this.cbCustom.Name = "cbCustom";
            this.cbCustom.Size = new System.Drawing.Size(70, 17);
            this.cbCustom.TabIndex = 7;
            this.cbCustom.Text = "Custom";
            this.cbCustom.UseVisualStyleBackColor = true;
            // 
            // tbCustom
            // 
            this.tbCustom.Location = new System.Drawing.Point(92, 26);
            this.tbCustom.Name = "tbCustom";
            this.tbCustom.Size = new System.Drawing.Size(165, 21);
            this.tbCustom.TabIndex = 8;
            this.tbCustom.Text = "https://reddit.com";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSSL);
            this.groupBox2.Controls.Add(this.tbSSL);
            this.groupBox2.Location = new System.Drawing.Point(17, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Misc";
            // 
            // cbSSL
            // 
            this.cbSSL.AutoSize = true;
            this.cbSSL.Location = new System.Drawing.Point(16, 28);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(88, 17);
            this.cbSSL.TabIndex = 7;
            this.cbSSL.Text = "SSL Check";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // tbSSL
            // 
            this.tbSSL.Location = new System.Drawing.Point(105, 26);
            this.tbSSL.Name = "tbSSL";
            this.tbSSL.Size = new System.Drawing.Size(165, 21);
            this.tbSSL.TabIndex = 8;
            this.tbSSL.Text = "https://google.com";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(846, 37);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(107, 28);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.btnSaveAll);
            this.tabPage2.Controls.Add(this.btnSaveC);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(962, 143);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbCustomURLCheck);
            this.groupBox6.Controls.Add(this.cbSSLCheck);
            this.groupBox6.Controls.Add(this.numPing);
            this.groupBox6.Controls.Add(this.cbPingCheck);
            this.groupBox6.Location = new System.Drawing.Point(260, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(239, 119);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Misc";
            // 
            // cbCustomURLCheck
            // 
            this.cbCustomURLCheck.AutoSize = true;
            this.cbCustomURLCheck.Location = new System.Drawing.Point(18, 83);
            this.cbCustomURLCheck.Name = "cbCustomURLCheck";
            this.cbCustomURLCheck.Size = new System.Drawing.Size(140, 17);
            this.cbCustomURLCheck.TabIndex = 3;
            this.cbCustomURLCheck.Text = "Custom URL Passed";
            this.cbCustomURLCheck.UseVisualStyleBackColor = true;
            // 
            // cbSSLCheck
            // 
            this.cbSSLCheck.AutoSize = true;
            this.cbSSLCheck.Location = new System.Drawing.Point(18, 51);
            this.cbSSLCheck.Name = "cbSSLCheck";
            this.cbSSLCheck.Size = new System.Drawing.Size(92, 17);
            this.cbSSLCheck.TabIndex = 2;
            this.cbSSLCheck.Text = "SSL Passed";
            this.cbSSLCheck.UseVisualStyleBackColor = true;
            // 
            // numPing
            // 
            this.numPing.Location = new System.Drawing.Point(127, 20);
            this.numPing.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numPing.Name = "numPing";
            this.numPing.Size = new System.Drawing.Size(97, 21);
            this.numPing.TabIndex = 1;
            // 
            // cbPingCheck
            // 
            this.cbPingCheck.AutoSize = true;
            this.cbPingCheck.Location = new System.Drawing.Point(18, 21);
            this.cbPingCheck.Name = "cbPingCheck";
            this.cbPingCheck.Size = new System.Drawing.Size(103, 17);
            this.cbPingCheck.TabIndex = 0;
            this.cbPingCheck.Text = "Ping (ms) <=";
            this.cbPingCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTransCheck);
            this.groupBox5.Controls.Add(this.cbAnonCheck);
            this.groupBox5.Controls.Add(this.cbEliteCheck);
            this.groupBox5.Controls.Add(this.cbHighEliteCheck);
            this.groupBox5.Location = new System.Drawing.Point(16, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(228, 119);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Anonymity";
            // 
            // cbTransCheck
            // 
            this.cbTransCheck.AutoSize = true;
            this.cbTransCheck.Location = new System.Drawing.Point(110, 66);
            this.cbTransCheck.Name = "cbTransCheck";
            this.cbTransCheck.Size = new System.Drawing.Size(94, 17);
            this.cbTransCheck.TabIndex = 3;
            this.cbTransCheck.Text = "Transparent";
            this.cbTransCheck.UseVisualStyleBackColor = true;
            // 
            // cbAnonCheck
            // 
            this.cbAnonCheck.AutoSize = true;
            this.cbAnonCheck.Location = new System.Drawing.Point(110, 43);
            this.cbAnonCheck.Name = "cbAnonCheck";
            this.cbAnonCheck.Size = new System.Drawing.Size(93, 17);
            this.cbAnonCheck.TabIndex = 2;
            this.cbAnonCheck.Text = "Anonymous";
            this.cbAnonCheck.UseVisualStyleBackColor = true;
            // 
            // cbEliteCheck
            // 
            this.cbEliteCheck.AutoSize = true;
            this.cbEliteCheck.Location = new System.Drawing.Point(25, 66);
            this.cbEliteCheck.Name = "cbEliteCheck";
            this.cbEliteCheck.Size = new System.Drawing.Size(50, 17);
            this.cbEliteCheck.TabIndex = 1;
            this.cbEliteCheck.Text = "Elite";
            this.cbEliteCheck.UseVisualStyleBackColor = true;
            // 
            // cbHighEliteCheck
            // 
            this.cbHighEliteCheck.AutoSize = true;
            this.cbHighEliteCheck.Location = new System.Drawing.Point(25, 43);
            this.cbHighEliteCheck.Name = "cbHighEliteCheck";
            this.cbHighEliteCheck.Size = new System.Drawing.Size(79, 17);
            this.cbHighEliteCheck.TabIndex = 0;
            this.cbHighEliteCheck.Text = "High Elite";
            this.cbHighEliteCheck.UseVisualStyleBackColor = true;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(829, 78);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(124, 28);
            this.btnSaveAll.TabIndex = 13;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnSaveC
            // 
            this.btnSaveC.Location = new System.Drawing.Point(829, 37);
            this.btnSaveC.Name = "btnSaveC";
            this.btnSaveC.Size = new System.Drawing.Size(124, 28);
            this.btnSaveC.TabIndex = 12;
            this.btnSaveC.Text = "Save by Criteria";
            this.btnSaveC.UseVisualStyleBackColor = true;
            this.btnSaveC.Click += new System.EventHandler(this.btnSaveC_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cmsProxies
            // 
            this.cmsProxies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.importProxiesToolStripMenuItem,
            this.importProxiesFromClipboardToolStripMenuItem,
            this.toolStripSeparator2,
            this.removeAllProxiesToolStripMenuItem});
            this.cmsProxies.Name = "cmsProxies";
            this.cmsProxies.Size = new System.Drawing.Size(235, 104);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // importProxiesToolStripMenuItem
            // 
            this.importProxiesToolStripMenuItem.Name = "importProxiesToolStripMenuItem";
            this.importProxiesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.importProxiesToolStripMenuItem.Text = "Import Proxies...";
            this.importProxiesToolStripMenuItem.Click += new System.EventHandler(this.importProxiesToolStripMenuItem_Click);
            // 
            // importProxiesFromClipboardToolStripMenuItem
            // 
            this.importProxiesFromClipboardToolStripMenuItem.Name = "importProxiesFromClipboardToolStripMenuItem";
            this.importProxiesFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.importProxiesFromClipboardToolStripMenuItem.Text = "Import Proxies from Clipboard";
            this.importProxiesFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.importProxiesFromClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // removeAllProxiesToolStripMenuItem
            // 
            this.removeAllProxiesToolStripMenuItem.Name = "removeAllProxiesToolStripMenuItem";
            this.removeAllProxiesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.removeAllProxiesToolStripMenuItem.Text = "Clear All Proxies";
            this.removeAllProxiesToolStripMenuItem.Click += new System.EventHandler(this.removeAllProxiesToolStripMenuItem_Click);
            // 
            // lvProxies
            // 
            this.lvProxies.AllowColumnResize = true;
            this.lvProxies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProxies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvProxies.ContextMenuStrip = this.cmsProxies;
            this.lvProxies.FullRowSelect = true;
            this.lvProxies.Location = new System.Drawing.Point(7, 198);
            this.lvProxies.Name = "lvProxies";
            this.lvProxies.Size = new System.Drawing.Size(967, 263);
            this.lvProxies.TabIndex = 0;
            this.lvProxies.UseCompatibleStateImageBehavior = false;
            this.lvProxies.View = System.Windows.Forms.View.Details;
            this.lvProxies.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProxies_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 67;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Proxy";
            this.columnHeader2.Width = 154;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Anonymity";
            this.columnHeader3.Width = 188;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Country";
            this.columnHeader4.Width = 245;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ping";
            this.columnHeader5.Width = 84;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "SSL";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "cURL";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 488);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvProxies);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(997, 527);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProxEZ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tap.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPing)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsProxies.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ListViewNF lvProxies;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripStatusLabel lStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tap;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.Button btnSourceBrowse;
        private System.Windows.Forms.TextBox tbCustomSources;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbProxEZ;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.CheckBox cbSSL;
        private System.Windows.Forms.TextBox tbSSL;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip cmsProxies;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importProxiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importProxiesFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem removeAllProxiesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnStopCheck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbCustom;
        private System.Windows.Forms.TextBox tbCustom;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numLimit;
        private System.Windows.Forms.CheckBox cbLimit;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnSaveC;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbHighEliteCheck;
        private System.Windows.Forms.CheckBox cbEliteCheck;
        private System.Windows.Forms.CheckBox cbTransCheck;
        private System.Windows.Forms.CheckBox cbAnonCheck;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown numPing;
        private System.Windows.Forms.CheckBox cbPingCheck;
        private System.Windows.Forms.CheckBox cbSSLCheck;
        private System.Windows.Forms.CheckBox cbCustomURLCheck;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}