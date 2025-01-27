internal class RingShop
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    private RingContainer rings;

    public RingShop()
    {
        this.rings = new RingContainer();
    }

    public RingShop(string name, string address, string phoneNumber)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        this.rings = new RingContainer();
    }

    public void AddRing(Ring ring) { rings.Add(ring); }

    public int GetCount() { return rings.Count; }

    public Ring GetRing(int index) { return rings.Get(index); }

    public void AddRings(RingShop rings)
    {
        for (int i = 0; i < rings.GetCount(); ++i)
        {
            if (rings.GetRing(i) != null)
                this.rings.Add(rings.GetRing(i));
        }
    }

    public double GetHighestPrice()
    {
        double price = 0.0;

        for (int i = 0; i < rings.Count; ++i)
            if (rings.Get(i).Price > price)
                price = rings.Get(i).Price;

        return price;
    }

    public void GetMostExpensiveRing(ref RingShop mostExpensive)
    {
        if (mostExpensive == null)
            return;

        double highestPrice = GetHighestPrice();

        for (int i = 0; i < rings.Count; ++i)
        {
            Ring ring = rings.Get(i);
            if (ring.Price == highestPrice)
                mostExpensive.AddRing(ring);
        }
    }

    public void GetPrabas(ref RingShop platina, ref RingShop gold, ref RingShop silver, ref RingShop paladis)
    {
        for (int i = 0; i < rings.Count; ++i)
        {
            Ring ring = rings.Get(i);
            int praba = ring.Praba;

            if (praba == 950)
                platina.AddRing(ring);
            else if (praba == 375 || praba == 585 || praba == 750)
                gold.AddRing(ring);
            else if (praba == 800 || praba == 830 || praba == 925)
                silver.AddRing(ring);
            else if (praba == 500 || praba == 850)
                paladis.AddRing(ring);
        }
    }

    bool DuplicateName(Ring ring)
    {
        for (int i = 0; i < rings.Count; ++i)
            if (rings.Get(i).Name == ring.Name)
                return true;

        return false;
    }

    public void CheapWhiteGold(ref RingShop whiteGold)
    {
        for (int i = 0; i < rings.Count; ++i)
        {
            Ring ring = rings.Get(i);
            if (ring.MetalType == "Baltas auksas" && ring.Price < 300)
            {
                if (!whiteGold.DuplicateName(ring))
                    whiteGold.AddRing(ring);
            }
        }
    }

    public void Sort()
    {
        rings.SortRings();
    }

    public string GetFormattedRing(int index) { return rings.Get(index).ToString(); }

    public string FormatCSVRing(int index)
    {
        return string.Format("{0};{1};{2};{3};{4};{5};{6}",
        rings.Get(index).Manufacturer, rings.Get(index).Name, rings.Get(index).MetalType, rings.Get(index).Size, rings.Get(index).Weight, rings.Get(index).Praba, rings.Get(index).Price);
    }

    public string FormatTableRing(int index) { return rings.Get(index).ToString(); }
}