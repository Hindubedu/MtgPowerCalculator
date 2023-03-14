using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgJsonFetcher
{
    internal class RatingSetter
    {
        public void RandomRatingSetter(Fetcher fetcher)
        {
            Random rnd = new Random();

            foreach (var item in fetcher.Set.Data.Cards)
            {
                item.Rating = rnd.Next(1, 11);
            }

        }

        public void SetRatingSetter(Fetcher fetcher, RatingScraper scraper) //Sets the reting of the cards for the given set contained in the data model class register. Uses a scraper this is the expert predictions
        {
            //List<(string, double)> ratings = GetRatedSet(setCode);
            List<(string, double)> ratings = scraper.Scrape();
            ratings.Sort();
            ratings.Count();
            fetcher.Set.Data.Cards.OrderBy(n => n.Name);
            fetcher.Set.Data.Cards.Count();

            foreach (var ratedCard in ratings)
            {
                foreach (var card in fetcher.Set.Data.Cards)
                {
                    if (card.Name == ratedCard.Item1)
                    {
                        card.Rating = (int)ratedCard.Item2;
                    }
                }
            }
        }

        public void Set17LandsRating(Fetcher fetcher, string filename) //Sets the rating of data model by a downloaded csv file from 17 lands. File must have format: csv : Name,"Color","Rarity","# GIH","GIH WR" 
        {
            List<(string, double)> ratings = new List<(string, double)>();
            int ratingSet = 0;

            using (var reader = new StreamReader(filename))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    List<string> values = line.Split(',').ToList();

                    if (values.Count() > 5) //some names are already seperated by commas we fix this here
                    {
                        values[0] = $"{values[0].Trim('"')},{values[1].Trim('"')}";
                        values.RemoveAt(1);
                    }


                    if (values.Count == 5 && string.IsNullOrWhiteSpace(values[4]) == false)
                    {
                        var name = values[0].Trim('"');
                        double gihWr;

                        if (double.TryParse(values[4].Trim('"').Replace("%", ""), out gihWr)) //skal seperere % fra string (replace)
                        {
                            gihWr = gihWr;

                        }
                        else
                        {
                            gihWr = 0;
                            Debug.WriteLine(values[0] + " rating not set");
                        }
                        ratings.Add((name, gihWr));
                    }
                }
            }
            ratings.Sort();
            ratings.Count();
            fetcher.Set.Data.Cards.OrderBy(n => n.Name);


            Debug.WriteLine("Cards: " + fetcher.Set.Data.Cards.Count());

            Debug.WriteLine("Individual cards: "+fetcher.Set.Data.Cards.DistinctBy(x => x.Name).Count());


            foreach (var ratedCard in ratings)
            {
                foreach (var card in fetcher.Set.Data.Cards.DistinctBy(x=>x.Name))
                {
                    if (card.Name == ratedCard.Item1)
                    {
                        card.Rating = (int)ratedCard.Item2;
                        ratingSet++;
                    }
                }
            }
            Debug.WriteLine($"Ratings set = {ratingSet} ");
        }


        public List<(string, double)> GetRatedSet(string setCode) //Gets the rated set by txt file - This is not currently used 
        {
            List<(string, double)> ratedCardList = new List<(string, double)>();
            string path = $"../../../{setCode}.txt";
            var lines = File.ReadAllLines(path);
            foreach (var item in lines)
            {
                string[] split = item.Split("½");
                (string, double) cardTouple = (split[0], Double.Parse(split[1]));
                ratedCardList.Add(cardTouple);
            }
            return ratedCardList;
        }
    }
}
