internal class InOutUtils
{
    public static List<Person> GetPeopleFromFile(string filename)
    {
        List<Person> people = new List<Person>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] values = line.Split(';');
            Person person = new Person();

            person.Name = values[0];
            person.Surname = values[1];
            person.Money = float.Parse(values[2]);

            people.Add(person);
        }

        return people;
    }

    public static void PrintPeopleBudgets(List<Person> people)
    {
        foreach (Person person in people)
            Console.WriteLine("{0} {1} skyre {2}eur", person.Name, person.Surname, person.TripMoney);
    }

    public static void PrintBiggestContributors(List<Person> biggestContributors)
    {
        foreach (Person person in biggestContributors)
            Console.WriteLine("{0} {1} - {2}eur", person.Name, person.Surname, person.TripMoney);
    }
}
