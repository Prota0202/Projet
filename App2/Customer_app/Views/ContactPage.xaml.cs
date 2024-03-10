using Customer_app.Models;
using System.Collections.ObjectModel;
namespace Customer_app.Views;

public partial class ContactPage : ContentPage
{
	public ObservableCollection<Customer> customerList {get; set;} = new ObservableCollection<Customer>();
	private readonly DatabaseManager databaseManager;
	public ContactPage()
	{
		databaseManager = new DatabaseManager();
		InitializeComponent();
	}

	private void OrderBackbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
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
