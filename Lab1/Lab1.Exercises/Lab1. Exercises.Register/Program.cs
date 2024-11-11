namespace Lab1.Exercises.Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(dogs);
            Console.WriteLine("Is viso sunu: {0}", dogs.Count);
            Console.WriteLine("Pateliu skaicius: {0}", TaskUtils.CountByGender(dogs, Gender.FEMALE));
            Console.WriteLine("Patinu skaicius: {0}", TaskUtils.CountByGender(dogs, Gender.MALE));
        
            Dog oldestDog = TaskUtils.FindOldestDogs(dogs);
            Console.WriteLine("Seniausias suo:");
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldestDog.Name, oldestDog.Breed, oldestDog.CalcAge());

            List<string> allBreeds = TaskUtils.FindBreeds(dogs);
            Console.WriteLine("Sunu veisles:");
            TaskUtils.PrintBreeds(allBreeds);

            Console.WriteLine("Kokios veisles sunis atrinkti?");
            string selectedBreed = Console.ReadLine();

            List<Dog> filteredDogs = TaskUtils.FilterByBreed(dogs, selectedBreed);
            InOutUtils.PrintDogs(filteredDogs);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(filteredDogs, fileName);
        }
    }
}