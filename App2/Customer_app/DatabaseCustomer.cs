

/*using MySql.Data.MySqlClient;

namespace Customer_app.Database
{
    public static class DatabaseConfig
    {
        public static string ConnectionString = "your_mysql_connection_string_here";
    }
}*/






// Ci-dessous c'est connexion Mysql qu'Ayoub a fait dans App1

/*namespace kitbox;
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
    }*/