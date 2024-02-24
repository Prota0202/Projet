namespace kitbox;

public class Element
{
    public string Name { get; }
    public string Code { get; }
    public int Quantity { get; }
    public int Quantityordered { get; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public string Color { get; set; }

    public Element(string name, string code, int quantity, int quantityordered)
    {
        Name = name;
        Code = code;
        Quantity  = quantity;
        Quantityordered = quantityordered;
    }

    public string DisplayNameCodeQuantityOrdered => $"{Name} ({Code}) : {Quantity} pieces available - {Quantityordered} coming";
}
