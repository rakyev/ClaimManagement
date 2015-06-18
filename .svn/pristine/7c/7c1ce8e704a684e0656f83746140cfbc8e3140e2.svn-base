using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICM.Storage.CloudProviderFolder;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //string containerName = ConfigurationManager.AppSettings["ContainerName"];
            string path1 = @"C:\Users\Femi\Desktop\Jobs\Femi_SoyomboResume.docx";
            //var store = CloudProvider.GetCloudProviderInstance();
            //var upload = store.UploadFile(path1,containerName,"femi.docx");
            CloudProvider pp = new CloudProvider();

            pp.UploadFile(path1, "femi", "femi.docx");
            Console.ReadKey();
        }
    }
}
