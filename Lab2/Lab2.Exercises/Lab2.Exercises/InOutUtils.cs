using System.Text;

internal class InOutUtils
{
    public static DogsRegister ReadDogs(string fileName)
    {
        DogsRegister register = new DogsRegister();

        if (!File.Exists(fileName)) 
            return register;

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] values = line.Split(";");

            if (values.Length != 5)
                continue;

            int id;
            string name = values[1];
            string breed = values[2];
            DateTime birthDate;
            Gender gender;

            if (!int.TryParse(values[0], out id) || !DateTime.TryParse(values[3], out birthDate) ||
                !Enum.TryParse(values[4], out gender))
                continue;

            Dog dog = new Dog(id, name, breed, birthDate, gender);
            if (!register.Contains(dog)) register.Add(dog);
        }

        return register;
    }

    public static void PrintDogs(DogsRegister register)
    {
        Console.WriteLine(new String('-', 74));
        Console.WriteLine("| {0,8} | {1,-15} | {2, -15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
        Console.WriteLine(new string('-', 74));
        for (int i = 0; i < register.DogsCount(); ++i)
        {
            Dog dog = register.GetDog(i);
            int dogID = dog.GetID();
            string dogName = dog.GetName();
            string dogBreed = dog.GetBreed();
            DateTime dogBirthDate = dog.GetBirthDate();
            Gender dogGender = dog.GetGender();

            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
                dogID, dogName, dogBreed, dogBirthDate, dogGender);
        }
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
        {
            int dogID = dogs[i].GetID();
            string dogName = dogs[i].GetName();
            DateTime dogBirthDate = dogs[i].GetBirthDate();
            Gender dogGender = dogs[i].GetGender();
            
            lines[i + 1] = String.Format("{0};{1};{2};{3}",
                dogID, dogName, dogBirthDate, dogGender);
        }

        File.WriteAllLines(fileName, lines, Encoding.UTF8);
    }
    public static List<Vaccination> ReadVaccinations(string fileName)
    {
        List<Vaccination> Vaccinations = new List<Vaccination>();
        string[] Lines = File.ReadAllLines(fileName);

        foreach (string line in Lines)
        {
            string[] Values = line.Split(';');
            int id = int.Parse(Values[0]);
            DateTime vaccinationDate = DateTime.Parse(Values[1]);

            Vaccinations.Add(new Vaccination(id, vaccinationDate));
        }

        return Vaccinations;
    }
}