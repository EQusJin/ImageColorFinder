using System.Drawing;
using System.Windows.Forms;

namespace ImageColorFinder
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			GridTaskList = new DataGridView();
			GBoxSelectPath = new GroupBox();
			BtnSelectPath = new Button();
			TBImagePath = new TextBox();
			GBColorPicker = new GroupBox();
			LblColorName = new Label();
			BtnColorRemove = new Button();
			LVColorList = new ListView();
			LayerImageList = new ImageList(components);
			BtnColorAdd = new Button();
			label3 = new Label();
			PBColorPreview = new PictureBox();
			TBBValue = new TextBox();
			label2 = new Label();
			TBGValue = new TextBox();
			TBRValue = new TextBox();
			label1 = new Label();
			BtnStart = new Button();
			GBTaskList = new GroupBox();
			BtnSave = new Button();
			((System.ComponentModel.ISupportInitialize)GridTaskList).BeginInit();
			GBoxSelectPath.SuspendLayout();
			GBColorPicker.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PBColorPreview).BeginInit();
			GBTaskList.SuspendLayout();
			SuspendLayout();
			// 
			// GridTaskList
			// 
			GridTaskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			GridTaskList.BackgroundColor = SystemColors.Control;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("굴림", 9F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			GridTaskList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			GridTaskList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("굴림", 9F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			GridTaskList.DefaultCellStyle = dataGridViewCellStyle2;
			GridTaskList.Dock = DockStyle.Fill;
			GridTaskList.EditMode = DataGridViewEditMode.EditProgrammatically;
			GridTaskList.Location = new Point(3, 23);
			GridTaskList.Margin = new Padding(3, 4, 3, 4);
			GridTaskList.MultiSelect = false;
			GridTaskList.Name = "GridTaskList";
			GridTaskList.ReadOnly = true;
			GridTaskList.RowHeadersWidth = 51;
			GridTaskList.RowTemplate.Height = 23;
			GridTaskList.ScrollBars = ScrollBars.Vertical;
			GridTaskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			GridTaskList.Size = new Size(1126, 540);
			GridTaskList.TabIndex = 25;
			GridTaskList.ColumnHeaderMouseClick += GridTaskList_ColumnHeaderMouseClick;
			GridTaskList.RowPostPaint += GridTaskList_RowPostPaint;
			// 
			// GBoxSelectPath
			// 
			GBoxSelectPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			GBoxSelectPath.Controls.Add(BtnSelectPath);
			GBoxSelectPath.Controls.Add(TBImagePath);
			GBoxSelectPath.Location = new Point(12, 12);
			GBoxSelectPath.Name = "GBoxSelectPath";
			GBoxSelectPath.Size = new Size(1138, 88);
			GBoxSelectPath.TabIndex = 26;
			GBoxSelectPath.TabStop = false;
			GBoxSelectPath.Text = "최상위 폴더선택";
			// 
			// BtnSelectPath
			// 
			BtnSelectPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSelectPath.Location = new Point(1084, 34);
			BtnSelectPath.Name = "BtnSelectPath";
			BtnSelectPath.Size = new Size(45, 29);
			BtnSelectPath.TabIndex = 27;
			BtnSelectPath.Text = "...";
			BtnSelectPath.UseVisualStyleBackColor = true;
			BtnSelectPath.Click += BtnSelectPath_Click;
			// 
			// TBImagePath
			// 
			TBImagePath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TBImagePath.Location = new Point(24, 35);
			TBImagePath.Name = "TBImagePath";
			TBImagePath.Size = new Size(1054, 27);
			TBImagePath.TabIndex = 0;
			// 
			// GBColorPicker
			// 
			GBColorPicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			GBColorPicker.Controls.Add(LblColorName);
			GBColorPicker.Controls.Add(BtnColorRemove);
			GBColorPicker.Controls.Add(LVColorList);
			GBColorPicker.Controls.Add(BtnColorAdd);
			GBColorPicker.Controls.Add(label3);
			GBColorPicker.Controls.Add(PBColorPreview);
			GBColorPicker.Controls.Add(TBBValue);
			GBColorPicker.Controls.Add(label2);
			GBColorPicker.Controls.Add(TBGValue);
			GBColorPicker.Controls.Add(TBRValue);
			GBColorPicker.Controls.Add(label1);
			GBColorPicker.Location = new Point(18, 106);
			GBColorPicker.Name = "GBColorPicker";
			GBColorPicker.Size = new Size(1132, 205);
			GBColorPicker.TabIndex = 27;
			GBColorPicker.TabStop = false;
			GBColorPicker.Text = "검출 색 설정";
			// 
			// LblColorName
			// 
			LblColorName.Location = new Point(28, 160);
			LblColorName.Name = "LblColorName";
			LblColorName.Size = new Size(102, 25);
			LblColorName.TabIndex = 33;
			LblColorName.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// BtnColorRemove
			// 
			BtnColorRemove.Location = new Point(297, 108);
			BtnColorRemove.Name = "BtnColorRemove";
			BtnColorRemove.Size = new Size(94, 29);
			BtnColorRemove.TabIndex = 32;
			BtnColorRemove.Text = "◀◀";
			BtnColorRemove.UseVisualStyleBackColor = true;
			BtnColorRemove.Click += BtnColorRemove_Click;
			// 
			// LVColorList
			// 
			LVColorList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			LVColorList.BackColor = SystemColors.Control;
			LVColorList.HideSelection = false;
			LVColorList.LargeImageList = LayerImageList;
			LVColorList.Location = new Point(450, 26);
			LVColorList.MultiSelect = false;
			LVColorList.Name = "LVColorList";
			LVColorList.Size = new Size(661, 160);
			LVColorList.SmallImageList = LayerImageList;
			LVColorList.TabIndex = 0;
			LVColorList.UseCompatibleStateImageBehavior = false;
			LVColorList.View = View.Tile;
			// 
			// LayerImageList
			// 
			LayerImageList.ColorDepth = ColorDepth.Depth32Bit;
			LayerImageList.ImageSize = new Size(24, 24);
			LayerImageList.TransparentColor = Color.Transparent;
			// 
			// BtnColorAdd
			// 
			BtnColorAdd.Location = new Point(297, 73);
			BtnColorAdd.Name = "BtnColorAdd";
			BtnColorAdd.Size = new Size(94, 29);
			BtnColorAdd.TabIndex = 31;
			BtnColorAdd.Text = "▶▶";
			BtnColorAdd.UseVisualStyleBackColor = true;
			BtnColorAdd.Click += BtnColorAdd_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(138, 129);
			label3.Name = "label3";
			label3.Size = new Size(26, 20);
			label3.TabIndex = 4;
			label3.Text = "B :";
			// 
			// PBColorPreview
			// 
			PBColorPreview.Location = new Point(28, 55);
			PBColorPreview.Name = "PBColorPreview";
			PBColorPreview.Size = new Size(102, 102);
			PBColorPreview.TabIndex = 1;
			PBColorPreview.TabStop = false;
			PBColorPreview.BackColorChanged += PBColorPreview_BackColorChanged;
			PBColorPreview.Click += PBColorPreview_Click;
			// 
			// TBBValue
			// 
			TBBValue.Location = new Point(170, 126);
			TBBValue.MaxLength = 3;
			TBBValue.Name = "TBBValue";
			TBBValue.Size = new Size(70, 27);
			TBBValue.TabIndex = 30;
			TBBValue.Text = "0";
			TBBValue.TextAlign = HorizontalAlignment.Center;
			TBBValue.KeyPress += RGBTextBox_KeyPress;
			TBBValue.KeyUp += RGBTextBox_KeyUp;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(136, 94);
			label2.Name = "label2";
			label2.Size = new Size(28, 20);
			label2.TabIndex = 3;
			label2.Text = "G :";
			// 
			// TBGValue
			// 
			TBGValue.Location = new Point(170, 91);
			TBGValue.MaxLength = 3;
			TBGValue.Name = "TBGValue";
			TBGValue.Size = new Size(70, 27);
			TBGValue.TabIndex = 29;
			TBGValue.Text = "0";
			TBGValue.TextAlign = HorizontalAlignment.Center;
			TBGValue.KeyPress += RGBTextBox_KeyPress;
			TBGValue.KeyUp += RGBTextBox_KeyUp;
			// 
			// TBRValue
			// 
			TBRValue.Location = new Point(170, 58);
			TBRValue.MaxLength = 3;
			TBRValue.Name = "TBRValue";
			TBRValue.Size = new Size(70, 27);
			TBRValue.TabIndex = 28;
			TBRValue.Text = "0";
			TBRValue.TextAlign = HorizontalAlignment.Center;
			TBRValue.KeyPress += RGBTextBox_KeyPress;
			TBRValue.KeyUp += RGBTextBox_KeyUp;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(138, 61);
			label1.Name = "label1";
			label1.Size = new Size(26, 20);
			label1.TabIndex = 2;
			label1.Text = "R :";
			// 
			// BtnStart
			// 
			BtnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnStart.Enabled = false;
			BtnStart.Location = new Point(1056, 902);
			BtnStart.Name = "BtnStart";
			BtnStart.Size = new Size(94, 29);
			BtnStart.TabIndex = 28;
			BtnStart.Text = "시작";
			BtnStart.UseVisualStyleBackColor = true;
			BtnStart.Click += BtnStart_Click;
			// 
			// GBTaskList
			// 
			GBTaskList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			GBTaskList.Controls.Add(GridTaskList);
			GBTaskList.Location = new Point(18, 330);
			GBTaskList.Name = "GBTaskList";
			GBTaskList.Size = new Size(1132, 566);
			GBTaskList.TabIndex = 29;
			GBTaskList.TabStop = false;
			GBTaskList.Text = "파일 목록";
			// 
			// BtnSave
			// 
			BtnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnSave.Enabled = false;
			BtnSave.Location = new Point(91, 902);
			BtnSave.Name = "BtnSave";
			BtnSave.Size = new Size(94, 29);
			BtnSave.TabIndex = 30;
			BtnSave.Text = "저장(csv)";
			BtnSave.UseVisualStyleBackColor = true;
			BtnSave.Click += BtnSave_Click;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1162, 943);
			Controls.Add(BtnSave);
			Controls.Add(GBColorPicker);
			Controls.Add(GBTaskList);
			Controls.Add(BtnStart);
			Controls.Add(GBoxSelectPath);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(1130, 990);
			Name = "FormMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "정사영상 색상 특이점 검출 프로그램";
			((System.ComponentModel.ISupportInitialize)GridTaskList).EndInit();
			GBoxSelectPath.ResumeLayout(false);
			GBoxSelectPath.PerformLayout();
			GBColorPicker.ResumeLayout(false);
			GBColorPicker.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PBColorPreview).EndInit();
			GBTaskList.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private DataGridView GridTaskList;
		private GroupBox GBoxSelectPath;
		private Button BtnSelectPath;
		private TextBox TBImagePath;
		private GroupBox GBColorPicker;
		private Button BtnColorRemove;
		private Button BtnColorAdd;
		private Label label3;
		private PictureBox PBColorPreview;
		private TextBox TBBValue;
		private Label label2;
		private ListView LVColorList;
		private TextBox TBGValue;
		private TextBox TBRValue;
		private Label label1;
		private Button BtnStart;
		private ImageList LayerImageList;
		private GroupBox GBTaskList;
		private Label LblColorName;
		private Button BtnSave;
	}
}