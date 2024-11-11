class Program
{
    static void Main(string[] args)
    {
        string dataFile = "data.csv";
        ApartamentRegister apartamentRegister = InOutUtils.ReadApartmentData(dataFile);

        if (apartamentRegister != null && apartamentRegister.GetCount() != 0)
        {
            // checks
            int roomCount = int.Parse(Console.ReadLine());
            int floor = int.Parse(Console.ReadLine());
            float maxPrice = float.Parse(Console.ReadLine());

            Apartament apartamentRequirements = new Apartament(roomCount, floor, maxPrice);
            
            List<Apartament> suitableApartaments = apartamentRegister.FindSuitableApartamens(apartamentRequirements);

            InOutUtils.PrintApartaments(suitableApartaments);
        }
        else Console.WriteLine("[ERROR] Duomenys nepateikti arba nepakanka duomenu");
    }
}
