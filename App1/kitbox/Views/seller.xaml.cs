namespace kitbox
{
    public partial class seller : ContentPage
    {
        private DatabaseManager databaseManager;
        private StackLayout stackLayout;

        public seller()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
            stackLayout = new StackLayout();
            scrollView.Content = stackLayout; // Utilisation de scrollView pour accéder à Content
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            List<string> orders = databaseManager.GetLatestOrder();

            foreach (string order in orders)
            {
                Label orderLabel = new Label
                {
                    Text = order,
                    Margin = new Thickness(0, 10, 0, 0)
                };
                stackLayout.Children.Add(orderLabel);
            }
        }

        private void OnShowOrdersClicked(object sender, EventArgs e)
        {
            DisplayOrders();
        }
    }
}