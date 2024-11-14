
namespace Raides
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFile = "Data.txt";
            const string outputFile = "Result.txt";
            LettersFrequency letters = new LettersFrequency();

            InOut.ReadRepetitions(inputFile, letters);

            int i_mostUsedLetter = letters.GetMostUsedLetter();
            if (i_mostUsedLetter != -1)
            {
                char ch = (char)letters.GetMostUsedLetter();
                Console.WriteLine("Dazniausiai naudojama raide: {0}", (char)letters.GetMostUsedLetter());
            }

            InOut.WriteDataToFile(outputFile, letters);
            InOut.WriteRepetitionSortedToFile("ResultSorted.txt", letters);
        }
    }
}