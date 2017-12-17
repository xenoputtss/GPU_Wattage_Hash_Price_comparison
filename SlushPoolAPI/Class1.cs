namespace SlushPoolAPI
{
    using System.Linq;
    using Newtonsoft.Json;
    using RestSharp;
    using System.Collections.Generic;
    using System;

    public static class SlushPoolAPI
    {
        private static RestClient _client = new RestClient("https://slushpool.com");

        private static (bool IsSuccess, PoolBlockHistoryRootResponse.r0) _Get_Pool_Block_History(int count)
        {
            var request = new RestRequest("api/v1/web/scalar/tree/", Method.POST);

            var requestbody = new PoolBlockHistoryRootRequest()
            {
                btc = new PoolBlockHistoryRootRequest.Btc()
                {
                    blocks = new PoolBlockHistoryRootRequest.Blocks()
                    {
                        item_count = 1,
                        items = new Dictionary<string, string>() { { count.ToString(), null } }
                    }
                },
                time = 1,
                last_deploy = 1
            };
            var json = request.JsonSerializer.Serialize(requestbody);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            var response = _client.Execute(request);
            var content = response
               .Content;
            var o = JsonConvert.DeserializeObject<PoolBlockHistoryRootResponse>(content);

            if (o.status_code == 0)
                return (true, o.data.btc.blocks.items.First().Value);
            else
                return (false, null);
        }

        public static (bool IsSuccess, List<PoolBlockHistoryRootResponse.PoolBlockHistoryDataItem> rounds) Get_Pool_Block_History()
        {
            var list = new List<PoolBlockHistoryRootResponse.PoolBlockHistoryDataItem>();

            while (true)
            {
                var (IsSuccess, r) = _Get_Pool_Block_History(list.Count());
                if (!IsSuccess)
                    break;

                list.AddRange(r.data.data.Select(item =>
                {
                    return new PoolBlockHistoryRootResponse.PoolBlockHistoryDataItem()
                    {
                        id = item[(int)PoolBlockHistoryRootResponse.keys.id].Parse<int>(),
                        found_at = item[(int)PoolBlockHistoryRootResponse.keys.found_at].Parse<int>().ConvertToDateTime(),
                        duration = TimeSpan.FromSeconds(item[(int)PoolBlockHistoryRootResponse.keys.duration].Parse<int>()),
                        total_shares = item[(int)PoolBlockHistoryRootResponse.keys.total_shares].Parse<long>(),
                        value = item[(int)PoolBlockHistoryRootResponse.keys.value].Parse<double>(),
                        height = item[(int)PoolBlockHistoryRootResponse.keys.height].Parse<int>(),
                        difficulty = item[(int)PoolBlockHistoryRootResponse.keys.difficulty].Parse<long>(),
                        hash = item[(int)PoolBlockHistoryRootResponse.keys.hash].ToString(),
                        luck_perc = item[(int)PoolBlockHistoryRootResponse.keys.luck_perc].Parse<double>(),
                        pool_scoring_hashrate = item[(int)PoolBlockHistoryRootResponse.keys.pool_scoring_hashrate].Parse<double?>(),
                        state = item[(int)PoolBlockHistoryRootResponse.keys.state].ToString(),
                        to_confirm = item[(int)PoolBlockHistoryRootResponse.keys.to_confirm].ToString() == "0"
                    };
                }).ToList());
            }

            return (true, list);
        }
        public static DateTime ConvertToDateTime(this int seconds)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(seconds);
        }
    }

    public static class StringExtensions
    {
        public static T Parse<T>(this object input)
        {
            if (input == null) return default(T);
            return (T)System.Convert.ChangeType(input, System.Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }
    }

    public class PoolBlockHistoryRootResponse
    {
        public Data data { get; set; }
        public string error_message { get; set; }
        public int status_code { get; set; }

        public class Data
        {
            public Btc btc { get; set; }
            public int last_deploy { get; set; }
            public int time { get; set; }
        }

        public class Btc
        {
            public Blocks blocks { get; set; }
        }

        public class Blocks
        {
            public int item_count { get; set; }
            public Dictionary<int, r0> items { get; set; }
        }

        public class r0
        {
            public long checksum { get; set; }
            public Data1 data { get; set; }
        }

        public class Data1
        {
            //    public bool $_complete { get; set; }
            //public string $_format { get; set; }
            public IList<IList<object>> data { get; set; }
            public IList<string> keys { get; set; }
        }
        public class PoolBlockHistoryDataItem
        {
            public int id { get; set; }
            public DateTime found_at { get; set; }
            public TimeSpan duration { get; set; }
            public long total_shares { get; set; }
            public double value { get; set; }
            public int height { get; set; }
            public long difficulty { get; set; }
            public string hash { get; set; }
            public double luck_perc { get; set; }
            public double? pool_scoring_hashrate { get; set; }
            public string state { get; set; }
            public bool to_confirm { get; set; }
        }
        public enum keys
        {
            id = 0,
            found_at,
            duration,
            total_shares,
            value,
            height,
            difficulty,
            hash,
            luck_perc,
            pool_scoring_hashrate,
            state,
            to_confirm
        }
    }

    public class PoolBlockHistoryRootRequest
    {
        public Btc btc { get; set; }
        public int time { get; set; }
        public int last_deploy { get; set; }

        public class Blocks
        {
            public int item_count { get; set; }
            public Dictionary<string, string> items { get; set; }
        }

        public class Btc
        {
            public Blocks blocks { get; set; }
        }
    }
}
