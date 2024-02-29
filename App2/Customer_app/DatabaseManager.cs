namespace Customer_app;
using System;
using Microsoft.Maui.Controls.Platform.Compatibility;
using MySql.Data.MySqlClient;
using Customer_app.Models;
public class DatabaseManager
{
    private MySqlConnection connection;

    public DatabaseManager(string server, string database, string username, string password)
    {
        string connString = $"Server={server}; database={database}; UID={username}; password={password}";
        connection = new MySqlConnection(connString);
    }

    public void OpenConnection()
    {
        connection.Open();
    }

    public void CloseConnection()
    {
        connection.Close();
    }

    public List<Order> GetOrders()
    {
        List<Order> Orders = new List<Order>();
        string query = "SELECT idorder, depth, width, height, panel_color, door_type, angle_iron_color, comment FROM `order`";

        try
        {
            MySqlCommand command = new MySqlCommand(query, connection);
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
                    reader.GetString("angle_iron_color"),
                    reader.IsDBNull(reader.GetOrdinal("comment")) ? null : reader.GetString("comment"));
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
}