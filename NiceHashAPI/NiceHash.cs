namespace NiceHashAPI
{
    using RestSharp;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public static class NiceHash
    {
        private static RestClient _client = new RestClient("https://api.nicehash.com/");
        private static string _HardwareCacheFileName = "HardwareData.json";
        public static void ClearCacheFiles()
        {
            System.IO.File.Delete(_HardwareCacheFileName);
            foreach (var f in System.IO.Directory.EnumerateFiles(".", "CalculatorData*.json"))
                System.IO.File.Delete(f);
        }

        public static List<GPU_Data> Get_HardwareData()
        {
            var content = string.Empty;

            if (!System.IO.File.Exists(_HardwareCacheFileName))
            {
                var request = new RestRequest("nicehashminer?method=hwdata&callback=callbackName", Method.GET);
                var response = _client.Execute(request);
                content = response
                   .Content
                   .Replace("callbackName(", "")
                   .Replace(");", "");
                System.IO.File.WriteAllText(_HardwareCacheFileName, content);
            }
            else
            {
                content = System.IO.File.ReadAllText($"HardwareData.json");
            }
            return JsonConvert.DeserializeObject<List<GPU_Data>>(content);
        }

        public static CalculatorData Get_CalculateProfitability(GPU_Data gpu, double kwhCost)
        {
            var content = string.Empty;

            if (!System.IO.File.Exists($"CalculatorData{gpu.id}.json"))
            {
                var request = new RestRequest("calc", Method.POST);
                request.AddParameter("hwname", gpu.name);
                request.AddParameter("icost", gpu.price);
                request.AddParameter("power", gpu.power);
                for (int i = 0; i <= 29; i++)
                    request.AddParameter("fa" + i, i < gpu.speeds.Length ? gpu.speeds[i] : 0.00);
                request.AddParameter("elcost", kwhCost);//Cost per KW/h of electricty
                request.AddParameter("recaptcha_challenge_field", "03AOmkcwJu0x6Q5za0WhctZ9JQih-XTTW_W8tVWjYq9ox0fgAXQuPo3qFtVfZ8moXJv_W1hYkMmCYaHF_m53J599FFnWdQdVfvr-QFcnGQ3TTYS5Ozp_2L6JkwLfosP-2VCbKYIPFXWyg7gkMdXE7s81wLQgjkyZliSgeWf0sDealbO0JpKVW5mpJH0TZfuy31fAUrmNCBBdW3");
                request.AddParameter("recaptcha_response_field", "");

                var response = _client.Execute(request);
                content = response.Content;
                System.IO.File.WriteAllText($"CalculatorData{gpu.id}.json", content);
            }
            else
            {
                content = System.IO.File.ReadAllText($"CalculatorData{gpu.id}.json");
            }
            var o = JsonConvert.DeserializeObject<CalculatorData>(content);
            return o;
        }
        public class GPU_Data
        {
            public int id { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public double power { get; set; }
            public double[] speeds { get; set; }
        }
        public class CalculatorData
        {
            public object error { get; set; }
            public double btc_rate { get; set; }
            public int current_algo { get; set; }
            public double current_prof { get; set; }
            public List<List<double>> past { get; set; }
        }
    }


}
