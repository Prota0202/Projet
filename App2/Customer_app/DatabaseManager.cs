namespace Customer_app;
using System;
using Microsoft.Maui.Controls.Platform.Compatibility;
using MySql.Data.MySqlClient;
using Customer_app.Models;
using System.Data;
using System.Text;

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

public string GetVerticalBattenCode(int height)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Vertical batten' AND Height_customer = @Height";
    try{
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Height", height);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read()){
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving vertical batten codes: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetSideCrossbarCode(int depth)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Crossbar' AND Depth = @Depth AND Side = 'left or right'";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Depth", depth);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetFrontCrossbarCode(int width)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Crossbar' AND Width = @Width AND Side = 'front'";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Width", width);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetBackCrossbarCode(int width)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Crossbar' AND Width = @Width AND Side = 'back'";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Width", width);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetBackPanelCode(string color, int height ,int width)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Panel' AND Side = 'back' AND Color = @Color AND Height_customer = @Height AND Width = @Width";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Color", color);
        command.Parameters.AddWithValue("@Height", height);
        command.Parameters.AddWithValue("@Width", width);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetSidePanelCode(string color, int height ,int depth)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Panel' AND Side = 'left or right' AND Color = @Color AND Height_customer = @Height AND Depth = @Depth";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Color", color);
        command.Parameters.AddWithValue("@Height", height);
        command.Parameters.AddWithValue("@Depth", depth);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetHorizontalPanelCode(string color, int width ,int depth)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Panel' AND Side = 'horizontal' AND Color = @Color AND Width = @Width AND Depth = @Depth";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Color", color);
        command.Parameters.AddWithValue("@Width", width);
        command.Parameters.AddWithValue("@Depth", depth);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public string GetDoorCode(string color, int height ,int width)
{
    string code = " ";
    string query = "SELECT Code FROM component WHERE Name = 'Door' AND Color = @Color AND Height_customer = @Height AND Width = @Width";
    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@Color", color);
        command.Parameters.AddWithValue("@Height", height);
        command.Parameters.AddWithValue("@Width", width);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            code = reader.GetString("Code");
        }
        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving crossbar code: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return code;
}

public int GetNextOrderId()
{
    int orderId = -1;
    string query = "SELECT MAX(idneworder) FROM neworder";

    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        object result = command.ExecuteScalar();

        if (result != null && result != DBNull.Value)
        {
            orderId = Convert.ToInt32(result);
        }
        orderId++; // Increment to get the next available order ID
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving next order ID: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return orderId;
}

public int GetNextIdclient()
{
    int Idclient = -1;
    string query = "SELECT MAX(idclient) FROM totalorder";

    try
    {
        OpenConnection();
        MySqlCommand command = new MySqlCommand(query, Connection);
        object result = command.ExecuteScalar();

        if (result != null && result != DBNull.Value)
        {
            Idclient = Convert.ToInt32(result);
        }
        Idclient++; // Increment to get the next available order ID
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving next order ID: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return Idclient;
}

public void AddIdNewOrderToTotalOrder(int idclient, int idNewOrder, int armoireNumber)
{
    try
    {
        // Ouvrez la connexion à la base de données
        OpenConnection();

        // Vérifiez d'abord si une ligne existe déjà pour ce client dans la table totalorder
        string checkQuery = "SELECT COUNT(*) FROM totalorder WHERE idclient = @idclient";
        MySqlCommand checkCommand = new MySqlCommand(checkQuery, Connection);
        checkCommand.Parameters.AddWithValue("@idclient", idclient);
        int rowCount = Convert.ToInt32(checkCommand.ExecuteScalar());

        if (rowCount == 0)
        {
            // Si aucune ligne n'existe pour ce client, insérez une nouvelle ligne
            string insertQuery = "INSERT INTO totalorder (idclient, armoire1) VALUES (@idclient, @IdNewOrder)";
            MySqlCommand insertCommand = new MySqlCommand(insertQuery, Connection);
            insertCommand.Parameters.AddWithValue("@idclient", idclient);
            insertCommand.Parameters.AddWithValue("@IdNewOrder", idNewOrder);
            insertCommand.ExecuteNonQuery();
        }
        else
        {
            // Si une ligne existe déjà pour ce client, mettez à jour la colonne appropriée (armoire1, armoire2, etc.)
            string updateQuery = $"UPDATE totalorder SET armoire{armoireNumber} = @IdNewOrder WHERE idclient = @idclient";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, Connection);
            updateCommand.Parameters.AddWithValue("@idclient", idclient);
            updateCommand.Parameters.AddWithValue("@IdNewOrder", idNewOrder);
            updateCommand.ExecuteNonQuery();
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error updating totalorder: " + ex.Message);
    }
    finally
    {
        // Fermez la connexion à la base de données
        CloseConnection();
    }
}
// Méthode pour vérifier l'existence d'une colonne dans une table
private bool ColumnExists(string columnName)
{
    // Construire la requête SQL pour vérifier si la colonne existe dans la table
    string query = "SELECT COUNT(*) FROM information_schema.columns " +
                   "WHERE table_schema = 'kitbox' AND table_name = 'totalorder' " +
                   $"AND column_name = '{columnName}'";

    // Créer une commande MySQL avec la requête SQL et la connexion à la base de données
    MySqlCommand command = new MySqlCommand(query, Connection);

    // Exécuter la commande et obtenir le nombre de colonnes correspondantes
    int columnCount = Convert.ToInt32(command.ExecuteScalar());

    // Si le nombre de colonnes correspondantes est supérieur à zéro, la colonne existe
    return columnCount > 0;
}

public void SaveLockerComponents(int orderId, int lockerNumber, string verticalBatten, string frontCrossbar, string backCrossbar, string sideCrossbar, string horizontalPanel, string sidePanel, string backPanel, string door)
{
    try
    {
        OpenConnection();

        string query = "INSERT INTO neworder (idneworder, verticalbatten" + lockerNumber + ", frontcrossbar" + lockerNumber + ", backcrossbar" + lockerNumber + ", sidecrossbar" + lockerNumber + ", horizontalpanel" + lockerNumber + ", sidepanel" + lockerNumber + ", backpanel" + lockerNumber + ", door" + lockerNumber + ") VALUES (@IdNewOrder, @VerticalBatten, @FrontCrossbar, @BackCrossbar, @SideCrossbar, @HorizontalPanel, @SidePanel, @BackPanel, @Door)";

        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@IdNewOrder", orderId);
        command.Parameters.AddWithValue("@VerticalBatten", verticalBatten);
        command.Parameters.AddWithValue("@FrontCrossbar", frontCrossbar);
        command.Parameters.AddWithValue("@BackCrossbar", backCrossbar);
        command.Parameters.AddWithValue("@SideCrossbar", sideCrossbar);
        command.Parameters.AddWithValue("@HorizontalPanel", horizontalPanel);
        command.Parameters.AddWithValue("@SidePanel", sidePanel);
        command.Parameters.AddWithValue("@BackPanel", backPanel);
        command.Parameters.AddWithValue("@Door", door);

        command.ExecuteNonQuery();
        Console.WriteLine("Components for locker " + lockerNumber + " saved successfully.");
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error saving locker components: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }
}

public void UpdateLockerComponents(int orderId, int lockerNumber, string verticalBatten, string frontCrossbar, string backCrossbar, string sideCrossbar, string horizontalPanel, string sidePanel, string backPanel, string door)
{
    try
    {
        OpenConnection();

        string query = "UPDATE neworder SET " +
                       "verticalbatten" + lockerNumber + " = @VerticalBatten, " +
                       "frontcrossbar" + lockerNumber + " = @FrontCrossbar, " +
                       "backcrossbar" + lockerNumber + " = @BackCrossbar, " +
                       "sidecrossbar" + lockerNumber + " = @SideCrossbar, " +
                       "horizontalpanel" + lockerNumber + " = @HorizontalPanel, " +
                       "sidepanel" + lockerNumber + " = @SidePanel, " +
                       "backpanel" + lockerNumber + " = @BackPanel, " +
                       "door" + lockerNumber + " = @Door " +
                       "WHERE idneworder = @OrderId";

        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@VerticalBatten", verticalBatten);
        command.Parameters.AddWithValue("@FrontCrossbar", frontCrossbar);
        command.Parameters.AddWithValue("@BackCrossbar", backCrossbar);
        command.Parameters.AddWithValue("@SideCrossbar", sideCrossbar);
        command.Parameters.AddWithValue("@HorizontalPanel", horizontalPanel);
        command.Parameters.AddWithValue("@SidePanel", sidePanel);
        command.Parameters.AddWithValue("@BackPanel", backPanel);
        command.Parameters.AddWithValue("@Door", door);
        command.Parameters.AddWithValue("@OrderId", orderId);

        command.ExecuteNonQuery();
        Console.WriteLine("Locker components saved successfully.");
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error saving locker components: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }
}

public string LoadOrder(int orderId, int amountlocker)
{
    StringBuilder orderDetails = new StringBuilder();

    try
    {
        OpenConnection();

        // Récupérer les données des lockers pour l'ID de la commande donnée
        string query = "SELECT * FROM neworder WHERE idneworder = @OrderId";
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@OrderId", orderId);
        MySqlDataReader reader = command.ExecuteReader();

       while (reader.Read())
        {
            for (int lockerNumber = 1; lockerNumber <= amountlocker; lockerNumber++)
            {
                // Ajouter le détail du locker à la chaîne
                orderDetails.AppendLine($"Locker {lockerNumber}:");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"verticalbatten{lockerNumber}"))} Vertical Batten :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"frontcrossbar{lockerNumber}"))} Front Crossbar :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"backcrossbar{lockerNumber}"))} Back Crossbar :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"sidecrossbar{lockerNumber}"))} Side Crossbar :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"horizontalpanel{lockerNumber}"))} Horizontal Panel :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"sidepanel{lockerNumber}"))} Side Panel :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"backpanel{lockerNumber}"))} Back Panel :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"door{lockerNumber}"))} Door :");
                orderDetails.AppendLine();
            }
        }

        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error loading order details: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return orderDetails.ToString();
}

// public string Loadkitb(int armoireNumber, int idClient)
// {
//     StringBuilder orderDetails = new StringBuilder();

//     try
//     {
//         OpenConnection();

//         // Récupérer l'idneworder correspondant à l'armoireNumber
//         int idneworder = GetIdNewOrderFromArmoireNumber(armoireNumber, idClient);

//         // Vérifier si l'idneworder est valide
//         if (idneworder != -1)
//         {
//             int lockerCount = 1; // Déclarer lockerCount ici

//             using (MySqlCommand cmd = Connection.CreateCommand())
//             {
//                 // Assurez-vous que la connexion est ouverte
//                 if (Connection.State != ConnectionState.Open)
//                 {
//                     Connection.Open();
//                 }

//                 // Construire la requête SQL pour récupérer les données des casiers
//                 cmd.CommandText = "SELECT * FROM neworder WHERE idneworder = @OrderId";
//                 cmd.Parameters.AddWithValue("@OrderId", idneworder);

//                 using (MySqlDataReader reader = cmd.ExecuteReader())
//                 {
//                     // Traitement des résultats de la requête
//                     while (reader.Read())
//                     {
//                         // Ajouter les détails du casier à la chaîne
//                         orderDetails.AppendLine($"Locker {armoireNumber}-{lockerCount}:");
//                         orderDetails.AppendLine($"- Vertical Batten: {GetComponentQuantity(reader.GetString($"verticalbatten{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Front Crossbar: {GetComponentQuantity(reader.GetString($"frontcrossbar{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Back Crossbar: {GetComponentQuantity(reader.GetString($"backcrossbar{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Side Crossbar: {GetComponentQuantity(reader.GetString($"sidecrossbar{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Horizontal Panel: {GetComponentQuantity(reader.GetString($"horizontalpanel{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Side Panel: {GetComponentQuantity(reader.GetString($"sidepanel{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Back Panel: {GetComponentQuantity(reader.GetString($"backpanel{lockerCount}"))}");
//                         orderDetails.AppendLine($"- Door: {GetComponentQuantity(reader.GetString($"door{lockerCount}"))}");
//                         orderDetails.AppendLine();

//                         lockerCount++; // Incrémenter lockerCount pour le prochain casier
//                     }
//                 }
//             }
//         }
//         else
//         {
//             Console.WriteLine("No idneworder found for armoireNumber: " + armoireNumber);
//         }
//     }
//     catch (MySqlException ex)
//     {
//         Console.WriteLine("Error loading order details: " + ex.Message);
//     }
//     finally
//     {
//         CloseConnection();
//     }

//     return orderDetails.ToString();
// }
public List<List<string>> Loadkitb(int armoireNumber, int idClient)
{
    List<List<string>> armoiresDetailsList = new List<List<string>>();

    try
    {
        OpenConnection();

        // Récupérer les idneworder correspondant à l'idClient
        List<int> idneworders = GetIdNewOrderFromArmoireNumber(armoireNumber, idClient);

        // Vérifier si des idneworders ont été trouvés
        if (idneworders.Count > 0)
        {
            foreach (int idneworder in idneworders)
            {
                List<string> armoireDetails = new List<string>();

                // Construire la requête SQL pour récupérer les données des casiers
                using (MySqlCommand cmd = Connection.CreateCommand())
                {
                    // Assurez-vous que la connexion est ouverte
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }

                    cmd.CommandText = "SELECT * FROM neworder WHERE idneworder = @OrderId";
                    cmd.Parameters.AddWithValue("@OrderId", idneworder);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Traitement des résultats de la requête
                        while (reader.Read())
                        {
                            // Ajouter les détails du casier à la liste
                            for (int lockerCount = 1; lockerCount <= 7; lockerCount++)
                            {
                                if (!reader.IsDBNull($"verticalbatten{lockerCount}") &&
                                    !reader.IsDBNull($"frontcrossbar{lockerCount}") &&
                                    !reader.IsDBNull($"backcrossbar{lockerCount}") &&
                                    !reader.IsDBNull($"sidecrossbar{lockerCount}") &&
                                    !reader.IsDBNull($"horizontalpanel{lockerCount}") &&
                                    !reader.IsDBNull($"sidepanel{lockerCount}") &&
                                    !reader.IsDBNull($"backpanel{lockerCount}") &&
                                    !reader.IsDBNull($"door{lockerCount}"))
                                {
                                    StringBuilder lockerDetails = new StringBuilder();
                                    lockerDetails.AppendLine($"Locker {lockerCount}:");
                                    lockerDetails.AppendLine($"- Vertical Batten: {GetComponentQuantity(reader.GetString($"verticalbatten{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Front Crossbar: {GetComponentQuantity(reader.GetString($"frontcrossbar{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Back Crossbar: {GetComponentQuantity(reader.GetString($"backcrossbar{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Side Crossbar: {GetComponentQuantity(reader.GetString($"sidecrossbar{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Horizontal Panel: {GetComponentQuantity(reader.GetString($"horizontalpanel{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Side Panel: {GetComponentQuantity(reader.GetString($"sidepanel{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Back Panel: {GetComponentQuantity(reader.GetString($"backpanel{lockerCount}"))}");
                                    lockerDetails.AppendLine($"- Door: {GetComponentQuantity(reader.GetString($"door{lockerCount}"))}");
                                    lockerDetails.AppendLine();
                                    armoireDetails.Add(lockerDetails.ToString());
                                }
                            }
                        }
                    }
                }

                armoiresDetailsList.Add(armoireDetails);
            }
        }
        else
        {
            Console.WriteLine("No idneworders found for idClient: " + idClient);
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error loading order details: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return armoiresDetailsList;
}






// //Méthode pour récupérer l'idneworder correspondant à l'armoireNumber
// public int GetIdNewOrderFromArmoireNumber(int armoireNumber, int idClient)
// {
//     int idneworder = -1;
    
//     try
//     {
//         OpenConnection();

//         // Construire la requête SQL pour récupérer l'idneworder correspondant à l'armoireNumber
//         string query = $"SELECT armoire{armoireNumber} FROM totalorder WHERE idclient = @IdClient";
//         MySqlCommand command = new MySqlCommand(query, Connection);
//         command.Parameters.AddWithValue("@IdClient", idClient); // Assurez-vous de définir idClient correctement
//         object result = command.ExecuteScalar();
        
//         if (result != null && result != DBNull.Value)
//         {
//             idneworder = Convert.ToInt32(result);
//         }
//     }
//     catch (MySqlException ex)
//     {
//         Console.WriteLine("Error getting idneworder from armoireNumber: " + ex.Message);
//     }
//     finally
//     {
//         CloseConnection();
//     }

//     return idneworder;
// }


public List<int> GetIdNewOrderFromArmoireNumber(int armoireNumber, int idClient)
{
    List<int> idneworders = new List<int>(); // Liste pour stocker les idneworder

    try
    {
        OpenConnection();

        // Construire la requête SQL pour récupérer les idneworder correspondant à l'armoireNumber
        string query = $"SELECT armoire{armoireNumber} FROM totalorder WHERE idclient = @IdClient";
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@IdClient", idClient); // Assurez-vous de définir idClient correctement
        MySqlDataReader reader = command.ExecuteReader();

        // Parcourir les résultats et ajouter les idneworder à la liste
        while (reader.Read())
        {
            if (!reader.IsDBNull(0))
            {
                idneworders.Add(reader.GetInt32(0));
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error getting idneworder from armoireNumber: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return idneworders;
}


// public List<int> GetSavedArmoireNumbers(int idClient, int armoireNumber)
// {
//     List<int> armoireNumbers = new List<int>();
    
//     try
//     {
//         OpenConnection();

//         // Construire la requête SQL pour récupérer les armoireNumber correspondants au client et à l'armoireNumber spécifié
//         string query = $"SELECT armoire{armoireNumber} FROM totalorder WHERE idclient = @IdClient";
//         MySqlCommand command = new MySqlCommand(query, Connection);
//         command.Parameters.AddWithValue("@IdClient", idClient);
//         MySqlDataReader reader = command.ExecuteReader();
        
//         while (reader.Read())
//         {
//             if (!reader.IsDBNull(0))
//             {
//                 armoireNumbers.Add(reader.GetInt32(0));
//             }
//         }
//     }
//     catch (MySqlException ex)
//     {
//         Console.WriteLine("Error getting armoire numbers for client: " + ex.Message);
//     }
//     finally
//     {
//         CloseConnection();
//     }

//     return armoireNumbers;
// }
// public List<int> GetPreviousArmoireNumbers(int idClient,int armoireNumber)
// {
//     List<int> armoireNumbers = new List<int>();

//     try
//     {
//         OpenConnection();

//         // Construire la requête SQL pour récupérer les numéros d'armoire précédents
//         string query = $"SELECT DISTINCT armoire{armoireNumber} FROM totalorder WHERE idClient = @IdClient";
//         MySqlCommand command = new MySqlCommand(query, Connection);
//         command.Parameters.AddWithValue("@IdClient", idClient);

//         using (MySqlDataReader reader = command.ExecuteReader())
//         {
//             while (reader.Read())
//             {
//                 armoireNumbers.Add(reader.GetInt32($"{armoireNumber}"));
//             }
//         }
//     }
//     catch (MySqlException ex)
//     {
//         Console.WriteLine("Error getting previous armoire numbers: " + ex.Message);
//     }
//     finally
//     {
//         CloseConnection();
//     }

//     return armoireNumbers;
// }
public List<int> GetPreviousArmoireOrders(int idClient, int armoireNumber)
{
    List<int> armoireOrders = new List<int>();

    try
    {
        OpenConnection();

        // Construire la requête SQL pour récupérer les commandes associées à chaque numéro d'armoire précédent
        string columnName = $"armoire{armoireNumber}";
        string query = $"SELECT DISTINCT {columnName} FROM totalorder WHERE idClient = @IdClient";
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@IdClient", idClient);

        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int idneworder = reader.GetInt32("idneworder");
                Console.WriteLine($"Contenu de l'armoire pour l'idneworder {idneworder}:");
                
                for (armoireNumber = 1; armoireNumber <= 14; armoireNumber++)
                {
                    // string columnName = $"armoire{armoireNumber}";
                    int value = reader.GetInt32(columnName);
                    Console.WriteLine($"Armoire {armoireNumber}: {value}");
                }
            }
        }

    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error getting previous armoire orders: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return armoireOrders;
}


// public string LoadPreviousArmoireDetails(int idClient,int armoireNumber)
// {
//     StringBuilder allArmoireDetails = new StringBuilder();

//     try
//     {
//         OpenConnection();

//         // Récupérer tous les numéros d'armoire pour le client donné
//         List<int> previousArmoireNumbers = GetPreviousArmoireOrders(idClient,armoireNumber);

//         // Parcourir tous les numéros d'armoire et récupérer leurs détails
//         foreach (int armoireNuumber in previousArmoireNumbers)
//         {
//             // Récupérer les détails de l'armoire pour ce numéro et ajouter à la chaîne
//             string armoireDetails = Loadkitb(armoireNuumber, idClient);
//             allArmoireDetails.AppendLine(armoireDetails);
//         }
//     }
//     catch (MySqlException ex)
//     {
//         Console.WriteLine("Error loading previous armoire details: " + ex.Message);
//     }
//     finally
//     {
//         CloseConnection();
//     }

//     return allArmoireDetails.ToString();
// }


public int GetComponentQuantity(string componentCode)
{
    int lockerQuantity = 0;
    Console.WriteLine("code recu " + componentCode);
    string query = "SELECT LockerQuantity FROM component WHERE Code = @ComponentCode";

    try
    {
        // Ouvrir une nouvelle connexion pour éviter les conflits avec le DataReader précédent
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ComponentCode", componentCode);
            object result = command.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lockerQuantity = Convert.ToInt32(result);
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving locker quantity for component: " + ex.Message);
    }

    return lockerQuantity;
}

private int GetRemainingQuantity(string componentCode)
{
    int remainingQuantity = 0;
    Console.WriteLine("code recu " + componentCode);
    string query = "SELECT RemainingQuantity FROM component WHERE Code = @ComponentCode";

    try
    {
        // Ouvrir une nouvelle connexion pour éviter les conflits avec le DataReader précédent
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ComponentCode", componentCode);
            object result = command.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                remainingQuantity = Convert.ToInt32(result);
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving remaining quantity for component: " + ex.Message);
    }

    return remainingQuantity;
}

public int TestContact(int orderId, int amountlocker)
{
    //StringBuilder orderDetails = new StringBuilder();
    int result = 1;
    try
    {
        OpenConnection();

        // Récupérer les données des lockers pour l'ID de la commande donnée
        string query = "SELECT * FROM neworder WHERE idneworder = @OrderId";
        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@OrderId", orderId);
        MySqlDataReader reader = command.ExecuteReader();

       while (reader.Read())
        {
            for (int lockerNumber = 1; lockerNumber <= amountlocker; lockerNumber++)
            {
                int verticalBattenNecessary = GetComponentQuantity(reader.GetString($"verticalbatten{lockerNumber}"));
                int frontCrossbarNecessary = GetComponentQuantity(reader.GetString($"frontcrossbar{lockerNumber}"));
                int backCrossbarNecessary = GetComponentQuantity(reader.GetString($"backcrossbar{lockerNumber}"));
                int sideCrossbarNecessary = GetComponentQuantity(reader.GetString($"sidecrossbar{lockerNumber}"));
                int horizontalPanelNecessary = GetComponentQuantity(reader.GetString($"horizontalpanel{lockerNumber}"));
                int sidePanelNecessary = GetComponentQuantity(reader.GetString($"sidepanel{lockerNumber}"));
                int backPanelNecessary = GetComponentQuantity(reader.GetString($"backpanel{lockerNumber}"));
                int doorNecessary = GetComponentQuantity(reader.GetString($"door{lockerNumber}"));

                int verticalBattenStock = GetRemainingQuantity(reader.GetString($"verticalbatten{lockerNumber}"));
                int frontCrossbarStock = GetRemainingQuantity(reader.GetString($"frontcrossbar{lockerNumber}"));
                int backCrossbarStock = GetRemainingQuantity(reader.GetString($"backcrossbar{lockerNumber}"));
                int sideCrossbarStock = GetRemainingQuantity(reader.GetString($"sidecrossbar{lockerNumber}"));
                int horizontalPanelStock = GetRemainingQuantity(reader.GetString($"horizontalpanel{lockerNumber}"));
                int sidePanelStock = GetRemainingQuantity(reader.GetString($"sidepanel{lockerNumber}"));
                int backPanelStock = GetRemainingQuantity(reader.GetString($"backpanel{lockerNumber}"));
                int doorStock = GetRemainingQuantity(reader.GetString($"door{lockerNumber}"));
                Console.WriteLine("Front : {0}",frontCrossbarStock);
                Console.WriteLine("Front Necessaire : {0}", verticalBattenNecessary);

                if(verticalBattenStock < verticalBattenNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    verticalBattenStock -= verticalBattenNecessary;
                }
                if(frontCrossbarStock < frontCrossbarNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    frontCrossbarStock -= frontCrossbarNecessary;
                }
                if(backCrossbarStock < backCrossbarNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    backCrossbarStock -= backCrossbarNecessary;
                }
                if(sideCrossbarStock < sideCrossbarNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    sideCrossbarStock -= sideCrossbarNecessary;
                }
                if(horizontalPanelStock < horizontalPanelNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    horizontalPanelStock -= horizontalPanelNecessary;
                }
                if(sidePanelStock < sidePanelNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    sidePanelStock -= sidePanelNecessary;
                }
                if(backPanelStock < backPanelNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    backPanelStock -= backPanelNecessary;
                }
                if(doorStock < doorNecessary)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    doorStock -= doorNecessary;
                }

                // Ajouter le détail du locker à la chaîne
                /*orderDetails.AppendLine($"Locker {lockerNumber}:");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"verticalbatten{lockerNumber}"))} Vertical Batten :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"frontcrossbar{lockerNumber}"))} Front Crossbar :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"backcrossbar{lockerNumber}"))} Back Crossbar :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"sidecrossbar{lockerNumber}"))} Side Crossbar :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"horizontalpanel{lockerNumber}"))} Horizontal Panel :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"sidepanel{lockerNumber}"))} Side Panel :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"backpanel{lockerNumber}"))} Back Panel :");
                orderDetails.AppendLine($"{GetComponentQuantity(reader.GetString($"door{lockerNumber}"))} Door :");
                orderDetails.AppendLine();*/
            }
        }

        reader.Close();
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error loading order details: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return result;
}


public void AddCustomer(Customer customer)
{
    try
    {
        OpenConnection();

        string query = "INSERT INTO customer (CustomerName, CustomerFirstName, MobileNumber, Mail) VALUES (@CustomerName, @CustomerFirstName, @MobileNumber, @Mail)";

        MySqlCommand command = new MySqlCommand(query, Connection);
        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
        command.Parameters.AddWithValue("@CustomerFirstName", customer.FirstCustomerName);
        command.Parameters.AddWithValue("@MobileNumber", customer.CustomerPhone);
        command.Parameters.AddWithValue("@Mail", customer.CustomerEmail);

        command.ExecuteNonQuery();
        Console.WriteLine("Customer added successfully.");
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error adding customer: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }
}

public double GetAveragePrice(string code)
{
    double averagePrice = 0;

    // Construire la requête SQL pour récupérer la ligne correspondante dans la table des prix
    string query = "SELECT price1, price2 FROM price WHERE code = @Code";

    try
    {
        OpenConnection();

        using (MySqlCommand command = new MySqlCommand(query, Connection))
        {
            // Ajouter le paramètre code à la commande SQL
            command.Parameters.AddWithValue("@Code", code);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                int price1Total = 0;
                int price2Total = 0;
                int count = 0;

                // Parcourir les résultats de la requête
                while (reader.Read())
                {
                    // Ajouter les valeurs de price1 et price2 aux totaux
                    price1Total += reader.GetInt32("price1");
                    price2Total += reader.GetInt32("price2");
                    count++;
                }

                // Calculer la moyenne des valeurs de price1 et price2
                if (count > 0)
                {
                    averagePrice = (double)(price1Total + price2Total) / (2 * count);
                }
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine("Error retrieving average price from the database: " + ex.Message);
    }
    finally
    {
        CloseConnection();
    }

    return averagePrice;
}

}