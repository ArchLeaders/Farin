namespace FarinResponceTool
{
    partial class FormApp
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApp));
            this.TbTriggerWords = new System.Windows.Forms.TextBox();
            this.TbTriggerResponce = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.CbxMode = new System.Windows.Forms.ComboBox();
            this.CbxGroups = new System.Windows.Forms.ComboBox();
            this.BtnRequest = new System.Windows.Forms.Button();
            this.Container = new System.Windows.Forms.SplitContainer();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnCreateKey = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbTriggerWords
            // 
            this.TbTriggerWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbTriggerWords.Location = new System.Drawing.Point(0, 0);
            this.TbTriggerWords.MaxLength = 600;
            this.TbTriggerWords.Multiline = true;
            this.TbTriggerWords.Name = "TbTriggerWords";
            this.TbTriggerWords.PlaceholderText = "Trigger words (one per line)";
            this.TbTriggerWords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbTriggerWords.Size = new System.Drawing.Size(834, 278);
            this.TbTriggerWords.TabIndex = 0;
            // 
            // TbTriggerResponce
            // 
            this.TbTriggerResponce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbTriggerResponce.Location = new System.Drawing.Point(0, 0);
            this.TbTriggerResponce.MaxLength = 1024;
            this.TbTriggerResponce.Multiline = true;
            this.TbTriggerResponce.Name = "TbTriggerResponce";
            this.TbTriggerResponce.PlaceholderText = "Trigger responce";
            this.TbTriggerResponce.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbTriggerResponce.Size = new System.Drawing.Size(834, 159);
            this.TbTriggerResponce.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(734, 498);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(112, 34);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CbxMode
            // 
            this.CbxMode.FormattingEnabled = true;
            this.CbxMode.Items.AddRange(new object[] {
            "Requires @Farin",
            "Any message"});
            this.CbxMode.Location = new System.Drawing.Point(130, 12);
            this.CbxMode.Name = "CbxMode";
            this.CbxMode.Size = new System.Drawing.Size(198, 33);
            this.CbxMode.TabIndex = 3;
            this.CbxMode.Text = "Requires @Farin";
            this.CbxMode.SelectedIndexChanged += new System.EventHandler(this.CbxMode_SelectedIndexChanged);
            // 
            // CbxGroups
            // 
            this.CbxGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxGroups.FormattingEnabled = true;
            this.CbxGroups.Location = new System.Drawing.Point(334, 12);
            this.CbxGroups.Name = "CbxGroups";
            this.CbxGroups.Size = new System.Drawing.Size(472, 33);
            this.CbxGroups.TabIndex = 4;
            this.CbxGroups.Text = "(Select group)";
            this.CbxGroups.SelectedIndexChanged += new System.EventHandler(this.CbxGroups_SelectedIndexChanged);
            // 
            // BtnRequest
            // 
            this.BtnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRequest.Location = new System.Drawing.Point(616, 498);
            this.BtnRequest.Name = "BtnRequest";
            this.BtnRequest.Size = new System.Drawing.Size(112, 34);
            this.BtnRequest.TabIndex = 6;
            this.BtnRequest.Text = "Request";
            this.BtnRequest.UseVisualStyleBackColor = true;
            this.BtnRequest.Click += new System.EventHandler(this.BtnRequest_Click);
            // 
            // Container
            // 
            this.Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Container.Location = new System.Drawing.Point(12, 51);
            this.Container.Name = "Container";
            this.Container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.Controls.Add(this.TbTriggerWords);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.Controls.Add(this.TbTriggerResponce);
            this.Container.Size = new System.Drawing.Size(834, 441);
            this.Container.SplitterDistance = 278;
            this.Container.TabIndex = 7;
            this.Container.TabStop = false;
            // 
            // BtnNew
            // 
            this.BtnNew.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnNew.Location = new System.Drawing.Point(12, 11);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(112, 34);
            this.BtnNew.TabIndex = 8;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = false;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnCreateKey
            // 
            this.BtnCreateKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCreateKey.Location = new System.Drawing.Point(12, 498);
            this.BtnCreateKey.Name = "BtnCreateKey";
            this.BtnCreateKey.Size = new System.Drawing.Size(122, 34);
            this.BtnCreateKey.TabIndex = 7;
            this.BtnCreateKey.TabStop = false;
            this.BtnCreateKey.Text = "Create Key";
            this.BtnCreateKey.UseVisualStyleBackColor = true;
            this.BtnCreateKey.Visible = false;
            this.BtnCreateKey.Click += new System.EventHandler(this.BtnCreateKey_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdate.Location = new System.Drawing.Point(299, 498);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(311, 34);
            this.BtnUpdate.TabIndex = 2;
            this.BtnUpdate.Text = "Push Changes (Requires Password)";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Visible = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(812, 12);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.BtnDel.Size = new System.Drawing.Size(34, 34);
            this.BtnDel.TabIndex = 9;
            this.BtnDel.Text = "❌";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 544);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnCreateKey);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnRequest);
            this.Controls.Add(this.CbxGroups);
            this.Controls.Add(this.CbxMode);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.Container);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "FormApp";
            this.Text = "Farin Responce Tool I Probably Should Not Have Wasted Time Making";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormApp_FormClosed);
            this.Load += new System.EventHandler(this.FormApp_Load);
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel1.PerformLayout();
            this.Container.Panel2.ResumeLayout(false);
            this.Container.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

#endregion

        private TextBox TbTriggerWords;
        private TextBox TbTriggerResponce;
        private Button BtnSave;
        private ComboBox CbxMode;
        private ComboBox CbxGroups;
        private Button BtnRequest;
        private SplitContainer Container;
        private Button BtnNew;
        private Button BtnCreateKey;
        private Button BtnUpdate;
        private Button BtnDel;
    }
}