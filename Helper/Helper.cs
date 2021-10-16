using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace tes_extramile.api.Helper
{
    public class Helper
    {
    }
    public class HelperApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/");
            return client;
        }
    }
}
 