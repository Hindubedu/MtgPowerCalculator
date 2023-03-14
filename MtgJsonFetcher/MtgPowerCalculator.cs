using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wrapper;

namespace MtgJsonFetcher
{
    internal class MtgPowerCalculator
    {
        public List<Card> cards = new List<Card>();
        Fetcher fetcher;
        public double CommonWeight{ get; set; }
        public double UncommonWeight { get; set; }
        public double RareWeight { get; set; }

        public double MythicWeight { get; set; }

        public MtgPowerCalculator(Fetcher fetcher)
        {
            this.fetcher = fetcher;
            CommonWeight = 10;
            UncommonWeight = 3;
            RareWeight = 0.85714285714;
            MythicWeight = 0.14285714286;
        }

        private List<Card> GetListOfColor(string color)
        {
            List<Card> colorList = new List<Card>();
            foreach (var item in fetcher.Set.Data.Cards)
            {
                if (item.Colors.Contains(color) && item.Colors.Count <= 2)
                {
                    colorList.Add(item);
                }
            }

            var distinctList = colorList.DistinctBy(x=>x.Name).ToList();

            return distinctList;
        }

        public double WeightedAverageOfColor(string color) ///Good luck... 
        {
            List<Card> cardsOfGivenColor = GetListOfColor(color);

            double weightedAverage = 0;
            double commonSum = 0;
            double uncommonSum = 0;
            double rareSum = 0;
            double mythicSum = 0;
            double commonCount = 0;
            double uncommonCount = 0;
            double rareCount = 0;
            double mythicCount = 0;


            foreach (var item in cardsOfGivenColor)
            {
                if (item.Colors.Count == 1)
                {
                    switch (item.Rarity)
                    {
                        case "common":
                            commonSum += (item.Rating);
                            commonCount++;
                            break;
                        case "uncommon":
                            uncommonSum += (item.Rating);
                            uncommonCount++;
                            break;
                        case "rare":
                            rareSum += (item.Rating);
                            rareCount++;
                            break;
                        case "mythic":
                            mythicSum += (item.Rating);
                            mythicCount++;
                            break;
                        default:
                            break;
                    }
                }
            }

            double commonAverage = commonSum / commonCount;
            double uncommonAverage = uncommonSum / uncommonCount;
            double rareAverage = rareSum / rareCount;
            double mythicAverage = mythicSum / mythicCount;

            if (Double.IsNaN(commonAverage))
            {
                commonAverage = 0;
            }
            if (Double.IsNaN(uncommonAverage))
            {
                uncommonAverage = 0;
            }
            if (Double.IsNaN(rareAverage))
            {
                rareAverage = 0;
            }
            if (Double.IsNaN(mythicAverage))
            {
                mythicAverage = 0;
            }

            return weightedAverage =
                commonAverage * (ConvertToPercentage(CommonWeight))
                + uncommonAverage * (ConvertToPercentage(UncommonWeight))
                + rareAverage * (ConvertToPercentage(RareWeight))
                + mythicAverage * (ConvertToPercentage(MythicWeight))
                + WeightedAverageDoubleColor(color);
        }

        private double WeightedAverageDoubleColor(string color)
        {
            List<Card> cardsOfGivenColor = GetListOfColor(color);
            double weightedAverageDoubleColor = 0;
            double commonAverage = 0;
            double uncommonAverage = 0;
            double rareAverage = 0;
            double mythicAverage = 0;
            double commonSum = 0;
            double uncommonSum = 0;
            double rareSum = 0;
            double mythicSum = 0;
            double commonCount = 0;
            double uncommonCount = 0;
            double rareCount = 0;
            double mythicCount = 0;


            foreach (var item in cardsOfGivenColor)
            {
                if (item.Colors.Count == 2)
                {
                    switch (item.Rarity)
                    {
                        case "common":
                            commonSum += (item.Rating);
                            commonCount++;
                            break;
                        case "uncommon":
                            uncommonSum += (item.Rating);
                            uncommonCount++;
                            break;
                        case "rare":
                            rareSum += (item.Rating);
                            rareCount++;
                            break;
                        case "mythic":
                            mythicSum += (item.Rating);
                            mythicCount++;
                            break;
                        default:
                            break;
                    }
                }
            }
            commonAverage = commonSum / commonCount;
            uncommonAverage = uncommonSum / uncommonCount;
            rareAverage = rareSum / rareCount;
            mythicAverage = mythicSum / mythicCount;

            if (Double.IsNaN(commonAverage))
            {
                commonAverage = 0;
            }
            if (Double.IsNaN(uncommonAverage))
            {
                uncommonAverage = 0;
            }
            if (Double.IsNaN(rareAverage))
            {
                rareAverage = 0;
            }
            if (Double.IsNaN(mythicAverage))
            {
                mythicAverage = 0;
            }

            return weightedAverageDoubleColor =
                  commonAverage * (ConvertToPercentage(CommonWeight)/4)
                + uncommonAverage * (ConvertToPercentage(UncommonWeight)/4)
                + rareAverage * (ConvertToPercentage(RareWeight)/4)
                + mythicAverage * (ConvertToPercentage(MythicWeight)/4);
        }

        private double ConvertToPercentage(double weight)
        {
            double sumOfRatings = 15;

            double result = weight / sumOfRatings;
            return result;
        }
    }
}
