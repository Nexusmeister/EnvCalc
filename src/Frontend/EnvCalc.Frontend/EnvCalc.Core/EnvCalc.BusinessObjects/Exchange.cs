namespace EnvCalc.BusinessObjects
{
    public class Exchange
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public double Amount { get; set; }

        public bool? Input { get; set; }
    }
}