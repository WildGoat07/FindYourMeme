using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FindYourMeme
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ApiKey => FindYourMeme.Properties.Resources.Key;
        public static string EngineId { get; } = "2bad711db3c3108e7";
        public static CseResource.ListRequest Request { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var service = new CustomsearchService(new BaseClientService.Initializer
            {
                ApplicationName = "FindYourMeme",
                ApiKey = ApiKey
            });
            Request = service.Cse.List();
            Request.Cx = EngineId;
            Request.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
        }
    }
}