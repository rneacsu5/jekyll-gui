namespace jekyll_gui.Forms
{
	partial class AboutForm
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
			this.author1Lb = new System.Windows.Forms.Label();
			this.author2Lb = new System.Windows.Forms.Label();
			this.websiteLb = new System.Windows.Forms.Label();
			this.versionLb = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.logoImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize) (this.logoImage)).BeginInit();
			this.SuspendLayout();
			// 
			// author1Lb
			// 
			this.author1Lb.AutoSize = true;
			this.author1Lb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.author1Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.author1Lb.Location = new System.Drawing.Point(15, 106);
			this.author1Lb.Name = "author1Lb";
			this.author1Lb.Size = new System.Drawing.Size(121, 17);
			this.author1Lb.TabIndex = 0;
			this.author1Lb.Text = "Neacșu Răzvan";
			this.author1Lb.Click += new System.EventHandler(this.author1Lb_Click);
			// 
			// author2Lb
			// 
			this.author2Lb.AutoSize = true;
			this.author2Lb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.author2Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.author2Lb.Location = new System.Drawing.Point(165, 106);
			this.author2Lb.Name = "author2Lb";
			this.author2Lb.Size = new System.Drawing.Size(133, 17);
			this.author2Lb.TabIndex = 0;
			this.author2Lb.Text = "Prof. Arici Liliana";
			this.author2Lb.Click += new System.EventHandler(this.author2Lb_Click);
			// 
			// websiteLb
			// 
			this.websiteLb.AutoSize = true;
			this.websiteLb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.websiteLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.websiteLb.Location = new System.Drawing.Point(15, 135);
			this.websiteLb.Name = "websiteLb";
			this.websiteLb.Size = new System.Drawing.Size(173, 17);
			this.websiteLb.TabIndex = 0;
			this.websiteLb.Text = "C. N. Nicolae Bălcescu";
			this.websiteLb.Click += new System.EventHandler(this.websiteLb_Click);
			// 
			// versionLb
			// 
			this.versionLb.AutoSize = true;
			this.versionLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.versionLb.Location = new System.Drawing.Point(15, 70);
			this.versionLb.Name = "versionLb";
			this.versionLb.Size = new System.Drawing.Size(104, 17);
			this.versionLb.TabIndex = 0;
			this.versionLb.Text = "Version 1.0.0.0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label5.Location = new System.Drawing.Point(13, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 25);
			this.label5.TabIndex = 1;
			this.label5.Text = "Jekyll GUI";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label6.Location = new System.Drawing.Point(15, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(218, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "A friendly user interface for Jekyll";
			// 
			// logoImage
			// 
			this.logoImage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.logoImage.Image = global::jekyll_gui.Properties.Resources.jekyll_image;
			this.logoImage.Location = new System.Drawing.Point(309, 10);
			this.logoImage.Name = "logoImage";
			this.logoImage.Size = new System.Drawing.Size(90, 90);
			this.logoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.logoImage.TabIndex = 2;
			this.logoImage.TabStop = false;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 167);
			this.Controls.Add(this.logoImage);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.versionLb);
			this.Controls.Add(this.websiteLb);
			this.Controls.Add(this.author2Lb);
			this.Controls.Add(this.author1Lb);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.Load += new System.EventHandler(this.AboutForm_Load);
			((System.ComponentModel.ISupportInitialize) (this.logoImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label author1Lb;
		private System.Windows.Forms.Label author2Lb;
		private System.Windows.Forms.Label websiteLb;
		private System.Windows.Forms.Label versionLb;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox logoImage;
	}
}