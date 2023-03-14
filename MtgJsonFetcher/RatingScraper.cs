using Newtonsoft.Json;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace MtgJsonFetcher
{
    public class RatingScraper
    {
        public string Scrape17Lands()
        {
            //Not possible website is non-static, we need to call an API see next method
            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage page = browser.NavigateToPage(new Uri("https://www.17lands.com/card_ratings"));
            XPathNavigator linkNode = page.Html.CreateNavigator().SelectSingleNode("/html/body/div/div/div[1]/div[4]/div[2]/div[2]/a");
            string linkUrl = linkNode?.GetAttribute("href", "");
            return linkUrl;
        }

        public async Task<string> GetSetDataFrom17LandsAPIAsync()
        {
            HttpClient client = new HttpClient();
            string ApiEndPoint = "https://www.17lands.com/card_ratings/data?expansion=ONE&format=PremierDraft&start_date=2023-02-07&end_date=2023-03-13";
            HttpResponseMessage response = client.GetAsync(ApiEndPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                Debug.WriteLine("Response unsuccesful");
                return null;
            }
        }

        public List<(string, double)> Scrape()
        {
            List<string> namesAndRatings = new List<string>();

            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage page = browser.NavigateToPage(new Uri("https://mtgazone.com/phyrexia-all-will-be-one-limited-tier-list/"));

            var tableRows = page.Html.CssSelect("#footable_parent_172072 #footable_172072 tbody tr");
            foreach (var row in tableRows)
            {
                var nameAndRating = row.CssSelect("td")
                    .Where(c => !new[] { "C", "U", "R", "M", "" }.Contains(c.InnerText.Trim()));

                foreach (var cell in nameAndRating)
                {
                    namesAndRatings.Add(cell.InnerText.Trim());
                }
            }

            List<(string, double)> nameRatingPairs = new List<(string, double)>();

            for (int i = 0; i < namesAndRatings.Count; i += 2)
            {
                if (i + 1 < namesAndRatings.Count && double.TryParse(namesAndRatings[i + 1], out double value))
                {
                    nameRatingPairs.Add((namesAndRatings[i], value / 10 * 2));
                }
            }
            return nameRatingPairs;
        }
    }
}
