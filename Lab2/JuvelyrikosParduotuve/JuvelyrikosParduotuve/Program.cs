namespace JuvelyrikosParduotuve
{
    class Program
    {
        internal static void Main(string[] args)
        {
            // Create shop register, read data into it
            ShopRegister shopRegister = InOutUtils.GetRingsFromFile("data.csv");
            if (shopRegister.GetShopCount() == 2)
            {
                // Find most expensive, highest praba ring
                Ring expensiveHighestPrabaRing = shopRegister.GetHighestPriceHighPrabaRing();
                if (expensiveHighestPrabaRing != null)
                {
                    // Find its shop
                    RingShop shop = shopRegister.GetRingShop(expensiveHighestPrabaRing);

                    if (shop != null)
                    {
                        Console.WriteLine("Brangiausio, auksciausios prabos ziedo parduotuve: {0}", shop.Name);
                        InOutUtils.PrintRingData(expensiveHighestPrabaRing);
                        Console.WriteLine();
                    }
                    else Console.WriteLine("[ERROR] parduotuve pagal pateikta zieda nerasta");
                }
                else Console.WriteLine("[ERROR] auksciausios prabos brangiausias ziedas nerastas");

                List<Ring> mostExpensiveRings = shopRegister.GetMostExpensiveRings();
                if (mostExpensiveRings.Count != 0)
                {
                    // Find and print most expensive ring from each store
                    InOutUtils.PrintMostExpensiveRingData(mostExpensiveRings, shopRegister);
                    Console.WriteLine();
                }
                else Console.WriteLine("[ERROR] nerasti brangiausi ziedai");

                List<Ring> cheapWhiteGoldRings = shopRegister.CheapWhiteRings(300.0);
                if (cheapWhiteGoldRings.Count != 0)
                    InOutUtils.WriteGoldRingDataToFile(cheapWhiteGoldRings, shopRegister, "BA300.csv");
                else Console.WriteLine("[ERROR] nerasta pigiu balto aukso ziedu");

                InOutUtils.StartDataToTableFile(shopRegister, "startData.txt");
            }
            else Console.WriteLine("[ERROR] privalo buti 2 parduotuves, duomenu nepakanka, arba duomenys nerasti");
        }
    }
}
