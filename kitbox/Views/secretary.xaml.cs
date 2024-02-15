namespace kitbox;
using System.Collections.ObjectModel;
// using Xamarin.Forms;
public partial class secretary : ContentPage
{
	public ObservableCollection<Part> partsList {get; set;} = new ObservableCollection<Part>();
	public ObservableCollection<Supplier> supplierList {get; set;} = new ObservableCollection<Supplier>();
	private DatabaseManager databaseManager;
	public secretary()
	{
		InitializeComponent();
		BindingContext = this;

		string server = "localhost";
        string database = "kitbox";
        string username = "root";
        string password = "root";
		databaseManager = new DatabaseManager(server, database, username, password);
		LoadPartsFromDatabase();
		LoadSuppliersFromDatabase();
	}

	private void LoadPartsFromDatabase(){
		databaseManager.OpenConnection();
		var partsFromDatabase = databaseManager.GetParts();
		databaseManager.CloseConnection();
		foreach(var part in partsFromDatabase){
			partsList.Add(part);
		}
	}

	private void OnAddTheNewProductClicked(object sender, EventArgs e) {
		string product2add = NewProductEntry.Text;
		if(int.TryParse(PriceProductAddedEntry.Text, out int priceofproduct)){
			Part thenewpart = new Part(product2add, priceofproduct);
			partsList.Add(thenewpart);
			databaseManager.OpenConnection();
			databaseManager.AddPart(thenewpart);
			databaseManager.CloseConnection();

			DisplayAlert("Succes","you created a new part","ok");
		}
	}

	private void LoadSuppliersFromDatabase(){
		databaseManager.OpenConnection();
		var suppliersFromDatabase = databaseManager.GetSuppliers();
		databaseManager.CloseConnection();
		foreach(var supplier in suppliersFromDatabase){
			supplierList.Add(supplier);
		}
		SupplierPicker.ItemsSource = supplierList.Select(part => part.DisplayName).ToList();
	}
}