namespace kitbox;
using System;
using System.Text;
using MySql.Data.MySqlClient;
public class DatabaseManager
{
    private MySqlConnection connection;
    private const string server = "pat.infolab.ecam.be";
    private const string port = "63425";
    private const string database = "kitbox";
    private const string username = "kitbox";
    private const string password = "kitbox";
    private readonly string connectionString;

    public DatabaseManager(){
        connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";
        connection = new MySqlConnection(connectionString);
    }

    public void OpenConnection(){
        try{
            connection.Open();
        }
        catch(MySqlException ex){
            Console.WriteLine("Error database couldn't open a connection: "+ ex.Message);
        }
    }

    public void CloseConnection(){
        try{
            connection.Close();
        }
        catch(MySqlException ex){
            Console.WriteLine("Error database couldn't close the connection: "+ ex.Message);
        }
    }

    public void AddPart(Part part){
        string query = "INSERT INTO Parts (PartName, Price, Quantity) VALUES (@PartName, @Price, @Quantity)";

        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@PartName", part.partname);
            command.Parameters.AddWithValue("@Price", part.price);
            command.Parameters.AddWithValue("@Quantity", part.quantity);
            command.ExecuteNonQuery();
            Console.WriteLine("we are in the dabase");
        }
        catch(MySqlException ex){
            Console.WriteLine("Error database couldn't add a Part: "+ ex.Message);
        }
    }

    public List<Part> GetParts(){
        List<Part> parts = new List<Part>();
        string query = "SELECT PartName, Price, Quantity FROM Parts";

        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()){
                string partName = reader.GetString("PartName");
                int price = reader.GetInt32("Price");
                int quantity = reader.GetInt32("Quantity");

                Part part = new Part(partName, price, quantity);
                parts.Add(part);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error retrieving parts from the database: " + ex.Message);
        }
        return parts;
    }
    public List<Supplier> GetSuppliers(){
        List<Supplier> suppliers = new List<Supplier>();
        string query = "SELECT SuplierName, Adress, Mail, PhoneNumber FROM supplier";

         try{
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read()){
            string supplierName = reader.IsDBNull(reader.GetOrdinal("SuplierName")) ? string.Empty : reader.GetString("SuplierName");
            string address = reader.IsDBNull(reader.GetOrdinal("Adress")) ? string.Empty : reader.GetString("Adress");
            string mail = reader.IsDBNull(reader.GetOrdinal("Mail")) ? string.Empty : reader.GetString("Mail");
            int phonenumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? 0 : reader.GetInt32("PhoneNumber");
            Supplier supplier = new Supplier(supplierName,address,mail,phonenumber);
            suppliers.Add(supplier);;}
        reader.Close();}
        catch (MySqlException ex){
            Console.WriteLine("Error retrieving suppliers from the database: " + ex.Message);
        }
    return suppliers;
    }

    public void AddSupplier(Supplier supplier){
        string query = "INSERT INTO supplier (SuplierName, Adress, Mail, PhoneNumber) VALUES (@SupplierName, @Adress, @Mail, @PhoneNumber)";

        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@SupplierName", supplier.suppliername);
            command.Parameters.AddWithValue("@Adress", supplier.adress);
            command.Parameters.AddWithValue("@Mail", supplier.mail);
            command.Parameters.AddWithValue("@PhoneNumber", supplier.phonenumber);
            command.ExecuteNonQuery();
            Console.WriteLine("Supplier added successfully to the database.");
        }
        catch (MySqlException ex){
            Console.WriteLine("Error adding supplier to the database: " + ex.Message);
        }
    }

    public void RemoveSupplier(string supplierName){
    string query = "DELETE FROM supplier WHERE SuplierName = @SupplierName";

    try{
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@SupplierName", supplierName);
        command.ExecuteNonQuery();
        Console.WriteLine("Supplier removed successfully from the database.");
    }
    catch (MySqlException ex){
        Console.WriteLine("Error removing supplier from the database: " + ex.Message);
    }
}

public List<Element> GetElements()
{
    List<Element> elements = new List<Element>();
    string query = "SELECT Name, Code, RemainingQuantity, Ordered_Quantity, Color, Length, Width, Height_real, Height_customer, Side, Depth, Diameter, LockerQuantity, KitboxQuantity FROM component";

        try
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString("Name");
                string code = reader.GetString("Code");
                int quantity = reader.IsDBNull(reader.GetOrdinal("RemainingQuantity")) ? 0 : reader.GetInt32("RemainingQuantity");
                int quantityOrdered = reader.IsDBNull(reader.GetOrdinal("Ordered_Quantity")) ? 0 : reader.GetInt32("Ordered_Quantity");
                string color = reader.IsDBNull(reader.GetOrdinal("Color")) ? "" : reader.GetString("Color");
                int length = reader.IsDBNull(reader.GetOrdinal("Length")) ? 0 : reader.GetInt32("Length");
                int width = reader.IsDBNull(reader.GetOrdinal("Width")) ? 0 : reader.GetInt32("Width");
                int heightReal = reader.IsDBNull(reader.GetOrdinal("Height_real")) ? 0 : reader.GetInt32("Height_real");
                int heightCustomer = reader.IsDBNull(reader.GetOrdinal("Height_customer")) ? 0 : reader.GetInt32("Height_customer");
                string side = reader.IsDBNull(reader.GetOrdinal("Side")) ? "" : reader.GetString("Side");
                int depth = reader.IsDBNull(reader.GetOrdinal("Depth")) ? 0 : reader.GetInt32("Depth");
                int diameter = reader.IsDBNull(reader.GetOrdinal("Diameter")) ? 0 : reader.GetInt32("Diameter");
                int lockerQuantity = reader.IsDBNull(reader.GetOrdinal("LockerQuantity")) ? 0 : reader.GetInt32("LockerQuantity");
                int kitboxQuantity = reader.IsDBNull(reader.GetOrdinal("KitboxQuantity")) ? 0 : reader.GetInt32("KitboxQuantity");

                Element element = new Element(name, code, color, length, width, heightReal, heightCustomer, quantity, side, depth, diameter, lockerQuantity, quantityOrdered, kitboxQuantity);
                elements.Add(element);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error retrieving elements from the database: " + ex.Message);
        }
        return elements;
    }

    public void UpdateElement(Element element)
    {
        string query = "UPDATE component SET Ordered_Quantity = @OrderedQuantity, RemainingQuantity = @RemainingQuantity WHERE Code = @Code";

        try
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderedQuantity", element.Quantityordered);
            command.Parameters.AddWithValue("@RemainingQuantity", element.Quantity);
            command.Parameters.AddWithValue("@Code", element.Code);
            command.ExecuteNonQuery();
            Console.WriteLine("Element updated successfully.");
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error updating element: " + ex.Message);
        }
    }

    public void AddElement(Element element){
        string query = "INSERT INTO component (Name, Code, Color, Length, Width, Height_real, Height_customer, RemainingQuantity, Side, Depth, Diameter, LockerQuantity, Ordered_Quantity, KitboxQuantity) " +
                       "VALUES (@Name, @Code, @Color, @Length, @Width, @Height_real, @Height_customer, @RemainingQuantity, @Side, @Depth, @Diameter, @LockerQuantity, @Ordered_Quantity, @KitboxQuantity)";

        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", element.Name);
            command.Parameters.AddWithValue("@Code", element.Code);
            command.Parameters.AddWithValue("@Color", element.Color);
            command.Parameters.AddWithValue("@Length", element.Length);
            command.Parameters.AddWithValue("@Width", element.Width);
            command.Parameters.AddWithValue("@Height_real", element.HeightReal);
            command.Parameters.AddWithValue("@Height_customer", element.HeightCustomer);
            command.Parameters.AddWithValue("@RemainingQuantity", element.Quantity);
            command.Parameters.AddWithValue("@Side", element.Side);
            command.Parameters.AddWithValue("@Depth", element.Depth);
            command.Parameters.AddWithValue("@Diameter", element.Diameter);
            command.Parameters.AddWithValue("@LockerQuantity", element.LockerQuantity);
            command.Parameters.AddWithValue("@Ordered_Quantity", element.Quantityordered);
            command.Parameters.AddWithValue("@KitboxQuantity", element.KitboxQuantity);
            command.ExecuteNonQuery();
            Console.WriteLine("Element added successfully to the database.");
        }
        catch (MySqlException ex){
            Console.WriteLine("Error adding element to the database: " + ex.Message);
        }
    }

    public void RemoveElement(Element element){
        string query = "DELETE FROM component WHERE Code = @Code";
        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", element.Code);
            command.ExecuteNonQuery();
            Console.WriteLine("Element removed successfully from the database.");
        }
        catch (MySqlException ex){
            Console.WriteLine("Error removing element from the database: " + ex.Message);
        }
    }



    public List<string> GetLatestOrder()
    {
        List<string> latestOrder = new List<string>(); // Modifier le type de retour

        try
        {
            this.OpenConnection();

            // Sélectionner la dernière commande de la table neworder
            string query = "SELECT * FROM neworder ORDER BY idneworder DESC LIMIT 1";
            MySqlCommand command = new MySqlCommand(query, this.connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Construire une chaîne de caractères représentant la dernière commande
                StringBuilder orderDetails = new StringBuilder();
                orderDetails.AppendLine($"Order ID: {reader.GetInt32("idneworder")}");

                // Ajouter les détails de chaque locker à la chaîne
                for (int i = 1; i <= 7; i++)
                {
                    string verticalBatten = reader.IsDBNull(reader.GetOrdinal($"verticalbatten{i}")) ? null : reader.GetString($"verticalbatten{i}");
                    string frontCrossbar = reader.IsDBNull(reader.GetOrdinal($"frontcrossbar{i}")) ? null : reader.GetString($"frontcrossbar{i}");
                    string backCrossbar = reader.IsDBNull(reader.GetOrdinal($"backcrossbar{i}")) ? null : reader.GetString($"backcrossbar{i}");
                    string sideCrossbar = reader.IsDBNull(reader.GetOrdinal($"sidecrossbar{i}")) ? null : reader.GetString($"sidecrossbar{i}");
                    string horizontalPanel = reader.IsDBNull(reader.GetOrdinal($"horizontalpanel{i}")) ? null : reader.GetString($"horizontalpanel{i}");
                    string sidePanel = reader.IsDBNull(reader.GetOrdinal($"sidepanel{i}")) ? null : reader.GetString($"sidepanel{i}");
                    string backPanel = reader.IsDBNull(reader.GetOrdinal($"backpanel{i}")) ? null : reader.GetString($"backpanel{i}");
                    string door = reader.IsDBNull(reader.GetOrdinal($"door{i}")) ? null : reader.GetString($"door{i}");

                    if (!string.IsNullOrEmpty(verticalBatten) && !string.IsNullOrEmpty(frontCrossbar) && !string.IsNullOrEmpty(backCrossbar) &&
                        !string.IsNullOrEmpty(sideCrossbar) && !string.IsNullOrEmpty(horizontalPanel) && !string.IsNullOrEmpty(sidePanel) &&
                        !string.IsNullOrEmpty(backPanel) && !string.IsNullOrEmpty(door))
                    {
                        orderDetails.AppendLine($"Locker {i}:");
                        orderDetails.AppendLine($"Vertical Batten: {verticalBatten}");
                        orderDetails.AppendLine($"Front Crossbar: {frontCrossbar}");
                        orderDetails.AppendLine($"Back Crossbar: {backCrossbar}");
                        orderDetails.AppendLine($"Side Crossbar: {sideCrossbar}");
                        orderDetails.AppendLine($"Horizontal Panel: {horizontalPanel}");
                        orderDetails.AppendLine($"Side Panel: {sidePanel}");
                        orderDetails.AppendLine($"Back Panel: {backPanel}");
                        orderDetails.AppendLine($"Door: {door}");
                        orderDetails.AppendLine();
                    }
                }

                latestOrder.Add(orderDetails.ToString()); // Ajouter la commande à la liste
            }

            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error retrieving the latest order from the database: " + ex.Message);
        }
        finally
        {
            this.CloseConnection();
        }

        return latestOrder;
    }

    public void OrderElement(Element element, int amountToOrder)
    {
        // Here you would implement the logic to place an order for the element
        // This could involve inserting a new order record in the database and updating the element's quantity
        // For demonstration, I will just print out a message

        Console.WriteLine($"Ordering {amountToOrder} of element {element.Code}.");
        
        // Assuming you have an "orders" table with columns "element_code" and "amount_ordered"
        string query = "INSERT INTO orders (element_code, amount_ordered) VALUES (@Code, @AmountOrdered);";

        try
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", element.Code);
            command.Parameters.AddWithValue("@AmountOrdered", amountToOrder);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error placing an order for the element: " + ex.Message);
        }
    }
}
