using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ImageColorFinder
{
	public partial class FormProgress : Form
	{
		public int ProgressMaximun
		{
			set { progressBar.Maximum = value; }
		}

		public string Message
		{
			set { lbMessage.Text = value; }
		}

		public int ProgressValue
		{
			set { progressBar.Value = value; }
		}

		public ProgressBarStyle ProgressStyle
		{
			set { progressBar.Style = value; }
		}

		public bool CancelVisible
		{
			set { BtnCancel.Visible = value; }
		}

		public FormProgress()
		{
			InitializeComponent();

			BtnCancel.Visible = true;
		}

		public event EventHandler<EventArgs> Canceled;

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Canceled?.Invoke(this, e);
		}
	}
}

