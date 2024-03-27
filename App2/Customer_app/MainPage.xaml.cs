using Customer_app.Views;

namespace Customer_app;

public partial class MainPage : ContentPage
{
	private DatabaseManager databaseManager;
	public int idClient;

	public MainPage()
	{
		InitializeComponent();
		databaseManager = new DatabaseManager();
		idClient = databaseManager.GetNextIdclient();//Faut créer la fonction GetNextIdclient
		Console.WriteLine("idclient "+idClient);
	}

	private void Orderbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OrderPage(idClient)); 
	}

}

