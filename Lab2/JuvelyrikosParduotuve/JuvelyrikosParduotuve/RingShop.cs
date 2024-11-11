internal class RingShop
{
    // Rings that the store has in stock
    List<Ring> rings;
    public string Name { get; }
    public string Address { get; }
    public string PhoneNumber { get; }

    public RingShop(string name, string address, string phoneNumber)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        rings = new List<Ring>();
    }

    // Returns list of rings that the store has
    public List<Ring> GetRings() { return rings; }

    // Returns count of rings that the store has
    public int GetRingCount() { return rings.Count; }

    // Adds a ring to the store ring list
    public void AddRing(Ring ring) { rings.Add(ring); }

    // Returns the highest praba value amongst all rings
    int GetHighestPraba()
    {
        int highestPraba = 0;

        foreach (Ring ring in rings)
            if (ring > highestPraba)
                highestPraba = ring.Praba;

        return highestPraba;
    }

    // Returns a ring with the highest praba value
    public Ring GetHighestPrabaRing()
    {
        Ring highestPrabaRing = null;
        int highestPraba = GetHighestPraba();

        foreach (Ring ring in rings)
            if (ring == highestPraba)
                highestPrabaRing = ring;

        return highestPrabaRing;
    }

    // Returns the highest price amongst all rings
    double GetHighestPrice()
    {
        double highestPrice = 0.0;

        foreach (Ring ring in rings)
            if (ring > highestPrice)
                highestPrice = ring.Price;

        return highestPrice;
    }

    // Returns a list of highest price rings
    public List<Ring> GetHighestPriceRings()
    {
        List<Ring> mostExpensiveRings = new List<Ring>();
        double HighestPrice = GetHighestPrice();

        foreach (Ring ring in rings)
        {
            if (ring == HighestPrice)
            {
                HighestPrice = ring.Price;
                mostExpensiveRings.Add(ring);
            }
        }

        return mostExpensiveRings;
    }

    // Returns a list of rings that are made of white gold and cost less than 300
    public List<Ring> GetCheapWhiteGoldRings(double maxPrice)
    {
        List<Ring> cheapGoldRings = new List<Ring>();

        foreach (Ring ring in rings)
            if (ring.MetalType == "Baltas auksas" && ring < maxPrice)
                cheapGoldRings.Add(ring);

        return cheapGoldRings;
    }
}