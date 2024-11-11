internal class ShopRegister
{
    List<RingShop> shops;

    public ShopRegister(List<RingShop> shops)
    {
        this.shops = shops;
    }

    // Returns a list of shops
    public List<RingShop> GetShops() { return shops; }

    // Returns shop count
    public int GetShopCount() { return shops.Count; }

    // Returns a list of rings that are the highest praba
    public List<Ring> GetHighestPrabaRings()
    {
        List<Ring> highestPrabaRings = new List<Ring>();

        foreach (RingShop shop in shops)
        {
            Ring highestPrabaRing = shop.GetHighestPrabaRing();

            if (highestPrabaRing != null)
                highestPrabaRings.Add(highestPrabaRing);
        }

        return highestPrabaRings;
    }

    // Returns a ring that is the most expensive
    public Ring GetHighestPriceRing(List<Ring> rings)
    {
        Ring mostExpensiveRing = null;
        double HighestPrice = 0.0;

        foreach (Ring ring in rings)
        {
            if (ring > HighestPrice)
            {
                HighestPrice = ring.Price;
                mostExpensiveRing = ring;
            }
        }

        return mostExpensiveRing;
    }

    // Returns highest price highest praba ring
    public Ring GetHighestPriceHighPrabaRing()
    {
        List<Ring> expensiveHighestPrabaRings = GetHighestPrabaRings();

        return GetHighestPriceRing(expensiveHighestPrabaRings);
    }

    // Returns ringshop based on the ring
    public RingShop GetRingShop(Ring ring)
    {
        foreach (RingShop shop in shops)
        {
            List<Ring> rings = shop.GetRings();
            if (rings.Contains(ring))
                return shop;
        }

        return null;
    }

    // Returns a list of most expensive rings
    public List<Ring> GetMostExpensiveRings()
    {
        List<Ring> mostExpensiveRings = new List<Ring>();

        foreach (RingShop shop in shops)
            mostExpensiveRings.AddRange(shop.GetHighestPriceRings());

        return mostExpensiveRings;
    }

    // Checks if the list of rings contains a specific ring
    bool HasRing(List<Ring> rings, Ring ring)
    {
        foreach (Ring r in rings)
            if (r == ring)
                return true;

        return false;
    }

    // Returns a list of cheap white gold rings that cost less than 300 from all stores
    public List<Ring> CheapWhiteRings(double maxPrice)
    {

        List<Ring> rings = shops[0].GetCheapWhiteGoldRings(maxPrice);

        foreach (RingShop shop in shops)
        {
            List<Ring> whiteGoldRings = shop.GetCheapWhiteGoldRings(maxPrice);

            foreach (Ring ring in whiteGoldRings)
                if (!HasRing(rings, ring))
                    rings.Add(ring);
        }

        return rings;
    }
}