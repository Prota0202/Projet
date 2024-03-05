namespace Customer_app.Models;


public class Element
{
    public string Name {get;set;}
    public string Code { get; set;}
    public string Color { get; set;}
    public int Lenght { get; set;}
    public int Width { get; set;}
    public int Height_real { get; set;}
    public int Height_customer { get; set;}
    public int RemainingQuantity { get; set;}
    public string Side { get; set;}
    public int Depth { get; set;}
    public int Diameter { get; set;}
    public int LockerQuantity { get; set;}
    public int Ordered_Quantity { get; set;}
    public int KitboxQuantity { get; set;}
    
    
    

    public Element(string name, string code, string color, int lenght, int width, int height_real, int height_customer, int remainingquantity, string side, int depth, int diameter, int lockerquantity, int ordered_quantity, int kitboxquantity )
    {
        Name = name;
        Code = code;
        Color = color;
        Lenght = lenght;
        Width = width;
        Height_real = height_real;
        Height_customer = height_customer;
        RemainingQuantity = remainingquantity;
        Side = side;
        Depth = depth;
        Diameter = diameter;
        LockerQuantity = lockerquantity;
        Ordered_Quantity = ordered_quantity;
        KitboxQuantity = kitboxquantity;

    }
}