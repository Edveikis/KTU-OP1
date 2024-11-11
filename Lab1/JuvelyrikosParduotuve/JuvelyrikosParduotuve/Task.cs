internal class Task
{
    // Find the biggest price of a ring
    public static double FindBiggestRingPrice(List<Ring> rings)
    {
        double biggestRingPrice = 0.0f;

        // Will compare ring price value against biggestRingPrice until biggest value is found
        foreach (Ring ring in rings) 
            if (ring.GetPrice() > biggestRingPrice)
                biggestRingPrice = ring.GetPrice();

        // return biggest ring price
        return biggestRingPrice;
    }

    // Find a list of rings that have the biggest price out of all rings
    public static List<Ring> GetMostExpensiveRings(List<Ring> rings) 
    {
        // New list of most expensive rings
        List<Ring> mostExpensiveRings = new List<Ring>();
        // Get the biggest price of a ring
        double biggestPrice = Task.FindBiggestRingPrice(rings);

        // Add all rings to the list that have the biggest price
        foreach (Ring ring in rings)
            if (ring.GetPrice() == biggestPrice)
                mostExpensiveRings.Add(ring);

        // Return the most expensive ring list
        return mostExpensiveRings;
    }

    // Find rings with the highest praba rating
    public static List<Ring> GetHighestPrabaRings(List<Ring> rings)
    {
        List<Ring> highestPrabaRings = new List<Ring>();

        foreach (Ring ring in rings)
        {
            // Based on the metal type select rings with the highest praba rating
            switch (ring.GetMetalType())
            {
                case "Auksas":
                    if (ring.GetPraba() == 750)
                        highestPrabaRings.Add(ring);
                    break;
                case "Platina":
                    if (ring.GetPraba() == 950)
                        highestPrabaRings.Add(ring);
                    break;
                case "Sidabras":
                    if (ring.GetPraba() == 925)
                        highestPrabaRings.Add(ring);
                    break;
                case "Paladis":
                    if (ring.GetPraba() == 850)
                        highestPrabaRings.Add(ring);
                    break;
            }
        }

        return highestPrabaRings;
    }

    // Find cheap white gold rings.
    // Cheap is considered when the price is less than 300
    public static List<Ring> GetCheapWhiteGoldRings(List<Ring> rings)
    {
        List<Ring> cheapWhiteGoldRings = new List<Ring>();

        // Create a list of cheap white gold rings that have a price of less than 300 and metal type of baltas auksas
        foreach(Ring ring in rings)
            if (ring.GetMetalType() == "Baltas auksas" && ring.GetPrice() < 300.0f)
                cheapWhiteGoldRings.Add(ring);

        return cheapWhiteGoldRings;
    }
}
