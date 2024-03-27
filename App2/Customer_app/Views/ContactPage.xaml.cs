using Customer_app.Models;
using System.Collections.ObjectModel;
namespace Customer_app.Views;

public partial class ContactPage : ContentPage
{
	public ObservableCollection<Customer> customerList {get; set;} = new ObservableCollection<Customer>();
	private readonly DatabaseManager databaseManager;
	public int idClient;
	public ContactPage(int idclient)//idlcient
	{
		databaseManager = new DatabaseManager();
		InitializeComponent();
		idClient = idclient;
	}

	private async void OrderBackbuttonclicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new OrderPage(0));
	}

	private void OnAddContactClicked(object sender, EventArgs e)
	{
		string customerName = NameContact.Text;
		string customerFirstName = FirstNameContact.Text;
		string customerEmail = EmailContact.Text;
		int customerPhone = Convert.ToInt32(PhoneContact.Text);
		Customer newCustomer = new Customer(customerName, customerFirstName, customerEmail, customerPhone);
		customerList.Add(newCustomer);
		databaseManager.AddCustomer(newCustomer);
	}
}
