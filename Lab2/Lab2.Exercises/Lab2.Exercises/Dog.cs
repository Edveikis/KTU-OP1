class Dog
{
    int ID;
    string Name;
    string Breed;
    DateTime BirthDate;
    Gender Gender;
    private const int VaccinationDuration = 1;
    public DateTime LastVaccinationDate { get; set; }

    public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
    {
        ID = id;
        Name = name;
        Breed = breed;
        BirthDate = birthDate;
        Gender = gender;
    }

    //public int CalcAge()
    //{
    //    DateTime today = DateTime.Today;
    //    int age = today.Year - BirthDate.Year;

    //    if (BirthDate.Date > today.AddYears(-age)) --age;

    //    return age;
    //}
    public int Age
    {
        get
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.BirthDate.Year;
            if (this.BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
    //public bool RequiresVaccination()
    //{
    //    if (LastVaccinationDate.Equals(DateTime.MinValue)) return true;
    //    return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
    //}
    public bool RequiresVaccination
    {
        get
        {
            if (LastVaccinationDate.Equals(DateTime.MinValue))
            {
                return true;
            }
            return LastVaccinationDate.AddYears(VaccinationDuration)
            .CompareTo(DateTime.Now) < 0;
        }
    }

    // Getters
    public int GetID() { return ID; }
    public string GetName() { return Name; }
    public string GetBreed() { return Breed; }
    public DateTime GetBirthDate() { return BirthDate; }
    public Gender GetGender() { return Gender; }

    public override bool Equals(object other) { return this.ID == ((Dog)other).ID; }
    public override int GetHashCode() { return this.ID.GetHashCode(); }
}