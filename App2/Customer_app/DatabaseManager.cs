namespace Customer_app;
using System;
using Microsoft.Maui.Controls.Platform.Compatibility;
using MySql.Data.MySqlClient;
using Customer_app.Models;
using System.Data;
public class DatabaseManager
{
    
    public MySqlConnection Connection { get; private set; }
    
    
    // private MySqlConnection connection;
    private const string server = "pat.infolab.ecam.be";
    private const string port = "63425";
    private const string database = "kitbox";
    private const string username = "kitbox";
    private const string password = "kitbox";
    private readonly string connectionString;

    public DatabaseManager()
    {
        connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";
        Connection = new MySqlConnection(connectionString);
    }

    public void OpenConnection()
    {
        try
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error database couldn't open a connection: " + ex.Message);
        }
    }


    public void CloseConnection(){
        try{
            Connection.Close();
        }
        catch(MySqlException ex){
            Console.WriteLine("Error database couldn't close the connection: "+ ex.Message);
        }
    }
    
    public List<Element> GetElements()
{
    List<Element> elements = new List<Element>();
    string query = "SELECT Name, Code, RemainingQuantity, Ordered_Quantity, Color, Length, Width, Height_real, Height_customer, Side, Depth, Diameter, LockerQuantity, KitboxQuantity FROM component";

    try
    {
        MySqlCommand command = new MySqlCommand(query, Connection);
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

    public List<Order> GetOrders()
    {
        List<Order> Orders = new List<Order>();
        string query = "SELECT idorder, depth, width, height, panel_color, door_type, angle_iron_color, comment FROM `order`";

        try
        {
            MySqlCommand command = new MySqlCommand(query, Connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Order order = new Order(
                    reader.GetInt32("idorder"),
                    reader.GetInt32("depth"),
                    reader.GetInt32("width"),
                    reader.GetInt32("height"),
                    reader.GetString("panel_color"),
                    reader.GetString("door_type"),
                    reader.GetString("angle_iron_color")
                    );
            
                
            Orders.Add(order);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error retrieving orders from the database: " + ex.Message);
        }
        return Orders;
    }
    
    
    public int SaveOrderWithoutId(Order order)
    {
        int orderId = -1; // Initialiser l'ID de la commande à une valeur par défaut

        try
        {
            OpenConnection();

            string query = "INSERT INTO `order` (depth, width, height, panel_color, door_type, angle_iron_color) VALUES (@Depth, @Width, @Height, @PanelColor, @Door, @AngleIronColor); SELECT LAST_INSERT_ID();";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@Depth", order.Depth);
            command.Parameters.AddWithValue("@Width", order.Width);
            command.Parameters.AddWithValue("@Height", order.Height);
            command.Parameters.AddWithValue("@PanelColor", order.PanelColor);
            command.Parameters.AddWithValue("@Door", order.Door);
            command.Parameters.AddWithValue("@AngleIronColor", order.AngleIronColor);

            // Exécuter la requête et récupérer l'ID de la commande nouvellement insérée
            orderId = Convert.ToInt32(command.ExecuteScalar());
            Console.WriteLine("Order saved successfully with ID: " + orderId);
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error saving order: " + ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return orderId;
    }


    public void SaveBill(int numOrder, string listOrder)
    {
        try
        {
            OpenConnection();

            // Ajoutez les instructions de débogage ici
            Console.WriteLine("NumOrder: " + numOrder);
            Console.WriteLine("ListOrder: " + listOrder);

            string query = "INSERT INTO bill (NumOrder, ListOrder) VALUES (@NumOrder, @ListOrder)";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@NumOrder", numOrder);
            command.Parameters.AddWithValue("@ListOrder", listOrder);

            // Ajoutez une instruction pour afficher la requête SQL complète
            Console.WriteLine("Query: " + command.CommandText);

            command.ExecuteNonQuery();
            Console.WriteLine("Bill saved successfully.");
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error saving bill: " + ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }




}
