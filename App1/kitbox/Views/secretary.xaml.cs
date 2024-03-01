namespace kitbox;
using System.Collections.ObjectModel;
// using Xamarin.Forms;
public partial class secretary : ContentPage
{
	public ObservableCollection<Element> elementsList {get; set;} = new ObservableCollection<Element>();
	public ObservableCollection<Supplier> supplierList {get; set;} = new ObservableCollection<Supplier>();
	private DatabaseManager databaseManager;
	public secretary()
	{
		InitializeComponent();
		BindingContext = this;
		databaseManager = new DatabaseManager();
		LoadElementsFromDatabase();
		LoadSuppliersFromDatabase();
	}
	private void LoadElementsFromDatabase(){
		databaseManager.OpenConnection();
		var ElementsFromDataBase = databaseManager.GetElements();
		databaseManager.CloseConnection();
		foreach(var elem in ElementsFromDataBase){
			elementsList.Add(elem);
		}
		PartSupplier.ItemsSource= elementsList.Select(elem => elem.DisplayNameCode).ToList();
	}
	private void OnAddTheNewProductClicked(object sender, EventArgs e)
{
    string name = NameEntry.Text;
    string code = CodeEntry.Text;
    string color = ColorEntry.Text;
    int length = Convert.ToInt32(LengthEntry.Text);
    int width = Convert.ToInt32(WidthEntry.Text);
    int heightReal = Convert.ToInt32(Height_RealEntry.Text);
    int heightCustomer = Convert.ToInt32(Height_CustomerEntry.Text);
    string side = SidePicker.SelectedItem?.ToString();
    int depth = Convert.ToInt32(DepthEntry.Text);
    int diameter = Convert.ToInt32(DiameterEntry.Text);
    int lockerQuantity = Convert.ToInt32(LockerQuantityEntry.Text);
    int kitboxQuantity = Convert.ToInt32(KitboxQuantityEntry.Text);
    Element newElement = new Element(name, code, color, length, width, heightReal, heightCustomer, 0, side, depth, diameter, lockerQuantity, 0, kitboxQuantity);
    elementsList.Add(newElement);
    databaseManager.OpenConnection();
    databaseManager.AddElement(newElement);
    databaseManager.CloseConnection();
    DisplayAlert("Success", "You created a new element", "OK");
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
private void OnRemoveTapped(object sender, EventArgs e){
    if (sender is View view){
        if (view.BindingContext is Element selectedElement){
            elementsList.Remove(selectedElement);
            databaseManager.OpenConnection();
            databaseManager.RemoveElement(selectedElement);
            databaseManager.CloseConnection();
        }
    }
}

}