using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;

namespace Sims4CLI
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        static void Main(string[] args)
        {

            Console.Title = "Moving mods - Sims4";
            Console.ForegroundColor = ConsoleColor.Green;
            string MyString1 = ""; //Downloaded Mods
            string MyString2 = ""; //Mods folder
            string MyString3 = ""; //Zip files location for extraction

            Console.WriteLine("Enter the mod folder location: "); //Set mods folder location first
            MyString1 = Console.ReadLine();
            Console.WriteLine("\r\nYour mod folder location is: " + MyString1); 

            Console.WriteLine("\r\nEnter the downloaded Sims 4 mods location: "); //Set Download mods location second.
            MyString2 = Console.ReadLine();
            Console.WriteLine("\r\n\r\nYour entered location is: " + MyString2);


            Console.WriteLine("Moving downloaded mods to folder now");
           // Console.ReadKey();
            System.Threading.Thread.Sleep(5);
            Console.Clear();

            //Credits to https://stackoverflow.com/questions/206323/how-to-execute-command-line-in-c-get-std-out-results -Cameron

            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = @"/c cd /d " + MyString2 + " && " + "xcopy /F /y" + " " + "*.package" + " " + '\u0022' + MyString1 + '\u0022';
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.UseShellExecute = false;
            p.OutputDataReceived += (a, b) => Console.WriteLine(b.Data);
            p.ErrorDataReceived += (a, b) => Console.WriteLine(b.Data);
            p.Start();
            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
            p.WaitForExit();
            Console.WriteLine("Press any button to continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Are there any zip files? Type Y or N");
            string option = Console.ReadLine();
            if (option == "Y")
            {
                Console.WriteLine("Confirmed. Continue to next prompt.");
                Console.Clear();
                Console.WriteLine("Enter the Archived Files location: ");
                MyString3 = Console.ReadLine();

                Environment.CurrentDirectory = "C:\\Users\\KevinPham\\Downloads";
                string remoteUri = "http://stahlworks.com/dev/";
                string fileName = "unzip.exe", myStringWebResource = null;
                WebClient myWebClient = new WebClient();
                // Concatenate the domain with the Web resource filename.
                myStringWebResource = remoteUri + fileName;
                Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(myStringWebResource, fileName);
                Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
                //Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t");
                System.Threading.Thread.Sleep(2);
                //Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Unzipping Files now");
                var UnZpi = "C:\\Users\\KevinPham\\Downloads\\unzip.exe";
                //Process.Start(UnZpi + MyString3 + "*.zip " + " -d "+ MyString1);
                //ProcessStartInfo info = new ProcessStartInfo(UnZpi + " " + MyString3 + "\\*.zip" + " -d " + MyString1);

                //Process.Start(UnZpi + " " + MyString3 + "\\*.zip" + " -d " + MyString1);
                //string zipextract;
                //        zipextract = "/k e " + " " + MyString3 +  "-o" + MyString2;
                //        Debug.WriteLine(@"C:\Program Files\7-Zip\7z.exe", zipextract);
                //}



                var x = new Process();
                x.StartInfo.FileName = "cmd.exe";
                x.StartInfo.Arguments = @"/c" + UnZpi + " " + MyString3 + "\\*.zip" + " -d " + MyString1;
                x.StartInfo.CreateNoWindow = true;
                x.StartInfo.RedirectStandardError = true;
                x.StartInfo.RedirectStandardOutput = true;
                x.StartInfo.RedirectStandardInput = false;
                x.StartInfo.UseShellExecute = false;
                x.OutputDataReceived += (a, b) => Console.WriteLine(b.Data);
                x.ErrorDataReceived += (a, b) => Console.WriteLine(b.Data);
                x.Start();
                x.BeginErrorReadLine();
                x.BeginOutputReadLine();
                x.WaitForExit();
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Console.Clear();


                if (option == "N")
                {
                    Console.Read();
                    Console.Clear();
                    Console.WriteLine("My work is done. Goodbye");
                }

                Console.ReadKey();
            }
        }
    }
}
