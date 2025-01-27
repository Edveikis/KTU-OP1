static class TaskUtils
{
    public static void GetMostExpensiveRing(RingShop s0, RingShop s1, ref RingShop mostExpensive)
    {
        RingShop mostExp0 = new RingShop(s0.Name, s0.Address, s0.PhoneNumber);
        s0.GetMostExpensiveRing(ref mostExp0);

        RingShop mostExp1 = new RingShop(s1.Name, s1.Address, s1.PhoneNumber);
        s1.GetMostExpensiveRing(ref mostExp1);

        if (mostExp0.GetHighestPrice() > mostExp1.GetHighestPrice())
            mostExpensive.AddRings(mostExp0);
        else if (mostExp0.GetHighestPrice() < mostExp1.GetHighestPrice())
            mostExpensive.AddRings(mostExp1);
        else
        {
            mostExpensive.AddRings(mostExp0);
            mostExpensive.AddRings(mostExp1);
        }
    }

    public static void GetDifferentPrabas(RingShop s0, RingShop s1, ref RingShop platina, ref RingShop gold, ref RingShop silver, ref RingShop paladis)
    {
        RingShop allRings = new RingShop();
        allRings.AddRings(s0);
        allRings.AddRings(s1);

        allRings.GetPrabas(ref platina, ref gold, ref silver, ref paladis);
    }

    static bool ShopContainsRing(RingShop shop, Ring ring)
    {
        for (int j = 0; j < shop.GetCount(); ++j)
            if (shop.GetRing(j) == ring)
                return true;

        return false;
    }

    public static void GetUniqueRings(RingShop s0, RingShop s1, ref RingShop unique)
    {
        RingShop allRings = new RingShop();
        allRings.AddRings(s0);
        allRings.AddRings(s1);

        for (int i = 0; i < allRings.GetCount(); ++i)
        {
            Ring ring = allRings.GetRing(i);
            bool foundInS0 = false;
            bool foundInS1 = false;

            if (ShopContainsRing(s0, ring))
                foundInS0 = true;

            if (ShopContainsRing(s1, ring))
                foundInS1 = true;

            if ((foundInS0 && !foundInS1) || (!foundInS0 && foundInS1))
                unique.AddRing(ring);
        }

        unique.Sort();
    }

    public static void GetWhiteGold(RingShop s0, RingShop s1, ref RingShop whiteGold)
    {
        RingShop allRings = new RingShop();
        allRings.AddRings(s0);
        allRings.AddRings(s1);

        allRings.CheapWhiteGold(ref whiteGold);
    }
}