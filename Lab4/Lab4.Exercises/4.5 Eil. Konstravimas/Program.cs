namespace LineConstruct
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Data.txt";
            const string CFr = "Results.txt";
            string punctuation = " .,!?:;()\t'";
            string name = "Arvydas";
            string surname = "Sabonis";
            TaskUtils.Process(CFd, CFr, punctuation, name, surname);
        }
    }
}