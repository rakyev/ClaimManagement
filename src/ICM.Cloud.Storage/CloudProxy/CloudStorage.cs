using System;
using System.Collections.Generic;
using System.Configuration;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace ICM.Cloud.Storage.CloudProxy
{
    public class CloudStorage
    {

        private static CloudIdentity _cloudIdentity;
        private static readonly string ContainerName = ConfigurationManager.AppSettings["containerName"];
        private static readonly string OutputPath = ConfigurationManager.AppSettings["outputPath"];


        public static string GetFilePath()
        {
            return OutputPath;
        }

        private static CloudIdentity CreateId()
        {
            return _cloudIdentity ?? (_cloudIdentity = new CloudIdentity
            {
                Username = ConfigurationManager.AppSettings["cloudUsername"],
                APIKey = ConfigurationManager.AppSettings["cloudApiKey"]
            });
        }

        public static CloudIdentity GetCloudId()
        {
            CreateId();
            return _cloudIdentity;
        }


        public static bool IsContainerExist(string containerName, CloudIdentity cloudId)
        {
            try
            {
                CloudFilesProvider cfp = new CloudFilesProvider(cloudId);
                Dictionary<string, string> cdnHeaders = cfp.GetContainerHeader(containerName);
                return true;
            }
            catch (Exception ex)
            {
                // Container does not exist
                return false;
            }
        }

        public static bool CreateContainer(string containername)
        {
            bool containerStatus = true;
            try
            {
                CloudFilesProvider cfp = new CloudFilesProvider(CreateId());
                if (!IsContainerExist(containername, CreateId()))
                {
                    ObjectStore objstr = cfp.CreateContainer(containername);
                }
            }
            catch (Exception ex)
            {
                containerStatus = false;
                //throw ex;
            }

            return containerStatus;
        }

        public static bool UploadFile(string filepath = null,string fileName = null)
        {
            bool uploadStatus = true;
            try
            {
                CloudFilesProvider cfp = new CloudFilesProvider(CreateId());
                if (string.IsNullOrEmpty(filepath))
                {
                    uploadStatus = false;
                }
                if (string.IsNullOrEmpty(ContainerName))
                {
                    uploadStatus = false;
                }
                if (string.IsNullOrEmpty(fileName))
                {
                    uploadStatus = false;
                }
                cfp.CreateObjectFromFile(ContainerName,filepath, fileName);
            }
            catch (Exception ex)
            {
                uploadStatus = false;
                //throw ex;
            }

            return uploadStatus;
        }

        public static void DownloadFile(string fileName)
        {
            var cloudFilesProvider = new CloudFilesProvider(CreateId());
            cloudFilesProvider.GetObjectSaveToFile(ContainerName, OutputPath, fileName);
            
        }

    
    }
}
