namespace kitbox;
using System;
using MySql.Data.MySqlClient;
public class DatabaseManager
{
    private MySqlConnection connection;
    private string connectionString;

    public DatabaseManager(string server, string database, string username, string password){
        connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
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

    public void UpdatePartQuantity(string partName, int quantityToAdd)
{
    int idPart = GetPartIdByName(partName);
    
    if (idPart != -1)
    {
        string query = "UPDATE Parts SET Quantity = Quantity + @QuantityToAdd WHERE idParts = @IdParts";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@QuantityToAdd", quantityToAdd);
        command.Parameters.AddWithValue("@IdParts", idPart);
        try
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Part quantity updated successfully.");
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error updating part quantity: " + ex.Message);
        }
    }
}

private int GetPartIdByName(string partName)
{
    int idPart = -1;
    string query = "SELECT idParts FROM Parts WHERE PartName = @PartName";
    MySqlCommand command = new MySqlCommand(query, connection);
    command.Parameters.AddWithValue("@PartName", partName);
    try
    {
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            idPart = reader.GetInt32("idParts");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving part id: " + ex.Message);
    }
    return idPart;
}

    public List<Supplier> GetSuppliers(){
        List<Supplier> suppliers = new List<Supplier>();
        string query = "SELECT SuplierName, Adress, Mail, PhoneNumber FROM Supplier";

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
        string query = "INSERT INTO Supplier (SuplierName, Adress, Mail, PhoneNumber) VALUES (@SupplierName, @Adress, @Mail, @PhoneNumber)";

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
    string query = "DELETE FROM Supplier WHERE SuplierName = @SupplierName";

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

public List<Element> GetElements(){
        List<Element> elements = new List<Element>();
        string query = "SELECT Name, Code, RemainingQuantity, Ordered_Quantity FROM component";

        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()){
                string Name = reader.GetString("Name");
                string code = reader.GetString("Code");
                int quantity = reader.IsDBNull(reader.GetOrdinal("RemainingQuantity")) ? 0 : reader.GetInt32("RemainingQuantity");
                int quantityordered = reader.IsDBNull(reader.GetOrdinal("Ordered_Quantity")) ? 0 : reader.GetInt32("Ordered_Quantity");
                Element elementloaded = new Element(Name, code, quantity, quantityordered);
                elements.Add(elementloaded);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error retrieving parts from the database: " + ex.Message);
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
}