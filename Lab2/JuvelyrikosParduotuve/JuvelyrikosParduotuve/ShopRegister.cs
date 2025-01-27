internal class ShopRegister
{
    private List<RingShop> shops;

    public ShopRegister(List<RingShop> shops)
    {
        this.shops = shops;
    }

    public int GetShopCount() { return shops.Count; }

    public RingShop GetShop(int index) { return shops[index]; }

    int HighestPraba()
    {
        int highestPraba = 0;

        foreach (RingShop shop in shops)
            if (shop.GetHighestPraba() > highestPraba)
                highestPraba = shop.GetHighestPraba();

        return highestPraba;
    }

    double HighestPrice(List<RingShop> shops)
    {
        double highestPrice = 0;

        foreach (RingShop shop in shops)
            if (shop.HighestPrice() > highestPrice)
                highestPrice = shop.HighestPrice();

        return highestPrice;
    }

    // Get the highest praba rings from all shops
    private void GetHighestPrabaRingShops(ref List<RingShop> highestPrabaShops)
    {
        int highestPraba = HighestPraba();

        foreach (RingShop shop in shops)
        {
            RingShop highestPrabaRingShop = null;
            shop.GetHighestPrabaRingShop(ref highestPrabaRingShop);
            if (highestPrabaRingShop != null && highestPrabaRingShop.GetHighestPraba() == highestPraba)
                highestPrabaShops.Add(highestPrabaRingShop);
        }
    }

    public void GetMostExpensiveHighestPrabaShops(ref List<RingShop> expensiveHighPraba)
    {
        List<RingShop> highestPraba = new List<RingShop>();
        GetHighestPrabaRingShops(ref highestPraba);
        double highestPrice = HighestPrice(highestPraba);

        foreach (RingShop shop in highestPraba)
        {
            double curPrice = HighestPrice(new List<RingShop> { shop });
            if (curPrice >= highestPrice)
                expensiveHighPraba.Add(shop);
        }
    }

    // Get the cheap white gold rings from all shops
    public void GetCheapWhiteGoldRingsShops(ref List<RingShop> cheapWhiteGoldShops)
    {
        List<string> names = new List<string>();

        foreach (RingShop shop in shops)
        {
            RingShop cheapWhiteGoldRingShop = shop.GetCheapWhiteGoldRingsShop();
            if (cheapWhiteGoldRingShop != null)
            {
                for (int i = 0; i < cheapWhiteGoldRingShop.GetCount(); ++i)
                {
                    if (!names.Contains(cheapWhiteGoldRingShop.GetName(i)))
                    {
                        names.Add(cheapWhiteGoldRingShop.GetName(i));
                        cheapWhiteGoldShops.Add(cheapWhiteGoldRingShop);
                    }
                }
            }
        }
    }

    // Get the shop containing the most expensive ring from each shop
    public void GetMostExpensiveRingsShops(ref List<RingShop> mostExpensiveShops)
    {
        double highestPrice = HighestPrice(shops);

        foreach (RingShop shop in shops)
        {
            RingShop highestPriceRingShop = null;
            shop.GetHighestPriceRingShop(ref highestPriceRingShop);
            if (highestPriceRingShop != null && highestPriceRingShop.HighestPrice() == highestPrice)
                mostExpensiveShops.Add(highestPriceRingShop);
        }
    }
}
