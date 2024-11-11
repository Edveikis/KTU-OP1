internal class Task
{
    public static void GetTripMoney(List<Person> people)
    {
        foreach (Person person in people) 
            person.TripMoney = person.Money * 0.25f;
    }

    public static float GetTotalBudget(List<Person> people)
    {
        float budget = 0.0f;

        foreach (Person person in people)
            budget += person.TripMoney;

        return budget;
    }

    public static float BiggestPersonBudget(List<Person> people) 
    {
        float budget = 0.0f;

        foreach(Person person in people)
            if (person.TripMoney > budget)
                budget = person.TripMoney;

        return budget;
    }

    public static List<Person> GetBiggestContributors(List<Person> people)
    {
        List<Person> contributors = new List<Person>(); 
        float biggestContribution = Task.BiggestPersonBudget(people);

        foreach (Person person in people)
            if (person.TripMoney == biggestContribution)
                contributors.Add(person);

        return contributors;
    }
}

