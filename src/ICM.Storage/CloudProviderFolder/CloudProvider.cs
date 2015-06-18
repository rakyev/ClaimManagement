using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Policy;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using ICM.Storage.Proxy;
namespace ICM.Storage.CloudProviderFolder
{
    public class CloudProvider
    {
        private static CloudProvider _cloudProvider;
       
        public static CloudProvider GetCloudProviderInstance()
        {
            return _cloudProvider ?? (_cloudProvider = new CloudProvider());
        }

        //upload file
        public Boolean UploadFile(string filepath, string containerName, string objectName)
        {
            CloudFilesProvider cloudFilesProvider = StorageProxy.GetCloudFilesProviderInstance();
            bool fileFlag = File.Exists(filepath);

            if (fileFlag)
            {
                try
                {
                    cloudFilesProvider.CreateObjectFromFile(containerName, filepath, objectName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }
            else
            {
                //file path does not exist
                return false;
            }
        }


        //checks if container exist, a private/static method.
        private static bool IsContainerExist(string containerName)
        {
            try
            {
                CloudFilesProvider cloudFilesProvider = StorageProxy.GetCloudFilesProviderInstance();
                Dictionary<string, string> cdnHeaders = cloudFilesProvider.GetContainerHeader(containerName);
                return true;
            }
            catch (Exception ex)
            {
                // Container does not exist
                return false;
            }
        }

        //create a container
        public void CreateContainer(string containername)
        {
            //CloudIdentity cloudIdentity = StorageProxy.GetCloudIdentity();
            try
            {

                if (!IsContainerExist(containername))
                {
                    //TODO - ObjectStore return from creating a container...might need to use the reference later
                    CloudFilesProvider cloudFilesProvider = StorageProxy.GetCloudFilesProviderInstance();
                    ObjectStore objstr = cloudFilesProvider.CreateContainer(containername);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //todo- need to look into this method again
        public Boolean RunUpload(string containerName, string filePath, string objectName)
        {
            //CloudIdentity cloudId = CreateIdentity();
            Boolean filePathStatus = UploadFile(filePath, containerName, objectName);

            //returns true if file path exist and false if file path doesn't exist
            return filePathStatus;
        }


        //Downloads file 
        public bool DownloadFile(string containerName, string outputPath, string objectName)
        {
            if (Directory.Exists(outputPath))
            {
                var cloudFilesProvider = StorageProxy.GetCloudFilesProviderInstance();
                cloudFilesProvider.GetObjectSaveToFile(containerName, outputPath, objectName);

                //path exists
                return true;
            }
            else
            {
                //paths does not exist
                return false;
            }
        }


        //Deletes file
        public static void DeleteFile(string containerName, string objectName)
        {

            var cloudFilesProvider = StorageProxy.GetCloudFilesProviderInstance();
            cloudFilesProvider.DeleteObject(containerName, objectName);
        }

        //Delete container
        public void DeleteContainer(string containerName)
        {
            var cloudFilesProvider = StorageProxy.GetCloudFilesProviderInstance();
            cloudFilesProvider.DeleteContainer(containerName);
        }

        
    }
}
