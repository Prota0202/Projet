namespace kitbox;

public class Element
{
    public string Name { get; }
    public string Code { get; }
    public int Quantity { get; set;}
    public int Quantityordered { get; set;}
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

    public int OrderToSupplier(int amount){
		Quantityordered += amount;
		return Quantityordered;
	}

    public int AddQuantity(int amount){
		Quantity += amount;
        Quantityordered -= amount;
		return Quantity;
	}

	public int RemoveQuantity(int amount){
		Quantity -= amount;
		return Quantity;
	}

    public string DisplayNameCodeQuantityOrdered => $"{Name} ({Code}) : {Quantity} pieces available - {Quantityordered} coming";
    public string DisplayName => $"{Name}";
}
