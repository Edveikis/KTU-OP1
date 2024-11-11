using System.Text;

internal class InOutUtils
{
    public static List<Dog> ReadDogs(string fileName)
    {
        List<Dog> dogs = new List<Dog>();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines) 
        {
            string[] values = line.Split(";");
            int id = int.Parse(values[0]);
            string name = values[1];
            string breed = values[2];
            DateTime birthDate = DateTime.Parse(values[3]);
            Gender gender;
            Enum.TryParse(values[4], out gender);

            Dog dog = new Dog(id, name, breed, birthDate, gender);
            dogs.Add(dog);
        }

        return dogs;
    }

    public static void PrintDogs(List<Dog> dogs)
    {
        Console.WriteLine(new String('-', 74));
        Console.WriteLine("| {0,8} | {1,-15} | {2, -15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
        Console.WriteLine(new string('-', 74));
        foreach (Dog dog in dogs) 
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
        Console.WriteLine(new string('-', 74));
    }

    public static void PrintBreeds(List<string> breeds)
    {
        foreach (string breed in breeds) Console.WriteLine(breed);
    }

    public static void PrintDogsToCSVFile(List<Dog> dogs, string fileName)
    {
        string[] lines = new string[dogs.Count + 1];
        lines[0] = String.Format("{0};{1};{2};{3}", "Reg.Nr.", "Veisle", "Gimimo data", "Lytis");
        for (int i = 0; i < dogs.Count; ++i)
            lines[i + 1] = String.Format("{0};{1};{2};{3}", dogs[i].ID, dogs[i].Name, dogs[i].BirthDate, dogs[i].Gender);

        File.WriteAllLines(fileName, lines, Encoding.UTF8);
    }
}
