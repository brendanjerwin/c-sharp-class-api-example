using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace csharpclassapiexample
{
    public class PriceResult
    {
        public Decimal Amount { get; set; }

        public string Currency { get; set; }
    }

    class MainClass
    {
        static RestClient client;

        private static void Configure()
        {
            client = new RestClient("https://coinbase.com/api/v1/");
            client.AddDefaultHeader("API_ACCESS_TOKEN", "asdfjhsdkfjhsdakjhfds");
            client.AddDefaultHeader("CLIENT_VERSION", "asdfsfdsf");
        }

        private static PriceResult GetCurrentPrice()
        {
            var request = new RestRequest("prices/spot_rate", Method.GET);
            request.Timeout = 10;

            return client.Execute<PriceResult>(request).Data;
        }

        public static void Main(string[] args)
        {
            Configure();
            while (true)
            {
                var price = GetCurrentPrice();
                Console.WriteLine("Price: {0}", price.Amount);
                System.Threading.Thread.Sleep(1 * 1000);
            }
        }
    }
}
