namespace kitbox
{
    public partial class seller : ContentPage
    {
        private DatabaseManager databaseManager;
        private StackLayout stackLayout;
        private List<string> listcodes;
        

        public seller()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
            stackLayout = new StackLayout();
            scrollView.Content = stackLayout; // Utilisation de scrollView pour accéder à Content
            DisplayOrders();
            listcodes = databaseManager.GetColumnCodes(50);
        }

        private void DisplayOrders()
        {
            List<string> orders = databaseManager.GetLatestOrder();

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
                        Label orderLabel = new Label
                        {
                            Text = components[0] + ": " + components[1],
                            Margin = new Thickness(0, 10, 0, 0)
                        };
                        Button okButton = new Button
                        {
                            Text = "OK",
                            Margin = new Thickness(5, 10, 0, 0)
                        };
                        okButton.Clicked += (sender, e) => OnOkButtonClicked(components[1]);
                        orderLayout.Children.Add(orderLabel);
                        orderLayout.Children.Add(okButton);
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
        private void OnOkButtonClicked(string code)
        {
            DisplayAlert("coucou",code,"siuuuu");
            Console.WriteLine("coucou aypub");
            databaseManager.UpdateRemainingQuantity(code);
        }
        private void OnShowOrdersClicked(object sender, EventArgs e)
        {
            DisplayOrders();
        }
    }
}