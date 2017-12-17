namespace NiceHashAPI
{
    using RestSharp;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public static class LiveMarket
    {
        private static RestClient _client = new RestClient("https://www.nicehash.com/");

        private static List<Order> GetLiveMarketData(Locations location, Algorithms algorithm)
        {
            var content = string.Empty;

            var request = new RestRequest($"api?method=orders.get&location={(int)location}&algo={(int)algorithm}", Method.GET);
            var response = _client.Execute(request);
            content = response.Content;

            var rawData = JsonConvert.DeserializeObject<OrdersRootObject>(content);
            foreach (var o in rawData.result.orders)
                o.location = location;

            return rawData.result.orders;

        }

        public static List<Order> GetLiveMarketData(Algorithms algorithm)
        {
            var liveData = new List<Order>();
            liveData.AddRange(NiceHashAPI.LiveMarket.GetLiveMarketData(Locations.Europe, algorithm));
            liveData.AddRange(NiceHashAPI.LiveMarket.GetLiveMarketData(Locations.USA, algorithm));
            return liveData;
        }
    }
}
