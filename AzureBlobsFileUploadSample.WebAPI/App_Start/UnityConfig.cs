using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using System.Web.Http;
using AzureBlobsFileUploadSample.WebAPI.Controllers;

namespace AzureBlobsFileUploadSample.WebAPI
{
    public static class UnityConfig
    {
        private static IUnityContainer _currentContainer;

        private static object _lock = new object();

        public static IUnityContainer CurrentContainer
        {
            get
            {
                if (_currentContainer == null)
                {
                    lock (_lock)
                    {
                        if (_currentContainer == null)
                        {
                            _currentContainer = new UnityContainer();
                        }
                    }
                }
                return _currentContainer;
            }
        }

        public static void RegisterComponents()
        {
            ConfigureContainer();
        

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(CurrentContainer);
        }

      

        private static void ConfigureContainer()
        {
            // Controllers
            CurrentContainer.RegisterType<FilesController>();   

        }

    
    }
}
