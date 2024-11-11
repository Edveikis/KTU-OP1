namespace sav_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = InOutUtils.GetPeopleFromFile("data.csv");
            Task.GetTripMoney(people);

            InOutUtils.PrintPeopleBudgets(people);
            float totalBudget = Task.GetTotalBudget(people);
            Console.WriteLine("Bendras biudzetas: {0}", totalBudget);

            Console.WriteLine();
            Console.WriteLine("Daugiausiai pinigu skyre:");
            List<Person> biggestContributors = Task.GetBiggestContributors(people);
            InOutUtils.PrintBiggestContributors(biggestContributors);
        }
    }
}