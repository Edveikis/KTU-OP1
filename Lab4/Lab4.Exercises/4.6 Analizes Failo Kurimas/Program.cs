namespace AnalysisFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Data.txt";
            const string CFr = "Results.txt";
            const string CFa = "Analysis.txt";
            const string vowels = "AEIYOUaeiyouĄąĘęĖėĮįŲųŪū";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            TaskUtils.Process(CFd, CFr, CFa, punctuation, vowels);
        }
    }
}