using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureToASCIIArt;

public static class BitmapHelpers
{
    public static Bitmap ScaleBitmap(this Bitmap bitmap, int maxWidth, int maxHeight)
    {
        double ratioX = (double)maxWidth / bitmap.Width;
        double ratioY = (double)maxHeight / bitmap.Height;
        double ratio = Math.Min(ratioX, ratioY);

        int newWidth = (int)(bitmap.Width * ratio);
        int newHeight = (int)(bitmap.Height * ratio);

        Bitmap newImage = new(newWidth, newHeight);

        using Graphics graphics = Graphics.FromImage(newImage);
        graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);

        return newImage;
    }

    public static Bitmap ToGrayscale(this Bitmap input, int maxWidth, int maxHeight)
    {
        Bitmap resized = input.ScaleBitmap(maxWidth, maxHeight);
        Bitmap grayscale = new(resized, new Size(resized.Width * 2, resized.Height));

        for (int x = 0; x < grayscale.Width; x++)
        {
            for (int y = 0; y < grayscale.Height; y++)
            {
                Color pixelColor = grayscale.GetPixel(x, y);
                int gray = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                grayscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, gray, gray, gray));
            }
        }

        return grayscale;
    }

    public static int[,] ToIntRange(this Bitmap input)
    {
        int width = input.Width;
        int height = input.Height;

        int[,] array2d = new int[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color cl = input.GetPixel(x, y);

                int gray = (int)Convert.ChangeType((cl.R * 0.3) + (cl.G * 0.59) + (cl.B * 0.11), typeof(int));

                array2d[x, y] = gray;
            }
        }

        return array2d;
    }
}
