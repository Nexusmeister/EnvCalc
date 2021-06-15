using System;
using System.Collections.Generic;

namespace EnvCalc.BusinessObjects.ProduktManager
{
    public class Produkt
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public int Version { get; set; }
        public List<Prozess> Prozesse { get; set; }
        public bool Deprecated { get; set; }
    }
}