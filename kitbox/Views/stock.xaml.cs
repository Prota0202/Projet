namespace kitbox;
using System.Collections.ObjectModel;
public partial class stock : ContentPage
{
	public ObservableCollection<Part> partsList {get; set;} = new ObservableCollection<Part>();
	private DatabaseManager databaseManager;
	public stock()
	{
		InitializeComponent();
		BindingContext = this;

		string server = "localhost";
        string database = "kitbox";
        string username = "root";
        string password = "root";
		databaseManager = new DatabaseManager(server, database, username, password);
		LoadPartsFromDatabase();
	}
	private void LoadPartsFromDatabase(){
		databaseManager.OpenConnection();
		var partsFromDatabase = databaseManager.GetParts();
		databaseManager.CloseConnection();
		foreach(var part in partsFromDatabase){
			partsList.Add(part);
		}

		AddPartPicker.ItemsSource = partsList.Select(part => part.DisplayName).ToList();
        RemovePartPicker.ItemsSource = partsList.Select(part => part.DisplayName).ToList();
	}

	private void OnAddPartsClicked(object sender, EventArgs e)
        {
            string selectedPartName = AddPartPicker.SelectedItem as string;
            int quantityToAdd = Convert.ToInt32(QuantityEntry.Text);

            Part selectedPart = partsList.FirstOrDefault(part => part.DisplayName == selectedPartName);
            if (selectedPart != null)
            {
                selectedPart.Add(quantityToAdd);//useless i think
                databaseManager.OpenConnection();
                databaseManager.UpdatePartQuantity(selectedPart.DisplayName,quantityToAdd);
                databaseManager.CloseConnection();
				RefreshListView();
            }
        }

	private void OnRemovePartsClicked(object sender, EventArgs e)
{
    string selectedPartName = RemovePartPicker.SelectedItem as string;
    int quantityToRemove = Convert.ToInt32(Quantity2Entry.Text);
    Part selectedPart = partsList.FirstOrDefault(part => part.DisplayName == selectedPartName);
    if (selectedPart != null)
    {
        int quantityChange = -quantityToRemove;
        databaseManager.OpenConnection();
        databaseManager.UpdatePartQuantity(selectedPart.DisplayName, quantityChange);
        databaseManager.CloseConnection();
        selectedPart.Remove(quantityToRemove);
		RefreshListView();
    }
}
    private void OnAddQuantityClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string partName = btn.CommandParameter.ToString();
            Part selectedPart = partsList.FirstOrDefault(part => part.DisplayName == partName);
            if (selectedPart != null)
            {
                int quantityToAdd = Convert.ToInt32(((Entry)btn.Parent.FindByName("QuantityToChangeEntry")).Text);
                selectedPart.Add(quantityToAdd);
                databaseManager.OpenConnection();
                databaseManager.UpdatePartQuantity(selectedPart.DisplayName, quantityToAdd);
                databaseManager.CloseConnection();
                RefreshListView();
            }
        }

        private void OnRemoveQuantityClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string partName = btn.CommandParameter.ToString();
            Part selectedPart = partsList.FirstOrDefault(part => part.DisplayName == partName);
            if (selectedPart != null)
            {
                int quantityToRemove = Convert.ToInt32(((Entry)btn.Parent.FindByName("QuantityToChangeEntry")).Text);
                int quantityChange = -quantityToRemove;
                databaseManager.OpenConnection();
                databaseManager.UpdatePartQuantity(selectedPart.DisplayName, quantityChange);
                databaseManager.CloseConnection();
                selectedPart.Remove(quantityToRemove);
                RefreshListView();
            }
        }

        
	private void RefreshListView()
{
    partsList.Clear();
	databaseManager.OpenConnection();
    var partsFromDatabase = databaseManager.GetParts();
	databaseManager.CloseConnection();
    foreach (var part in partsFromDatabase)
    {
        partsList.Add(part);
    }
}
}