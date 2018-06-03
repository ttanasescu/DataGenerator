namespace RegExGenerator.Tokens
{
    public class Quantifier
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public Quantifier(int minimum = 0, int maximum = int.MaxValue - 1)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}