namespace Customer_app;
using System.Collections.ObjectModel;
using Customer_app.Models; 
using Customer_app.Views; 

public partial class OrderingPage : ContentPage
{
    public ObservableCollection<Order> OrdersList { get; set; } = new ObservableCollection<Order>();
    private DatabaseManager databaseManager;

    public OrderingPage()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        BindingContext = this;

        string server = "localhost";
        string database = "order";
        string username = "root";
        string password = "root";
        databaseManager = new DatabaseManager(server, database, username, password);
        LoadOrdersFromDatabase();
    }

    private void LoadOrdersFromDatabase()
    {
        databaseManager.OpenConnection();
        var OrdersFromDataBase = databaseManager.GetOrders();
        databaseManager.CloseConnection();
        foreach (var order in OrdersFromDataBase)
        {
            OrdersList.Add(order);
        }
    }

    private void BasketClicked(object sender, EventArgs e)
{
     Navigation.PushAsync(new BasketPage());
}


    private void OnRefreshClicked(object sender, EventArgs e)
    {
        RefreshListView();
    }

    private void RefreshListView()
    {
        OrdersList.Clear();
        LoadOrdersFromDatabase(); 
    }
}