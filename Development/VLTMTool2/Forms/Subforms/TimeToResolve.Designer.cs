namespace VLTMTool.Forms.Subforms
{
    partial class TimeToResolve
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
            this.inputVersionResolved = new C1.Win.C1Input.C1TextBox();
            this.inputUsedTime = new C1.Win.C1Input.C1TextBox();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.buttonCancel = new C1.Win.C1Input.C1Button();
            this.buttonAccept = new C1.Win.C1Input.C1Button();
            this.lblVersionResolved = new C1.Win.C1Input.C1Label();
            this.lblUsedTime = new C1.Win.C1Input.C1Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputVersionResolved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputUsedTime)).BeginInit();
            this.panelGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersionResolved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsedTime)).BeginInit();
            this.SuspendLayout();
            // 
            // inputVersionResolved
            // 
            this.inputVersionResolved.AutoSize = false;
            this.inputVersionResolved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inputVersionResolved.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputVersionResolved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputVersionResolved.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputVersionResolved.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputVersionResolved.ForeColor = System.Drawing.Color.Navy;
            this.inputVersionResolved.Location = new System.Drawing.Point(148, 44);
            this.inputVersionResolved.Name = "inputVersionResolved";
            this.inputVersionResolved.Size = new System.Drawing.Size(179, 23);
            this.inputVersionResolved.TabIndex = 2;
            this.inputVersionResolved.Tag = null;
            this.inputVersionResolved.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.inputVersionResolved.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // inputUsedTime
            // 
            this.inputUsedTime.AutoSize = false;
            this.inputUsedTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inputUsedTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(177)))), ((int)(((byte)(184)))));
            this.inputUsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputUsedTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputUsedTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputUsedTime.ForeColor = System.Drawing.Color.Navy;
            this.inputUsedTime.Location = new System.Drawing.Point(148, 15);
            this.inputUsedTime.Name = "inputUsedTime";
            this.inputUsedTime.Size = new System.Drawing.Size(179, 23);
            this.inputUsedTime.TabIndex = 1;
            this.inputUsedTime.Tag = null;
            this.inputUsedTime.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.inputUsedTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.buttonCancel);
            this.panelGeneral.Controls.Add(this.buttonAccept);
            this.panelGeneral.Controls.Add(this.lblVersionResolved);
            this.panelGeneral.Controls.Add(this.lblUsedTime);
            this.panelGeneral.Controls.Add(this.inputVersionResolved);
            this.panelGeneral.Controls.Add(this.inputUsedTime);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(361, 109);
            this.panelGeneral.TabIndex = 28;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Navy;
            this.buttonCancel.Image = global::VLTMTool.Properties.Resources.iconfinder_x_16x16;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(243, 77);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonCancel.Size = new System.Drawing.Size(106, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.ForeColor = System.Drawing.Color.Navy;
            this.buttonAccept.Image = global::VLTMTool.Properties.Resources.iconfinder_check_16x16;
            this.buttonAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccept.Location = new System.Drawing.Point(131, 77);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonAccept.Size = new System.Drawing.Size(106, 23);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // lblVersionResolved
            // 
            this.lblVersionResolved.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionResolved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblVersionResolved.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionResolved.ForeColor = System.Drawing.Color.Navy;
            this.lblVersionResolved.Location = new System.Drawing.Point(12, 46);
            this.lblVersionResolved.Name = "lblVersionResolved";
            this.lblVersionResolved.Size = new System.Drawing.Size(130, 21);
            this.lblVersionResolved.TabIndex = 29;
            this.lblVersionResolved.Tag = null;
            this.lblVersionResolved.Text = "Version resolved";
            this.lblVersionResolved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVersionResolved.TextDetached = true;
            this.lblVersionResolved.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            // 
            // lblUsedTime
            // 
            this.lblUsedTime.BackColor = System.Drawing.Color.Transparent;
            this.lblUsedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblUsedTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedTime.ForeColor = System.Drawing.Color.Navy;
            this.lblUsedTime.Location = new System.Drawing.Point(12, 17);
            this.lblUsedTime.Name = "lblUsedTime";
            this.lblUsedTime.Size = new System.Drawing.Size(130, 21);
            this.lblUsedTime.TabIndex = 28;
            this.lblUsedTime.Tag = null;
            this.lblUsedTime.Text = "Time used for resolved";
            this.lblUsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUsedTime.TextDetached = true;
            this.lblUsedTime.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            // 
            // TimeToResolve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 109);
            this.Controls.Add(this.panelGeneral);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 148);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 148);
            this.Name = "TimeToResolve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TimeToResolve";
            ((System.ComponentModel.ISupportInitialize)(this.inputVersionResolved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputUsedTime)).EndInit();
            this.panelGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersionResolved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsedTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1TextBox inputVersionResolved;
        private C1.Win.C1Input.C1TextBox inputUsedTime;
        private System.Windows.Forms.Panel panelGeneral;
        private C1.Win.C1Input.C1Label lblVersionResolved;
        private C1.Win.C1Input.C1Label lblUsedTime;
        private C1.Win.C1Input.C1Button buttonCancel;
        private C1.Win.C1Input.C1Button buttonAccept;
    }
}