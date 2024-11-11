using System.Drawing;

internal class Apartament
{
    public int Number { get; }
    public float Area { get; }
    public int RoomCount { get; }
    public float Price { get; }
    public string PhoneNumber { get; }
    public int Floor { get; set; }

    public Apartament(int number, float area, int roomCount, float price, string phoneNumber)
    {
        Number = number;
        Area = area;
        RoomCount = roomCount;
        Price = price;
        PhoneNumber = phoneNumber;
    }

    public Apartament(int roomCount, int floor, float maxPrice)
    {
        RoomCount = roomCount;
        Floor = floor;
        Price = maxPrice;
    }

    public override bool Equals(object other)
    {
        return (Number - 1) / 3 + 1 == ((Apartament)other).Floor && 
            RoomCount == ((Apartament)other).RoomCount && 
            Price <= ((Apartament)other).Price;
    }
}