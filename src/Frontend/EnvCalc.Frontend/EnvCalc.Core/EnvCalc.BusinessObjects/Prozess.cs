using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnvCalc.BusinessObjects
{
    public class Prozess
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("exchanges")]
        public List<Exchange> Exchanges { get; set; }
    }
}