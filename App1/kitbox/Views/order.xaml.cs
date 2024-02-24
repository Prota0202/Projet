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

		string server = "localhost";
        string database = "kitbox";
        string username = "root";
        string password = "root";
		databaseManager = new DatabaseManager(server, database, username, password);
		LoadPartsFromDatabase();
	}
	private void LoadPartsFromDatabase(){
		databaseManager.OpenConnection();
		var partsFromDatabase = databaseManager.GetElements();
		databaseManager.CloseConnection();
		foreach(var elem in partsFromDatabase){
			elementsList.Add(elem);
		}
	}
}