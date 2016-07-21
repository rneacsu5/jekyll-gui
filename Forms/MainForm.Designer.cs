namespace jekyll_gui.Forms
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emptyProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromTemplatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toggleServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rebuildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.jekyllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kramdownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.webdevMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toporSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectPanel = new System.Windows.Forms.Panel();
			this.toggleServerBtn = new System.Windows.Forms.Button();
			this.consoleTextBox = new System.Windows.Forms.TextBox();
			this.consoleMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyConsoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAllConsoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearConsoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectPathLb = new System.Windows.Forms.Label();
			this.projectNameLb = new System.Windows.Forms.Label();
			this.portPanel = new System.Windows.Forms.Panel();
			this.portNumericBox = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.serverStatusPanel = new System.Windows.Forms.Panel();
			this.hostLb = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.mainMenuStrip.SuspendLayout();
			this.projectPanel.SuspendLayout();
			this.consoleMenuStrip.SuspendLayout();
			this.portPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.portNumericBox)).BeginInit();
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
            this.newMenuItem,
            this.openMenuItem,
            this.exportMenuItem,
            this.toolStripSeparator2,
            this.closeMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "&File";
			// 
			// newMenuItem
			// 
			this.newMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultProjectMenuItem,
            this.emptyProjectMenuItem,
            this.fromTemplatMenuItem});
			this.newMenuItem.Name = "newMenuItem";
			this.newMenuItem.Size = new System.Drawing.Size(189, 22);
			this.newMenuItem.Text = "&New";
			// 
			// defaultProjectMenuItem
			// 
			this.defaultProjectMenuItem.Name = "defaultProjectMenuItem";
			this.defaultProjectMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.defaultProjectMenuItem.Size = new System.Drawing.Size(227, 22);
			this.defaultProjectMenuItem.Text = "Default &project";
			this.defaultProjectMenuItem.Click += new System.EventHandler(this.defaultProjectMenuItem_Click);
			// 
			// emptyProjectMenuItem
			// 
			this.emptyProjectMenuItem.Name = "emptyProjectMenuItem";
			this.emptyProjectMenuItem.Size = new System.Drawing.Size(227, 22);
			this.emptyProjectMenuItem.Text = "&Empty project";
			this.emptyProjectMenuItem.Click += new System.EventHandler(this.emptyProjectMenuItem_Click);
			// 
			// fromTemplatMenuItem
			// 
			this.fromTemplatMenuItem.Name = "fromTemplatMenuItem";
			this.fromTemplatMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this.fromTemplatMenuItem.Size = new System.Drawing.Size(227, 22);
			this.fromTemplatMenuItem.Text = "From &template";
			this.fromTemplatMenuItem.Click += new System.EventHandler(this.fromTemplatMenuItem_Click);
			// 
			// openMenuItem
			// 
			this.openMenuItem.Name = "openMenuItem";
			this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openMenuItem.Size = new System.Drawing.Size(189, 22);
			this.openMenuItem.Text = "&Open folder...";
			this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
			// 
			// exportMenuItem
			// 
			this.exportMenuItem.Name = "exportMenuItem";
			this.exportMenuItem.Size = new System.Drawing.Size(189, 22);
			this.exportMenuItem.Text = "&Export site...";
			this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
			// 
			// closeMenuItem
			// 
			this.closeMenuItem.Name = "closeMenuItem";
			this.closeMenuItem.Size = new System.Drawing.Size(189, 22);
			this.closeMenuItem.Text = "&Close";
			this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitMenuItem.Size = new System.Drawing.Size(189, 22);
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// projectMenu
			// 
			this.projectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleServerMenuItem,
            this.toolStripSeparator3,
            this.buildMenuItem,
            this.rebuildMenuItem,
            this.cleanMenuItem});
			this.projectMenu.Enabled = false;
			this.projectMenu.Name = "projectMenu";
			this.projectMenu.Size = new System.Drawing.Size(56, 20);
			this.projectMenu.Text = "&Project";
			// 
			// toggleServerMenuItem
			// 
			this.toggleServerMenuItem.Name = "toggleServerMenuItem";
			this.toggleServerMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.toggleServerMenuItem.Size = new System.Drawing.Size(180, 22);
			this.toggleServerMenuItem.Text = "&Start/Stop server";
			this.toggleServerMenuItem.Click += new System.EventHandler(this.toggleServerMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
			// 
			// buildMenuItem
			// 
			this.buildMenuItem.Name = "buildMenuItem";
			this.buildMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.buildMenuItem.Size = new System.Drawing.Size(180, 22);
			this.buildMenuItem.Text = "&Build";
			this.buildMenuItem.Click += new System.EventHandler(this.buildMenuItem_Click);
			// 
			// rebuildMenuItem
			// 
			this.rebuildMenuItem.Name = "rebuildMenuItem";
			this.rebuildMenuItem.Size = new System.Drawing.Size(180, 22);
			this.rebuildMenuItem.Text = "&Rebuild";
			this.rebuildMenuItem.Click += new System.EventHandler(this.rebuildMenuItem_Click);
			// 
			// cleanMenuItem
			// 
			this.cleanMenuItem.Name = "cleanMenuItem";
			this.cleanMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cleanMenuItem.Text = "&Clean";
			this.cleanMenuItem.Click += new System.EventHandler(this.cleanMenuItem_Click);
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
			this.helpMenu.Text = "&Help";
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
			this.aboutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
			this.aboutMenuItem.Size = new System.Drawing.Size(158, 22);
			this.aboutMenuItem.Text = "&About";
			this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
			// 
			// projectPanel
			// 
			this.projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.projectPanel.Controls.Add(this.toggleServerBtn);
			this.projectPanel.Controls.Add(this.consoleTextBox);
			this.projectPanel.Controls.Add(this.projectPathLb);
			this.projectPanel.Controls.Add(this.projectNameLb);
			this.projectPanel.Controls.Add(this.portPanel);
			this.projectPanel.Controls.Add(this.serverStatusPanel);
			this.projectPanel.Location = new System.Drawing.Point(0, 24);
			this.projectPanel.Name = "projectPanel";
			this.projectPanel.Size = new System.Drawing.Size(459, 312);
			this.projectPanel.TabIndex = 0;
			// 
			// toggleServerBtn
			// 
			this.toggleServerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toggleServerBtn.ForeColor = System.Drawing.Color.DarkGreen;
			this.toggleServerBtn.Location = new System.Drawing.Point(10, 70);
			this.toggleServerBtn.Name = "toggleServerBtn";
			this.toggleServerBtn.Size = new System.Drawing.Size(152, 48);
			this.toggleServerBtn.TabIndex = 1;
			this.toggleServerBtn.Text = "Start Server";
			this.toggleServerBtn.UseVisualStyleBackColor = true;
			this.toggleServerBtn.Click += new System.EventHandler(this.toggleServerBtn_Click);
			// 
			// consoleTextBox
			// 
			this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleTextBox.BackColor = System.Drawing.Color.Black;
			this.consoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.consoleTextBox.ContextMenuStrip = this.consoleMenuStrip;
			this.consoleTextBox.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.consoleTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.consoleTextBox.Location = new System.Drawing.Point(10, 124);
			this.consoleTextBox.MaxLength = 100000;
			this.consoleTextBox.Multiline = true;
			this.consoleTextBox.Name = "consoleTextBox";
			this.consoleTextBox.ReadOnly = true;
			this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.consoleTextBox.Size = new System.Drawing.Size(439, 178);
			this.consoleTextBox.TabIndex = 0;
			this.consoleTextBox.TabStop = false;
			this.consoleTextBox.Text = "Microsoft Windows [Version 10.0.10586]\r\n(c) 2015 Microsoft Corporation. All right" +
    "s reserved.\r\n\r\nC:\\Users\\Jekyll>";
			// 
			// consoleMenuStrip
			// 
			this.consoleMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyConsoleMenuItem,
            this.copyAllConsoleMenuItem,
            this.clearConsoleMenuItem});
			this.consoleMenuStrip.Name = "consoleMenuStrip";
			this.consoleMenuStrip.Size = new System.Drawing.Size(120, 70);
			this.consoleMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.consoleMenuStrip_Opening);
			// 
			// copyConsoleMenuItem
			// 
			this.copyConsoleMenuItem.Name = "copyConsoleMenuItem";
			this.copyConsoleMenuItem.Size = new System.Drawing.Size(119, 22);
			this.copyConsoleMenuItem.Text = "Copy";
			this.copyConsoleMenuItem.Click += new System.EventHandler(this.copyConsoleMenuItem_Click);
			// 
			// copyAllConsoleMenuItem
			// 
			this.copyAllConsoleMenuItem.Name = "copyAllConsoleMenuItem";
			this.copyAllConsoleMenuItem.Size = new System.Drawing.Size(119, 22);
			this.copyAllConsoleMenuItem.Text = "Copy All";
			this.copyAllConsoleMenuItem.Click += new System.EventHandler(this.copyAllConsoleMenuItem_Click);
			// 
			// clearConsoleMenuItem
			// 
			this.clearConsoleMenuItem.Name = "clearConsoleMenuItem";
			this.clearConsoleMenuItem.Size = new System.Drawing.Size(119, 22);
			this.clearConsoleMenuItem.Text = "Clear";
			this.clearConsoleMenuItem.Click += new System.EventHandler(this.clearConsoleMenuItem_Click);
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
			this.projectPathLb.TabIndex = 0;
			this.projectPathLb.Text = "D:\\Jekyll\\Data\\GitHub\\example.github.io";
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
			// portPanel
			// 
			this.portPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.portPanel.Controls.Add(this.portNumericBox);
			this.portPanel.Controls.Add(this.label3);
			this.portPanel.Location = new System.Drawing.Point(168, 70);
			this.portPanel.Name = "portPanel";
			this.portPanel.Size = new System.Drawing.Size(281, 48);
			this.portPanel.TabIndex = 0;
			// 
			// portNumericBox
			// 
			this.portNumericBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.portNumericBox.Location = new System.Drawing.Point(44, 15);
			this.portNumericBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.portNumericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.portNumericBox.Name = "portNumericBox";
			this.portNumericBox.Size = new System.Drawing.Size(78, 23);
			this.portNumericBox.TabIndex = 2;
			this.portNumericBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.portNumericBox.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.portNumericBox.ValueChanged += new System.EventHandler(this.portNumericBox_ValueChanged);
			this.portNumericBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.portNumericBox_KeyUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(0, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Port:";
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
			this.serverStatusPanel.TabIndex = 0;
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
			this.hostLb.TabIndex = 0;
			this.hostLb.Text = "http://127.0.0.1:4000";
			this.hostLb.Click += new System.EventHandler(this.hostLb_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hostname:";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Choose location";
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
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.projectPanel.ResumeLayout(false);
			this.projectPanel.PerformLayout();
			this.consoleMenuStrip.ResumeLayout(false);
			this.portPanel.ResumeLayout(false);
			this.portPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.portNumericBox)).EndInit();
			this.serverStatusPanel.ResumeLayout(false);
			this.serverStatusPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem newMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
		private System.Windows.Forms.TextBox consoleTextBox;
		private System.Windows.Forms.Label hostLb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button toggleServerBtn;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Panel serverStatusPanel;
		private System.Windows.Forms.ToolStripMenuItem projectMenu;
		private System.Windows.Forms.ToolStripMenuItem buildMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cleanMenuItem;
		private System.Windows.Forms.ContextMenuStrip consoleMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem copyAllConsoleMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearConsoleMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyConsoleMenuItem;
		private System.Windows.Forms.Panel portPanel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown portNumericBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rebuildMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toggleServerMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem defaultProjectMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emptyProjectMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromTemplatMenuItem;
	}
}

