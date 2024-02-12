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
        string query = "SELECT SuplierName FROM Supplier";

         try{
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read()){
            string supplierName = reader.GetString("SuplierName");
            Supplier supplier = new Supplier(supplierName);
            suppliers.Add(supplier);}
        reader.Close();}
        catch (MySqlException ex){
            Console.WriteLine("Error retrieving suppliers from the database: " + ex.Message);
        }
    return suppliers;
    }

    public void AddSupplier(Supplier supplier){
        string query = "INSERT INTO Supplier (SuplierName) VALUES (@SupplierName)";

        try{
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@SupplierName", supplier.suppliername);
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
}