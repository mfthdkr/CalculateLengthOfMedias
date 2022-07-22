using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            // Bütün ses kayıtları
           string[] filePathListAll =
                Directory.GetFiles(@"");

            // EndOfFile dosyaları
            string[] filePathListWithEndOfFile =
                Directory.GetFiles(@"").Where(p=>p.Contains("EndOfFile")).ToArray();


            // EndOfFile dosyaları çıkarılmış şekilde
            string[] filePathList = filePathListAll.Except(filePathListWithEndOfFile).ToArray();

            // ölçümleri dosya boyutu(byte) ile yaptım. Burası bitti
            #region CalculateWithFileSize

            long _15Sn = 60536;
            long _360Sn = 1452875;
            long _60Sn = 243784;
            double hakedisdDkForFileSize = 0;

            
            var fileLengthList = filePathList.Select(x => new FileInfo(x).Length);
            foreach (var fileLength in fileLengthList)
            {
                if (fileLength >= _15Sn)
                {
                    if (fileLength >= _360Sn)
                    {
                        hakedisdDkForFileSize += Convert.ToDouble(_360Sn) / Convert.ToDouble(_60Sn);
                    }
                    else
                    {
                        hakedisdDkForFileSize += Convert.ToDouble(fileLength) / Convert.ToDouble(_60Sn);
                    }
                }

            }

            Console.WriteLine("Hakediş Dakikası: " + Convert.ToInt32(hakedisdDkForFileSize));

            #endregion


            // Ses dosyasının uzunluğu ile ölçüm yapıcam. Henüz bitmedi
            #region CalculateWithDurationOfFile

            if (false)
            {
                string test = @"C:\Users\MUHAMMET FATİH DİKER\Desktop\test";

                Console.WriteLine("Kayıt süresi : " + GetVideoDuration(test));

                TimeSpan GetVideoDuration(string filePath)
                {
                    using (var shell = ShellObject.FromParsingName(filePath))
                    {
                        IShellProperty prop = shell.Properties.System.Media.Duration;
                        var t = (ulong)prop.ValueAsObject;
                        return TimeSpan.FromTicks((long)t);
                    }
                }
            }
            
            #endregion
            
            Console.ReadLine();

        }
    }
}
