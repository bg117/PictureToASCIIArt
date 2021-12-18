using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureToASCIIArt;

public static class ASCII
{
    public static string FromIntRange(int[,] intRange)
    {
        StringBuilder sb = new();

        for (int y = 0; y < intRange.GetLength(1); y++)
        {
            for (int x = 0; x < intRange.GetLength(0); x++)
            {
                int currentPixelIntensity = intRange[x, y];
                switch (currentPixelIntensity)
                {
                    case >= 0 and <= 25:
                        sb.Append('M');
                        break;
                    case >= 26 and <= 50:
                        sb.Append('$');
                        break;
                    case >= 51 and <= 76:
                        sb.Append('o');
                        break;
                    case >= 77 and <= 102:
                        sb.Append('|');
                        break;
                    case >= 103 and <= 127:
                        sb.Append('*');
                        break;
                    case >= 128 and <= 152:
                        sb.Append(':');
                        break;
                    case >= 153 and <= 178:
                        sb.Append('=');
                        break;
                    case >= 179 and <= 204:
                        sb.Append('\'');
                        break;
                    case >= 205 and <= 230:
                        sb.Append('.');
                        break;
                    case >= 231 and <= 255:
                        sb.Append(' ');
                        break;
                }
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}
