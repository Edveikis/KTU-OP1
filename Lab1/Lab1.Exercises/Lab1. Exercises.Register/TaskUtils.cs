internal class TaskUtils
{
    public static int CountByGender(List<Dog> dogs, Gender gender)
    {
        int count = 0;

        foreach (Dog dog in dogs)
            if (dog.Gender == gender) ++count;

        return count;
    }

    public static Dog FindOldestDogs(List<Dog> dogs)
    {
        DateTime oldestBirth = DateTime.Today;
        Dog oldestDog = null;

        foreach (Dog dog in dogs) 
        {
            if (dog.BirthDate < oldestBirth)
            {
                oldestDog = dog;
                oldestBirth = dog.BirthDate;
            }
        }

        return oldestDog;
    }

    public static List<string> FindBreeds(List<Dog> Dogs)
    {
        List<string> breeds = new List<string>();
        
        foreach (Dog dog in Dogs) 
            if (!breeds.Contains(dog.Breed)) breeds.Add(dog.Breed);

        return breeds;
    }

    public static void PrintBreeds(List<string> breeds)
    {
        foreach (string breed in breeds) Console.WriteLine(breed);
    }

    public static List<Dog> FilterByBreed(List<Dog> dogs, string breed)
    {
        List<Dog> filteredDogs = new List<Dog>();

        foreach (Dog dog in dogs) 
            if (dog.Breed == breed) filteredDogs.Add(dog);
    
        return filteredDogs;
    }
}


