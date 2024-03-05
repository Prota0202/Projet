using System.Collections.ObjectModel;
using Customer_app.Models;
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
        
        
        
        
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Récupérer les valeurs sélectionnées dans l'interface utilisateur
            int depth = Convert.ToInt32(DepthPicker.SelectedItem);
            int width = Convert.ToInt32(WidthPicker.SelectedItem);
            int height = Convert.ToInt32(HeightPicker.SelectedItem);
            string panelColor = PanelColorPicker.SelectedItem.ToString();
            string doorType = DoorPicker.SelectedItem.ToString();
            string angleIronColor = AngleIronColorPicker.SelectedItem.ToString();

            // Créer un nouvel objet Order avec ces valeurs
            Order newOrder = new Order(0, depth, width, height, panelColor, doorType, angleIronColor);

            // Appeler la méthode pour enregistrer cette commande dans la base de données
            SaveOrder(newOrder);
        }

        private void SaveOrder(Order order)
        {
            // Appeler la méthode appropriée de DatabaseManager pour enregistrer la commande
            databaseManager.SaveOrder(order);
        }


        private void basketclicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage());
        }
    }
}

    
