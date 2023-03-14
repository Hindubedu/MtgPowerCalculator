using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MtgJsonFetcher
{
    internal class Fetcher
    {
        string path;
        public Wrapper.Root Set { get; }

        public Fetcher(string setCode)
        {
            Set = ChooseSet(setCode);
        }

        public Wrapper.Root ChooseSet(string setCode)
        {
            path = $"../../../Files/{setCode}.json";
            var jsonString = File.ReadAllText(path);
            var deserialized = JsonConvert.DeserializeObject<Wrapper.Root>(jsonString);
            //Next project: structur med deserialized og adgang
            return deserialized;
        }
    }
}
