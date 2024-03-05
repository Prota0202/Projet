using System.Collections.ObjectModel;
namespace Customer_app.Views

    
{
    public partial class OrderPage : ContentPage
    {
        private int lockerCount = 0;
        
     
        public ObservableCollection<Customer_app.Models.Element> elementsList { get; set; } = new ObservableCollection<Customer_app.Models.Element>();

        
        private readonly DatabaseManager databaseManager;

        public OrderPage()
        {
            databaseManager = new DatabaseManager();
            InitializeComponent();
			//MainGrid = this.FindByName<Grid>("MainGrid");
        }

        public void LoadElementsFromDatabase(){
            databaseManager.OpenConnection();
            var ElementsFromDataBase = databaseManager.GetElements();
            databaseManager.CloseConnection();
            foreach(var elem in ElementsFromDataBase){
                elementsList.Add(elem);
            }
        }


        private void AddLockerButton_Clicked(object sender, EventArgs e)
        {
            if (lockerCount < 7)
            {
                lockerCount++;
                var newLockerLabel = new Label
                {
                    Text = "Locker " + lockerCount,
                    HorizontalOptions = LayoutOptions.Center
                };

				//Grid.SetRow(newLockerLabel, 6);
        		//Grid.SetColumn(newLockerLabel, 13);
                MainStackLayout.Children.Add(newLockerLabel);
            }
            else
            {
                DisplayAlert("Limit reached", "You cannot add more than 7 lockers.", "OK");
            }
        }

        private void basketclicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage());
        }
    }
}
    
