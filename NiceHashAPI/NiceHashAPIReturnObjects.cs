namespace NiceHashAPI
{
    using System.Collections.Generic;

    public class Order
    {
        public string limit_speed { get; set; }
        public bool alive { get; set; }
        public string price { get; set; }
        public int id { get; set; }
        public int type { get; set; }
        public int workers { get; set; }
        public int algo { get; set; }
        public string accepted_speed { get; set; }
        public Locations location { get; set; }
    }

    public class Result
    {
        public List<Order> orders { get; set; }
        public int timestamp { get; set; }
    }

    public class OrdersRootObject
    {
        public Result result { get; set; }
        public string method { get; set; }
    }
}
