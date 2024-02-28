namespace kitbox;

public class Element
{
    public string Name { get; }
    public string Code { get; }
    public int Quantity { get; set;}
    public int Quantityordered { get; set;}
    public int Length { get; set; }
    public int Width { get; set; }
    public int HeightReal { get; set; }
    public int HeightCustomer { get; set; }
    public string Color { get; set; }
    public string Side { get; set; }
    public int Depth { get; set; }
    public int Diameter { get; set; }
    public int LockerQuantity { get; set; }
    public int KitboxQuantity { get; set; }

    public Element(string name, string code, string color, int length, int width, int heightreal, int heightcustomer, int quantity, string side, int depth, int diameter, int lockerquantity, int quantityordered, int kitboxquantity)
    {
        Name = name;
        Code = code;
        Color = color;
        Length = length;
        Width = width;
        HeightReal = heightreal;
        HeightCustomer = heightcustomer;
        Quantity  = quantity;
        Side = side;
        Depth = depth;
        Diameter = diameter;
        LockerQuantity = lockerquantity;
        Quantityordered = quantityordered;
        KitboxQuantity = kitboxquantity;
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
    public string DisplayNameCode => $"{Code} : {Name}";
}
