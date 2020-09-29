using System;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace binaryconv
{
    class Program
    {
        const int BytesInRow = 7;
        const int PixelsInByte = 8;

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please pass bitmap file name as argument, exiting");
                return;
            }

            using (var image = Image.Load(args[0]).CloneAs<Bgr24>())
            {
                int bitIndex = 0;
                int byteIndex = 0;
                char[] byteString = new char[8];
                StringBuilder sb = new StringBuilder();

                for (int clear = 0; clear < PixelsInByte; clear++)
                {
                    byteString[clear] = '0';
                }

                sb.AppendLine("#define image_width " + image.Width.ToString());
                sb.AppendLine("#define image_height " + image.Height.ToString());
                sb.AppendLine("const uint8_t PROGMEM image_data[] = {");
                sb.Append("   ");

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var pixel = image[x, y];

                        byteString[bitIndex++] = pixel.B > 0 ? '1': '0';

                        if (bitIndex >= PixelsInByte)
                        {
                            bitIndex = 0;
                            byteIndex++;

                            sb.Append(" B" + new string(byteString) + ",");
                        }

                        if (byteIndex >= BytesInRow)
                        {
                            sb.Append("\r\n   ");

                            byteIndex = 0;

                            for (int clear = 0; clear < PixelsInByte; clear++)
                            {
                                byteString[clear] = '0';
                            }
                        }
                    }
                }

                sb.AppendLine("\r\n};");

                string outputName = "output.h";

                if (args.Length > 1) outputName = args[1];

                File.WriteAllText(
                    Path.Combine(Path.GetDirectoryName(args[0]), outputName),
                    sb.ToString());
            }
        }
    }
}
