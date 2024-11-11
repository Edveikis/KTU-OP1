class Ring
{
    string Manufacturer;
    string Name;
    string MetalType;
    double Size;
    double Weight;
    int Praba;
    double Price;

    public Ring(string manufacturer, string name, string metalType, double weight, double size, int praba, double price)
    {
        this.Manufacturer = manufacturer;
        this.Name = name;
        this.MetalType = metalType;
        this.Size = size;
        this.Weight = weight;
        this.Praba = praba;
        this.Price = price;
    }

    // Getters
    public string GetManufacturer() { return this.Manufacturer; }
    public string GetName() { return this.Name; }
    public string GetMetalType() { return this.MetalType; }
    public double GetSize() { return this.Size; }
    public double GetWeight() { return this.Weight; }
    public int GetPraba() { return this.Praba; }
    public double GetPrice() { return this.Price; }
}

