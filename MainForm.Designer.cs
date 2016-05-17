namespace jekyll_gui {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
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
		private void InitializeComponent() {
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.siteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.moreThemesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.jekyllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.markdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.yAMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectPanel = new System.Windows.Forms.Panel();
			this.projectPathLb = new System.Windows.Forms.Label();
			this.projectNameLb = new System.Windows.Forms.Label();
			this.mainMenuStrip.SuspendLayout();
			this.projectPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.helpMenu});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(384, 24);
			this.mainMenuStrip.TabIndex = 0;
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.moreThemesMenuItem,
            this.exitMenuItem});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "File";
			// 
			// newMenuItem
			// 
			this.newMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectMenuItem,
            this.fileMenuItem});
			this.newMenuItem.Name = "newMenuItem";
			this.newMenuItem.Size = new System.Drawing.Size(153, 22);
			this.newMenuItem.Text = "New";
			// 
			// projectMenuItem
			// 
			this.projectMenuItem.Name = "projectMenuItem";
			this.projectMenuItem.Size = new System.Drawing.Size(120, 22);
			this.projectMenuItem.Text = "Project...";
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.Name = "fileMenuItem";
			this.fileMenuItem.Size = new System.Drawing.Size(120, 22);
			this.fileMenuItem.Text = "File...";
			// 
			// openMenuItem
			// 
			this.openMenuItem.Name = "openMenuItem";
			this.openMenuItem.Size = new System.Drawing.Size(153, 22);
			this.openMenuItem.Text = "Open folder...";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siteToolStripMenuItem,
            this.templateToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// siteToolStripMenuItem
			// 
			this.siteToolStripMenuItem.Name = "siteToolStripMenuItem";
			this.siteToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.siteToolStripMenuItem.Text = "Site...";
			// 
			// templateToolStripMenuItem
			// 
			this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
			this.templateToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.templateToolStripMenuItem.Text = "Template...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
			// 
			// moreThemesMenuItem
			// 
			this.moreThemesMenuItem.Name = "moreThemesMenuItem";
			this.moreThemesMenuItem.Size = new System.Drawing.Size(153, 22);
			this.moreThemesMenuItem.Text = "More themes...";
			this.moreThemesMenuItem.Click += new System.EventHandler(this.moreThemesMenuItem_Click);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Size = new System.Drawing.Size(153, 22);
			this.exitMenuItem.Text = "Exit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jekyllToolStripMenuItem,
            this.markdownToolStripMenuItem,
            this.yAMLToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(44, 20);
			this.helpMenu.Text = "Help";
			// 
			// jekyllToolStripMenuItem
			// 
			this.jekyllToolStripMenuItem.Name = "jekyllToolStripMenuItem";
			this.jekyllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.jekyllToolStripMenuItem.Text = "Jekyll";
			// 
			// markdownToolStripMenuItem
			// 
			this.markdownToolStripMenuItem.Name = "markdownToolStripMenuItem";
			this.markdownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.markdownToolStripMenuItem.Text = "Markdown";
			// 
			// yAMLToolStripMenuItem
			// 
			this.yAMLToolStripMenuItem.Name = "yAMLToolStripMenuItem";
			this.yAMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.yAMLToolStripMenuItem.Text = "YAML";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			this.toolStripSeparator2.Click += new System.EventHandler(this.toolStripSeparator2_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// projectPanel
			// 
			this.projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.projectPanel.Controls.Add(this.projectPathLb);
			this.projectPanel.Controls.Add(this.projectNameLb);
			this.projectPanel.Location = new System.Drawing.Point(0, 24);
			this.projectPanel.Name = "projectPanel";
			this.projectPanel.Size = new System.Drawing.Size(384, 237);
			this.projectPanel.TabIndex = 1;
			// 
			// projectPathLb
			// 
			this.projectPathLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.projectPathLb.AutoEllipsis = true;
			this.projectPathLb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.projectPathLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.projectPathLb.Location = new System.Drawing.Point(13, 40);
			this.projectPathLb.Name = "projectPathLb";
			this.projectPathLb.Size = new System.Drawing.Size(356, 22);
			this.projectPathLb.TabIndex = 1;
			this.projectPathLb.Text = "D:\\Nexus\\Programs\\Visual Studio Ultimate 2015\\Projects\\jekyll-gui";
			this.projectPathLb.Click += new System.EventHandler(this.projectPathLb_Click);
			// 
			// projectNameLb
			// 
			this.projectNameLb.AutoSize = true;
			this.projectNameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.projectNameLb.Location = new System.Drawing.Point(12, 12);
			this.projectNameLb.Name = "projectNameLb";
			this.projectNameLb.Size = new System.Drawing.Size(104, 20);
			this.projectNameLb.TabIndex = 0;
			this.projectNameLb.Text = "Project Name";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.projectPanel);
			this.Controls.Add(this.mainMenuStrip);
			this.MainMenuStrip = this.mainMenuStrip;
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Jekyll GUI";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.projectPanel.ResumeLayout(false);
			this.projectPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem newMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolStripMenuItem projectMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem moreThemesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jekyllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem markdownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem yAMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Panel projectPanel;
		private System.Windows.Forms.Label projectNameLb;
		private System.Windows.Forms.Label projectPathLb;
	}
}

