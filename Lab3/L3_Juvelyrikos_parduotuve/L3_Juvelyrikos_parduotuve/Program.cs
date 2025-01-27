namespace JuvelyrikosParduotuve
{
    class Program
    {
        static void Main(string[] args)
        {
            RingShop shop0 = InOutUtils.GetRingsFromFile("data0.csv");
            RingShop shop1 = InOutUtils.GetRingsFromFile("data1.csv");

            if (shop0 != null && shop1 != null)
            {
                RingShop mostExpensiveRings = new RingShop();
                TaskUtils.GetMostExpensiveRing(shop0, shop1, ref mostExpensiveRings);
                if (mostExpensiveRings.GetCount() != 0)
                {
                    Console.WriteLine("Brangiausias ziedas:");
                    InOutUtils.PrintRingData(mostExpensiveRings);
                }

                Console.WriteLine();

                RingShop platina = new RingShop();
                RingShop gold = new RingShop();
                RingShop silver = new RingShop();
                RingShop paladis = new RingShop();
                TaskUtils.GetDifferentPrabas(shop0, shop1, ref platina, ref gold, ref silver, ref paladis);
                if (platina.GetCount() != 0)
                {
                    Console.WriteLine("Platina:");
                    InOutUtils.PrintRingData(platina);
                }
                else Console.WriteLine("Platinos nera");
                if (gold.GetCount() != 0)
                {
                    Console.WriteLine("Auksas:");
                    InOutUtils.PrintRingData(gold);
                }
                else Console.WriteLine("Aukso nera");
                if (silver.GetCount() != 0)
                {
                    Console.WriteLine("Sidabras:");
                    InOutUtils.PrintRingData(silver);
                }
                else Console.WriteLine("Sidabras nera");
                if (paladis.GetCount() != 0)
                {
                    Console.WriteLine("Paladis:");
                    InOutUtils.PrintRingData(paladis);
                }
                else Console.WriteLine("Paladzio nera");

                RingShop unique = new RingShop();
                TaskUtils.GetUniqueRings(shop0, shop1, ref unique);
                if (unique.GetCount() != 0)
                    InOutUtils.RingToCSV(unique, "Unikalūs.csv");


                RingShop whiteGold = new RingShop();
                TaskUtils.GetWhiteGold(shop0, shop1, ref whiteGold);
                if (whiteGold.GetCount() != 0)
                    InOutUtils.RingToCSV(whiteGold, "BA300.csv");

                InOutUtils.StartDataToTableFile(shop0, shop1, "Pradiniai.txt");
            }
        }
    }
}