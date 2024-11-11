class DogsRegister
{
    private DogsContainer AllDogs;

    public DogsRegister()
    {
        AllDogs = new DogsContainer();
    }
    public DogsRegister(DogsContainer Dogs)
    {
        AllDogs = Dogs;
    }

    public void Add(Dog dog) { AllDogs.Add(dog); }
    public int DogsCount() { return AllDogs.Count; }
    public Dog GetDog(int index) { return AllDogs.GetDog(index); }
    public int CountByGender(Gender gender)
    {
        int count = 0;

        for (int i = 0; i < AllDogs.Count; ++i)
            if (AllDogs.GetDog(i).GetGender() == gender) ++count;

        return count;
    }
    private Dog FindOldestDogs(DogsContainer dogs)
    {
        DateTime oldestBirth = DateTime.Today;
        Dog oldestDog = dogs.GetDog(0);

        for (int i = 0; i < dogs.Count; ++i)
        {
            if (dogs.GetDog(i).GetBirthDate() < oldestBirth)
            {
                oldestDog = dogs.GetDog(i);
                oldestBirth = dogs.GetDog(i).GetBirthDate();
            }
        }

        return oldestDog;
    }
    public Dog FindOldestDogs() { return FindOldestDogs(AllDogs); }
    public Dog FindOldestDogs(string breed)
    {
        DogsContainer filtered = FilterByBreed(breed);
        return FindOldestDogs(AllDogs);
    }
    public List<string> FindBreeds()
    {
        List<string> breeds = new List<string>();

        for (int i = 0; i < AllDogs.Count; ++i)
        {
            string breed = AllDogs.GetDog(i).GetBreed();
            if (!breeds.Contains(breed)) breeds.Add(breed);
        }

        return breeds;
    }
    public DogsContainer FilterByBreed(string breed)
    {
        DogsContainer filteredDogs = new DogsContainer();

        for (int i = 0; i < AllDogs.Count; ++i)
            if (AllDogs.GetDog(i).GetBreed() == breed) filteredDogs.Add(AllDogs.GetDog(i));

        return filteredDogs;
    }
    private Dog FindDogByID(int ID)
    {
        for (int i = 0; i < AllDogs.Count; ++i)
            if (AllDogs.GetDog(i).GetID() == ID) return AllDogs.GetDog(i);

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
    public DogsContainer FilterByVaccinationExpired()
    {
        DogsContainer notVaccinatedRegister = new DogsContainer();

        for (int i = 0; i < AllDogs.Count; ++i)
        {
            Dog dog = AllDogs.GetDog(i);
            if (dog.RequiresVaccination) notVaccinatedRegister.Add(dog);
        }

        return notVaccinatedRegister;
    }
    public bool Contains(Dog dog) { return AllDogs.Contains(dog); }
}