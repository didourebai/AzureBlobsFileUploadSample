using System.Web.Http.Filters;
using System.Web.Mvc;


namespace AzureBlobsFileUploadSample.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterGlobalApiFilters(HttpFilterCollection filters)
        {
        }
    }
}