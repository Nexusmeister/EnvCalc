using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EnvCalc.BusinessObjects.ProduktManager
{
    public class Produkt
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        
        [JsonPropertyName("processes")]
        public List<Prozess> Prozesse { get; set; }
        public bool Deprecated { get; set; }
        
        [JsonPropertyName("created")]
        public DateTime Erstellungsdatum { get; set; }
    }
}