using System.Drawing;
using System.Text.RegularExpressions;
using PictureToASCIIArt;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

const string helpMessage =
	"Flags:\n\n--render-file:<image-file> : Convert <image-file> to ASCII art\n\tExample usage: --render-file:image.jpg\n\n\tOptional flags:\n\t--to:<file-path> : Write the ASCII art to <file-path>.\n\t--max-width:<int> : Sets <int> as the maximum width of the ASCII art. Only numbers accepted.\n\t--max-height:<int> : Sets <int> as the maximum height of the ASCII art. Only numbers accepted.";

if (0 < args.Length)
{
	string[] options = args[0].Split(':', 2);

	switch (options[0])
	{
		case "--render-file":
			Image<Rgba32> bmp = Image.Load<Rgba32>(options[1]);

			bool exportToFile = false;
			string? file = null;

			int maxWidth = bmp.Width;
			int maxHeight = 200;

			if (args.Contains(@"--to:(.+)"))
			{
				string[] exportOptions = args.FirstOf(@"--to:(.+)").Split(':', 2);

				if (exportOptions[0] == "--to")
				{
					file = exportOptions[1];
					exportToFile = true;
				}
			}

			if (args.Contains(@"--max-width:(\d+)"))
			{
				string[] maxWidthOptions = args.FirstOf(@"--max-width:(\d+)").Split(':', 2);

				if (maxWidthOptions[0] == @"--max-width")
					maxWidth = int.Parse(maxWidthOptions[1]);
			}

			if (args.Contains(@"--max-height:(\d+)"))
			{
				string[] maxHeightOptions = args.FirstOf(@"--max-height:(\d+)").Split(':', 2);

				if (maxHeightOptions[0] == "--max-height")
					maxHeight = int.Parse(maxHeightOptions[1]);
			}

			int[,] intRange = bmp.ToGrayscale(maxWidth, maxHeight).ToIntRange();
			string ascii = ASCII.FromIntRange(intRange);

			if (!string.IsNullOrEmpty(ascii))
			{
				if (exportToFile && file != null)
					File.WriteAllText(file, ascii);
				else
					Console.WriteLine(ascii);
			}

			break;
		default:
			Console.WriteLine(helpMessage);
			break;
	}
}
else
{
	Console.WriteLine(helpMessage);
}