namespace jekyll_gui.Forms
{
	partial class TemplateDialog
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
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.refreshTemplatesBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.templatesListBox = new System.Windows.Forms.ListBox();
			this.templatePanel = new System.Windows.Forms.Panel();
			this.templateNameLb = new System.Windows.Forms.Label();
			this.demoBrowser = new System.Windows.Forms.WebBrowser();
			this.viewSourceBtn = new System.Windows.Forms.Button();
			this.viewInBrowserBtn = new System.Windows.Forms.Button();
			this.submitBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.templatePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.refreshTemplatesBtn);
			this.mainSplitContainer.Panel1.Controls.Add(this.label1);
			this.mainSplitContainer.Panel1.Controls.Add(this.templatesListBox);
			this.mainSplitContainer.Panel1MinSize = 140;
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.templatePanel);
			this.mainSplitContainer.Panel2MinSize = 360;
			this.mainSplitContainer.Size = new System.Drawing.Size(984, 561);
			this.mainSplitContainer.SplitterDistance = 222;
			this.mainSplitContainer.TabIndex = 0;
			this.mainSplitContainer.TabStop = false;
			// 
			// refreshTemplatesBtn
			// 
			this.refreshTemplatesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.refreshTemplatesBtn.Location = new System.Drawing.Point(0, 533);
			this.refreshTemplatesBtn.Name = "refreshTemplatesBtn";
			this.refreshTemplatesBtn.Size = new System.Drawing.Size(222, 28);
			this.refreshTemplatesBtn.TabIndex = 2;
			this.refreshTemplatesBtn.Text = "Refresh list";
			this.refreshTemplatesBtn.UseVisualStyleBackColor = true;
			this.refreshTemplatesBtn.Click += new System.EventHandler(this.refreshTemplatesBtn_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(222, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Available templates";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// templatesListBox
			// 
			this.templatesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.templatesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.templatesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.templatesListBox.FormattingEnabled = true;
			this.templatesListBox.IntegralHeight = false;
			this.templatesListBox.ItemHeight = 16;
			this.templatesListBox.Location = new System.Drawing.Point(0, 40);
			this.templatesListBox.Name = "templatesListBox";
			this.templatesListBox.Size = new System.Drawing.Size(222, 493);
			this.templatesListBox.Sorted = true;
			this.templatesListBox.TabIndex = 1;
			this.templatesListBox.SelectedIndexChanged += new System.EventHandler(this.templatesListBox_SelectedIndexChanged);
			// 
			// templatePanel
			// 
			this.templatePanel.Controls.Add(this.templateNameLb);
			this.templatePanel.Controls.Add(this.demoBrowser);
			this.templatePanel.Controls.Add(this.viewSourceBtn);
			this.templatePanel.Controls.Add(this.viewInBrowserBtn);
			this.templatePanel.Controls.Add(this.submitBtn);
			this.templatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templatePanel.Location = new System.Drawing.Point(0, 0);
			this.templatePanel.Name = "templatePanel";
			this.templatePanel.Size = new System.Drawing.Size(758, 561);
			this.templatePanel.TabIndex = 0;
			// 
			// templateNameLb
			// 
			this.templateNameLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.templateNameLb.AutoEllipsis = true;
			this.templateNameLb.BackColor = System.Drawing.SystemColors.Control;
			this.templateNameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.templateNameLb.Location = new System.Drawing.Point(0, 0);
			this.templateNameLb.Name = "templateNameLb";
			this.templateNameLb.Size = new System.Drawing.Size(462, 40);
			this.templateNameLb.TabIndex = 0;
			this.templateNameLb.Text = "Template Name";
			this.templateNameLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// demoBrowser
			// 
			this.demoBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.demoBrowser.Location = new System.Drawing.Point(0, 40);
			this.demoBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.demoBrowser.Name = "demoBrowser";
			this.demoBrowser.ScriptErrorsSuppressed = true;
			this.demoBrowser.Size = new System.Drawing.Size(758, 521);
			this.demoBrowser.TabIndex = 4;
			// 
			// viewSourceBtn
			// 
			this.viewSourceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.viewSourceBtn.Location = new System.Drawing.Point(468, 4);
			this.viewSourceBtn.Name = "viewSourceBtn";
			this.viewSourceBtn.Size = new System.Drawing.Size(80, 30);
			this.viewSourceBtn.TabIndex = 3;
			this.viewSourceBtn.Text = "View source";
			this.viewSourceBtn.UseVisualStyleBackColor = true;
			this.viewSourceBtn.Click += new System.EventHandler(this.viewSourceBtn_Click);
			// 
			// viewInBrowserBtn
			// 
			this.viewInBrowserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.viewInBrowserBtn.Location = new System.Drawing.Point(554, 4);
			this.viewInBrowserBtn.Name = "viewInBrowserBtn";
			this.viewInBrowserBtn.Size = new System.Drawing.Size(95, 30);
			this.viewInBrowserBtn.TabIndex = 3;
			this.viewInBrowserBtn.Text = "Open in browser";
			this.viewInBrowserBtn.UseVisualStyleBackColor = true;
			this.viewInBrowserBtn.Click += new System.EventHandler(this.viewInBrowserBtn_Click);
			// 
			// submitBtn
			// 
			this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.submitBtn.Location = new System.Drawing.Point(655, 4);
			this.submitBtn.Name = "submitBtn";
			this.submitBtn.Size = new System.Drawing.Size(100, 30);
			this.submitBtn.TabIndex = 3;
			this.submitBtn.Text = "Use template";
			this.submitBtn.UseVisualStyleBackColor = true;
			this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
			// 
			// TemplateDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.mainSplitContainer);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(520, 360);
			this.Name = "TemplateDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Templates";
			this.Load += new System.EventHandler(this.TemplateDialog_Load);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.templatePanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.ListBox templatesListBox;
		private System.Windows.Forms.Button refreshTemplatesBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label templateNameLb;
		private System.Windows.Forms.Button submitBtn;
		private System.Windows.Forms.WebBrowser demoBrowser;
		private System.Windows.Forms.Panel templatePanel;
		private System.Windows.Forms.Button viewInBrowserBtn;
		private System.Windows.Forms.Button viewSourceBtn;
	}
}