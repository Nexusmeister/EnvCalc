using Newtonsoft.Json;

namespace EnvCalc.BusinessObjects
{
    public class Exchange
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("input")]
        public bool Input { get; set; }
    }
}