using System;
using System.IO;
using System.Threading.Tasks;

namespace Robot
{
    public class Util
    {
        public static async Task<byte[]> ToByteArrayAsync(Stream stream)
        {
            await using (stream)
            {
                await using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        // public static bool IsSmallEnough(this byte[] fileSize,
        // {
        //     if (fileSize.Length > 256000)
        //     {
        //         size = FormatSize(fileSize.LongLength);
        //         return false;
        //     }
        //     size = FormatSize(fileSize.LongLength);
        //     return true;
        // }
        public static string FormatSize(long bytes)
        {
            var suffixes = new[]
            {
                "Bytes",
                "KB",
                "MB",
                "GB",
                "TB",
                "PB"
            };
    
            var counter = 0;
            var number = (decimal) bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return $"{number:n1}{suffixes[counter]}";
        }
    }
}