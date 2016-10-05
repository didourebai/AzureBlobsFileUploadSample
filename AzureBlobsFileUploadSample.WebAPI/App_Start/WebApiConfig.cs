using System;
using System.Web.Http;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using AzureBlobsFileUploadSample.WebAPI.Handlers;
using AzureBlobsFileUploadSample.WebAPI.App_Start;
using System.Text;

namespace AzureBlobsFileUploadSample.WebAPI
{
    public static class WebApiConfig
    {


        public static void Register(HttpConfiguration config)
        {
            //Enabling Cross-Origin Requests in ASP.NET Web API
            config.MessageHandlers.Add(new CorsHandler());

            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //json configuration
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new FirstCharLowercaseContractResolver();
            json.SerializerSettings.Converters.Add(new StringEnumConverter());

            config.EnsureInitialized();

            UnityActionFilterProvider.RegisterFilterProviders(config);
        }
    }

    public class FirstCharLowercaseContractResolver : DefaultContractResolver
    {
        private StringBuilder _propertyNameBuilder;

        protected override string ResolvePropertyName(string propertyName)
        {

            _propertyNameBuilder = new StringBuilder(propertyName);

            return String.Format("{0}{1}", Char.ToLowerInvariant(_propertyNameBuilder[0]), _propertyNameBuilder.Remove(0, 1));
        }
    }
}

