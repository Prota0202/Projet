namespace kitbox
{
    public partial class seller : ContentPage
    {
        private DatabaseManager databaseManager;
        private StackLayout stackLayout;
        private List<string> listcodes;
        private int Orderid;
        

        public seller(int orderid)
        {
            InitializeComponent();
            Orderid = orderid;
            databaseManager = new DatabaseManager();
            stackLayout = new StackLayout();
            scrollView.Content = stackLayout; 
            DisplayOrders();
            listcodes = databaseManager.GetColumnCodes(orderid);
        }

        private void DisplayOrders()
{
    List<string> orders = databaseManager.GetOrderById(Orderid);

    foreach (string order in orders)
    {
        StackLayout orderLayout = new StackLayout();
        bool isLockerLine = false;

        string[] lines = order.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        foreach (string line in lines)
        {
            if (line.StartsWith("Locker "))
            {
                isLockerLine = true;
            }
            else
            {
                isLockerLine = false;
                string[] components = line.Split(':'); // Séparer le nom du composant et sa valeur
                if (components.Length == 2 && !string.IsNullOrEmpty(components[1].Trim())) // Vérifier si la valeur du composant n'est pas null ou vide
                {
                    if (!line.StartsWith("Order ID")) // Vérifier si la ligne ne commence pas par "Order ID"
                    {
                        // Create a horizontal StackLayout for each component
                        StackLayout componentLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Margin = new Thickness(0, 10, 0, 0)
                        };

                        Label orderLabel = new Label
                        {
                            Text = components[0] + ": " + components[1],
                            HorizontalOptions = LayoutOptions.StartAndExpand
                        };
                        Button okButton = new Button
                        {
                            Text = "OK",
                            Margin = new Thickness(5, 0, 0, 0)
                        };
                        okButton.Clicked += (sender, e) => OnOkButtonClicked(components[1]);

                        // Add label and button to the horizontal StackLayout
                        componentLayout.Children.Add(orderLabel);
                        componentLayout.Children.Add(okButton);
                        
                        orderLayout.Children.Add(componentLayout); // Add horizontal StackLayout to the orderLayout
                    } 
                    else
                    {
                        Label orderLabel = new Label
                        {
                            Text = line,
                            Margin = new Thickness(0, 10, 0, 0)
                        };
                        orderLayout.Children.Add(orderLabel);
                    }
                }
                else
                {
                    Label orderLabel = new Label
                    {
                        Text = line,
                        Margin = new Thickness(0, 10, 0, 0)
                    };
                    orderLayout.Children.Add(orderLabel);
                }
            }
        }

        if (isLockerLine)
        {
            Label orderLabel = new Label
            {
                Text = order,
                Margin = new Thickness(0, 10, 0, 0)
            };
            orderLayout.Children.Add(orderLabel);
        }

        stackLayout.Children.Add(orderLayout);
    }
}

    private async void OnOkButtonClicked(string code)
    {
        // Display an alert dialog
        await DisplayAlert("Alert", "Code: " + code, "OK");

        // Perform additional actions if needed
        Console.WriteLine("OK button clicked with code: " + code);
        databaseManager.UpdateRemainingQuantity(code);
    }

    private void OnShowOrdersClicked(object sender, EventArgs e)
    {
        DisplayOrders();
    }


}
}