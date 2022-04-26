using VLTMTool.ViewModel;

namespace VLTMTool.Forms
{
    partial class TicketsGestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsGestion));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.buttonClear = new C1.Win.C1Input.C1Button();
            this.labelTicketNumber = new System.Windows.Forms.Label();
            this.buttonSearch = new C1.Win.C1Input.C1Button();
            this.labelApplication = new System.Windows.Forms.Label();
            this.inputStatus = new C1.Win.C1List.C1Combo();
            this.bsVMTicketStatus = new System.Windows.Forms.BindingSource(this.components);
            this.labelAppVersion = new System.Windows.Forms.Label();
            this.inputPriority = new C1.Win.C1List.C1Combo();
            this.labelAppModule = new System.Windows.Forms.Label();
            this.inputType = new C1.Win.C1List.C1Combo();
            this.bsVMTicketTypes = new System.Windows.Forms.BindingSource(this.components);
            this.labelType = new System.Windows.Forms.Label();
            this.inputAppModule = new C1.Win.C1List.C1Combo();
            this.bsVMtempvTHORApplicationsModules = new System.Windows.Forms.BindingSource(this.components);
            this.labelPriority = new System.Windows.Forms.Label();
            this.inputApplication = new C1.Win.C1List.C1Combo();
            this.bsVMvTHORApplications = new System.Windows.Forms.BindingSource(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.inputCreationUser = new C1.Win.C1Input.C1TextBox();
            this.labelCreationUser = new System.Windows.Forms.Label();
            this.inputAppVersion = new C1.Win.C1Input.C1TextBox();
            this.labelCreationDateFrom = new System.Windows.Forms.Label();
            this.inputTicketNumber = new C1.Win.C1Input.C1TextBox();
            this.labelCreationDateTo = new System.Windows.Forms.Label();
            this.inputCurrStDateTo = new C1.Win.Calendar.C1DateEdit();
            this.labelCurrStDateFrom = new System.Windows.Forms.Label();
            this.inputCurrStDateFrom = new C1.Win.Calendar.C1DateEdit();
            this.labelCurrStDateTo = new System.Windows.Forms.Label();
            this.inputCreationDateTo = new C1.Win.Calendar.C1DateEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.inputCreationDateFrom = new C1.Win.Calendar.C1DateEdit();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dataGridViewTickets = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bsFiltersTickets = new System.Windows.Forms.BindingSource(this.components);
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnDeleteTicket = new C1.Win.C1Input.C1Button();
            this.btnAddTicket = new C1.Win.C1Input.C1Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMTicketStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMTicketTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAppModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMtempvTHORApplicationsModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMvTHORApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCreationUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAppVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTicketNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCurrStDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCurrStDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCreationDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCreationDateFrom)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiltersTickets)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelFilters, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1282, 647);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelFilters
            // 
            this.panelFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilters.Controls.Add(this.gbSearch);
            this.panelFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFilters.Location = new System.Drawing.Point(4, 3);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1274, 128);
            this.panelFilters.TabIndex = 0;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.buttonClear);
            this.gbSearch.Controls.Add(this.labelTicketNumber);
            this.gbSearch.Controls.Add(this.buttonSearch);
            this.gbSearch.Controls.Add(this.labelApplication);
            this.gbSearch.Controls.Add(this.inputStatus);
            this.gbSearch.Controls.Add(this.labelAppVersion);
            this.gbSearch.Controls.Add(this.inputPriority);
            this.gbSearch.Controls.Add(this.labelAppModule);
            this.gbSearch.Controls.Add(this.inputType);
            this.gbSearch.Controls.Add(this.labelType);
            this.gbSearch.Controls.Add(this.inputAppModule);
            this.gbSearch.Controls.Add(this.labelPriority);
            this.gbSearch.Controls.Add(this.inputApplication);
            this.gbSearch.Controls.Add(this.labelStatus);
            this.gbSearch.Controls.Add(this.inputCreationUser);
            this.gbSearch.Controls.Add(this.labelCreationUser);
            this.gbSearch.Controls.Add(this.inputAppVersion);
            this.gbSearch.Controls.Add(this.labelCreationDateFrom);
            this.gbSearch.Controls.Add(this.inputTicketNumber);
            this.gbSearch.Controls.Add(this.labelCreationDateTo);
            this.gbSearch.Controls.Add(this.inputCurrStDateTo);
            this.gbSearch.Controls.Add(this.labelCurrStDateFrom);
            this.gbSearch.Controls.Add(this.inputCurrStDateFrom);
            this.gbSearch.Controls.Add(this.labelCurrStDateTo);
            this.gbSearch.Controls.Add(this.inputCreationDateTo);
            this.gbSearch.Controls.Add(this.button1);
            this.gbSearch.Controls.Add(this.inputCreationDateFrom);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.ForeColor = System.Drawing.Color.Navy;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1274, 128);
            this.gbSearch.TabIndex = 126;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.Navy;
            this.buttonClear.Image = global::VLTMTool.Properties.Resources.iconfinder_pencil_16x16;
            this.buttonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClear.Location = new System.Drawing.Point(1118, 86);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonClear.Size = new System.Drawing.Size(106, 23);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Clear Filter";
            this.buttonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelTicketNumber
            // 
            this.labelTicketNumber.AutoSize = true;
            this.labelTicketNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketNumber.ForeColor = System.Drawing.Color.Navy;
            this.labelTicketNumber.Location = new System.Drawing.Point(9, 25);
            this.labelTicketNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTicketNumber.Name = "labelTicketNumber";
            this.labelTicketNumber.Size = new System.Drawing.Size(94, 15);
            this.labelTicketNumber.TabIndex = 0;
            this.labelTicketNumber.Text = "TICKET NUMBER";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.Navy;
            this.buttonSearch.Image = global::VLTMTool.Properties.Resources.iconfinder_search_16x16;
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(1118, 41);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonSearch.Size = new System.Drawing.Size(106, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Apply Filter";
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelApplication
            // 
            this.labelApplication.AutoSize = true;
            this.labelApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApplication.ForeColor = System.Drawing.Color.Navy;
            this.labelApplication.Location = new System.Drawing.Point(149, 25);
            this.labelApplication.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApplication.Name = "labelApplication";
            this.labelApplication.Size = new System.Drawing.Size(80, 15);
            this.labelApplication.TabIndex = 1;
            this.labelApplication.Text = "APPLICATION";
            // 
            // inputStatus
            // 
            this.inputStatus.AllowColSelect = true;
            this.inputStatus.AlternatingRows = true;
            this.inputStatus.AutoCompletion = true;
            this.inputStatus.AutoSize = false;
            this.inputStatus.Caption = "";
            this.inputStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputStatus.ColumnHeaders = false;
            this.inputStatus.ColumnWidth = 100;
            this.inputStatus.ContentHeight = 17;
            this.inputStatus.DataSource = this.bsVMTicketStatus;
            this.inputStatus.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.inputStatus.DisplayMember = "StatusName";
            this.inputStatus.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown;
            this.inputStatus.DropDownWidth = 190;
            this.inputStatus.EditorBackColor = System.Drawing.SystemColors.Window;
            this.inputStatus.ExtendRightColumn = true;
            this.inputStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("inputStatus.Images"))));
            this.inputStatus.Location = new System.Drawing.Point(818, 41);
            this.inputStatus.MatchEntryTimeout = ((long)(2000));
            this.inputStatus.MaxDropDownItems = ((short)(5));
            this.inputStatus.MaxLength = 100;
            this.inputStatus.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.inputStatus.Name = "inputStatus";
            this.inputStatus.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.inputStatus.Size = new System.Drawing.Size(129, 23);
            this.inputStatus.TabIndex = 8;
            this.inputStatus.ValueMember = "IdStatus";
            this.inputStatus.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Silver;
            this.inputStatus.PropBag = resources.GetString("inputStatus.PropBag");
            // 
            // bsVMTicketStatus
            // 
            this.bsVMTicketStatus.DataSource = typeof(VLTMTool.ViewModel.VMTicketStatus);
            // 
            // labelAppVersion
            // 
            this.labelAppVersion.AutoSize = true;
            this.labelAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppVersion.ForeColor = System.Drawing.Color.Navy;
            this.labelAppVersion.Location = new System.Drawing.Point(317, 25);
            this.labelAppVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppVersion.Name = "labelAppVersion";
            this.labelAppVersion.Size = new System.Drawing.Size(79, 15);
            this.labelAppVersion.TabIndex = 2;
            this.labelAppVersion.Text = "APP VERSION";
            // 
            // inputPriority
            // 
            this.inputPriority.AllowColSelect = true;
            this.inputPriority.AlternatingRows = true;
            this.inputPriority.AutoCompletion = true;
            this.inputPriority.AutoSize = false;
            this.inputPriority.Caption = "";
            this.inputPriority.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputPriority.ColumnHeaders = false;
            this.inputPriority.ContentHeight = 17;
            this.inputPriority.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.inputPriority.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown;
            this.inputPriority.DropDownWidth = 190;
            this.inputPriority.EditorBackColor = System.Drawing.SystemColors.Window;
            this.inputPriority.ExtendRightColumn = true;
            this.inputPriority.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputPriority.Images.Add(((System.Drawing.Image)(resources.GetObject("inputPriority.Images"))));
            this.inputPriority.Location = new System.Drawing.Point(737, 41);
            this.inputPriority.MatchEntryTimeout = ((long)(2000));
            this.inputPriority.MaxDropDownItems = ((short)(5));
            this.inputPriority.MaxLength = 100;
            this.inputPriority.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.inputPriority.Name = "inputPriority";
            this.inputPriority.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.inputPriority.Size = new System.Drawing.Size(74, 23);
            this.inputPriority.TabIndex = 7;
            this.inputPriority.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Silver;
            this.inputPriority.PropBag = resources.GetString("inputPriority.PropBag");
            // 
            // labelAppModule
            // 
            this.labelAppModule.AutoSize = true;
            this.labelAppModule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppModule.ForeColor = System.Drawing.Color.Navy;
            this.labelAppModule.Location = new System.Drawing.Point(451, 25);
            this.labelAppModule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppModule.Name = "labelAppModule";
            this.labelAppModule.Size = new System.Drawing.Size(80, 15);
            this.labelAppModule.TabIndex = 3;
            this.labelAppModule.Text = "APP MODULE";
            // 
            // inputType
            // 
            this.inputType.AllowColSelect = true;
            this.inputType.AlternatingRows = true;
            this.inputType.AutoCompletion = true;
            this.inputType.AutoSize = false;
            this.inputType.Caption = "";
            this.inputType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputType.ColumnHeaders = false;
            this.inputType.ColumnWidth = 100;
            this.inputType.ContentHeight = 17;
            this.inputType.DataSource = this.bsVMTicketTypes;
            this.inputType.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.inputType.DisplayMember = "TypeName";
            this.inputType.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown;
            this.inputType.DropDownWidth = 190;
            this.inputType.EditorBackColor = System.Drawing.SystemColors.Window;
            this.inputType.ExtendRightColumn = true;
            this.inputType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputType.Images.Add(((System.Drawing.Image)(resources.GetObject("inputType.Images"))));
            this.inputType.Location = new System.Drawing.Point(615, 41);
            this.inputType.MatchEntryTimeout = ((long)(2000));
            this.inputType.MaxDropDownItems = ((short)(5));
            this.inputType.MaxLength = 100;
            this.inputType.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.inputType.Name = "inputType";
            this.inputType.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.inputType.Size = new System.Drawing.Size(114, 23);
            this.inputType.TabIndex = 6;
            this.inputType.ValueMember = "IdType";
            this.inputType.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Silver;
            this.inputType.PropBag = resources.GetString("inputType.PropBag");
            // 
            // bsVMTicketTypes
            // 
            this.bsVMTicketTypes.DataSource = typeof(VLTMTool.ViewModel.VMTicketTypes);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.Navy;
            this.labelType.Location = new System.Drawing.Point(612, 25);
            this.labelType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(33, 15);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "TYPE";
            // 
            // inputAppModule
            // 
            this.inputAppModule.AllowColSelect = true;
            this.inputAppModule.AlternatingRows = true;
            this.inputAppModule.AutoCompletion = true;
            this.inputAppModule.AutoSize = false;
            this.inputAppModule.Caption = "";
            this.inputAppModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputAppModule.ColumnHeaders = false;
            this.inputAppModule.ColumnWidth = 100;
            this.inputAppModule.ContentHeight = 17;
            this.inputAppModule.DataSource = this.bsVMtempvTHORApplicationsModules;
            this.inputAppModule.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.inputAppModule.DisplayMember = "AppModuleName";
            this.inputAppModule.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown;
            this.inputAppModule.DropDownWidth = 190;
            this.inputAppModule.EditorBackColor = System.Drawing.SystemColors.Window;
            this.inputAppModule.ExtendRightColumn = true;
            this.inputAppModule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputAppModule.Images.Add(((System.Drawing.Image)(resources.GetObject("inputAppModule.Images"))));
            this.inputAppModule.Location = new System.Drawing.Point(454, 41);
            this.inputAppModule.MatchEntryTimeout = ((long)(2000));
            this.inputAppModule.MaxDropDownItems = ((short)(5));
            this.inputAppModule.MaxLength = 100;
            this.inputAppModule.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.inputAppModule.Name = "inputAppModule";
            this.inputAppModule.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.inputAppModule.Size = new System.Drawing.Size(153, 23);
            this.inputAppModule.TabIndex = 5;
            this.inputAppModule.ValueMember = "AppModuleCode";
            this.inputAppModule.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Silver;
            this.inputAppModule.PropBag = resources.GetString("inputAppModule.PropBag");
            // 
            // bsVMtempvTHORApplicationsModules
            // 
            this.bsVMtempvTHORApplicationsModules.DataSource = typeof(VLTMTool.ViewModel.VMTHORApplicationsModules);
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriority.ForeColor = System.Drawing.Color.Navy;
            this.labelPriority.Location = new System.Drawing.Point(733, 25);
            this.labelPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(56, 15);
            this.labelPriority.TabIndex = 5;
            this.labelPriority.Text = "PRIORITY";
            // 
            // inputApplication
            // 
            this.inputApplication.AllowColSelect = true;
            this.inputApplication.AlternatingRows = true;
            this.inputApplication.AutoCompletion = true;
            this.inputApplication.AutoSize = false;
            this.inputApplication.Caption = "";
            this.inputApplication.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputApplication.ColumnHeaders = false;
            this.inputApplication.ColumnWidth = 100;
            this.inputApplication.ContentHeight = 17;
            this.inputApplication.DataSource = this.bsVMvTHORApplications;
            this.inputApplication.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.inputApplication.DisplayMember = "AppName";
            this.inputApplication.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown;
            this.inputApplication.DropDownWidth = 190;
            this.inputApplication.EditorBackColor = System.Drawing.SystemColors.Window;
            this.inputApplication.ExtendRightColumn = true;
            this.inputApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputApplication.Images.Add(((System.Drawing.Image)(resources.GetObject("inputApplication.Images"))));
            this.inputApplication.Location = new System.Drawing.Point(152, 41);
            this.inputApplication.MatchEntryTimeout = ((long)(2000));
            this.inputApplication.MaxDropDownItems = ((short)(5));
            this.inputApplication.MaxLength = 100;
            this.inputApplication.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.inputApplication.Name = "inputApplication";
            this.inputApplication.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.inputApplication.Size = new System.Drawing.Size(160, 23);
            this.inputApplication.TabIndex = 3;
            this.inputApplication.ValueMember = "AppCode";
            this.inputApplication.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Silver;
            this.inputApplication.PropBag = resources.GetString("inputApplication.PropBag");
            // 
            // bsVMvTHORApplications
            // 
            this.bsVMvTHORApplications.DataSource = typeof(VLTMTool.ViewModel.VMTHORApplications);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.Navy;
            this.labelStatus.Location = new System.Drawing.Point(815, 25);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(45, 15);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "STATUS";
            // 
            // inputCreationUser
            // 
            this.inputCreationUser.AutoSize = false;
            this.inputCreationUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputCreationUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputCreationUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputCreationUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputCreationUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCreationUser.Location = new System.Drawing.Point(12, 86);
            this.inputCreationUser.Name = "inputCreationUser";
            this.inputCreationUser.Size = new System.Drawing.Size(129, 23);
            this.inputCreationUser.TabIndex = 9;
            this.inputCreationUser.Tag = null;
            this.inputCreationUser.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCreationUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // labelCreationUser
            // 
            this.labelCreationUser.AutoSize = true;
            this.labelCreationUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreationUser.ForeColor = System.Drawing.Color.Navy;
            this.labelCreationUser.Location = new System.Drawing.Point(9, 68);
            this.labelCreationUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreationUser.Name = "labelCreationUser";
            this.labelCreationUser.Size = new System.Drawing.Size(92, 15);
            this.labelCreationUser.TabIndex = 7;
            this.labelCreationUser.Text = "CREATION USER";
            // 
            // inputAppVersion
            // 
            this.inputAppVersion.AutoSize = false;
            this.inputAppVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputAppVersion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputAppVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputAppVersion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputAppVersion.Location = new System.Drawing.Point(320, 41);
            this.inputAppVersion.Name = "inputAppVersion";
            this.inputAppVersion.Size = new System.Drawing.Size(127, 23);
            this.inputAppVersion.TabIndex = 4;
            this.inputAppVersion.Tag = null;
            this.inputAppVersion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputAppVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // labelCreationDateFrom
            // 
            this.labelCreationDateFrom.AutoSize = true;
            this.labelCreationDateFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreationDateFrom.ForeColor = System.Drawing.Color.Navy;
            this.labelCreationDateFrom.Location = new System.Drawing.Point(149, 68);
            this.labelCreationDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreationDateFrom.Name = "labelCreationDateFrom";
            this.labelCreationDateFrom.Size = new System.Drawing.Size(128, 15);
            this.labelCreationDateFrom.TabIndex = 8;
            this.labelCreationDateFrom.Text = "CREATION DATE FROM";
            // 
            // inputTicketNumber
            // 
            this.inputTicketNumber.AutoSize = false;
            this.inputTicketNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputTicketNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputTicketNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTicketNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputTicketNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTicketNumber.Location = new System.Drawing.Point(12, 41);
            this.inputTicketNumber.Name = "inputTicketNumber";
            this.inputTicketNumber.Size = new System.Drawing.Size(129, 23);
            this.inputTicketNumber.TabIndex = 2;
            this.inputTicketNumber.Tag = null;
            this.inputTicketNumber.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputTicketNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // labelCreationDateTo
            // 
            this.labelCreationDateTo.AutoSize = true;
            this.labelCreationDateTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreationDateTo.ForeColor = System.Drawing.Color.Navy;
            this.labelCreationDateTo.Location = new System.Drawing.Point(317, 68);
            this.labelCreationDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreationDateTo.Name = "labelCreationDateTo";
            this.labelCreationDateTo.Size = new System.Drawing.Size(109, 15);
            this.labelCreationDateTo.TabIndex = 9;
            this.labelCreationDateTo.Text = "CREATION DATE TO";
            // 
            // inputCurrStDateTo
            // 
            this.inputCurrStDateTo.AutoSize = false;
            this.inputCurrStDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputCurrStDateTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputCurrStDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputCurrStDateTo.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.inputCurrStDateTo.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCurrStDateTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputCurrStDateTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCurrStDateTo.GapHeight = 0;
            this.inputCurrStDateTo.ImagePadding = new System.Windows.Forms.Padding(0);
            this.inputCurrStDateTo.Location = new System.Drawing.Point(659, 86);
            this.inputCurrStDateTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputCurrStDateTo.Name = "inputCurrStDateTo";
            this.inputCurrStDateTo.Size = new System.Drawing.Size(161, 23);
            this.inputCurrStDateTo.TabIndex = 13;
            this.inputCurrStDateTo.Tag = null;
            this.inputCurrStDateTo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCurrStDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // labelCurrStDateFrom
            // 
            this.labelCurrStDateFrom.AutoSize = true;
            this.labelCurrStDateFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrStDateFrom.ForeColor = System.Drawing.Color.Navy;
            this.labelCurrStDateFrom.Location = new System.Drawing.Point(485, 66);
            this.labelCurrStDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrStDateFrom.Name = "labelCurrStDateFrom";
            this.labelCurrStDateFrom.Size = new System.Drawing.Size(124, 15);
            this.labelCurrStDateFrom.TabIndex = 10;
            this.labelCurrStDateFrom.Text = "CURR. ST. DATE FROM";
            // 
            // inputCurrStDateFrom
            // 
            this.inputCurrStDateFrom.AutoSize = false;
            this.inputCurrStDateFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputCurrStDateFrom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputCurrStDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputCurrStDateFrom.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.inputCurrStDateFrom.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCurrStDateFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputCurrStDateFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCurrStDateFrom.GapHeight = 0;
            this.inputCurrStDateFrom.ImagePadding = new System.Windows.Forms.Padding(0);
            this.inputCurrStDateFrom.Location = new System.Drawing.Point(488, 86);
            this.inputCurrStDateFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputCurrStDateFrom.Name = "inputCurrStDateFrom";
            this.inputCurrStDateFrom.Size = new System.Drawing.Size(161, 23);
            this.inputCurrStDateFrom.TabIndex = 12;
            this.inputCurrStDateFrom.Tag = null;
            this.inputCurrStDateFrom.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCurrStDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // labelCurrStDateTo
            // 
            this.labelCurrStDateTo.AutoSize = true;
            this.labelCurrStDateTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrStDateTo.ForeColor = System.Drawing.Color.Navy;
            this.labelCurrStDateTo.Location = new System.Drawing.Point(656, 69);
            this.labelCurrStDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrStDateTo.Name = "labelCurrStDateTo";
            this.labelCurrStDateTo.Size = new System.Drawing.Size(105, 15);
            this.labelCurrStDateTo.TabIndex = 11;
            this.labelCurrStDateTo.Text = "CURR. ST. DATE TO";
            // 
            // inputCreationDateTo
            // 
            this.inputCreationDateTo.AutoSize = false;
            this.inputCreationDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputCreationDateTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputCreationDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputCreationDateTo.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.inputCreationDateTo.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCreationDateTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputCreationDateTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCreationDateTo.GapHeight = 0;
            this.inputCreationDateTo.ImagePadding = new System.Windows.Forms.Padding(0);
            this.inputCreationDateTo.Location = new System.Drawing.Point(320, 86);
            this.inputCreationDateTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputCreationDateTo.Name = "inputCreationDateTo";
            this.inputCreationDateTo.Size = new System.Drawing.Size(161, 23);
            this.inputCreationDateTo.TabIndex = 11;
            this.inputCreationDateTo.Tag = null;
            this.inputCreationDateTo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCreationDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(920, 82);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 27);
            this.button1.TabIndex = 12;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // inputCreationDateFrom
            // 
            this.inputCreationDateFrom.AutoSize = false;
            this.inputCreationDateFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(236)))));
            this.inputCreationDateFrom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputCreationDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputCreationDateFrom.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.inputCreationDateFrom.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCreationDateFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputCreationDateFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCreationDateFrom.GapHeight = 0;
            this.inputCreationDateFrom.ImagePadding = new System.Windows.Forms.Padding(0);
            this.inputCreationDateFrom.Location = new System.Drawing.Point(152, 86);
            this.inputCreationDateFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputCreationDateFrom.Name = "inputCreationDateFrom";
            this.inputCreationDateFrom.Size = new System.Drawing.Size(161, 23);
            this.inputCreationDateFrom.TabIndex = 10;
            this.inputCreationDateFrom.Tag = null;
            this.inputCreationDateFrom.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.inputCreationDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTicketNumber_KeyDown);
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.Controls.Add(this.dataGridViewTickets);
            this.panelGrid.Location = new System.Drawing.Point(4, 138);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(29, 0, 29, 0);
            this.panelGrid.Size = new System.Drawing.Size(1274, 455);
            this.panelGrid.TabIndex = 1;
            // 
            // dataGridViewTickets
            // 
            this.dataGridViewTickets.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.dataGridViewTickets.AllowEditing = false;
            this.dataGridViewTickets.AllowFiltering = true;
            this.dataGridViewTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTickets.AutoGenerateColumns = false;
            this.dataGridViewTickets.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.dataGridViewTickets.ColumnInfo = resources.GetString("dataGridViewTickets.ColumnInfo");
            this.dataGridViewTickets.DataSource = this.bsFiltersTickets;
            this.dataGridViewTickets.ExtendLastCol = true;
            this.dataGridViewTickets.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.dataGridViewTickets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTickets.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.dataGridViewTickets.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.dataGridViewTickets.Location = new System.Drawing.Point(29, 3);
            this.dataGridViewTickets.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewTickets.Name = "dataGridViewTickets";
            this.dataGridViewTickets.Rows.Count = 1;
            this.dataGridViewTickets.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.dataGridViewTickets.Size = new System.Drawing.Size(1212, 447);
            this.dataGridViewTickets.StyleInfo = resources.GetString("dataGridViewTickets.StyleInfo");
            this.dataGridViewTickets.TabIndex = 1;
            this.dataGridViewTickets.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver;
            this.dataGridViewTickets.DoubleClick += new System.EventHandler(this.dataGridViewTickets_DoubleClick);
            // 
            // bsFiltersTickets
            // 
            this.bsFiltersTickets.DataSource = typeof(VLTMTool.ViewModel.VMvTickets);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnDeleteTicket);
            this.panelButtons.Controls.Add(this.btnAddTicket);
            this.panelButtons.Location = new System.Drawing.Point(4, 600);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1274, 44);
            this.panelButtons.TabIndex = 2;
            // 
            // btnDeleteTicket
            // 
            this.btnDeleteTicket.Enabled = false;
            this.btnDeleteTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTicket.ForeColor = System.Drawing.Color.Navy;
            this.btnDeleteTicket.Image = global::VLTMTool.Properties.Resources.Trash;
            this.btnDeleteTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteTicket.Location = new System.Drawing.Point(141, 12);
            this.btnDeleteTicket.Name = "btnDeleteTicket";
            this.btnDeleteTicket.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDeleteTicket.Size = new System.Drawing.Size(106, 23);
            this.btnDeleteTicket.TabIndex = 15;
            this.btnDeleteTicket.Text = "Delete";
            this.btnDeleteTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteTicket.UseVisualStyleBackColor = true;
            this.btnDeleteTicket.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.btnDeleteTicket.Click += new System.EventHandler(this.btnDeleteTicket_Click);
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTicket.ForeColor = System.Drawing.Color.Navy;
            this.btnAddTicket.Image = global::VLTMTool.Properties.Resources.iconfinder_document_16x16;
            this.btnAddTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTicket.Location = new System.Drawing.Point(29, 12);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAddTicket.Size = new System.Drawing.Size(106, 23);
            this.btnAddTicket.TabIndex = 14;
            this.btnAddTicket.Text = "Add Ticket";
            this.btnAddTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.btnAddTicket.Click += new System.EventHandler(this.buttonAddTicket_Click);
            // 
            // TicketsGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 647);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1298, 686);
            this.Name = "TicketsGestion";
            this.Text = "Tickets Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMTicketStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMTicketTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAppModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMtempvTHORApplicationsModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVMvTHORApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCreationUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAppVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTicketNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCurrStDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCurrStDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCreationDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCreationDateFrom)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiltersTickets)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label labelTicketNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCurrStDateTo;
        private System.Windows.Forms.Label labelCurrStDateFrom;
        private System.Windows.Forms.Label labelCreationDateTo;
        private System.Windows.Forms.Label labelCreationDateFrom;
        private System.Windows.Forms.Label labelCreationUser;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelAppModule;
        private System.Windows.Forms.Label labelAppVersion;
        private System.Windows.Forms.Label labelApplication;
        private System.Windows.Forms.BindingSource bsFiltersTickets;
        private C1.Win.Calendar.C1DateEdit inputCurrStDateTo;
        private C1.Win.Calendar.C1DateEdit inputCurrStDateFrom;
        private C1.Win.Calendar.C1DateEdit inputCreationDateTo;
        private C1.Win.Calendar.C1DateEdit inputCreationDateFrom;
        private C1.Win.C1FlexGrid.C1FlexGrid dataGridViewTickets;
        private C1.Win.C1Input.C1TextBox inputTicketNumber;
        private C1.Win.C1Input.C1TextBox inputCreationUser;
        private C1.Win.C1Input.C1TextBox inputAppVersion;
        private C1.Win.C1Input.C1Button buttonSearch;
        private C1.Win.C1List.C1Combo inputStatus;
        private C1.Win.C1List.C1Combo inputPriority;
        private C1.Win.C1List.C1Combo inputType;
        private C1.Win.C1List.C1Combo inputAppModule;
        private C1.Win.C1List.C1Combo inputApplication;
        private C1.Win.C1Input.C1Button buttonClear;
        private System.Windows.Forms.BindingSource bsVMtempvTHORApplicationsModules;
        private System.Windows.Forms.BindingSource bsVMvTHORApplications;
        private System.Windows.Forms.BindingSource bsVMTicketTypes;
        private System.Windows.Forms.BindingSource bsVMTicketStatus;
        private C1.Win.C1Input.C1Button btnDeleteTicket;
        private C1.Win.C1Input.C1Button btnAddTicket;
        private System.Windows.Forms.GroupBox gbSearch;
    }
}