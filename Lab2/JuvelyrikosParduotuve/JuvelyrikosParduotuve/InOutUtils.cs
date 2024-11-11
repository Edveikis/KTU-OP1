internal class InOutUtils
{
    // Reads ring data from a file
    public static ShopRegister GetRingsFromFile(string fileName)
    {
        List<RingShop> shops = new List<RingShop>();
        RingShop shop = null;

        if (!File.Exists(fileName))
            return null;

        // File lines stored in str arr
        string[] lines = File.ReadAllLines(fileName);

        // Create new ring, add it to rings arr
        for (int i = 0; i < lines.Length; ++i)
        {
            string[] values = lines[i].Split(';');

            if (values.Length == 1)
            {
                string[] storeName = values;
                string[] storeAddress = lines[i + 1].Split(';');
                string[] phoneNumber = lines[i + 2].Split(';');

                if (storeName.Length != 1 && storeAddress.Length != 1 && phoneNumber.Length != 1)
                    continue;

                shop = new RingShop(storeName[0], storeAddress[0], phoneNumber[0]);
                shops.Add(shop);
                i += 2;
                continue;
            }
            if (shop != null)
            {
                // If there is not enough data/wrong format, ignore the line
                if (values.Length != 7)
                    continue;

                // Values from line
                string manufacturer = values[0];
                string name = values[1];
                string metalType = values[2];
                double weight;
                double size;
                int praba;
                double price;

                // If parsing the data fails, iteration gets skipped
                if (!double.TryParse(values[3], out weight) || !double.TryParse(values[4], out size) ||
                    !int.TryParse(values[5], out praba) || !double.TryParse(values[6], out price))
                    continue;

                shop.AddRing(new Ring(manufacturer, name, metalType, weight, size, praba, price));
            }
        }

        // Return rings
        return new ShopRegister(shops);
    }

    // Prints data about a specific ring
    public static void PrintRingData(Ring ring)
    {
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", ring.Manufacturer, ring.Name, ring.MetalType, ring.Weight, ring.Size, ring.Praba, ring.Price);
    }

    // Prints data about list of rings
    public static void PrintRingsData(List<Ring> rings)
    {
        // If the list is empty, print a warning
        if (rings.Count == 0)
            Console.WriteLine("[ERROR] PrintRingData: rings list is empty!");
        else
            // Print all rings data
            foreach (Ring ring in rings)
                PrintRingData(ring);
    }

    // Prints data of most expensive rings
    public static void PrintMostExpensiveRingData(List<Ring> mostExpensiveRings, ShopRegister register)
    {
        // If the list is empty, print a warning
        if (mostExpensiveRings.Count == 0)
            Console.WriteLine("[ERROR] PrintMostExpensiveRingData: no data in mostExpensiveRings list!");
        else
        {
            // Print all rings data
            foreach (Ring ring in mostExpensiveRings)
            {
                RingShop ringShop = register.GetRingShop(ring);
                if (ringShop != null)
                    Console.WriteLine("Parduotuves: {0} brangiausias ziedas: {1} {2} {3} {4} {5} {6} {7}", ringShop.Name, ring.Manufacturer, ring.Name, ring.MetalType, ring.Size, ring.Weight, ring.Praba, ring.Price);
            }
        }
    }

    // Writes all the data about cheap white gold rings to a file
    public static void WriteGoldRingDataToFile(List<Ring> rings, ShopRegister register, string fileName)
    {
        // If ring list is empty, show error
        if (rings.Count == 0)
            Console.WriteLine("[ERROR] WriteRingDataToFile: writing to {0}, rings list empty!", fileName);
        else
        {
            // Write all the data to the file if list is not empty
            using (StreamWriter writer = new StreamWriter(fileName))
                foreach (Ring ring in rings)
                {
                    RingShop ringShop = register.GetRingShop(ring);
                    if (ringShop != null)
                        writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", ringShop.Name, ringShop.Address, ringShop.PhoneNumber, ring.Manufacturer, ring.Name, ring.MetalType, ring.Weight, ring.Size, ring.Praba, ring.Price);
                }
        }
    }

    // Writes start data to a file with a table format
    public static void StartDataToTableFile(ShopRegister register, string fileName)
    {
        List<RingShop> shops = register.GetShops();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < shops.Count; ++i)
            {
                RingShop shop = shops[i];
                List<Ring> rings = shop.GetRings();

                if (rings.Count == 0)
                    continue;

                if (i == 0)
                {
                    writer.WriteLine(new string('-', 191));
                    writer.WriteLine("| {0,-20} | {1,-20} | {2,20} | {3,-20} | {4,-20} | {5,-20} | {6,10} | {7,10} | {8,10} | {9,10} |",
                        "Parduotuve", "Adresas", "Tel. nr.", "Gamintojas", "Pavadinimas", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
                    writer.WriteLine(new string('-', 191));
                }

                foreach (Ring ring in rings)
                    writer.WriteLine("| {0,-20} | {1,-20} | {2,20} | {3,-20} | {4,-20} | {5,-20} | {6,10} | {7,10} | {8,10} | {9,10} |",
                        shop.Name, shop.Address, shop.PhoneNumber, ring.Manufacturer, ring.Name, ring.MetalType, ring.Weight, ring.Size, ring.Size, ring.Price);

            }
            writer.WriteLine(new string('-', 191));
        }
    }
}