namespace WordSeparate
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Data.txt";
            string punctuation = "\\s,.;:!?()\\-";

            Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd, punctuation));
        }
    }
}