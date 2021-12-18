using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureToASCIIArt;

public static class GrayscaleConverter
{
    public static Bitmap ToGrayscale(this Bitmap input)
    {
        Bitmap grayscale = new(input, new Size(input.Width * 2, input.Height));

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
