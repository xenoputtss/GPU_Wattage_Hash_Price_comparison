namespace GPU_Wattage_Hash_Price_comparison
{
    using Newtonsoft.Json;
    using NiceHashAPI;
    using SlushPoolAPI;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hardwareStatsToolStripMenuItem_Click(null, null);
        }

        private void clearCacheFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NiceHash.ClearCacheFiles();
        }

        private void hardwareStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////////////////////var list = NiceHash.Get_HardwareData();
            //////////////////////textBox1.Text = "";
            ////////////////////var newList = list
            ////////////////////    .Select(g => CorrectPricing(g))
            ////////////////////    .Select(g => new
            ////////////////////    {
            ////////////////////        gpuData = g,
            ////////////////////        profData = NiceHash.Get_CalculateProfitability(g, 1.00)
            ////////////////////    })
            ////////////////////    .Select(g => new
            ////////////////////    {
            ////////////////////        g.gpuData,
            ////////////////////        g.profData,
            ////////////////////        profitPerDay = (g.profData.btc_rate * g.profData.current_prof) - (g.gpuData.power * 24 * (0.12 / 1000))
            ////////////////////    })
            ////////////////////    .Select(g => new
            ////////////////////    {
            ////////////////////        g.gpuData,
            ////////////////////        g.profData,
            ////////////////////        g.profitPerDay,
            ////////////////////        ROIDays = (g.gpuData.price / g.profitPerDay)
            ////////////////////    })
            ////////////////////    .Select(g => new
            ////////////////////    {
            ////////////////////        g.gpuData.id,
            ////////////////////        g.gpuData.name,
            ////////////////////        g.gpuData.power,
            ////////////////////        g.gpuData.price,
            ////////////////////        g.profitPerDay,
            ////////////////////        g.ROIDays,
            ////////////////////        g.profData.btc_rate,
            ////////////////////        g.profData.current_prof,
            ////////////////////        current_algo = (Algorithms)Enum.ToObject(typeof(Algorithms), g.profData.current_algo),
            ////////////////////        OneYearProfit = g.profitPerDay * 365 - g.gpuData.price,
            ////////////////////        TwoYearProfit = g.profitPerDay * 365 * 2 - g.gpuData.price,
            ////////////////////        CostPerROI = g.gpuData.price / g.ROIDays,
            ////////////////////        ComparedWithBest = (700.0 / g.gpuData.price) * g.profitPerDay,
            ////////////////////        DaysToPayOffTotalWith6Cards = (440.0 + 6 * g.gpuData.price) / (g.profitPerDay * 6),
            ////////////////////        TotalCost = (440.0 + 6 * g.gpuData.price),
            ////////////////////        TotalProfitForYear = (g.profitPerDay * 6) * 365,
            ////////////////////        Ratio_TotalCostTotalProfit = (440.0 + 6 * g.gpuData.price) / ((g.profitPerDay * 6) * 365)

            ////////////////////    })

            ////////////////////    //.Where(g => g.name.Contains("CPU"))
            ////////////////////    //.Where(g => g.current_algo == Algorithms.DaggerHashimoto)
            ////////////////////    //.Where(g =>
            ////////////////////    //    g.name.Contains(" CPU") ||
            ////////////////////    //    g.name.Contains("AMD ") ||
            ////////////////////    //    g.name.Contains("NVIDIA ")
            ////////////////////    //) 
            ////////////////////    .Where(g =>
            ////////////////////        !g.name.Contains("ANTMINER") &&
            ////////////////////        !g.name.Contains("Canaan") &&
            ////////////////////        !g.name.Contains("X11") &&
            ////////////////////        !g.name.Contains("Innosilicon") &&
            ////////////////////        !g.name.Contains("BITMAIN") &&
            ////////////////////        !g.name.Contains("Antminer")
            ////////////////////    )
            ////////////////////    .Where(g => g.ROIDays >= 0)
            ////////////////////    //.Where(g => g.ROIDays < 365)
            ////////////////////    .Where(g => g.TwoYearProfit > 0)
            ////////////////////    .OrderByDescending(g => g.profitPerDay)
            ////////////////////    .OrderBy(g => g.ROIDays)
            ////////////////////    //.OrderBy(g => g.name)
            ////////////////////    //.OrderByDescending(g => g.profitPerDay)
            ////////////////////    //.OrderBy(g => g.ROIDays);
            ////////////////////    ;
            var newList = WhatToMine.Get_HardwareData();
            dataGridView1.DataSource = newList.ToList().ToDataTable();
        }

        private NiceHash.GPU_Data CorrectPricing(NiceHash.GPU_Data g)
        {
            var newG = new NiceHash.GPU_Data()
            {
                id = g.id,
                name = g.name,
                price = g.price,
                power = g.power,
                speeds = g.speeds.ToArray()
            };

            newG.price =
                g.name == "AMD RX 470 4GB" ? 310 :
                g.name == "AMD RX 480 8GB" ? 480 :
                g.name == "NVIDIA GTX 1070" ? 480 :
                g.name == "NVIDIA GTX 1060 6GB" ? 319 :
                g.name == "NVIDIA GTX 1080 Ti" ? 780 :
                g.name == "NVIDIA GTX 1080" ? 580 :
                g.name == "NVIDIA GTX 980 Ti" ? 450 :
                g.name == "AMD RX 570 4GB" ? 350 :
                g.name == "AMD R7 370" ? 470 :
                g.price;
            return newG;
        }

        private void liveMarketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liveData = NiceHashAPI.LiveMarket.GetLiveMarketData(Algorithms.SHA256);
            dataGridView1.DataSource = liveData
                .Where(o => o.workers > 0)
                .OrderBy(o => o.price)
                .ToList()
                .ToDataTable();
        }

        private void slushPoolStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("roundData.json"))
            {
                var (IsSuccess, a) = SlushPoolAPI.Get_Pool_Block_History();
                System.IO.File.WriteAllText("roundData.json", JsonConvert.SerializeObject(a));
            }

            var rounds = JsonConvert.DeserializeObject<List<PoolBlockHistoryRootResponse.PoolBlockHistoryDataItem>>(System.IO.File.ReadAllText("roundData.json"));

            //dataGridView1.DataSource = 
            var rr = rounds
                .Where(r => r.pool_scoring_hashrate > 300 * 1000 * 1000)
                .Sum(r => r.value)

                //.Select(r =>
                //    new
                //    {
                //        r.id,
                //        r.value,
                //        r.pool_scoring_hashrate,
                //        rate =6.4*( (r.value / r.pool_scoring_hashrate) / 1000.0 / 1000.0 )
                //    })
                //.ToList()
                ;
            //var average = a.blocks.Sum(b => double.Parse(b.Value.reward));
        }
    }
}
