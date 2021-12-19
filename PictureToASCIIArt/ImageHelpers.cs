using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Common;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Color = System.Drawing.Color;
using Size = System.Drawing.Size;

namespace PictureToASCIIArt;

public static class ImageHelpers
{
	public static Image<Rgba32> ScaleImage(this Image<Rgba32> image, int maxWidth, int maxHeight)
	{
		double ratioX = (double)maxWidth / image.Width;
		double ratioY = (double)maxHeight / image.Height;
		double ratio = Math.Min(ratioX, ratioY);

        int newWidth = (int)(image.Width * ratio);
		int newHeight = (int)(image.Height * ratio);

		image.Mutate(x => x.Resize(newWidth, newHeight));

		return image;
	}

	public static Image<Rgba32> ToGrayscale(this Image<Rgba32> input, int maxWidth, int maxHeight)
	{
		Image<Rgba32> resized = input.ScaleImage(maxWidth, maxHeight);
		resized.Mutate(x => x.Resize(resized.Width * 2, resized.Height).Grayscale());

		return resized;
	}

	public static int[,] ToIntRange(this Image<Rgba32> input)
	{
		int width = input.Width;
		int height = input.Height;

		int[,] array2d = new int[width, height];

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				Rgba32 cl = input[x, y];

                int gray = (cl.R + cl.G + cl.B) / 3;

				array2d[x, y] = gray;
			}
		}

		return array2d;
	}
}
