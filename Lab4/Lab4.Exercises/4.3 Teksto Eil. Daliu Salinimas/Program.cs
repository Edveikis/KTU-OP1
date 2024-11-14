namespace LineParts
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Data.txt";
            const string CFr = "Result.txt";
            const string CFa = "Analysis.txt";
            InOut.Process(CFd, CFr, CFa);
        }
    }
}