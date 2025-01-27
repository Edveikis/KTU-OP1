namespace JuvelyrikosParduotuve
{
    class Program
    {
        internal static void Main(string[] args)
        {
            RingShop shop0 = InOutUtils.GetRingsFromFile("data.csv");
            RingShop shop1 = InOutUtils.GetRingsFromFile("data1.csv");

            if (shop0 != null && shop1 != null)
            {
                List<RingShop> shops = new List<RingShop>();

                shops.Add(shop0);
                shops.Add(shop1);

                // Create shop register, read data into it
                ShopRegister shopRegister = new ShopRegister(shops);

                // Find the highest praba rings from all shops
                List<RingShop> highestPrabaShops = new List<RingShop>();
                shopRegister.GetMostExpensiveHighestPrabaShops(ref highestPrabaShops);
                if (highestPrabaShops.Count > 0)
                {
                    Console.WriteLine("Auksciausios prabos brangiausias ziedas");
                    InOutUtils.PrintRingData(highestPrabaShops);
                    Console.WriteLine();
                }
                else Console.WriteLine("[ERROR] auksciausios prabos ziedas nerastas");

                // Find the most expensive rings from all shops
                List<RingShop> mostExpensiveShops = new List<RingShop>();
                shopRegister.GetMostExpensiveRingsShops(ref mostExpensiveShops);
                if (mostExpensiveShops.Count > 0)
                {
                    Console.WriteLine("Brangiausi ziedai:");
                    InOutUtils.PrintRingData(mostExpensiveShops);
                }
                else
                    Console.WriteLine("[ERROR] brangiausi ziedai nerasti");

                // Find cheap white gold rings from all shops
                List<RingShop> cheapWhiteGoldShops = new List<RingShop>();
                shopRegister.GetCheapWhiteGoldRingsShops(ref cheapWhiteGoldShops);
                if (cheapWhiteGoldShops.Count > 0)
                    InOutUtils.WriteGoldRingDataToFile(cheapWhiteGoldShops, "BA300.csv");
                else
                    Console.WriteLine("[ERROR] pigiu balto aukso ziedu nerasta");
                InOutUtils.StartDataToTableFile(shopRegister, "pradiniai.txt");
            }
            else
            {
                Console.WriteLine("[ERROR] privalo buti 2 parduotuves, duomenu nepakanka, arba duomenys nerasti");
            }
        }
    }
}
