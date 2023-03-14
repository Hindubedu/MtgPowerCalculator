using HtmlAgilityPack;
using MtgJsonFetcher.MyProject;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Network;
using ScrapySharp.Html.Forms;
using System.Linq;
using System.Net;
using System.Xml.XPath;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace MtgJsonFetcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RatingScraper scraper = new RatingScraper();

            GetOnlineDataAsync().Wait();

            //RatingScraper scraper = new RatingScraper();
            //var deserialized = await scraper.GetSetDataFrom17LandsAPIAsync();
            //foreach (var item in deserialized.Result.CardStatistics)
            //{
            //    Debug.WriteLine($"{item.Name} GIHWR: {item.EverDrawnWinRate}");
            //}

            Fetcher fetcher = new Fetcher("ONE");
            RatingSetter ratingSetter = new RatingSetter();
            ratingSetter.SetRatingSetter(fetcher, scraper);

            MtgPowerCalculator powerCalculator = new MtgPowerCalculator(fetcher);


            foreach (var item in fetcher.Set.Data.Cards)
            {
                Console.WriteLine($"Name: {item.Name} Rarity: {item.Rarity} Colors: {string.Join(", ", item.ColorIdentity)} Rating {item.Rating}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");

            //wubrg
            var w = powerCalculator.WeightedAverageOfColor("W");
            var u = powerCalculator.WeightedAverageOfColor("U");
            var b = powerCalculator.WeightedAverageOfColor("B");
            var r = powerCalculator.WeightedAverageOfColor("R");
            var g = powerCalculator.WeightedAverageOfColor("G");

            Console.WriteLine("Color Ratings:");
            Console.WriteLine("");
            Console.WriteLine("White");
            Console.WriteLine(w);
            Console.WriteLine("Blue");
            Console.WriteLine(u);
            Console.WriteLine("Black");
            Console.WriteLine(b);
            Console.WriteLine("Red");
            Console.WriteLine(r);
            Console.WriteLine("Green");
            Console.WriteLine(g);

            Console.WriteLine("");

            Console.WriteLine("Average ratings compared percentage:");
            var average = (w + u + b + r + g) / 5;
            Console.WriteLine("White");
            Console.WriteLine(w / average * 100 + " %");
            Console.WriteLine("Blue");
            Console.WriteLine(u / average * 100 + " %");
            Console.WriteLine("Black");
            Console.WriteLine(b / average * 100 + " %");
            Console.WriteLine("Red");
            Console.WriteLine(r / average * 100 + " %");
            Console.WriteLine("Green");
            Console.WriteLine(g / average * 100 + " %");

            Console.WriteLine("");

            //Her behøver man ikke at lave nye, men kunne blot sette data på den gamle fetcher og powercalculator, dette er bare et dobbelttjek.
            RatingSetter seventeensetter = new RatingSetter();
            Fetcher seventeenFetcher = new Fetcher("ONE");
            MtgPowerCalculator seventeenPower = new MtgPowerCalculator(seventeenFetcher);
            seventeensetter.Set17LandsRating(seventeenFetcher, $"../../../Files/card-ratings-2023-03-07.csv");

            var W = seventeenPower.WeightedAverageOfColor("W");
            var U = seventeenPower.WeightedAverageOfColor("U");
            var B = seventeenPower.WeightedAverageOfColor("B");
            var R = seventeenPower.WeightedAverageOfColor("R");
            var G = seventeenPower.WeightedAverageOfColor("G");

            Console.WriteLine("Color Ratings 17 lands:");
            Console.WriteLine("");
            Console.WriteLine("White");
            Console.WriteLine(W);
            Console.WriteLine("Blue");
            Console.WriteLine(U);
            Console.WriteLine("Black");
            Console.WriteLine(B);
            Console.WriteLine("Red");
            Console.WriteLine(R);
            Console.WriteLine("Green");
            Console.WriteLine(G);

            Console.WriteLine("");

            Console.WriteLine("Average ratings compared percentage 17 lands:");
            var avg = (W + U + B + R + G) / 5;
            Console.WriteLine("White");
            Console.WriteLine(W / avg * 100 + " %");
            Console.WriteLine("Blue");
            Console.WriteLine(U / avg * 100 + " %");
            Console.WriteLine("Black");
            Console.WriteLine(B / avg * 100 + " %");
            Console.WriteLine("Red");
            Console.WriteLine(R / avg * 100 + " %");
            Console.WriteLine("Green");
            Console.WriteLine(G / avg * 100 + " %");



            //Dictionary<string, double> weighted = lands.CalculateWeightedAverage($"../../../card-ratings-2023-02-28.csv");

            //Console.WriteLine("Average ratings compared percentage 17 Lands GIHWR:");
            //var avg = (weighted["W"]+ weighted["U"]+ weighted["B"]+ weighted["R"]+ weighted["G"]) / 5;
            //Console.WriteLine("White");
            //Console.WriteLine(weighted["W"] / avg * 100 + " %");
            //Console.WriteLine("Blue");
            //Console.WriteLine(weighted["U"] / avg * 100 + " %");
            //Console.WriteLine("Black");
            //Console.WriteLine(weighted["B"] / avg * 100 + " %");
            //Console.WriteLine("Red");
            //Console.WriteLine(weighted["R"] / avg * 100 + " %");
            //Console.WriteLine("Green");
            //Console.WriteLine(weighted["G"] / avg * 100 + " %");
        }
        public static async Task GetOnlineDataAsync()
        {
            RatingScraper scraper = new RatingScraper();
            var serialized = await scraper.GetSetDataFrom17LandsAPIAsync();

            var deserialized = JsonConvert.DeserializeObject<List<SeventeenWrapper.Root>>(serialized);

            foreach (var item in deserialized)
            {       
                    Console.WriteLine($"{item.Name} GIHWR: {(double)item.EverDrawnWinRate}");
            }
        }
    }
}