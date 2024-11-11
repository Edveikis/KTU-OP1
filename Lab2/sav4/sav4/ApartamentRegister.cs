internal class ApartamentRegister
{
    const int APARTAMENTS_PER_FLOOR = 3;
    List<Apartament> apartaments;

    public ApartamentRegister(List<Apartament> apartaments)
    {
        this.apartaments = apartaments;
    }

    public List<Apartament> FindSuitableApartamens(Apartament apartamentRequirements)
    {
        List<Apartament> suitableApartaments = new List<Apartament>();

        foreach (Apartament apartament in apartaments)
            if (apartament.Equals(apartamentRequirements)) suitableApartaments.Add(apartament);

        return suitableApartaments;
    }

    public int GetCount() { return apartaments.Count; }
    public List<Apartament> GetApartaments() { return apartaments; }
}