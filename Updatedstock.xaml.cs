namespace kitbox;
using System.Collections.ObjectModel;
using System.Linq; 

public partial class stock : ContentPage
{
    public ObservableCollection<Element> elementsList { get; set; } = new ObservableCollection<Element>();
    private DatabaseManager databaseManager;
    public stock()
    {
        InitializeComponent();
        BindingContext = this;
        databaseManager = new DatabaseManager();
        LoadElementsFromDatabase();
    }

    private void LoadElementsFromDatabase()
    {
        databaseManager.OpenConnection();
        var ElementsFromDataBase = databaseManager.GetElements();
        databaseManager.CloseConnection();
        elementsList = new ObservableCollection<Element>(ElementsFromDataBase);
        RefreshListView();
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        RefreshListView();
    }

    private void OnAddQuantityClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var element = (Element)button.CommandParameter;
        if (element != null)
        {
            int quantityToAdd = Convert.ToInt32(((Entry)button.Parent.FindByName("QuantityToChangeEntry")).Text);
            element.Quantity += quantityToAdd; 
            databaseManager.UpdateElement(element);
            RefreshListView();
        }
    }

    private void OnRemoveQuantityClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var element = (Element)button.CommandParameter;
        if (element != null)
        {
            int quantityToRemove = Convert.ToInt32(((Entry)button.Parent.FindByName("QuantityToChangeEntry")).Text);
            element.Quantity -= quantityToRemove; 
            databaseManager.UpdateElement(element);
            RefreshListView();
        }
    }

    private void OnOrderClicked(object sender, EventArgs e)
    {
        
        foreach (var element in elementsList.Where(el => el.Quantity == 0))
        {
            databaseManager.OrderElement(element, 1);
        }

        
        RefreshListView();
    }

    private void RefreshListView()
    {
        
        LoadElementsFromDatabase();
    }
}