internal class InOutUtils
{
    // Reads ring data from a file
    public static RingShop GetRingsFromFile(string fileName)
    {
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
        return shop;
    }

    // Prints data about a specific ring
    public static void PrintRingData(List<RingShop> stores)
    {
        if (stores.Count == 0) return;

        foreach (RingShop store in stores)
        {
            Console.WriteLine(store.Name);
            for (int i = 0; i < store.GetCount(); ++i)
                Console.WriteLine(store.GetFormattedRing(i));
        }
    }

    public static void WriteGoldRingDataToFile(List<RingShop> cheapWhiteGoldShops, string fileName)
    {
        // If ring list is empty, show error
        if (cheapWhiteGoldShops.Count == 0)
            Console.WriteLine("[ERROR] WriteRingDataToFile: writing to {0}, rings list empty!", fileName);
        else
        {
            // Write all the data to the file if list is not empty
            using (StreamWriter writer = new StreamWriter(fileName))
                foreach (RingShop shop in cheapWhiteGoldShops)
                {
                    for (int i = 0; i < shop.GetCount(); ++i)
                    {
                        if (shop != null)
                            writer.WriteLine(shop.FormatCSVRing(i));
                    }
                }
        }
    }

    public static void StartDataToTableFile(ShopRegister register, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(new string('-', 162));
            writer.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,20} | {4,20} | {5,20} | {6,20} |",
                "Gamintojas", "Pavadinimas", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            writer.WriteLine(new string('-', 162));
            
            for (int i = 0; i < register.GetShopCount(); ++i)
            {
                RingShop shop = register.GetShop(i);

                for (int j = 0; j < shop.GetCount(); ++j)
                    writer.WriteLine(shop.FormatTableRing(i));

            }
            writer.WriteLine(new string('-', 162));
        }
    }
}