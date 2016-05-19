namespace jekyll_gui {
	partial class ProgressForm {
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
			this.progressTextLb = new System.Windows.Forms.Label();
			this.taskProgressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// progressTextLb
			// 
			this.progressTextLb.AutoSize = true;
			this.progressTextLb.Location = new System.Drawing.Point(12, 14);
			this.progressTextLb.Name = "progressTextLb";
			this.progressTextLb.Size = new System.Drawing.Size(70, 13);
			this.progressTextLb.TabIndex = 0;
			this.progressTextLb.Text = "Please wait...";
			// 
			// taskProgressBar
			// 
			this.taskProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskProgressBar.Location = new System.Drawing.Point(12, 38);
			this.taskProgressBar.Maximum = 1000;
			this.taskProgressBar.Name = "taskProgressBar";
			this.taskProgressBar.Size = new System.Drawing.Size(301, 23);
			this.taskProgressBar.TabIndex = 1;
			// 
			// ProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 73);
			this.Controls.Add(this.taskProgressBar);
			this.Controls.Add(this.progressTextLb);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Jekyll GUI";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstallBinariesForm_FormClosing);
			this.Load += new System.EventHandler(this.InstallBinariesForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label progressTextLb;
		private System.Windows.Forms.ProgressBar taskProgressBar;
	}
}