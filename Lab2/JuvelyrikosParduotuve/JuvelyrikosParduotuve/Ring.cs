class Ring
{
    // Methods
    public string Manufacturer { get; }
    public string Name { get; }
    public string MetalType { get; }
    public double Size { get; }
    public double Weight { get; }
    public int Praba { get; }
    public double Price { get; }

    // Constructors
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

    // Operator overloads for logical operations
    public static bool operator ==(Ring ring1, Ring ring2)
    {
        if (ring1 is null || ring2 is null) 
            return false;

        if (ReferenceEquals(ring1, ring2)) 
            return true;

        return ring1.Name == ring2.Name && ring1.Manufacturer == ring2.Manufacturer;
    }

    public static bool operator !=(Ring ring1, Ring ring2)
    {
        return !(ring1 == ring2);
    }

    public static bool operator >(Ring ring, double price)
    {
        return ring.Price > price;
    }

    public static bool operator <(Ring ring, double price)
    {
        return ring.Price < price;
    }

    public static bool operator >=(Ring ring, double price)
    {
        return ring.Price >= price;
    }

    public static bool operator <=(Ring ring, double price)
    {
        return ring.Price <= price;
    }

    public static bool operator ==(Ring ring, double price)
    {
        return ring.Price == price;
    }

    public static bool operator !=(Ring ring, double price)
    {
        return !(ring == price);
    }

    public static bool operator >(Ring ring, int praba)
    {
        return ring.Praba > praba;
    }

    public static bool operator <(Ring ring, int praba)
    {
        return ring.Praba < praba;
    }

    public static bool operator >=(Ring ring, int praba)
    {
        return ring.Praba >= praba;
    }

    public static bool operator <=(Ring ring, int price)
    {
        return ring.Price <= price;
    }

    public static bool operator ==(Ring ring, int praba)
    {
        return ring.Praba == praba;
    }

    public static bool operator !=(Ring ring, int praba)
    {
        return !(ring == praba);
    }
}

