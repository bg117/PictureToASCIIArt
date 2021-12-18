using System.Drawing;
using PictureToASCIIArt;

if (!OperatingSystem.IsWindows())
{
    Console.WriteLine("This app doesn't work on operating systems other than Windows.");
    return;
}

const string helpMessage =
    "Flags:\n\n--render-file:<image-file> : Convert <image-file> to ASCII art\n\tExample usage: --render-file:image.jpg\n\n\tOptional\n\t--to:<file-path> : Write the ASCII art to <file-path>";

if (0 < args.Length)
{
    string[] options = args[0].Split(':', 2);

    switch (options[0])
    {
        case "--render-file":
            bool exportToFile = false;
            string? file = null;

            if (1 < args.Length)
            {
                string[] exportOptions = args[1].Split(':', 2);
                file = exportOptions[1];
                exportToFile = true;
            }

            Bitmap bmp = new(options[1]);
            int[,] intRange = bmp.ToGrayscale().ToIntRange();
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