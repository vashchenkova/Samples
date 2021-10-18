using System;
using FileDownloader; 
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileDownloaderDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logFile = File.ReadAllLines("C:/Users/Olga_Vashchenkova/RiderProjects/FileDownloader/Download/urls-list.txt");
            var logList = new List<string>(logFile);
            foreach(var s in logFile)
            {
                var filename = s.Substring(s.LastIndexOf("/")+1, s.Length-s.LastIndexOf("/")-1);
                // Do whatever you need
                var downloadFile = new FileDownloader.FileDownloader();
                downloadFile.AddFileToDownloadingQueue("",s,"C:/Users/Olga_Vashchenkova/RiderProjects/FileDownloader/Download/"+filename);
                
            }
        
        }
    }
}