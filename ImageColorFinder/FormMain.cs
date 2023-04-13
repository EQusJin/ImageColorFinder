using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace ImageColorFinder
{
	public partial class FormMain : Form
	{
		string ImagePath { get => TBImagePath.Text; set => TBImagePath.Text = value; }

		string ColorName
		{
			set => LblColorName.Text = ColorTranslator.FromHtml("#" + value).Name;
		}

		int RValue
		{
			get
			{
				_ = int.TryParse(TBRValue.Text, out int value);

				return value;
			}
			set => TBRValue.Text = value.ToString();
		}

		int GValue
		{
			get
			{
				_ = int.TryParse(TBGValue.Text, out int value);

				return value;
			}
			set => TBGValue.Text = value.ToString();
		}

		int BValue
		{
			get
			{
				_ = int.TryParse(TBBValue.Text, out int value);

				return value;
			}
			set => TBBValue.Text = value.ToString();
		}

		readonly List<TaskController> Tasks;
		readonly List<PickedColor> PickedColors;

		public FormMain()
		{
			InitializeComponent();

			Tasks = new List<TaskController>();

			PBColorPreview.BackColor = Color.FromArgb(RValue, GValue, BValue);

			PickedColors = new List<PickedColor>
			{
				new PickedColor(Color.FromArgb(0, 0, 255)),
				new PickedColor(Color.FromArgb(255, 0, 0))
				//new PickedColor(Color.FromArgb(255, 255, 255))
				//new PickedColor(Color.FromArgb(255, 255, 250)),
				//new PickedColor(Color.FromArgb(255, 250, 255)),
				//new PickedColor(Color.FromArgb(250, 255, 255))
			};

			UpdateColorListView();
			UpdateGridTaskList();
		}

		private void BtnSelectPath_Click(object sender, EventArgs e)
		{
			ImagePath = FolderSelect("영상 파일이 포함된 최상위 폴더를 선택하세요.");

			if (string.IsNullOrEmpty(ImagePath))
				return;

			Tasks.Clear();

			var imageFiles = Directory.GetFiles(ImagePath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".tif") || s.EndsWith(".jpg")).Select(d => new FileInfo(d)).ToList();

			imageFiles.ForEach(d => Tasks.Add(new TaskController(d)));

			UpdateGridTaskList();

			BtnStart.Enabled = true;
		}

		private void BtnStart_Click(object sender, EventArgs e)
		{
			int cnt = 1;
			FormProgress formProgress = new()
			{
				ProgressStyle = ProgressBarStyle.Continuous,
				CancelVisible = false,
				ProgressValue = 0,
				ProgressMaximun = Tasks.Count
			};

			BackgroundWorkerHelper.Run
			(
				// dowork
				(s, ea) =>
				{
					Tasks.ForEach(t =>
					{
						((BackgroundWorker?)s)!.ReportProgress(cnt++, $"{t.ImageFile!.Name} 파일 분석 중 입니다.");

						t.RunColorFinder(PickedColors);
					});
				},
				// complete
				(s, ea) =>
				{
					formProgress.Close();
					MessageBox.Show("색상 검출 작업이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

					UpdateGridTaskList();

					BtnSave.Enabled = true;
				},
				// reportProgress
				(s, ea) =>
				{
					formProgress.Message = $"{ea.UserState} ({ea.ProgressPercentage} / {Tasks.Count})";
					formProgress.ProgressValue = ea.ProgressPercentage;
				}
			);

			formProgress.ShowDialog();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new()
			{
				Title = "CSV 파일 저장",
				DefaultExt = "csv",
				Filter = "csv file(*.csv)|*.csv"
			};

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				(GridTaskList.DataSource as DataTable)!.ToCSV(sfd.FileName.ToString(), "상태");

				MessageBox.Show($"{sfd.FileName} 저장이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void RGBTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			string textValue = ((TextBox)sender).Text;

			_ = int.TryParse(textValue, out int value);

			if (value > 256)
				((TextBox)sender).Text = "255";
			else if (textValue == "")
				((TextBox)sender).Text = "0";

			PBColorPreview.BackColor = Color.FromArgb(RValue, GValue, BValue);
		}

		private void PBColorPreview_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new();

			if (cd.ShowDialog() == DialogResult.OK)
			{
				RValue = cd.Color.R;
				GValue = cd.Color.G;
				BValue = cd.Color.B;

				PBColorPreview.BackColor = cd.Color;
			}
		}

		private void UpdateColorListView()
		{
			LVColorList.Items.Clear();
			LayerImageList.Images.Clear();

			foreach (var pickedColor in PickedColors)
			{
				LayerImageList.Images.Add(pickedColor.RGBName, pickedColor.ThumbNail);

				LVColorList.Items.Add($"{pickedColor.RGBName}{pickedColor.RGBValue}", pickedColor.RGBName);
			}
		}

		private void UpdateGridTaskList()
		{
			GBTaskList.Text = $"파일 목록 : {Tasks.Count} 개";

			GridTaskList.DataSource = null;

			DataTable dt = new();
			dt.Columns.Add(new DataColumn("파일명", typeof(string)));
			PickedColors.ForEach(d => dt.Columns.Add(new DataColumn($"{d.RGBName}\r\n{d.RGBValue}", typeof(string))));
			dt.Columns.Add(new DataColumn("상태", typeof(string)));

			DataRow dr = dt.NewRow();

			Tasks.ForEach(d =>
			{
				dr[0] = d.ImageFile!.Name;

				if (d.FinderMap!.Count != 0)
				{
					for (int i = 1; i <= dt.Columns.Count - 2; i++)
					{
						try
						{
							dr[i] = string.Format("{0:n0}", d.FinderMap![dt.Columns[i].ColumnName.Split("\r\n".ToCharArray())[0]]);
						}
						catch { dr[i] = ""; }
					}
				}

				dr[dt.Columns.Count - 1] = d.Status;

				dt.Rows.Add(dr);
				dr = dt.NewRow();
			});

			dt.DefaultView.Sort = "상태 ASC";
			GridTaskList.DataSource = dt;

			SetGridColor();
		}

		private void SetGridColor()
		{
			for (int i = 0; i < GridTaskList.Rows.Count; i++)
			{
				if (GridTaskList[GridTaskList.ColumnCount - 1, i].Value == null)
					continue;

				if (GridTaskList[GridTaskList.ColumnCount - 1, i].Value.Equals("Detected"))
					GridTaskList.Rows[i].DefaultCellStyle.BackColor = Color.Moccasin;
			}
		}

		private void BtnColorAdd_Click(object sender, EventArgs e)
		{
			if (PickedColors.Count >= 6)
			{
				MessageBox.Show("검출 색 설정은 최대 6개까지 지정할 수 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Color selectedColor = Color.FromArgb(RValue, GValue, BValue);

			if (PickedColors.Where(d => d.ColorRGB == selectedColor).FirstOrDefault() == null)
			{
				PickedColors.Add(new PickedColor(selectedColor));

				UpdateColorListView();
				UpdateGridTaskList();
			}
			else
				MessageBox.Show("이미 추가된 색상입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void BtnColorRemove_Click(object sender, EventArgs e)
		{
			if (LVColorList.SelectedItems.Count != 0)
				PickedColors.RemoveAt(LVColorList.SelectedIndices[0]);

			UpdateColorListView();
			UpdateGridTaskList();
		}

		private string FolderSelect(string titleStr)
		{
			CustomizedFolderBrowser cfb = new()
			{
				Title = titleStr
			};

			if (cfb.ShowDialog(this.Handle) == true)
				return cfb.ResultPath;

			return "";
		}

		private void RGBTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
			{
				e.Handled = true;
			}
		}

		private void PBColorPreview_BackColorChanged(object sender, EventArgs e)
		{
			ColorName = Color.FromArgb(RValue, GValue, BValue).Name;
		}

		private void GridTaskList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			var grid = sender as DataGridView;
			var rowIdx = (e.RowIndex + 1).ToString();

			var centerFormat = new StringFormat()
			{
				// right alignment might actually make more sense for numbers
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};

			var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid!.RowHeadersWidth, e.RowBounds.Height);
			e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
		}

		private void GridTaskList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			GridTaskList.ClearSelection();
			SetGridColor();
		}
	}

	public static class CSVUtlity
	{
		public static void ToCSV(this DataTable dtDataTable, string strFilePath, string? sortField = null)
		{
			if (sortField != null)
			{
				dtDataTable.DefaultView.Sort = $"{sortField} ASC";
				dtDataTable = dtDataTable.DefaultView.ToTable();
			}

			StreamWriter sw = new StreamWriter(strFilePath, false, System.Text.Encoding.GetEncoding("utf-8"));

			//headers    
			for (int i = 0; i < dtDataTable!.Columns.Count; i++)
			{
				sw.Write(dtDataTable.Columns[i].ToString().Replace("\r\n", " "));

				if (i < dtDataTable.Columns.Count - 1)
				{
					sw.Write(",");
				}
			}

			sw.Write(sw.NewLine);

			foreach (DataRow dr in dtDataTable!.Rows)
			{
				for (int i = 0; i < dtDataTable.Columns.Count; i++)
				{
					if (!Convert.IsDBNull(dr[i]))
					{
						string? value = dr[i].ToString();

						if (value!.Contains(','))
						{
							value = String.Format("\"{0}\"", value);
							sw.Write(value);
						}
						else
							sw.Write(dr[i].ToString());
					}
					if (i < dtDataTable.Columns.Count - 1)
						sw.Write(",");
				}
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
	}
}