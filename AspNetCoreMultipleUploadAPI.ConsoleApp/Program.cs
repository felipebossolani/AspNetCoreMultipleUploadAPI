using AspNetCoreMultipleUploadAPI.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace AspNetCoreMultipleUploadAPI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sleep for 5 seconds.");
            Thread.Sleep(5000);
            /*try
            {*/
                var fileInfos = new List<FileInfo>() {
                    new FileInfo(@"C:\temp\upload\google.png"),
                    new FileInfo(@"C:\temp\upload\facebook.png"),
                    new FileInfo(@"C:\temp\upload\twitter.png")
                };
                var uploadRestClientModel = new UploadRestClientModel();
                var result = uploadRestClientModel.Upload(fileInfos).Result;
                var fileResults = result.Content.ReadAsAsync<List<FileResult>>().Result;
                Console.WriteLine("Status: " + result.StatusCode);
                foreach (var fileResult in fileResults)
                {
                    Console.WriteLine("File name: " + fileResult.Name);
                    Console.WriteLine("File size: " + fileResult.Length);
                    Console.WriteLine("====================");
                }
            /*}
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            */
            Console.ReadLine();
        }    
    }
}
