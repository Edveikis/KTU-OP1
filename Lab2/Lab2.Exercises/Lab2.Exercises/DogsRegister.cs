class DogsRegister
{
    private List<Dog> AllDogs;

    public DogsRegister()
    {
        AllDogs = new List<Dog>();
    }
    public DogsRegister(List<Dog> Dogs)
    {
        AllDogs = new List<Dog>();
        foreach (Dog dog in Dogs)
            AllDogs.Add(dog);
    }

    public void Add(Dog dog) { AllDogs.Add(dog); }
    public int DogsCount() { return AllDogs.Count; }
    public Dog GetDog(int index) { return AllDogs[index]; }
    public int CountByGender(Gender gender)
    {
        int count = 0;

        for (int i = 0; i < AllDogs.Count; ++i)
            if (AllDogs[i].GetGender() == gender) ++count;

        return count;
    }
    private Dog FindOldestDogs(List<Dog> dogs)
    {
        DateTime oldestBirth = DateTime.Today;
        Dog oldestDog = dogs[0];

        foreach (Dog dog in dogs)
        {
            if (dog.GetBirthDate() < oldestBirth)
            {
                oldestDog = dog;
                oldestBirth = dog.GetBirthDate();
            }
        }

        return oldestDog;
    }
    public Dog FindOldestDogs() { return FindOldestDogs(AllDogs); }
    public Dog FindOldestDogs(string breed)
    {
        List<Dog> filtered = FilterByBreed(breed);
        return FindOldestDogs(AllDogs);
    }
    public List<string> FindBreeds()
    {
        List<string> breeds = new List<string>();

        foreach (Dog dog in AllDogs)
        {
            string breed = dog.GetBreed();
            if (!breeds.Contains(breed)) breeds.Add(breed);
        }

        return breeds;
    }
    public List<Dog> FilterByBreed(string breed)
    {
        List<Dog> filteredDogs = new List<Dog>();

        foreach (Dog dog in AllDogs)
            if (dog.GetBreed() == breed) filteredDogs.Add(dog);

        return filteredDogs;
    }
    private Dog FindDogByID(int ID)
    {
        foreach (Dog dog in this.AllDogs)
            if (dog.GetID() == ID) return dog;

        return null;
    }
    public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
    {
        foreach (Vaccination vaccination in Vaccinations)
        {
            Dog dog = FindDogByID(vaccination.DogID);
            if (dog == null) return;

            if (vaccination > dog.LastVaccinationDate) dog.LastVaccinationDate = vaccination.Date;
        }
    }
    public DogsRegister FilterByVaccinationExpired()
    {
        DogsRegister notVaccinatedRegister = new DogsRegister();

        for (int i = 0; i < AllDogs.Count; ++i)
        {
            Dog dog = AllDogs[i];
            if (dog.RequiresVaccination) notVaccinatedRegister.Add(dog);
        }

        return notVaccinatedRegister;
    }
    public bool Contains(Dog dog) { return AllDogs.Contains(dog); }
}