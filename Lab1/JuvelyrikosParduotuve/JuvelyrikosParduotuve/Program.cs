namespace JuvelyrikosParduotuve
{
    class Program
    {
        internal static void Main(string[] args)
        {
            string dataFileName = "data.csv";
            // Read ring data from a file
            List<Ring> rings = InOutUtils.GetRingsFromFile(dataFileName);

            InOutUtils.StartDataToTableFile(rings, "pradiniai.txt");

            // If the list is not empty, continue the application flow
            if (rings.Count != 0)
            {
                // Find the most expensive rings
                List<Ring> mostExpensiveRings = Task.GetMostExpensiveRings(rings);
                // Print most expensive ring data
                Console.WriteLine("Brangiausi ziedai:");
                InOutUtils.PrintMostExpensiveRingData(mostExpensiveRings);

                // Padding
                Console.WriteLine();

                // Find rings with the highest praba
                List<Ring> highestPrabaRings = Task.GetHighestPrabaRings(rings);
                // Print highest praba ring data
                Console.WriteLine("Ziedai su didziausia praba: {0}", highestPrabaRings.Count);
                InOutUtils.PrintRingData(highestPrabaRings);

                // Find white gold rings that cost less than 300
                List<Ring> whiteGold = Task.GetCheapWhiteGoldRings(rings);
                // Write cheap white gold ring data to a separate file
                InOutUtils.WriteRingDataToFile(whiteGold, "BA300.csv");
            }
            else Console.WriteLine("[ERROR] Duomenu failas {0} tuscias arba neegzistuoja", dataFileName);
        }
    }
}
