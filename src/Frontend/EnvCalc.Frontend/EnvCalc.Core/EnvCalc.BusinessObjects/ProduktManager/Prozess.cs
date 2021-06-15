using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EnvCalc.BusinessObjects.ProduktManager
{
    public class Prozess
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Amplifier { get; set; }
        
        [JsonPropertyName("input")]
        public List<Exchange> Inputs { get; set; }
        
        [JsonPropertyName("output")]
        public List<Exchange> Outputs { get; set; }
    }
}