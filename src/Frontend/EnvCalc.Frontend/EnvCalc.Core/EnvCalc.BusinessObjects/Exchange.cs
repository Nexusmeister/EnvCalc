namespace EnvCalc.BusinessObjects
{
    public class Exchange
    {
        public string Name { get; init; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public bool Input { get; set; }
    }
}