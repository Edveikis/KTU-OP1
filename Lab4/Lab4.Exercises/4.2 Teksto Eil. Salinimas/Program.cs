namespace Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFile = "Data.txt";
            const string outputFile = "Result.txt";
            List<int> Nos = InOut.LongestLine(inputFile);

            InOut.RemoveLine(inputFile, outputFile, Nos);

            InOut.PrintLongestLineIDs(Nos);
        }
    }
}