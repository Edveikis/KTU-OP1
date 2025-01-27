class Ring
{
    public string Manufacturer { get; }
    public string Name { get; }
    public string MetalType { get; }
    public double Size { get; }
    public double Weight { get; }
    public int Praba { get; }
    public double Price { get; }

    public Ring(string manufacturer, string name, string metalType, double weight, double size, int praba, double price)
    {
        Manufacturer = manufacturer;
        Name = name;
        MetalType = metalType;
        Size = size;
        Weight = weight;
        Praba = praba;
        Price = price;
    }

    public override string ToString()
    {
        return string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,20} | {4,20} | {5,20} | {6,20} |",
        Manufacturer, Name, MetalType, Size, Weight, Praba, Price);
    }

    public static bool operator ==(Ring ring1, Ring ring2)
    {
        if (ReferenceEquals(ring1, ring2)) return true;
        if (ring1 is null || ring2 is null) return false;
        return ring1.Name == ring2.Name && ring1.Manufacturer == ring2.Manufacturer && ring1.MetalType == ring2.MetalType && ring1.Size == ring2.Size && ring1.Weight == ring2.Weight && ring1.Praba == ring2.Praba;
    }

    public static bool operator !=(Ring ring1, Ring ring2)
    {
        return !(ring1 == ring2);
    }
}