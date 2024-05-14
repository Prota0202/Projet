using System.Collections.ObjectModel;
using Customer_app.Models;
using System.Text;
using MySql.Data.MySqlClient;
using System.Net.Cache;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Customer_app.Views

    
{
    public partial class OrderPage : ContentPage
    {
        private int lockerCount = 0;
        public ObservableCollection<Customer_app.Models.Element> elementsList { get; set; } =
            new ObservableCollection<Customer_app.Models.Element>();
        private readonly DatabaseManager databaseManager;
        public NewOrder currentOrder;
        public int idClient;

        public int armoireNumber2;
        public OrderPage(int idclient, int armoireNumber)
        {
            databaseManager = new DatabaseManager();
            InitializeComponent();
            idClient = idclient;
            armoireNumber2 += armoireNumber;
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
        // private async void ShowConfirmationAlert(object sender, EventArgs e)
        // {
        //     var result = await DisplayAlert("Confirmation", "the depth and width will be the same for every locker", "OK", "CANCEL");

        //     if (result)
        //     {
        //         SaveDepthWidth();
        //         // Si l'utilisateur clique sur OK, masquez les Picker
        //         DepthPicker.IsVisible = false;
        //         WidthPicker.IsVisible = false;
        //     }
        //     else
        //     {
        //         // Si l'utilisateur clique sur ANNULER, laissez les Picker visibles
        //         DepthPicker.IsVisible = true;
        //         WidthPicker.IsVisible = true;
        //     }
        // }
        public string ChoiceText { get; set; }
        public bool IsChoiceTextVisible { get; set; }

        private async void ShowConfirmationAlert(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmation", "The depth and width will be the same for every locker", "OK", "CANCEL");

            if (result)
            {
                SaveDepthWidth();

                // Masquez le StackLayout des Pickers
                PickerStackLayout.IsVisible = false;

                // Affichez le StackLayout des Labels
                LabelStackLayout.IsVisible = true;

                OrderStackLayout.IsVisible = true;


                // Mettez à jour les Labels avec les valeurs sélectionnées
                Sentence.Text = $"Your choice is → {DepthPicker.SelectedItem}cm deep and → {WidthPicker.SelectedItem}cm wide ";

            }
            else
            {
                // Si l'utilisateur clique sur ANNULER, laissez le StackLayout des Pickers visible
                PickerStackLayout.IsVisible = true;

                // Masquez le StackLayout des Labels
                LabelStackLayout.IsVisible = false;

                OrderStackLayout.IsVisible = false;

            }
        }

        private void SaveDepthWidth(){
            int depth = Convert.ToInt32(DepthPicker.SelectedItem);
            int width = Convert.ToInt32(WidthPicker.SelectedItem);
            currentOrder = new NewOrder(depth,width);
            Console.WriteLine(currentOrder.DisplayName);
        }
        // private void AddLockerButton_Clicked(object sender, EventArgs e)
        // {
        //     if (lockerCount < 7)
        //     {
        //         lockerCount++;
        //         int height = Convert.ToInt32(HeightPicker.SelectedItem);
        //         string panelColor = PanelColorPicker.SelectedItem.ToString();
        //         string doorType = DoorPicker.SelectedItem.ToString();
        //         string angleIronColor = AngleIronColorPicker.SelectedItem.ToString();
        //         currentOrder.AddLocker(height,panelColor,doorType,angleIronColor);
        //         Console.WriteLine(currentOrder.DisplayText);


        //         var newLockerLabel = new Label
        //         {
        //             Text = "Locker " + lockerCount + "\nHeight : " + height + "cm" + "\nPanel Color : " + panelColor + "\nDoor : " + doorType + "\n Angle Iron : " + angleIronColor,
        //             // HorizontalOptions = LayoutOptions.Center
        //         };
        //         // //Grid.SetRow(newLockerLabel, 6);
        //         // //Grid.SetColumn(newLockerLabel, 13);
        //         // MainStackLayout.Children.Add(newLockerLabel);
        //         //RightStackLayout.Children.Add(newLockerLabel);

        //         var removeButton = new Button
        //         {
        //             Text = "Remove",
        //             CommandParameter = lockerCount,
        //         };
        //         removeButton.CommandParameter = currentOrder.Lockers.Last(); // Utilisez le dernier casier ajouté comme paramètre de commande


        //         var lockerLayout = new StackLayout
        //         {
        //             Children = { newLockerLabel, removeButton }
        //         };

        //         RightStackLayout.Children.Add(lockerLayout);
                
        //         // Actualisez l'affichage
        //         UpdateLockerLabels();
        //     }
        //     else
        //     {
        //         DisplayAlert("Limit reached", "You cannot add more than 7 lockers.", "OK");
        //     }
        // }

        private void AddLockerButton_Clicked(object sender, EventArgs e)
        {
            if (lockerCount < 7)
            {
                int height = Convert.ToInt32(HeightPicker.SelectedItem);
                string panelColor = PanelColorPicker.SelectedItem.ToString();
                string doorType = DoorPicker.SelectedItem.ToString();
                string angleIronColor = AngleIronColorPicker.SelectedItem.ToString();
                currentOrder.AddLocker(height,panelColor,doorType,angleIronColor);
                Console.WriteLine(currentOrder.DisplayText);

                var newLockerLabel = new Label
                {
                    Text = $"Locker {lockerCount + 1}\nHeight: {height}cm\nPanel Color: {panelColor}\nDoor: {doorType}\nAngle Iron: {angleIronColor}"
                };

                var removeButton = new Button
                {
                    Text = "Remove",
                    CommandParameter = lockerCount, // Utilisez le compteur actuel comme paramètre
                };
                removeButton.Clicked += RemoveButton_Clicked;

                var lockerLayout = new StackLayout
                {
                    Children = { newLockerLabel, removeButton }
                };

                RightStackLayout.Children.Add(lockerLayout);

                // Incrémentez le compteur après l'affichage du casier
                lockerCount++;

                // Appel pour mettre à jour les numéros de casier après l'ajout initial
                UpdateLockerLabels();
            }
            else
            {
                DisplayAlert("Limit reached", "You cannot add more than 7 lockers.", "OK");
            }
        }


        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var lockerIndex = (int)button.CommandParameter;

                // Assurez-vous que votre classe NewOrder a une méthode pour supprimer un casier
                // Remplacez RemoveLocker(locker) par l'appel à la méthode appropriée
                currentOrder.RemoveLocker(lockerIndex);

                // Supprimez le layout du casier de la vue
                RightStackLayout.Children.Remove(button.Parent as View);

                // Décrémentez lockerCount après la suppression
                lockerCount--;

                // Mettez à jour les labels après la suppression
                UpdateLockerLabels();
            }
        }


        private void UpdateLockerLabels()
        {
            int index = -1;
            foreach (var child in RightStackLayout.Children)
            {
                if (child is StackLayout lockerLayout)
                {
                    if (lockerLayout.Children.Count == 2 && lockerLayout.Children[0] is Label label && lockerLayout.Children[1] is Button removeButton)
                    {
                        label.Text = $"Locker {index}\n{string.Join('\n', label.Text.Split('\n')[1..5])}";

                        removeButton.CommandParameter = index;
                    }
                }
                index++;
            }
        }

        // Modifier pour test fichier JSON
        // private async void SaveButton_Clicked(object sender, EventArgs e)
        // {
        //     SaveButton.Clicked -= SaveButton_Clicked;
        //     int depth = currentOrder.Depth;
        //     int width = currentOrder.Width;
        //     int idneworder = databaseManager.GetNextOrderId();

        //     int lockerNumber = 1;
        //     foreach (var locker in currentOrder.Lockers)
        //     {
        //         string verticalbatten = databaseManager.GetVerticalBattenCode(locker.Height);
        //         string sidecrossbar = databaseManager.GetSideCrossbarCode(depth);
        //         string frontcrossbar = databaseManager.GetFrontCrossbarCode(width);
        //         string backcrossbar = databaseManager.GetBackCrossbarCode(width);
        //         string horizontalpanel = databaseManager.GetHorizontalPanelCode(locker.PanelColor, width, depth);
        //         string sidepanel = databaseManager.GetSidePanelCode(locker.PanelColor, locker.Height, depth);
        //         string backpanel = databaseManager.GetBackPanelCode(locker.PanelColor, locker.Height, width);
        //         string door = databaseManager.GetDoorCode(locker.PanelColor, locker.Height, width);
        //         if (lockerNumber == 1)
        //         {
        //             databaseManager.SaveLockerComponents(idneworder, lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
        //         }
        //         else
        //         {
        //             databaseManager.UpdateLockerComponents(idneworder, lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
        //         }
        //         lockerNumber++;
        //     }
        //     armoireNumber++; // Incrémenter ici pour éviter l'écrasement
        //     databaseManager.AddIdNewOrderToTotalOrder(idClient, idneworder, armoireNumber);
        //     //  await Navigation.PushAsync(new BasketPage(currentOrder, idClient, armoireNumber));

        //     // Attendre une courte période avant de réactiver le gestionnaire d'événements
        //     await Task.Delay(1000);

        //     // Réactiver le gestionnaire d'événements après une courte période
        //     SaveButton.Clicked += SaveButton_Clicked;
        // }

        //TEST fichier JSON
        public class LockerContent
        {
            public int Depth { get; set; }
            public int Width { get; set; }

            public int Height { get; set; }

            // public int lockerCount { get; set;}
            public string PanelColor { get; set; }
            public string DoorType { get; set; }
            public string AngleIronColor { get; set; }


            public string VerticalBatten { get; set; }
            public string FrontCrossbar { get; set; }
            public string BackCrossbar { get; set; }
            public string SideCrossbar { get; set; }
            public string HorizontalPanel { get; set; }
            public string SidePanel { get; set; }
            public string BackPanel { get; set; }
            public string Door { get; set; }
            
        }

        public class ArmoireContent
        {
            public int ArmoireNumber { get; set; }
            public List<LockerContent> Lockers { get; set; }
        }

        public class BasketContent
        {
            public List<ArmoireContent> Armoires { get; set; }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            SaveButton.Clicked -= SaveButton_Clicked;

            BasketContent basketContent = null;

            // Vérifier si le fichier JSON existe déjà
            string filePath = "basket_content.json";
            if (File.Exists(filePath))
            {
                // Charger le contenu actuel du fichier JSON
                string jsonContent = await File.ReadAllTextAsync(filePath);

                // Désérialiser le contenu JSON en objet BasketContent
                basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);
            }
            else
            {
                // Créer un nouvel objet BasketContent s'il n'existe pas déjà de fichier JSON
                basketContent = new BasketContent();
                basketContent.Armoires = new List<ArmoireContent>();

                // Créer le fichier JSON s'il n'existe pas
                await File.WriteAllTextAsync(filePath, "");
            }

            
            // Créer un nouvel objet ArmoireContent pour la nouvelle entrée
            ArmoireContent currentArmoire = new ArmoireContent();
            currentArmoire.ArmoireNumber = armoireNumber2 + 1 ; // pour ne pas commencer à 0, j'ai mis +1
            currentArmoire.Lockers = new List<LockerContent>();

            int depth = currentOrder.Depth;
            int width = currentOrder.Width;

            foreach (var locker in currentOrder.Lockers)
            {
                LockerContent lockerContent = new LockerContent
                {
                    Depth = depth,
                    Width = width,
                    Height = locker.Height,
                    //lockerCount = locker.lockerCount,
                    PanelColor = locker.PanelColor,
                    DoorType = locker.DoorType,
                    AngleIronColor = locker.AngleIronColor,
                    VerticalBatten = databaseManager.GetVerticalBattenCode(locker.Height),
                    SideCrossbar = databaseManager.GetSideCrossbarCode(depth),
                    FrontCrossbar = databaseManager.GetFrontCrossbarCode(width),
                    BackCrossbar = databaseManager.GetBackCrossbarCode(width),
                    HorizontalPanel = databaseManager.GetHorizontalPanelCode(locker.PanelColor, width, depth),
                    SidePanel = databaseManager.GetSidePanelCode(locker.PanelColor, locker.Height, depth),
                    BackPanel = databaseManager.GetBackPanelCode(locker.PanelColor, locker.Height, width),
                    Door = databaseManager.GetDoorCode(locker.PanelColor, locker.Height, width)
                };

                currentArmoire.Lockers.Add(lockerContent);
            }

            // Ajouter le nouvel objet ArmoireContent à la liste des armoires dans BasketContent
            basketContent.Armoires.Add(currentArmoire);

            // Incrémenter le numéro d'armoire
            armoireNumber2++;
            

            // Convertir le contenu mis à jour en JSON
            /////////string updatedJsonContent = JsonSerializer.Serialize(basketContent);

            // Ajouter un saut de ligne après chaque virgule qui sépare les objets ArmoireContent
           // updatedJsonContent = Regex.Replace(updatedJsonContent, @"},\s*{""ArmoireNumber""", "},\n{\"ArmoireNumber\"");
            string updatedJsonContent = JsonSerializer.Serialize(basketContent, new JsonSerializerOptions { WriteIndented = true });


            // Enregistrer le contenu mis à jour dans le fichier JSON
            await File.WriteAllTextAsync(filePath, updatedJsonContent);

            // Attendre une courte période avant de réactiver le gestionnaire d'événements
            await Task.Delay(1000);

            // Réactiver le gestionnaire d'événements après une courte période
            SaveButton.Clicked += SaveButton_Clicked;
            
            Navigation.PushAsync(new OrderPage(idClient, armoireNumber2));
        }
        
        
        private async void SeeBasket_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasketPage(currentOrder, idClient, armoireNumber2));
        }


        // private void ResetFields()
        // {
        //     DepthPicker.SelectedItem = null;
        //     WidthPicker.SelectedItem = null;
        //     HeightPicker.SelectedItem = null;
        //     PanelColorPicker.SelectedItem = null;
        //     DoorPicker.SelectedItem = null;
        //     AngleIronColorPicker.SelectedItem = null;

        //     // Effacer le contenu de RightStackLayout
        //     RightStackLayout.Children.Clear();
        // }


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
            Navigation.PushAsync(new ContactPage(idClient));
        }
    }
}


