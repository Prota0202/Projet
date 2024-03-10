using System.Collections.ObjectModel;
using Customer_app.Models;
using System.Text;
using MySql.Data.MySqlClient;
using System.Net.Cache;
namespace Customer_app.Views

    
{
    public partial class OrderPage : ContentPage
    {
        private int lockerCount = 0;
        public ObservableCollection<Customer_app.Models.Element> elementsList { get; set; } =
            new ObservableCollection<Customer_app.Models.Element>();
        private readonly DatabaseManager databaseManager;
        private NewOrder currentOrder;
        public OrderPage()
        {
            databaseManager = new DatabaseManager();
            InitializeComponent();
            //MainGrid = this.FindByName<Grid>("MainGrid");
        }
        public void LoadElementsFromDatabase()
        {
            databaseManager.OpenConnection();
            var ElementsFromDataBase = databaseManager.GetElements();
            databaseManager.CloseConnection();
            foreach (var elem in ElementsFromDataBase)
            {
                elementsList.Add(elem);
            }
        }
        private async void ShowConfirmationAlert(object sender, EventArgs e){
            var result = await DisplayAlert("Confirmation","the depth and width will be the same for every locker","ok","cancel");

            if(result){
                SaveDepthWidth();
            }
            else{}
        }
        private void SaveDepthWidth(){
            int depth = Convert.ToInt32(DepthPicker.SelectedItem);
            int width = Convert.ToInt32(WidthPicker.SelectedItem);
            currentOrder = new NewOrder(depth,width);
            Console.WriteLine(currentOrder.DisplayName);
        }
        private void AddLockerButton_Clicked(object sender, EventArgs e)
        {
            if (lockerCount < 7)
            {
                lockerCount++;
                int height = Convert.ToInt32(HeightPicker.SelectedItem);
                string panelColor = PanelColorPicker.SelectedItem.ToString();
                string doorType = DoorPicker.SelectedItem.ToString();
                string angleIronColor = AngleIronColorPicker.SelectedItem.ToString();
                currentOrder.AddLocker(height,panelColor,doorType,angleIronColor);
                Console.WriteLine(currentOrder.DisplayText);


                var newLockerLabel = new Label
                {
                    Text = "Locker " + lockerCount + "\nHeight : " + height + "cm" + "\nPanel Color : " + panelColor + "\nDoor : " + doorType + "\n Angle Iron : " + angleIronColor,
                    // HorizontalOptions = LayoutOptions.Center
                };
                // //Grid.SetRow(newLockerLabel, 6);
                // //Grid.SetColumn(newLockerLabel, 13);
                // MainStackLayout.Children.Add(newLockerLabel);
                RightStackLayout.Children.Add(newLockerLabel);
            }
            else
            {
                DisplayAlert("Limit reached", "You cannot add more than 7 lockers.", "OK");
            }
        }




        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Désactiver le gestionnaire d'événements pour éviter les enregistrements multiples
            SaveButton.Clicked -= SaveButton_Clicked;

            // Récupérer les valeurs sélectionnées dans l'interface utilisateur
            // int depth = Convert.ToInt32(DepthPicker.SelectedItem);
            // int width = Convert.ToInt32(WidthPicker.SelectedItem);
            // int height = Convert.ToInt32(HeightPicker.SelectedItem);
            // string panelColor = PanelColorPicker.SelectedItem.ToString();
            // string doorType = DoorPicker.SelectedItem.ToString();
            // string angleIronColor = AngleIronColorPicker.SelectedItem.ToString();

            // // Ajoutez les instructions de débogage ici
            // Console.WriteLine("Depth: " + depth);
            // Console.WriteLine("Width: " + width);
            // Console.WriteLine("Height: " + height);
            // Console.WriteLine("PanelColor: " + panelColor);
            // Console.WriteLine("DoorType: " + doorType);
            // Console.WriteLine("AngleIronColor: " + angleIronColor);
            // string verticalbatten = databaseManager.GetVerticalBattenCode(height);
            // Console.WriteLine("VERTICAL BATTEN "+verticalbatten);
            // string sidecrossbar = databaseManager.GetSideCrossbarCode(depth);
            // Console.WriteLine("SIDE CROSSBAR "+sidecrossbar);
            // string frontcrossbar = databaseManager.GetFrontCrossbarCode(width);
            // Console.WriteLine("FRONT CROSSBAR "+frontcrossbar);
            // string backcrossbar = databaseManager.GetBackCrossbarCode(width);
            // Console.WriteLine("BACK CROSSBAR "+backcrossbar);
            // string backpanel = databaseManager.GetBackPanelCode(panelColor,height,width);
            // Console.WriteLine("BACK PANEL "+backpanel);
            // string door = databaseManager.GetDoorCode(panelColor, height,width);
            // Console.WriteLine("DOOR"+door);
            int depth = currentOrder.Depth;
            int width = currentOrder.Width;
            int idneworder = databaseManager.GetNextOrderId();

            int lockerNumber = 1;
            foreach (var locker in currentOrder.Lockers){
            string verticalbatten = databaseManager.GetVerticalBattenCode(locker.Height);
            string sidecrossbar = databaseManager.GetSideCrossbarCode(depth);
            string frontcrossbar = databaseManager.GetFrontCrossbarCode(width);
            string backcrossbar = databaseManager.GetBackCrossbarCode(width);
            string horizontalpanel = databaseManager.GetHorizontalPanelCode(locker.PanelColor,width,depth);
            string sidepanel = databaseManager.GetSidePanelCode(locker.PanelColor,locker.Height,depth);
            string backpanel = databaseManager.GetBackPanelCode(locker.PanelColor, locker.Height, width);
            string door = databaseManager.GetDoorCode(locker.PanelColor, locker.Height, width);
            if(lockerNumber==1){
                    databaseManager.SaveLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
            }
            else{
                    databaseManager.UpdateLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
            }
            lockerNumber++;
            }

            int amountlocker = currentOrder.GetNumberOfLockers();
            string recap = databaseManager.LoadOrder(idneworder, amountlocker);
            Console.WriteLine(recap);
            DisplayAlert("Recap",recap,"okay");
            ResetFields();


            // Créer un nouvel objet Order avec ces valeurs
            // Order newOrder = new Order(0, depth, width, height, panelColor, doorType, angleIronColor);

            // Appeler la méthode pour enregistrer cette commande dans la base de données
            // int orderId = databaseManager.SaveOrderWithoutId(newOrder);

            // Vérifier si l'enregistrement de la commande a réussi
            // if (orderId != -1)
            // {
            //     // Réinitialiser les champs après l'enregistrement de la commande
            //     ResetFields();

            //     // Appeler la méthode pour enregistrer la facture avec l'ID de la commande
            //     SaveBill(orderId, GenerateBillList(newOrder));
            // }

            //Activer l'alerte pour le formulaire de contact
            DisplayActionSheet("Out of stock : Please complete the contact form", "Cancel", null, "Contact Form");
            
            
            // Attendre une courte période avant de réactiver le gestionnaire d'événements
            await Task.Delay(1000);

            // Réactiver le gestionnaire d'événements après une courte période
            SaveButton.Clicked += SaveButton_Clicked;
        }



        private void ResetFields(){
            DepthPicker.SelectedItem = null;
            WidthPicker.SelectedItem = null;
            HeightPicker.SelectedItem = null;
            PanelColorPicker.SelectedItem = null;
            DoorPicker.SelectedItem = null;
            AngleIronColorPicker.SelectedItem = null;
        }

        private string GenerateBillList(Order order)
        {
            // Générer la liste des commandes pour la facture
            // Par exemple, vous pouvez concaténer les détails de la commande dans une chaîne
            // Retourner la chaîne générée
            return $"{order.Depth}x{order.Width}x{order.Height}, Panel Color: {order.PanelColor}, Door Type: {order.Door}, Angle Iron Color: {order.AngleIronColor}";
        }

        private void SaveBill(int numOrder, string listOrder)
        {
            try
            {
                databaseManager.OpenConnection();
                
               

                // Insérer les données dans la table "bill"
                databaseManager.SaveBill(numOrder, listOrder);
                Console.WriteLine("Bill saved successfully.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error saving bill: " + ex.Message);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
}




        public int SaveOrderWithoutId(Order order)
        {
            int orderId = -1; // Initialiser l'ID de la commande à une valeur par défaut

            try
            {
                databaseManager.OpenConnection();

                string query = "INSERT INTO `order` (depth, width, height, panel_color, door_type, angle_iron_color) VALUES (@Depth, @Width, @Height, @PanelColor, @Door, @AngleIronColor); SELECT LAST_INSERT_ID();";

                MySqlCommand command = new MySqlCommand(query, databaseManager.Connection);
                command.Parameters.AddWithValue("@Depth", order.Depth);
                command.Parameters.AddWithValue("@Width", order.Width);
                command.Parameters.AddWithValue("@Height", order.Height);
                command.Parameters.AddWithValue("@PanelColor", order.PanelColor);
                command.Parameters.AddWithValue("@Door", order.Door);
                command.Parameters.AddWithValue("@AngleIronColor", order.AngleIronColor);
                string ayoub = databaseManager.GetVerticalBattenCode(order.Height);
                Console.WriteLine(ayoub);

                // Exécuter la requête et récupérer l'ID de la commande nouvellement insérée
                orderId = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine("Order saved successfully with ID: " + orderId);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error saving order: " + ex.Message);
            }
            finally
            {
                databaseManager.CloseConnection();
            }

            return orderId;
        }











        //Modifie la fonction pour que le bouton renvoie vers la page de contact (modif aussi le nom du bouton dans xaml)
        private void ContactPageclicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactPage());
        }
    }
}


