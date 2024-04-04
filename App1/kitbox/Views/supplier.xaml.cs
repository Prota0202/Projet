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
		databaseManager = new DatabaseManager();
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
			string adress2add = NewSupplierAdress.Text;
			string mail2add = NewSupplierMail.Text;
			int phonenumber2add = Convert.ToInt32(NewSupplierPhoneNumber.Text);
			Supplier newsupplier = new Supplier(supplier2add, adress2add, mail2add, phonenumber2add);
			supplierList.Add(newsupplier);
			// Nettoyer les champs d'entrée
			NewSupplierEntry.Text = "";
			NewSupplierAdress.Text = "";
			NewSupplierMail.Text = "";
			NewSupplierPhoneNumber.Text = "";

			databaseManager.OpenConnection();
			databaseManager.AddSupplier(newsupplier);
			databaseManager.CloseConnection();
			DisplayAlert("Succes","You succesfuly added a new supplier","ok");
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

	private void OnEditTapped(object sender, EventArgs e)
	{
		var label = (Label)sender;
		Supplier supplier = (Supplier)label.BindingContext;
		databaseManager.OpenConnection();
		int id = databaseManager.FindSupplierId(supplier);
		databaseManager.CloseConnection();
		string supplier2add = NewSupplierEntry.Text;
		string adress2add = NewSupplierAdress.Text;
		string mail2add = NewSupplierMail.Text;
		int phonenumber2add = Convert.ToInt32(NewSupplierPhoneNumber.Text);
		Supplier supplier2update = new Supplier(supplier2add,adress2add,mail2add,phonenumber2add);
		
		
		
		int index = supplierList.IndexOf(supplier);
		if (index != -1)
		{
			supplierList[index] = supplier2update;
		}
		
		NewSupplierEntry.Text = "";
		NewSupplierAdress.Text = "";
		NewSupplierMail.Text = "";
		NewSupplierPhoneNumber.Text = "";
		
		
		databaseManager.OpenConnection();
		databaseManager.UpdateSupplier(id, supplier2update.suppliername, supplier2update.adress, supplier2update.mail, supplier2update.phonenumber);
		databaseManager.CloseConnection();
	}



}


