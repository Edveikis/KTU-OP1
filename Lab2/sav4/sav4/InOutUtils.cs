using System.Net.NetworkInformation;

internal class InOutUtils
{
    public static ApartamentRegister ReadApartmentData(string fileName)
    {
        List<Apartament> apartaments = new List<Apartament>();

        if (!File.Exists(fileName)) return null;

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] values = line.Split(";");

            if (values.Length != 5) continue;

            int apartamentNumber = 0;
            float area = 0;
            int roomCount = 0;
            float price = 0;
            string phoneNumber = values[4];

            if (!int.TryParse(values[0], out apartamentNumber) ||
                !float.TryParse(values[1], out area) ||
                !int.TryParse(values[2], out roomCount) ||
                !float.TryParse(values[3], out price)) continue;

            if (apartamentNumber <= 0 || area <= 0.0 || roomCount <= 0 || price <= 0.0) continue;

            apartaments.Add(new Apartament(apartamentNumber, area, roomCount, price, phoneNumber));
        }

        return new ApartamentRegister(apartaments);
    }

    public static void PrintApartaments(List<Apartament> apartaments)
    {
        if (apartaments.Count == 0)
            return;

        Console.WriteLine(new string('-', 72));
        Console.WriteLine("| {0,10} | {1,10} | {2,10} | {3,10} | {4,15} |",
                "Buto nr", "Plotas", "Kambariu sk", "Kaina", "Tel. nr.");
        Console.WriteLine(new string('-', 72));

        foreach (Apartament apartament in apartaments)
            Console.WriteLine("| {0,10} | {1,10} | {2,10} | {3,10} | {4,15} |",
                    apartament.Number, apartament.Area, apartament.RoomCount, apartament.Price, apartament.PhoneNumber);

        Console.WriteLine(new string('-', 72));
    }
}