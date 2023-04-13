using System.Drawing;
using System.Windows.Forms;

namespace ImageColorFinder
{
	partial class FormProgress
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
			BtnCancel = new Button();
			progressBar = new ProgressBar();
			lbMessage = new Label();
			SuspendLayout();
			// 
			// BtnCancel
			// 
			BtnCancel.Location = new Point(325, 171);
			BtnCancel.Margin = new Padding(3, 5, 3, 5);
			BtnCancel.Name = "BtnCancel";
			BtnCancel.Size = new Size(111, 35);
			BtnCancel.TabIndex = 6;
			BtnCancel.Text = "Cancel";
			BtnCancel.UseVisualStyleBackColor = true;
			BtnCancel.Click += BtnCancel_Click;
			// 
			// progressBar
			// 
			progressBar.Location = new Point(17, 113);
			progressBar.Margin = new Padding(3, 5, 3, 5);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(420, 35);
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 5;
			// 
			// lbMessage
			// 
			lbMessage.BackColor = SystemColors.InactiveCaption;
			lbMessage.Location = new Point(14, 12);
			lbMessage.Name = "lbMessage";
			lbMessage.Size = new Size(423, 79);
			lbMessage.TabIndex = 4;
			lbMessage.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// FormProgress
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.InactiveCaption;
			ClientSize = new Size(450, 227);
			Controls.Add(BtnCancel);
			Controls.Add(progressBar);
			Controls.Add(lbMessage);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(3, 5, 3, 5);
			Name = "FormProgress";
			StartPosition = FormStartPosition.CenterParent;
			Text = "FormProgress";
			ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lbMessage;
	}
}