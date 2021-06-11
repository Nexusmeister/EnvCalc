using System.Collections.Generic;

namespace EnvCalc.BusinessObjects.ProduktManager
{
    public class Prozess
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Amplifier { get; set; }
        public List<Exchange> Inputs { get; set; }
        public List<Exchange> Outputs { get; set; }
    }
}