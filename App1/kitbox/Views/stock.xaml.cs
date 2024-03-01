namespace kitbox;
using System.Collections.ObjectModel;
public partial class stock : ContentPage
{
    public ObservableCollection<Element> elementsList {get; set;} = new ObservableCollection<Element>();
	private DatabaseManager databaseManager;
	public stock()
	{
		InitializeComponent();
		BindingContext = this;
		databaseManager = new DatabaseManager();
        LoadElementsFromDatabase();
	}
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
    private void OnAddQuantityClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var element = (Element)btn.CommandParameter;
            if (element != null)
            {
                int quantityToAdd = Convert.ToInt32(((Entry)btn.Parent.FindByName("QuantityToChangeEntry")).Text);
                element.AddQuantity(quantityToAdd);
                databaseManager.OpenConnection();
                databaseManager.UpdateElement(element);
                databaseManager.CloseConnection();
                RefreshListView();
            }
        }

        private void OnRemoveQuantityClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var element = (Element)btn.CommandParameter;;
            if (element != null)
            {
                int quantityToRemove = Convert.ToInt32(((Entry)btn.Parent.FindByName("QuantityToChangeEntry")).Text);
                element.RemoveQuantity(quantityToRemove);
                databaseManager.OpenConnection();
                databaseManager.UpdateElement(element);
                databaseManager.CloseConnection();
                RefreshListView();
            }
        }
	private void RefreshListView()
{
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