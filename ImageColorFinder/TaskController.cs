using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using OpenCvSharp;

namespace ImageColorFinder
{
	public class TaskController
	{
		public FileInfo? ImageFile { get; private set; }
		public string? Status { get; private set; }
		public Dictionary<string, int>? FinderMap { get; private set; }

		public TaskController(FileInfo imageFile)
		{
			ImageFile = imageFile;
			Status = "Ready";
			FinderMap = new ();
		}

		public void RunColorFinder(List<PickedColor> PickedColors)
		{
			FinderMap!.Clear();

			using Mat src = new(ImageFile!.FullName);

			PickedColors.ForEach(c =>
			{
				Mat range = new ();
				Cv2.InRange(src, new Scalar(c.ColorRGB.B, c.ColorRGB.G, c.ColorRGB.R), new Scalar(c.ColorRGB.B, c.ColorRGB.G, c.ColorRGB.R), range);

				FinderMap!.Add(c.RGBName, Cv2.CountNonZero(range));
			});

			UpdateStatus();
		}

		private void UpdateStatus()
		{
			Status = FinderMap!.All(d => d.Value == 0) ? "Pass" : "Detected";
		}
	}

	public class PickedColor
	{
		public Color ColorRGB { get; private set; }
		public string RGBValue { get { return $"({ColorRGB.R} {ColorRGB.G} {ColorRGB.B})"; } }
		public string RGBName { get { return ColorTranslator.FromHtml("#" + ColorRGB.Name).Name; } }
		public Bitmap ThumbNail { get; private set; }
		
		public PickedColor(Color color)
		{
			ColorRGB = color;
			ThumbNail = DrawColorSymbol(color);
		}

		private static Bitmap DrawColorSymbol(Color fillColor)
		{
			Bitmap bmp = new (24, 24);

			using (var graphics = Graphics.FromImage(bmp))
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillEllipse(new SolidBrush(fillColor), 0, 0, bmp.Width, bmp.Height);
			}

			return bmp;
		}
	}
}
