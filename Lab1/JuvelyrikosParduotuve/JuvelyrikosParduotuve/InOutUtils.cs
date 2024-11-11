using System;
using System.IO;

internal class InOutUtils
{
    // Reads ring data from a file
    public static List<Ring> GetRingsFromFile(string fileName)
    {
        // New list is created
        List<Ring> rings = new List<Ring>();

        if (!File.Exists(fileName))
            return rings;

        // File lines stored in str arr
        string[] lines = File.ReadAllLines(fileName);

        // Create new ring, add it to rings arr
        foreach (string line in lines)
        {
            string[] values = line.Split(';');

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

            // Try parse, create variables first with names, do checks
            Ring ring = new Ring(manufacturer, name, metalType, weight, size, praba, price);
            rings.Add(ring);
        }

        // Return rings
        return rings;
    }

    // Prints most expensive rings name, metal, size, weight, praba
    public static void PrintRingData(List<Ring> rings)
    {
        // If the list is empty, print a warning
        if (rings.Count == 0)
            Console.WriteLine("[ERROR] PrintRingData: rings list is empty!");
        else
            // Print all rings data
            foreach (Ring ring in rings)
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", ring.GetManufacturer(), ring.GetName(), ring.GetMetalType(), ring.GetWeight(), ring.GetSize(), ring.GetPraba(), ring.GetPrice());
    }

    // Prints the most expensive ring data.
    // Prints: Name, metal type, size, weight, praba
    public static void PrintMostExpensiveRingData(List<Ring> mostExpensiveRings)
    {
        // If the list is empty, print a warning
        if (mostExpensiveRings.Count == 0)
            Console.WriteLine("[ERROR] PrintMostExpensiveRingData: no data in mostExpensiveRings list!");
        else
            // Print all rings data
            foreach (Ring ring in mostExpensiveRings)
                Console.WriteLine("{0} {1} {2} {3} {4}", ring.GetName(), ring.GetMetalType(), ring.GetSize(), ring.GetWeight(), ring.GetPraba());
    }

    // Writes ring data to a file
    public static void WriteRingDataToFile(List<Ring> rings, string fileName)
    {
        // If ring list is empty, show error
        if (rings.Count == 0)
            Console.WriteLine("[ERROR] WriteRingDataToFile: writing to {0}, rings list empty!", fileName);
        else
            // Write all the data to the file if list is not empty
            using (StreamWriter writer = new StreamWriter(fileName))
                foreach (Ring ring in rings)
                    writer.WriteLine("{0};{1};{2};{3};{4};{5};{6}", ring.GetManufacturer(), ring.GetName(), ring.GetMetalType(), ring.GetWeight(), ring.GetSize(), ring.GetPraba(), ring.GetPrice());
    }

    // Prints starting data to a text file in a formated table
    public static void StartDataToTableFile(List<Ring> rings, string fileName)
    {
        if (rings.Count == 0)
            return;

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(new string('-', 122));
            writer.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,10} | {4,10} | {5,10} | {6,10} |",
                "Gamintojas", "Pavadinimas", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            writer.WriteLine(new string('-', 122));

            foreach (Ring ring in rings)
                writer.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,10} | {4,10} | {5,10} | {6,10} |",
                    ring.GetManufacturer(), ring.GetName(), ring.GetMetalType(), ring.GetWeight(), ring.GetSize(), ring.GetPraba(), ring.GetPrice());

            writer.WriteLine(new string('-', 122));
        }
    }
}