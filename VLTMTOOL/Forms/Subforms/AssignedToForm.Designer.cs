namespace VLTMTool.Forms.Subforms
{
    partial class AssignedToForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignedToForm));
            this.panelAssignedTo = new System.Windows.Forms.Panel();
            this.inputAssignedTo = new C1.Win.C1List.C1Combo();
            this.bsTechnicals = new System.Windows.Forms.BindingSource(this.components);
            this.labelAssignTo = new C1.Win.C1Input.C1Label();
            this.buttonCancel = new C1.Win.C1Input.C1Button();
            this.buttonAccept = new C1.Win.C1Input.C1Button();
            this.panelAssignedTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputAssignedTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTechnicals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelAssignTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAccept)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAssignedTo
            // 
            this.panelAssignedTo.Controls.Add(this.buttonCancel);
            this.panelAssignedTo.Controls.Add(this.buttonAccept);
            this.panelAssignedTo.Controls.Add(this.labelAssignTo);
            this.panelAssignedTo.Controls.Add(this.inputAssignedTo);
            this.panelAssignedTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAssignedTo.Location = new System.Drawing.Point(0, 0);
            this.panelAssignedTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelAssignedTo.Name = "panelAssignedTo";
            this.panelAssignedTo.Size = new System.Drawing.Size(361, 109);
            this.panelAssignedTo.TabIndex = 0;
            // 
            // inputAssignedTo
            // 
            this.inputAssignedTo.AllowColSelect = true;
            this.inputAssignedTo.AutoSize = false;
            this.inputAssignedTo.Caption = "";
            this.inputAssignedTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inputAssignedTo.ColumnHeaders = false;
            this.inputAssignedTo.ColumnWidth = 100;
            this.inputAssignedTo.ContentHeight = 26;
            this.inputAssignedTo.DataSource = this.bsTechnicals;
            this.inputAssignedTo.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.inputAssignedTo.DisplayMember = "TechnicalName";
            this.inputAssignedTo.ExtendRightColumn = true;
            this.inputAssignedTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputAssignedTo.Images.Add(((System.Drawing.Image)(resources.GetObject("inputAssignedTo.Images"))));
            this.inputAssignedTo.Location = new System.Drawing.Point(13, 29);
            this.inputAssignedTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputAssignedTo.MatchEntryTimeout = ((long)(2000));
            this.inputAssignedTo.MaxDropDownItems = ((short)(5));
            this.inputAssignedTo.MaxLength = 32767;
            this.inputAssignedTo.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.inputAssignedTo.Name = "inputAssignedTo";
            this.inputAssignedTo.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.inputAssignedTo.Size = new System.Drawing.Size(327, 32);
            this.inputAssignedTo.TabIndex = 8;
            this.inputAssignedTo.ValueMember = "IdTechnical";
            this.inputAssignedTo.PropBag = resources.GetString("inputAssignedTo.PropBag");
            // 
            // bsTechnicals
            // 
            this.bsTechnicals.DataSource = typeof(VLTMTool.ViewModel.VMTechnicalUsers);
            // 
            // labelAssignTo
            // 
            this.labelAssignTo.AutoSize = true;
            this.labelAssignTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelAssignTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelAssignTo.ForeColor = System.Drawing.Color.Navy;
            this.labelAssignTo.Location = new System.Drawing.Point(13, 11);
            this.labelAssignTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAssignTo.Name = "labelAssignTo";
            this.labelAssignTo.Size = new System.Drawing.Size(223, 15);
            this.labelAssignTo.TabIndex = 9;
            this.labelAssignTo.Tag = null;
            this.labelAssignTo.Text = "Select Technical for assigned to the ticket";
            this.labelAssignTo.TextDetached = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Navy;
            this.buttonCancel.Image = global::VLTMTool.Properties.Resources.iconfinder_x_16x16;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(234, 74);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonCancel.Size = new System.Drawing.Size(106, 23);
            this.buttonCancel.TabIndex = 128;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.buttonCancel.Click += new System.EventHandler(this.c1ButtonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.ForeColor = System.Drawing.Color.Navy;
            this.buttonAccept.Image = global::VLTMTool.Properties.Resources.iconfinder_check_16x16;
            this.buttonAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccept.Location = new System.Drawing.Point(122, 74);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonAccept.Size = new System.Drawing.Size(106, 23);
            this.buttonAccept.TabIndex = 127;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.buttonAccept.Click += new System.EventHandler(this.c1ButtonAccept_Click);
            // 
            // AssignedToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 109);
            this.Controls.Add(this.panelAssignedTo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 318);
            this.MinimizeBox = false;
            this.Name = "AssignedToForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assigned To";
            this.panelAssignedTo.ResumeLayout(false);
            this.panelAssignedTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputAssignedTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTechnicals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelAssignTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAccept)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAssignedTo;
        private System.Windows.Forms.BindingSource bsTechnicals;
        private C1.Win.C1List.C1Combo inputAssignedTo;
        private C1.Win.C1Input.C1Label labelAssignTo;
        private C1.Win.C1Input.C1Button buttonCancel;
        private C1.Win.C1Input.C1Button buttonAccept;
    }
}