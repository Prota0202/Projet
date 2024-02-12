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
		RemoveSupplierPicker.ItemsSource = supplierList.Select(part => part.DisplayName).ToList();
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

	private void OnSupplierRemoveClicked(object sender, EventArgs e){
    string selectedSupplierName = RemoveSupplierPicker.SelectedItem as string;

    if (!string.IsNullOrEmpty(selectedSupplierName)){
        databaseManager.OpenConnection();
        databaseManager.RemoveSupplier(selectedSupplierName);
        databaseManager.CloseConnection();
        Supplier supplierToRemove = supplierList.FirstOrDefault(s => s.suppliername == selectedSupplierName);
        if (supplierToRemove != null){
            supplierList.Remove(supplierToRemove);
            DisplayAlert("Success", "Supplier removed successfully", "OK");
        }
        else{
            DisplayAlert("Error", "Failed to find the supplier to remove", "OK");
        }
    }
    else{
        DisplayAlert("Error", "Please select a supplier to remove", "OK");
    }
}
}