using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace FileDownloader
{
    interface IFileDownloader
    {
        void AddFileToDownloadingQueue(string fileId, string url, string pathToSave);
        event Action<string> OnDownloaded;
        event Action<string, Exception> OnFailed;
    }
     
    public class FileDownloader: IFileDownloader
    {
        
        public delegate void Action(string message);
        public event Action<string> OnDownloaded;            
        public event Action<string, Exception> OnFailed; 
         
        public  async void AddFileToDownloadingQueue(string fileId, string url, string pathToSave)
        {
          
              Console.WriteLine("Downloading " + url);
              Console.WriteLine("Writing to " + pathToSave);
              var httpClient = new HttpClient();
              byte[] fileBytes = await httpClient.GetByteArrayAsync(url);
              Console.WriteLine($"{url,-60} {fileBytes.Length,10:#,#}"); 
              File.WriteAllBytes(pathToSave, fileBytes); 
              try
              {

                  OnDownloaded?.Invoke($"Downloaded ");

              }
              catch (Exception e)
              {
                  Console.WriteLine(e);
                  OnFailed?.Invoke($"Failed ", e);
                  throw;
              }
              
        }

    }
}