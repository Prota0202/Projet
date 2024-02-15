namespace kitbox;
using System.Collections.ObjectModel;
public partial class supplier : ContentPage
{
	public ObservableCollection<Supplier> supplierList {get; set;} = new ObservableCollection<Supplier>();
	private DatabaseManager databaseManager;
	public supplier()
	{
		InitializeComponent();
		BindingContext = this;

		string server = "localhost";
        string database = "kitbox";
        string username = "root";
        string password = "root";
		databaseManager = new DatabaseManager(server, database, username, password);
		LoadSuppliersFromDatabase();
	}

	private void LoadSuppliersFromDatabase(){
		databaseManager.OpenConnection();
		var suppliersFromDatabase = databaseManager.GetSuppliers();
		databaseManager.CloseConnection();
		foreach(var supplier in suppliersFromDatabase){
			supplierList.Add(supplier);
		}
		// RemoveSupplierPicker.ItemsSource = supplierList.Select(part => part.DisplayName).ToList();
	}

	private void OnAddNewSupplier(object sender, EventArgs e) {
			string supplier2add = NewSupplierEntry.Text;
			Supplier newsupplier = new Supplier(supplier2add);
			supplierList.Add(newsupplier);
			databaseManager.OpenConnection();
			databaseManager.AddSupplier(newsupplier);
			databaseManager.CloseConnection();
			DisplayAlert("Succes","you created a new part","ok");
	}

	private void OnRemoveTapped(object sender, EventArgs e)
{
    var label = (Label)sender;
    var supplier = (Supplier)label.BindingContext;
    supplierList.Remove(supplier);
    databaseManager.OpenConnection();
    databaseManager.RemoveSupplier(supplier.DisplayName);
    databaseManager.CloseConnection();
}
}