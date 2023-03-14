using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;

namespace MtgJsonFetcher
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    namespace MyProject
    {
        public class WeightedAverageOf17Lands
        {
            public Dictionary<string, double> CalculateWeightedAverage(string filename)///Method not in use
            {
                Dictionary<string, double> weightedAverages = new Dictionary<string, double>();
                Dictionary<string, List<double>> colorLists = new Dictionary<string, List<double>>();
                

                // Create lists for each color
                colorLists.Add("G", new List<double>());
                colorLists.Add("W", new List<double>());
                colorLists.Add("R", new List<double>());
                colorLists.Add("U", new List<double>());
                colorLists.Add("B", new List<double>());

                // Read the CSV file
                using (var reader = new StreamReader(filename))
                {
                    // Skip the header row
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        List<string> values = line.Split(',').ToList();

                        if (values.Count() > 5) //some names are already seperated by commas we fix this here
                        {
                            values[0] = $"{values[0]} {values[1]}";
                            values.RemoveAt(1);
                        }


                        if (values.Count==5 && string.IsNullOrWhiteSpace(values[4])==false)
                        {
                            // Parse the fields
                            var name = values[0];
                            var color = values[1].Trim('"');
                            var rarity = values[2].Trim('"');
                            var gihCount = int.Parse(values[3].Trim('"'));
                            double gihWr;
                            if (double.TryParse(values[4], out gihWr))
                            {
                                gihWr = gihWr / 10;
                            }
                            else
                            {
                                gihWr = 0;
                            }
                          

                            double.TryParse(values[4].Trim('"').Replace("%", ""),out gihWr); //skal seperere % fra string (replace)

                            // Calculate the weight based on the rarity
                            double weight = 0.0;
                            switch (rarity)
                            {
                                case "C":
                                    weight = 10.0;
                                    break;
                                case "U":
                                    weight = 3.0;
                                    break;
                                case "R":
                                    weight = 0.85714285714;
                                    break;
                                case "M":
                                    weight = 0.14285714286;
                                    break;
                                default:
                                    break;
                            }
                            
                            // Add the GIH WR to the appropriate color list with the appropriate weight
                            if (color == "G" || color == "B" || color == "U" || color == "R" || color == "W")
                            {
                                colorLists[color].Add(gihWr * weight);
                            } 
                        }
                        else
                        {
                            Debug.WriteLine($"Card: {values[0]} incorrect LineCount");
                        }
                    }
                }

                // Calculate the weighted averages for each color
                foreach (var kvp in colorLists)
                {
                    var color = kvp.Key;
                    var values = kvp.Value;
                    var weightedAverage = values.Sum() / values.Count;
                    weightedAverages.Add(color, weightedAverage);
                }
                return weightedAverages;
            }
        }
    }
}
