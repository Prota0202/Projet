namespace kitbox
{
    public partial class seller : ContentPage
    {
        private DatabaseManager databaseManager;
        private StackLayout stackLayout;
        private List<string> listcodes;
        private int Orderid;
        StackLayout orderLayout;

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
        orderLayout = new StackLayout();
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
                        Button okButton = new Button
                        {
                            Text = "OK",
                            Margin = new Thickness(0, 10, 0, 0)
                        };
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
                        okButton.Clicked += (sender, e) => OnOkButtonClicked(components[1],orderLabel,okButton,componentLayout);

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
            // bool isLastLine = lines[lines.Length - 1] == line;
            // if (isLastLine)
            // {
            //     // Add "Order Completed" button
            //     Button orderCompletedButton = new Button
            //     {
            //         Text = "Order Completed",
            //         BackgroundColor = Color.FromArgb("#FF0000"),
            //         Margin = new Thickness(5, 10, 0, 0)
            //     };
            //     orderCompletedButton.Clicked += (sender, e) => OnOrderCompletedButtonClicked();
            //     orderLayout.Children.Add(orderCompletedButton);
            // }
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

        Button orderCompletedButton = new Button
        {
            Text = "Order Completed",
            BackgroundColor = Color.FromArgb("#FF0000"),
            Margin = new Thickness(5, 10, 0, 0)
        };
        orderCompletedButton.Clicked += (sender, e) => OnOrderCompletedButtonClicked();
        orderLayout.Children.Add(orderCompletedButton);

        stackLayout.Children.Add(orderLayout);
    }
}

    private async void OnOkButtonClicked(string code,Label orderLabel,Button okButton,StackLayout componentLayout){
    var quantities = databaseManager.UpdateRemainingQuantity(code);
    int lockerQuantity = quantities.lockerQuantity;
    int remainingQuantity = quantities.remainingQuantity;
    string trimmedCode = code.Trim();

    string alertMessage = "You have taken " + lockerQuantity + " of : " + trimmedCode + "\nStill remaining : " + remainingQuantity;
    await DisplayAlert("Alert", alertMessage, "OK");
    Console.WriteLine("OK button clicked with code: " + code);

    componentLayout.Children.Remove(orderLabel);
    componentLayout.Children.Remove(okButton);
    orderLayout.Children.Remove(componentLayout);
    }

    private void OnShowOrdersClicked(object sender, EventArgs e)
    {
        DisplayOrders();
    }

    private async void OnOrderCompletedButtonClicked()
{
    bool orderCompleted = await DisplayAlert("Order Completed", "Have you completed the order?", "OK", "Cancel");
    
    if (orderCompleted)
    {
        databaseManager.RemoveTheOrder(Orderid);
        await Navigation.PushAsync(new SellerSearch());
    }
}


}
}