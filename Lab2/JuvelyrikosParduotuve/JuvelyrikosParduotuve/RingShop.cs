internal class RingShop
{
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

    public string GetName(int index) { return rings[index].Name; }

    public int GetCount() { return rings.Count; }

    public void AddRing(Ring ring) { rings.Add(ring); }

    public void AddRings(List<Ring> rings) { this.rings.AddRange(rings); }

    public int GetHighestPraba()
    {
        int highestPraba = 0;

        foreach (Ring ring in rings)
        {
            if (ring.Praba > highestPraba)
                highestPraba = ring.Praba;
        }

        return highestPraba;
    }

    public bool HigherPraba(RingShop other)
    {
        int highestPraba = GetHighestPraba();

        if (highestPraba > other.GetHighestPraba())
            return false;

        return true;
    }

    // Method to get the highest praba ring encapsulated within the RingShop
    public void GetHighestPrabaRingShop(ref RingShop highestPrabaRingShop)
    {
        Ring highestPrabaRing = null;
        int highestPraba = GetHighestPraba();
        double highestPrice = 0;

        foreach (Ring ring in rings)
        {
            if (ring.Praba == highestPraba)
            {
                if (ring.Price > highestPrice)
                {
                    highestPrice = ring.Price;
                    highestPrabaRing = ring;
                }
            }
        }

        if (highestPrabaRing == null) return;

        // Create a new RingShop and add the most expensive highest praba ring to it
        highestPrabaRingShop = new RingShop(Name, Address, PhoneNumber);
        highestPrabaRingShop.AddRing(highestPrabaRing);
    }

    public double HighestPrice()
    {
        double highestPrice = 0;

        foreach (Ring ring in rings)
            if (ring.Price > highestPrice)
                highestPrice = ring.Price;

        return highestPrice;
    }

    // Method to get the most expensive rings encapsulated within the RingShop
    public void GetHighestPriceRingShop(ref RingShop highestPriceRingShop)
    {
        double highestPrice = HighestPrice();
        List<Ring> highestPriceRings = new List<Ring>();

        foreach (Ring ring in rings)
            if (ring.Price == highestPrice)
                highestPriceRings.Add(ring);

        if (highestPriceRings.Count == 0)
            return;

        highestPriceRingShop = new RingShop(Name, Address, PhoneNumber);
        highestPriceRingShop.AddRings(highestPriceRings);
    }

    // Method to get cheap white gold rings encapsulated within the RingShop
    public RingShop GetCheapWhiteGoldRingsShop()
    {
        List<Ring> cheapWhiteGoldRings = new List<Ring>();

        foreach (Ring ring in rings)
            if (ring.MetalType == "Baltas auksas" && ring.Price < 300)
                cheapWhiteGoldRings.Add(ring);

        if (cheapWhiteGoldRings.Count == 0) return null;

        RingShop cheapWhiteGoldRingShop = new RingShop(Name, Address, PhoneNumber);

        cheapWhiteGoldRingShop.AddRings(cheapWhiteGoldRings);

        return cheapWhiteGoldRingShop;
    }

    public string GetFormattedRing(int index) { return rings[index].ToString(); }

    public string FormatCSVRing(int index)
    {
        return string.Format("{0};{1};{2};{3};{4};{5};{6}",
        rings[index].Manufacturer, rings[index].Name, rings[index].MetalType, rings[index].Size, rings[index].Weight, rings[index].Praba, rings[index].Price);
    }

    public string FormatTableRing(int index) { return rings[index].ToString(); }
}
