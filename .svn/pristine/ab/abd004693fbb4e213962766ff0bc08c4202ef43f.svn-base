using System;
using ICM.Storage.CloudProviderFolder;

namespace CloudTestForOpenStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudProvider cloudProvider = new CloudProvider();
            cloudProvider.CreateContainer("femi");
            string pathString1 = @"c:\tmp";
            string pathString2 = @"c:\tmp\IMG_20141009_063711.jpg";
            cloudProvider.UploadFile(pathString2, "femi", "picture");
            //cloudProvider.DownloadFile("femi", pathString1, "picture");
            //cloudProvider.DeleteContainer("Demo2");
            //Console.WriteLine("Container created");

            Console.ReadKey();
        }
    }
}
