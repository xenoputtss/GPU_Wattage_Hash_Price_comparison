namespace NiceHashAPI
{
    using RestSharp;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Linq;
    using System;
    public static class WhatToMine
    {
        private static RestClient _client = new RestClient("https://whattomine.com/");

        const double PRICEOFBTC = 15000;
        const double machineCost = 300;
        const double psuCost = 100;
        const double psuWattage = 800;
        const double daysPerYearToRun = 365;

        public static List<CardResults> Get_HardwareData()
        {
            var dict = new Dictionary<string, string> {
                {"280x",  "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_280x=true&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=66.0&factor%5Beth_p%5D=1320.0&grof=true&factor%5Bgro_hr%5D=142.8&factor%5Bgro_p%5D=1500.0&x11gf=true&factor%5Bx11g_hr%5D=17.4&factor%5Bx11g_p%5D=1200.0&cn=true&factor%5Bcn_hr%5D=2940.0&factor%5Bcn_p%5D=1320.0&eq=true&factor%5Beq_hr%5D=1740.0&factor%5Beq_p%5D=1380.0&lre=true&factor%5Blrev2_hr%5D=84300.0&factor%5Blrev2_p%5D=1320.0&ns=true&factor%5Bns_hr%5D=2940.0&factor%5Bns_p%5D=1500.0&lbry=true&factor%5Blbry_hr%5D=360.0&factor%5Blbry_p%5D=1200.0&bk2bf=true&factor%5Bbk2b_hr%5D=5760.0&factor%5Bbk2b_p%5D=1500.0&bk14=true&factor%5Bbk14_hr%5D=8700.0&factor%5Bbk14_p%5D=1320.0&pas=true&factor%5Bpas_hr%5D=3480.0&factor%5Bpas_p%5D=1500.0&skh=true&factor%5Bskh_hr%5D=0.0&factor%5Bskh_p%5D=0.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"380",   "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_380=true&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=114.0&factor%5Beth_p%5D=870.0&grof=true&factor%5Bgro_hr%5D=93.0&factor%5Bgro_p%5D=780.0&x11gf=true&factor%5Bx11g_hr%5D=15.0&factor%5Bx11g_p%5D=720.0&cn=true&factor%5Bcn_hr%5D=3180.0&factor%5Bcn_p%5D=720.0&eq=true&factor%5Beq_hr%5D=1230.0&factor%5Beq_p%5D=780.0&lre=true&factor%5Blrev2_hr%5D=38400.0&factor%5Blrev2_p%5D=750.0&ns=true&factor%5Bns_hr%5D=2100.0&factor%5Bns_p%5D=870.0&lbry=true&factor%5Blbry_hr%5D=264.0&factor%5Blbry_p%5D=810.0&bk2bf=true&factor%5Bbk2b_hr%5D=4560.0&factor%5Bbk2b_p%5D=900.0&bk14=true&factor%5Bbk14_hr%5D=6840.0&factor%5Bbk14_p%5D=930.0&pas=true&factor%5Bpas_hr%5D=2880.0&factor%5Bpas_p%5D=870.0&skh=true&factor%5Bskh_hr%5D=54.0&factor%5Bskh_p%5D=720.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"fury",  "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_fury=true&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=175.2&factor%5Beth_p%5D=1080.0&grof=true&factor%5Bgro_hr%5D=104.4&factor%5Bgro_p%5D=1080.0&x11gf=true&factor%5Bx11g_hr%5D=27.0&factor%5Bx11g_p%5D=840.0&cn=true&factor%5Bcn_hr%5D=4800.0&factor%5Bcn_p%5D=720.0&eq=true&factor%5Beq_hr%5D=2730.0&factor%5Beq_p%5D=1200.0&lre=true&factor%5Blrev2_hr%5D=85200.0&factor%5Blrev2_p%5D=1140.0&ns=true&factor%5Bns_hr%5D=3000.0&factor%5Bns_p%5D=960.0&lbry=true&factor%5Blbry_hr%5D=498.0&factor%5Blbry_p%5D=1200.0&bk2bf=true&factor%5Bbk2b_hr%5D=8400.0&factor%5Bbk2b_p%5D=1560.0&bk14=true&factor%5Bbk14_hr%5D=11400.0&factor%5Bbk14_p%5D=1620.0&pas=true&factor%5Bpas_hr%5D=5700.0&factor%5Bpas_p%5D=1620.0&skh=true&factor%5Bskh_hr%5D=0.0&factor%5Bskh_p%5D=0.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"470",   "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_470=true&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=144.0&factor%5Beth_p%5D=720.0&grof=true&factor%5Bgro_hr%5D=87.0&factor%5Bgro_p%5D=720.0&x11gf=true&factor%5Bx11g_hr%5D=31.8&factor%5Bx11g_p%5D=750.0&cn=true&factor%5Bcn_hr%5D=3960.0&factor%5Bcn_p%5D=600.0&eq=true&factor%5Beq_hr%5D=1560.0&factor%5Beq_p%5D=660.0&lre=true&factor%5Blrev2_hr%5D=26400.0&factor%5Blrev2_p%5D=720.0&ns=true&factor%5Bns_hr%5D=3600.0&factor%5Bns_p%5D=840.0&lbry=true&factor%5Blbry_hr%5D=480.0&factor%5Blbry_p%5D=720.0&bk2bf=true&factor%5Bbk2b_hr%5D=4800.0&factor%5Bbk2b_p%5D=720.0&bk14=true&factor%5Bbk14_hr%5D=6600.0&factor%5Bbk14_p%5D=720.0&pas=true&factor%5Bpas_hr%5D=3060.0&factor%5Bpas_p%5D=720.0&skh=true&factor%5Bskh_hr%5D=90.0&factor%5Bskh_p%5D=630.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"480",   "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_480=true&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=159.0&factor%5Beth_p%5D=810.0&grof=true&factor%5Bgro_hr%5D=108.0&factor%5Bgro_p%5D=780.0&x11gf=true&factor%5Bx11g_hr%5D=40.2&factor%5Bx11g_p%5D=840.0&cn=true&factor%5Bcn_hr%5D=4380.0&factor%5Bcn_p%5D=660.0&eq=true&factor%5Beq_hr%5D=1740.0&factor%5Beq_p%5D=720.0&lre=true&factor%5Blrev2_hr%5D=29400.0&factor%5Blrev2_p%5D=780.0&ns=true&factor%5Bns_hr%5D=3900.0&factor%5Bns_p%5D=900.0&lbry=true&factor%5Blbry_hr%5D=570.0&factor%5Blbry_p%5D=840.0&bk2bf=true&factor%5Bbk2b_hr%5D=5940.0&factor%5Bbk2b_p%5D=900.0&bk14=true&factor%5Bbk14_hr%5D=8400.0&factor%5Bbk14_p%5D=900.0&pas=true&factor%5Bpas_hr%5D=4140.0&factor%5Bpas_p%5D=810.0&skh=true&factor%5Bskh_hr%5D=108.0&factor%5Bskh_p%5D=690.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"570",   "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_570=true&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=153.0&factor%5Beth_p%5D=720.0&grof=true&factor%5Bgro_hr%5D=93.0&factor%5Bgro_p%5D=660.0&x11gf=true&factor%5Bx11g_hr%5D=33.6&factor%5Bx11g_p%5D=660.0&cn=true&factor%5Bcn_hr%5D=4200.0&factor%5Bcn_p%5D=660.0&eq=true&factor%5Beq_hr%5D=1560.0&factor%5Beq_p%5D=660.0&lre=true&factor%5Blrev2_hr%5D=33000.0&factor%5Blrev2_p%5D=660.0&ns=true&factor%5Bns_hr%5D=3780.0&factor%5Bns_p%5D=840.0&lbry=true&factor%5Blbry_hr%5D=690.0&factor%5Blbry_p%5D=690.0&bk2bf=true&factor%5Bbk2b_hr%5D=5040.0&factor%5Bbk2b_p%5D=690.0&bk14=true&factor%5Bbk14_hr%5D=6840.0&factor%5Bbk14_p%5D=690.0&pas=true&factor%5Bpas_hr%5D=3480.0&factor%5Bpas_p%5D=810.0&skh=true&factor%5Bskh_hr%5D=97.8&factor%5Bskh_p%5D=660.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"750Ti", "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_750Ti=true&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=2.8&factor%5Beth_p%5D=270.0&grof=true&factor%5Bgro_hr%5D=49.9&factor%5Bgro_p%5D=480.0&x11gf=true&factor%5Bx11g_hr%5D=12.3&factor%5Bx11g_p%5D=330.0&cn=true&factor%5Bcn_hr%5D=1500.0&factor%5Bcn_p%5D=330.0&eq=true&factor%5Beq_hr%5D=450.0&factor%5Beq_p%5D=330.0&lre=true&factor%5Blrev2_hr%5D=39840.0&factor%5Blrev2_p%5D=420.0&ns=true&factor%5Bns_hr%5D=1320.0&factor%5Bns_p%5D=450.0&lbry=true&factor%5Blbry_hr%5D=306.0&factor%5Blbry_p%5D=450.0&bk2bf=true&factor%5Bbk2b_hr%5D=2100.0&factor%5Bbk2b_p%5D=450.0&bk14=true&factor%5Bbk14_hr%5D=3660.0&factor%5Bbk14_p%5D=450.0&pas=true&factor%5Bpas_hr%5D=1200.0&factor%5Bpas_p%5D=330.0&skh=true&factor%5Bskh_hr%5D=0.0&factor%5Bskh_p%5D=0.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"10606", "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_10606=true&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=135.0&factor%5Beth_p%5D=540.0&grof=true&factor%5Bgro_hr%5D=123.0&factor%5Bgro_p%5D=540.0&x11gf=true&factor%5Bx11g_hr%5D=43.2&factor%5Bx11g_p%5D=540.0&cn=true&factor%5Bcn_hr%5D=2580.0&factor%5Bcn_p%5D=420.0&eq=true&factor%5Beq_hr%5D=1620.0&factor%5Beq_p%5D=540.0&lre=true&factor%5Blrev2_hr%5D=121800.0&factor%5Blrev2_p%5D=540.0&ns=true&factor%5Bns_hr%5D=3000.0&factor%5Bns_p%5D=540.0&lbry=true&factor%5Blbry_hr%5D=1020.0&factor%5Blbry_p%5D=540.0&bk2bf=true&factor%5Bbk2b_hr%5D=5940.0&factor%5Bbk2b_p%5D=480.0&bk14=true&factor%5Bbk14_hr%5D=9300.0&factor%5Bbk14_p%5D=540.0&pas=true&factor%5Bpas_hr%5D=3480.0&factor%5Bpas_p%5D=540.0&skh=true&factor%5Bskh_hr%5D=108.0&factor%5Bskh_p%5D=540.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"1070",  "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_1070=true&adapt_q_1080=6&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=180.0&factor%5Beth_p%5D=720.0&grof=true&factor%5Bgro_hr%5D=213.0&factor%5Bgro_p%5D=780.0&x11gf=true&factor%5Bx11g_hr%5D=69.0&factor%5Bx11g_p%5D=720.0&cn=true&factor%5Bcn_hr%5D=3000.0&factor%5Bcn_p%5D=600.0&eq=true&factor%5Beq_hr%5D=2580.0&factor%5Beq_p%5D=720.0&lre=true&factor%5Blrev2_hr%5D=213000.0&factor%5Blrev2_p%5D=780.0&ns=true&factor%5Bns_hr%5D=6300.0&factor%5Bns_p%5D=930.0&lbry=true&factor%5Blbry_hr%5D=1620.0&factor%5Blbry_p%5D=720.0&bk2bf=true&factor%5Bbk2b_hr%5D=9600.0&factor%5Bbk2b_p%5D=720.0&bk14=true&factor%5Bbk14_hr%5D=15000.0&factor%5Bbk14_p%5D=750.0&pas=true&factor%5Bpas_hr%5D=5640.0&factor%5Bpas_p%5D=720.0&skh=true&factor%5Bskh_hr%5D=159.0&factor%5Bskh_p%5D=720.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"1080",  "coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_1080=true&adapt_q_1080Ti=6&eth=true&factor%5Beth_hr%5D=139.8&factor%5Beth_p%5D=840.0&grof=true&factor%5Bgro_hr%5D=267.0&factor%5Bgro_p%5D=900.0&x11gf=true&factor%5Bx11g_hr%5D=81.0&factor%5Bx11g_p%5D=870.0&cn=true&factor%5Bcn_hr%5D=3480.0&factor%5Bcn_p%5D=600.0&eq=true&factor%5Beq_hr%5D=3210.0&factor%5Beq_p%5D=780.0&lre=true&factor%5Blrev2_hr%5D=279000.0&factor%5Blrev2_p%5D=900.0&ns=true&factor%5Bns_hr%5D=6300.0&factor%5Bns_p%5D=900.0&lbry=true&factor%5Blbry_hr%5D=2160.0&factor%5Blbry_p%5D=900.0&bk2bf=true&factor%5Bbk2b_hr%5D=12900.0&factor%5Bbk2b_p%5D=900.0&bk14=true&factor%5Bbk14_hr%5D=19800.0&factor%5Bbk14_p%5D=900.0&pas=true&factor%5Bpas_hr%5D=7500.0&factor%5Bpas_p%5D=900.0&skh=true&factor%5Bskh_hr%5D=219.0&factor%5Bskh_p%5D=900.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
                {"1080Ti","coins.json?utf8=%E2%9C%93&adapt_q_280x=6&adapt_q_380=6&adapt_q_fury=6&adapt_q_470=6&adapt_q_480=6&adapt_q_570=6&adapt_q_750Ti=6&adapt_q_10606=6&adapt_q_1070=6&adapt_q_1080=6&adapt_q_1080Ti=6&adapt_1080Ti=true&eth=true&factor%5Beth_hr%5D=210.0&factor%5Beth_p%5D=840.0&grof=true&factor%5Bgro_hr%5D=348.0&factor%5Bgro_p%5D=1260.0&x11gf=true&factor%5Bx11g_hr%5D=117.0&factor%5Bx11g_p%5D=1020.0&cn=true&factor%5Bcn_hr%5D=4980.0&factor%5Bcn_p%5D=840.0&eq=true&factor%5Beq_hr%5D=3810.0&factor%5Beq_p%5D=1140.0&lre=true&factor%5Blrev2_hr%5D=384000.0&factor%5Blrev2_p%5D=1140.0&ns=true&factor%5Bns_hr%5D=8400.0&factor%5Bns_p%5D=1140.0&lbry=true&factor%5Blbry_hr%5D=2760.0&factor%5Blbry_p%5D=1140.0&bk2bf=true&factor%5Bbk2b_hr%5D=16800.0&factor%5Bbk2b_p%5D=1140.0&bk14=true&factor%5Bbk14_hr%5D=26100.0&factor%5Bbk14_p%5D=1260.0&pas=true&factor%5Bpas_hr%5D=10200.0&factor%5Bpas_p%5D=1260.0&skh=true&factor%5Bskh_hr%5D=285.0&factor%5Bskh_p%5D=1140.0&factor%5Bl2z_hr%5D=420.0&factor%5Bl2z_p%5D=300.0&factor%5Bcost%5D=0.15&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=bleutrade&factor%5Bexchanges%5D%5B%5D=bter&factor%5Bexchanges%5D%5B%5D=c_cex&factor%5Bexchanges%5D%5B%5D=cryptopia&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=yobit&dataset=Main&commit=Calculate" },
            };


            var list = dict.Select(card =>
                 {
                     var request = new RestRequest(card.Value, Method.GET);
                     var response = _client.Execute(request);
                     var content = response.Content;
                     var coinList = JsonConvert.DeserializeObject<root>(content);
                     var MaxWattage = GetMaxWattage(card.Value);
                     var cardCost =
                        card.Key == "470" ? 310 :
                        card.Key == "480" ? 289 :
                        card.Key == "1070" ? 550 :
                        card.Key == "10606" ? 319 :
                        card.Key == "1080Ti" ? 800 :
                        card.Key == "1080" ? 569 :
                        //card.Key == "NVIDIA GTX 980 Ti" ? 450 :
                        card.Key == "570" ? 307 :
                        card.Key == "280x" ? 270 :
                        card.Key == "380" ? 330 :
                        card.Key == "fury" ? 600 :
                        card.Key == "750Ti" ? 150 :
                        //card.Key == "AMD R7 370" ? 470 :
                        int.MaxValue;

                     return new
                     {
                         card = card.Key,
                         MaxWattage,
                         CardCost = cardCost,
                         bestCoin = coinList.coins.
                            OrderByDescending(c => c.Value.btc_revenue24)
                            .First()
                     };
                 }
            )
            //.Select(c => new CardResults
            .Select(c => new
            {
                Name = c.card,
                c.CardCost,
                BTC_Daily_Reward = c.bestCoin.Value.btc_revenue24,
                Max_Wattage = c.MaxWattage,
                Daily_Cost = c.MaxWattage * 24 * 0.00013,
                Daily_Revenue = (c.bestCoin.Value.btc_revenue24 * PRICEOFBTC)
            })
            .Select(c => new
            {
                c.Name,
                c.CardCost,
                c.Max_Wattage,
                c.Daily_Cost,
                c.BTC_Daily_Reward,
                c.Daily_Revenue,
                Daily_Profit = c.Daily_Revenue - c.Daily_Cost
            })
            .Select(c => new
            {
                c.Name,
                c.CardCost,
                c.Max_Wattage,
                c.Daily_Cost,
                c.BTC_Daily_Reward,
                c.Daily_Revenue,
                c.Daily_Profit,
                InvestmentCost = machineCost + (6 * c.CardCost) + ((c.Max_Wattage > psuWattage ? 1 : 2) * psuCost),
            })
            .Select(c => new
            {
                c.Name,
                c.CardCost,
                c.Max_Wattage,
                c.Daily_Cost,
                c.BTC_Daily_Reward,
                c.Daily_Revenue,
                c.Daily_Profit,
                c.InvestmentCost,
                ROI_Days = c.InvestmentCost / c.Daily_Profit,
                YearlyProfit = c.Daily_Profit * daysPerYearToRun
            })

            .Select(c => new CardResults
            {
                Name = c.Name,
                CardCost = c.CardCost,
                Max_Wattage = c.Max_Wattage,
                Daily_Cost = c.Daily_Cost,
                BTC_Daily_Reward = c.BTC_Daily_Reward,
                Daily_Revenue = c.Daily_Revenue,
                Daily_Profit = c.Daily_Profit,
                InvestmentCost = (int)c.InvestmentCost,
                ROI_Days = c.ROI_Days,
                Yearly_Profit = c.YearlyProfit,
                ProfitPerInvestment = c.YearlyProfit / c.InvestmentCost,
                ProfitAt2Years = (2 * c.YearlyProfit) - c.InvestmentCost
            })
            .ToList()
            ;
            return list;
        }
        private static Double DailyRevenue(double btc, double btcRate) => btc * btcRate;
        private static double GetMaxWattage(string inputString)
        {
            //_p%5D=
            var regex = new System.Text.RegularExpressions.Regex(@"_p%5D=(.+?)&");
            var max = regex
                .Matches(inputString)
                .Cast<System.Text.RegularExpressions.Match>()
                .Select(i => double.Parse(i.Groups[1].Value))
                .Max();
            return max;
        }

        public class CardResults
        {
            public string Name { get; internal set; }
            public int CardCost { get; internal set; }
            public double Max_Wattage { get; internal set; }
            public double Daily_Cost { get; internal set; }
            public double BTC_Daily_Reward { get; internal set; }
            public double Daily_Revenue { get; internal set; }
            public double Daily_Profit { get; internal set; }
            public int InvestmentCost { get; internal set; }
            public double ROI_Days { get; internal set; }
            public double Yearly_Profit { get; internal set; }
            public double ProfitPerInvestment { get; internal set; }
            public double ProfitAt2Years { get; internal set; }
        }
        public class Coin
        {
            public int id { get; set; }
            public string tag { get; set; }
            public string algorithm { get; set; }
            public string block_time { get; set; }
            public double block_reward { get; set; }
            public double block_reward24 { get; set; }
            public int last_block { get; set; }
            public double difficulty { get; set; }
            public double difficulty24 { get; set; }
            public string nethash { get; set; }
            public double exchange_rate { get; set; }
            public double exchange_rate24 { get; set; }
            public double exchange_rate_vol { get; set; }
            public string exchange_rate_curr { get; set; }
            public string market_cap { get; set; }
            public double estimated_rewards { get; set; }
            public double estimated_rewards24 { get; set; }
            public double btc_revenue { get; set; }
            public double btc_revenue24 { get; set; }
            public int profitability { get; set; }
            public int profitability24 { get; set; }
            public bool lagging { get; set; }
            public long timestamp { get; set; }
        }
        public class root
        {
            public Dictionary<string, Coin> coins { get; set; }
        }


    }
}
