using System;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using ICM.Storage.CloudProviderFolder;

namespace ICM.Storage.Proxy
{

    //Singleton class
    public class StorageProxy
    {
        private StorageProxy() { }

        private static CloudIdentity _clouldIdentity;
        private static CloudProvider _cloudProvider;
        private static CloudFilesProvider _cloudFilesProvider;

        public static CloudProvider GetCloudProviderInstance()
        {
            if(_cloudProvider == null)
                _cloudProvider = new CloudProvider();

            return _cloudProvider;
        }

        //creates and returns a ClouldFilesProvider if none exist
        public static CloudFilesProvider GetCloudFilesProviderInstance()
        {
            if (_cloudProvider == null)
            {
                _cloudProvider = new CloudProvider();
            }

            //checks if CloudIdentity exist
            if(_clouldIdentity == null)
                _clouldIdentity = CreateIdentity();

            return _cloudFilesProvider ?? (_cloudFilesProvider = new CloudFilesProvider(_clouldIdentity));
        }

        //getter for cloud Identity
        public static CloudIdentity GetCloudIdentity()
        {
            return _clouldIdentity;
        }


        //creates a Cloud Identity
        private static CloudIdentity CreateIdentity()
        {
            try
            {

                string userName = "femi04"; // System.Configuration.ConfigurationManager.AppSettings["cloudUsername"];
                string apiKey = "cdecd14697214aa782010b500e6d8e24";// System.Configuration.ConfigurationManager.AppSettings["cloudApiKey"];

                _clouldIdentity = new CloudIdentity()
                {
                    Username = userName,
                    APIKey = apiKey
                };

                CloudIdentityProvider bar = new CloudIdentityProvider();
                //UserAccess ua = bar.Authenticate(_clouldIdentity);
                
                return _clouldIdentity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
