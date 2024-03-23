namespace kitbox;

public partial class HistoryOrderPage : ContentPage
{
	DatabaseManager databaseManager = new DatabaseManager();
	public HistoryOrderPage()
	{
		InitializeComponent();
		DisplayHistoricOrders();
	}

	private void DisplayHistoricOrders(){
		var (codes, amounts) = databaseManager.GetHistoricOrderDetails();
		List<Element> elements = new List<Element>();
            foreach (var code in codes)
            {
                Element element = databaseManager.SearchElementCode(code);
                if (element != null)
                {
                    elements.Add(element);
                }
            }
			foreach (var element in elements)
            {
                string displayString = element.DisplayAll;
                Console.WriteLine(displayString);
            }
	}
}