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
    public string DisplayNameCodeQuantityOrdereds 
    {
        get
        {
            int spacesToAdd1 = 17 - Name.Length;
            string space1 = new string(' ', spacesToAdd1);

            int spacesToAdd2 = 10 - Color.Length;
            string space2 = new string(' ', spacesToAdd2);

            int spacesToAdd3 = 12 - Code.Length;namespace kitbox;

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
    public string DisplayNameCodeQuantityOrdereds 
    {
        get
        {
            int spacesToAdd1 = 20 - Name.Length;
            string space1 = new string(' ', spacesToAdd1);

            int spacesToAdd2 = 15 - Color.Length;
            string space2 = new string(' ', spacesToAdd2);

            int spacesToAdd3 = 25 - Code.Length;
            string space3 = new string(' ', spacesToAdd3);

            string a = Quantity.ToString();
            int spacesToAdd4 = 30 - a.Length;
            string space4 = new string(' ', spacesToAdd4);

            return $"{Name}{space1}{Color}{space2}{Code}{space3}{Quantity}{space4}{Quantityordered}";
        }
    }
    public string DisplayName => $"{Name}";
    public string DisplayNameCode => $"{Code} : {Name}";
}

            string space3 = new string(' ', spacesToAdd3);

            string a = Quantity.ToString();
            int spacesToAdd4 = 7 - a.Length;
            string space4 = new string(' ', spacesToAdd4);

            return $"{Name}{space1}{Color}{space2}{Code}{space3}{Quantity} pieces available{space4}{Quantityordered} coming";
        }
    }
    public string DisplayName => $"{Name}";
    public string DisplayNameCode => $"{Code} : {Name}";
    public string DisplayAll => $"{Name} ({Code}) [{Quantity} pieces available : {Quantityordered} coming] : color {Color}; length {Length}; height {HeightCustomer}; width {Width}; side {Side}; lockerquantity {LockerQuantity}";
}
