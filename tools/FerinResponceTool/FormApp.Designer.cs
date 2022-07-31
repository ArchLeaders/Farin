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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.BtnRequest = new System.Windows.Forms.Button();
            this.Container = new System.Windows.Forms.SplitContainer();
            this.BtnNew = new System.Windows.Forms.Button();
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
            this.TbTriggerWords.Multiline = true;
            this.TbTriggerWords.Name = "TbTriggerWords";
            this.TbTriggerWords.PlaceholderText = "Trigger words (one per line)";
            this.TbTriggerWords.Size = new System.Drawing.Size(834, 278);
            this.TbTriggerWords.TabIndex = 0;
            // 
            // TbTriggerResponce
            // 
            this.TbTriggerResponce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbTriggerResponce.Location = new System.Drawing.Point(0, 0);
            this.TbTriggerResponce.MaxLength = 1999;
            this.TbTriggerResponce.Multiline = true;
            this.TbTriggerResponce.Name = "TbTriggerResponce";
            this.TbTriggerResponce.PlaceholderText = "Trigger responce";
            this.TbTriggerResponce.Size = new System.Drawing.Size(834, 159);
            this.TbTriggerResponce.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(583, 498);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(263, 34);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save (Requires Password)";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Requires @Ferin",
            "Any message"});
            this.comboBox1.Location = new System.Drawing.Point(248, 499);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 33);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Requires @Ferin";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(130, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(716, 33);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "(Select group)";
            // 
            // BtnRequest
            // 
            this.BtnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRequest.Location = new System.Drawing.Point(465, 498);
            this.BtnRequest.Name = "BtnRequest";
            this.BtnRequest.Size = new System.Drawing.Size(112, 34);
            this.BtnRequest.TabIndex = 6;
            this.BtnRequest.Text = "Request";
            this.BtnRequest.UseVisualStyleBackColor = true;
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
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNew.Location = new System.Drawing.Point(12, 10);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(112, 34);
            this.BtnNew.TabIndex = 8;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = true;
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 544);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnRequest);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.Container);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "FormApp";
            this.Text = "Farin Responce Tool I Probably Should Not Have Wasted Time Making";
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
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button BtnRequest;
        private SplitContainer Container;
        private Button BtnNew;
    }
}