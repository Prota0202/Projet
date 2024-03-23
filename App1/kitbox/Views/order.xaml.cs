namespace kitbox;
using System.Collections.ObjectModel;

public partial class order : ContentPage
{
	public ObservableCollection<Element> elementsList {get; set;} = new ObservableCollection<Element>();
	private DatabaseManager databaseManager;
	public order()
	{
		InitializeComponent();
		BindingContext = this;
		databaseManager = new DatabaseManager();
		LoadElementsFromDatabase();	}
	private void LoadElementsFromDatabase(){
		databaseManager.OpenConnection();
		var ElementsFromDataBase = databaseManager.GetElements();
		databaseManager.CloseConnection();
		foreach(var elem in ElementsFromDataBase){
			elementsList.Add(elem);
		}
	}

	private void OnRefreshClicked(object sender, EventArgs e)
{
		RefreshListView();
}
	private void OnButtonPlusClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var element = (Element)button.CommandParameter;
			Console.WriteLine(element.Name);
			Console.WriteLine(element.Code);
            if (element != null)
            {
				Console.WriteLine("it works");
                int quantityToAdd = Convert.ToInt32(((Entry)button.Parent.FindByName("QuantityToChangeEntry")).Text);
				Console.WriteLine(quantityToAdd);
				element.OrderToSupplier(quantityToAdd);
				databaseManager.OpenConnection();
                databaseManager.UpdateElement(element);
                databaseManager.CloseConnection();
				RefreshListView();
            }
            else
            {
                Console.WriteLine("Invalid quantity entered.");
            }
        }

private void RefreshListView(){
    elementsList.Clear();
	databaseManager.OpenConnection();
    var ElementsFromDataBase = databaseManager.GetElements();
	databaseManager.CloseConnection();
    foreach (var elem in ElementsFromDataBase)
    {
        elementsList.Add(elem);
    }
}
}