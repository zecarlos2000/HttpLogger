namespace WebRequestLogger
{
	partial class WebRequestLoggerForm
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
			this.startBtn = new System.Windows.Forms.Button();
			this.listeningEndPointLbl = new System.Windows.Forms.Label();
			this.listeningEndpointTextBox = new System.Windows.Forms.TextBox();
			this.redirectChkBox = new System.Windows.Forms.CheckBox();
			this.redirectToTextBox = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// startBtn
			// 
			this.startBtn.Location = new System.Drawing.Point(15, 12);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(97, 34);
			this.startBtn.TabIndex = 0;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
			// 
			// listeningEndPointLbl
			// 
			this.listeningEndPointLbl.AutoSize = true;
			this.listeningEndPointLbl.Location = new System.Drawing.Point(12, 58);
			this.listeningEndPointLbl.Name = "listeningEndPointLbl";
			this.listeningEndPointLbl.Size = new System.Drawing.Size(128, 17);
			this.listeningEndPointLbl.TabIndex = 1;
			this.listeningEndPointLbl.Text = "Listening endpoint:";
			// 
			// listeningEndpointTextBox
			// 
			this.listeningEndpointTextBox.Location = new System.Drawing.Point(146, 58);
			this.listeningEndpointTextBox.Name = "listeningEndpointTextBox";
			this.listeningEndpointTextBox.ReadOnly = true;
			this.listeningEndpointTextBox.Size = new System.Drawing.Size(521, 22);
			this.listeningEndpointTextBox.TabIndex = 2;
			// 
			// redirectChkBox
			// 
			this.redirectChkBox.AutoSize = true;
			this.redirectChkBox.Location = new System.Drawing.Point(15, 101);
			this.redirectChkBox.Name = "redirectChkBox";
			this.redirectChkBox.Size = new System.Drawing.Size(103, 21);
			this.redirectChkBox.TabIndex = 3;
			this.redirectChkBox.Text = "Redirect to:";
			this.redirectChkBox.UseVisualStyleBackColor = true;
			this.redirectChkBox.CheckedChanged += new System.EventHandler(this.redirectChkBox_CheckedChanged);
			// 
			// redirectToTextBox
			// 
			this.redirectToTextBox.Location = new System.Drawing.Point(146, 99);
			this.redirectToTextBox.Name = "redirectToTextBox";
			this.redirectToTextBox.ReadOnly = true;
			this.redirectToTextBox.Size = new System.Drawing.Size(521, 22);
			this.redirectToTextBox.TabIndex = 4;
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.Location = new System.Drawing.Point(15, 138);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(764, 300);
			this.flowLayoutPanel.TabIndex = 5;
			// 
			// WebRequestLoggerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.redirectToTextBox);
			this.Controls.Add(this.redirectChkBox);
			this.Controls.Add(this.listeningEndpointTextBox);
			this.Controls.Add(this.listeningEndPointLbl);
			this.Controls.Add(this.startBtn);
			this.Name = "WebRequestLoggerForm";
			this.Text = "WebRequestLogger";
			this.Load += new System.EventHandler(this.WebRequestLoggerForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Label listeningEndPointLbl;
		private System.Windows.Forms.TextBox listeningEndpointTextBox;
		private System.Windows.Forms.CheckBox redirectChkBox;
		private System.Windows.Forms.TextBox redirectToTextBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
	}
}

