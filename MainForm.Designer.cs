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
			this.newProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.moreThemesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.buildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.jekyllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kramdownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.webdevMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toporSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectPanel = new System.Windows.Forms.Panel();
			this.serverStatusPanel = new System.Windows.Forms.Panel();
			this.hostLb = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.toggleServerBtn = new System.Windows.Forms.Button();
			this.consoleText = new System.Windows.Forms.TextBox();
			this.projectPathLb = new System.Windows.Forms.Label();
			this.projectNameLb = new System.Windows.Forms.Label();
			this.projectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.mainMenuStrip.SuspendLayout();
			this.projectPanel.SuspendLayout();
			this.serverStatusPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.projectMenu,
            this.helpMenu});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(459, 24);
			this.mainMenuStrip.TabIndex = 0;
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectMenuItem,
            this.openMenuItem,
            this.exportMenuItem,
            this.toolStripSeparator1,
            this.moreThemesMenuItem,
            this.exitMenuItem});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "File";
			// 
			// newProjectMenuItem
			// 
			this.newProjectMenuItem.Name = "newProjectMenuItem";
			this.newProjectMenuItem.Size = new System.Drawing.Size(153, 22);
			this.newProjectMenuItem.Text = "New project...";
			this.newProjectMenuItem.Click += new System.EventHandler(this.newProjectMenuItem_Click);
			// 
			// openMenuItem
			// 
			this.openMenuItem.Name = "openMenuItem";
			this.openMenuItem.Size = new System.Drawing.Size(153, 22);
			this.openMenuItem.Text = "Open folder...";
			this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
			// 
			// exportMenuItem
			// 
			this.exportMenuItem.Name = "exportMenuItem";
			this.exportMenuItem.Size = new System.Drawing.Size(153, 22);
			this.exportMenuItem.Text = "Export site...";
			this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
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
			// projectMenu
			// 
			this.projectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildMenuItem,
            this.cleanMenuItem,
            this.closeMenuItem});
			this.projectMenu.Enabled = false;
			this.projectMenu.Name = "projectMenu";
			this.projectMenu.Size = new System.Drawing.Size(56, 20);
			this.projectMenu.Text = "Project";
			// 
			// buildMenuItem
			// 
			this.buildMenuItem.Name = "buildMenuItem";
			this.buildMenuItem.Size = new System.Drawing.Size(104, 22);
			this.buildMenuItem.Text = "Build";
			this.buildMenuItem.Click += new System.EventHandler(this.buildMenuItem_Click);
			// 
			// cleanMenuItem
			// 
			this.cleanMenuItem.Name = "cleanMenuItem";
			this.cleanMenuItem.Size = new System.Drawing.Size(104, 22);
			this.cleanMenuItem.Text = "Clean";
			this.cleanMenuItem.Click += new System.EventHandler(this.cleanMenuItem_Click);
			// 
			// closeMenuItem
			// 
			this.closeMenuItem.Name = "closeMenuItem";
			this.closeMenuItem.Size = new System.Drawing.Size(104, 22);
			this.closeMenuItem.Text = "Close";
			this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jekyllMenuItem,
            this.kramdownMenuItem,
            this.webdevMenuItem,
            this.toporSeparator,
            this.aboutMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(44, 20);
			this.helpMenu.Text = "Help";
			// 
			// jekyllMenuItem
			// 
			this.jekyllMenuItem.Name = "jekyllMenuItem";
			this.jekyllMenuItem.Size = new System.Drawing.Size(158, 22);
			this.jekyllMenuItem.Text = "Jekyll";
			this.jekyllMenuItem.Click += new System.EventHandler(this.jekyllMenuItem_Click);
			// 
			// kramdownMenuItem
			// 
			this.kramdownMenuItem.Name = "kramdownMenuItem";
			this.kramdownMenuItem.Size = new System.Drawing.Size(158, 22);
			this.kramdownMenuItem.Text = "Kramdown";
			this.kramdownMenuItem.Click += new System.EventHandler(this.kramdownMenuItem_Click);
			// 
			// webdevMenuItem
			// 
			this.webdevMenuItem.Name = "webdevMenuItem";
			this.webdevMenuItem.Size = new System.Drawing.Size(158, 22);
			this.webdevMenuItem.Text = "HTML, CSS, JS...";
			this.webdevMenuItem.Click += new System.EventHandler(this.webdevMenuItem_Click);
			// 
			// toporSeparator
			// 
			this.toporSeparator.Name = "toporSeparator";
			this.toporSeparator.Size = new System.Drawing.Size(155, 6);
			this.toporSeparator.Click += new System.EventHandler(this.toporSeparator_Click);
			// 
			// aboutMenuItem
			// 
			this.aboutMenuItem.Name = "aboutMenuItem";
			this.aboutMenuItem.Size = new System.Drawing.Size(158, 22);
			this.aboutMenuItem.Text = "About";
			this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
			// 
			// projectPanel
			// 
			this.projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.projectPanel.Controls.Add(this.serverStatusPanel);
			this.projectPanel.Controls.Add(this.toggleServerBtn);
			this.projectPanel.Controls.Add(this.consoleText);
			this.projectPanel.Controls.Add(this.projectPathLb);
			this.projectPanel.Controls.Add(this.projectNameLb);
			this.projectPanel.Location = new System.Drawing.Point(0, 24);
			this.projectPanel.Name = "projectPanel";
			this.projectPanel.Size = new System.Drawing.Size(459, 312);
			this.projectPanel.TabIndex = 1;
			// 
			// serverStatusPanel
			// 
			this.serverStatusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.serverStatusPanel.Controls.Add(this.hostLb);
			this.serverStatusPanel.Controls.Add(this.label1);
			this.serverStatusPanel.Location = new System.Drawing.Point(168, 70);
			this.serverStatusPanel.Name = "serverStatusPanel";
			this.serverStatusPanel.Size = new System.Drawing.Size(281, 48);
			this.serverStatusPanel.TabIndex = 5;
			// 
			// hostLb
			// 
			this.hostLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hostLb.AutoEllipsis = true;
			this.hostLb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.hostLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hostLb.ForeColor = System.Drawing.Color.RoyalBlue;
			this.hostLb.Location = new System.Drawing.Point(76, 17);
			this.hostLb.Name = "hostLb";
			this.hostLb.Size = new System.Drawing.Size(205, 20);
			this.hostLb.TabIndex = 4;
			this.hostLb.Text = "http://192.168.1.11:4000";
			this.hostLb.Click += new System.EventHandler(this.hostLb_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Hostname:";
			// 
			// toggleServerBtn
			// 
			this.toggleServerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toggleServerBtn.ForeColor = System.Drawing.Color.DarkGreen;
			this.toggleServerBtn.Location = new System.Drawing.Point(10, 70);
			this.toggleServerBtn.Name = "toggleServerBtn";
			this.toggleServerBtn.Size = new System.Drawing.Size(152, 48);
			this.toggleServerBtn.TabIndex = 3;
			this.toggleServerBtn.Text = "Start Server";
			this.toggleServerBtn.UseVisualStyleBackColor = true;
			this.toggleServerBtn.Click += new System.EventHandler(this.toggleServerBtn_Click);
			// 
			// consoleText
			// 
			this.consoleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleText.BackColor = System.Drawing.Color.Black;
			this.consoleText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.consoleText.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.consoleText.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.consoleText.Location = new System.Drawing.Point(10, 124);
			this.consoleText.MaxLength = 100000;
			this.consoleText.Multiline = true;
			this.consoleText.Name = "consoleText";
			this.consoleText.ReadOnly = true;
			this.consoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.consoleText.Size = new System.Drawing.Size(439, 178);
			this.consoleText.TabIndex = 2;
			this.consoleText.TabStop = false;
			this.consoleText.Text = "Microsoft Windows [Version 10.0.10586]\r\n(c) 2015 Microsoft Corporation. All right" +
    "s reserved.\r\n\r\nC:\\Users\\Nexus>";
			// 
			// projectPathLb
			// 
			this.projectPathLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.projectPathLb.AutoEllipsis = true;
			this.projectPathLb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.projectPathLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.projectPathLb.Location = new System.Drawing.Point(10, 40);
			this.projectPathLb.Name = "projectPathLb";
			this.projectPathLb.Size = new System.Drawing.Size(431, 22);
			this.projectPathLb.TabIndex = 1;
			this.projectPathLb.Text = "D:\\Nexus\\Programs\\Visual Studio Ultimate 2015\\Projects\\jekyll-gui";
			this.projectPathLb.Click += new System.EventHandler(this.projectPathLb_Click);
			// 
			// projectNameLb
			// 
			this.projectNameLb.AutoSize = true;
			this.projectNameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.projectNameLb.Location = new System.Drawing.Point(10, 15);
			this.projectNameLb.Name = "projectNameLb";
			this.projectNameLb.Size = new System.Drawing.Size(104, 20);
			this.projectNameLb.TabIndex = 0;
			this.projectNameLb.Text = "Project Name";
			// 
			// projectFolderDialog
			// 
			this.projectFolderDialog.Description = "Choose project location";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 336);
			this.Controls.Add(this.projectPanel);
			this.Controls.Add(this.mainMenuStrip);
			this.MainMenuStrip = this.mainMenuStrip;
			this.MinimumSize = new System.Drawing.Size(475, 375);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Jekyll GUI";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.projectPanel.ResumeLayout(false);
			this.projectPanel.PerformLayout();
			this.serverStatusPanel.ResumeLayout(false);
			this.serverStatusPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem newProjectMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem moreThemesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jekyllMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kramdownMenuItem;
		private System.Windows.Forms.ToolStripMenuItem webdevMenuItem;
		private System.Windows.Forms.ToolStripSeparator toporSeparator;
		private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
		private System.Windows.Forms.Panel projectPanel;
		private System.Windows.Forms.Label projectNameLb;
		private System.Windows.Forms.Label projectPathLb;
		private System.Windows.Forms.TextBox consoleText;
		private System.Windows.Forms.Label hostLb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button toggleServerBtn;
		private System.Windows.Forms.FolderBrowserDialog projectFolderDialog;
		private System.Windows.Forms.Panel serverStatusPanel;
		private System.Windows.Forms.ToolStripMenuItem projectMenu;
		private System.Windows.Forms.ToolStripMenuItem buildMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cleanMenuItem;
	}
}

