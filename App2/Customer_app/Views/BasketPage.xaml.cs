using System.Collections.ObjectModel;
using Customer_app.Models;
using System.Text;
using MySql.Data.MySqlClient;
using System.Net.Cache;
using System.IO; // Pour la manipulation des fichiers
using System.Text.Json; // Pour la désérialisation JSON
namespace Customer_app.Views;

public partial class BasketPage : ContentPage
{
	private readonly DatabaseManager databaseManager;
	public ObservableCollection<Customer_app.Models.Element> elementsList { get; set; } =
            new ObservableCollection<Customer_app.Models.Element>();
	private int lockerCount;
	private int depth;
	private int width;
	private NewOrder currentOrder;
	public int idClient;
	public int kit_boxNumber;
	private int kit_boxCount = 0;
	private List<Label> kit_boxLabels = new List<Label>();

							public BasketPage(NewOrder currentorder, int idclient, int kit_boxnumber)
							{
								databaseManager = new DatabaseManager();
								currentOrder = currentorder;
								idClient = idclient;
								kit_boxNumber = kit_boxnumber;
								InitializeComponent();

								// Appel à la méthode DisplayBasketContent pour afficher le contenu du fichier JSON
    							DisplayBasketContent();

								CalculateTotalPrice();

								// Après avoir sauvegardé la commande dans SaveButton_Clicked
								List<List<string>> kit_boxDetailsList = databaseManager.Loadkitb(kit_boxNumber,idClient);

								// Ajouter une colonne pour chaque kit_box dans la grille
								for (int i = 0; i < kit_boxDetailsList.Count; i++)
								{
									Kit_boxGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
								}

								// Ajouter le contenu de chaque kit_box dans la colonne correspondante
								for (int i = 0; i < kit_boxDetailsList.Count; i++)
								{
									// Créer un ScrollView pour cette colonne
									var scrollView = new ScrollView();
									Grid.SetColumn(scrollView, i); // Définir la colonne pour ce ScrollView
									Kit_boxGrid.Children.Add(scrollView); // Ajouter le ScrollView à la grille

									// Créer un StackLayout pour contenir le contenu de l'kit_box
									var stackLayout = new StackLayout();
									scrollView.Content = stackLayout; // Définir le StackLayout comme contenu du ScrollView

									// Enregistrer le contenu de l'kit_box
									foreach (var kit_boxDetails in kit_boxDetailsList[i])
									{
										stackLayout.Children.Add(new Label { Text = kit_boxDetails, FontSize = 18 });
									}
								}
							}



        public class LockerContent
        {
			public int Depth { get; set; }
			public int Width { get; set; }
			public int Height { get; set; }
			public int LockerCounted { get; set; }
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

        public class Kit_boxContent
        {
            public int Kit_boxNumber { get; set; }
            public List<LockerContent> Lockers { get; set; }
        }

        public class BasketContent
        {
            public List<Kit_boxContent> Kit_boxs { get; set; }
        }
        private void DisplayBasketContent()
        {
            string filePath = "basket_content.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

                // Parcourir chaque kit_box dans le contenu du panier
                foreach (var kit_box in basketContent.Kit_boxs)
                {
					int depth = kit_box.Lockers.FirstOrDefault()?.Depth ?? 0;
					int width = kit_box.Lockers.FirstOrDefault()?.Width ?? 0;

                    Label kit_boxLabel = new Label
                    {
                        Text = $"Kitbox n° {kit_box.Kit_boxNumber} [Depth : {depth} cm - Width : {width} cm]",
                        FontSize = 20,
						BackgroundColor = Color.FromRgb(53, 52, 55), 
						TextColor = Color.FromRgb(144, 102, 242),
                        HorizontalOptions = LayoutOptions.Center,
						WidthRequest = 2000 // Définit la largeur sur celle de la fenêtre
                    };

                    Kit_boxStackLayout.Children.Add(kit_boxLabel);

					int lockerCounted = 1; // Initialisation du compteur de casier			
                    foreach (var locker in kit_box.Lockers)
                    {
						locker.LockerCounted = lockerCounted; // Affectez le numéro du casier au casier actuel
    					lockerCounted++; // Incrémentation du compteur pour le prochain casier

						
                        StackLayout lockerLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(10),
                            //BackgroundColor = Color.FromRgb(200, 0, 0),
                            Spacing = 5
                        };


                        // Ajouter chaque propriété du locker à une label
						AddLockerProperty(lockerLayout, "Locker n°", locker.LockerCounted.ToString());
						AddLockerProperty(lockerLayout, "Height", locker.Height.ToString());
                        AddLockerProperty(lockerLayout, "PanelColor", locker.PanelColor);
                        AddLockerProperty(lockerLayout, "DoorType", locker.DoorType);
                        AddLockerProperty(lockerLayout, "AngleIronColor", locker.AngleIronColor);
                        // AddLockerProperty(lockerLayout, "Vertical Batten", locker.VerticalBatten);
                        // AddLockerProperty(lockerLayout, "Front Crossbar", locker.FrontCrossbar);
                        // AddLockerProperty(lockerLayout, "Back Crossbar", locker.BackCrossbar);
                        // AddLockerProperty(lockerLayout, "Side Crossbar", locker.SideCrossbar);
                        // AddLockerProperty(lockerLayout, "Horizontal Panel", locker.HorizontalPanel);
                        // AddLockerProperty(lockerLayout, "Side Panel", locker.SidePanel);
                        // AddLockerProperty(lockerLayout, "Back Panel", locker.BackPanel);
                        // AddLockerProperty(lockerLayout, "Door", locker.Door);
                        Kit_boxStackLayout.Children.Add(lockerLayout);
                    }
                }
            }
            else
            {
                // Afficher un message si le fichier JSON n'existe pas
                Label noContentLabel = new Label
                {
                    Text = "Le contenu du panier est vide.",
                    FontSize = 20,
                    //TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Center
                };

                Kit_boxStackLayout.Children.Add(noContentLabel);
            }
        }

        // Méthode pour ajouter une propriété du locker à une label
        private void AddLockerProperty(StackLayout lockerLayout, string propertyName, string propertyValue)
        {
            Label propertyLabel = new Label
            {
                Text = $"{propertyName} : {propertyValue}",
                FontSize = 16,
                //TextColor = Color.Black
            };

			    if (propertyName == "Locker n°")
			{
				propertyLabel.FontSize = 20;
				propertyLabel.FontAttributes = FontAttributes.Bold;
				propertyLabel.Text = $"{propertyName} {propertyValue} :";
				propertyLabel.TextDecorations = TextDecorations.Underline;
				//TextColor = Color.FromRgb(144, 102, 242),
			}

            lockerLayout.Children.Add(propertyLabel);
        }

	private void OrderBackbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OrderPage(idClient, kit_boxNumber));
	}

	private async void Deleteakitbox(object sender, EventArgs e)
	{
		// Demander à l'utilisateur le numéro de l'kit_box à supprimer
		string kit_boxNumberInput = await DisplayPromptAsync("Delete a kitbox", "Enter the kitbox number:");

		if (!string.IsNullOrEmpty(kit_boxNumberInput))
		{
			int kit_boxNumberToDelete;
			if (int.TryParse(kit_boxNumberInput, out kit_boxNumberToDelete))
			{
				// Lire le contenu du fichier JSON
				string filePath = "basket_content.json";
				string jsonContent = File.ReadAllText(filePath);
				BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

				// Parcourir la liste à l'envers pour pouvoir supprimer l'élément en toute sécurité
				for (int i = basketContent.Kit_boxs.Count - 1; i >= 0; i--)
				{
					if (basketContent.Kit_boxs[i].Kit_boxNumber == kit_boxNumberToDelete)
					{
						// Supprimer l'kit_box de la liste
						basketContent.Kit_boxs.RemoveAt(i);
						
						//Décrémenter les numéros d'kit_box pour les kit_boxs suivantes
						foreach (var kit_box in basketContent.Kit_boxs.Where(a => a.Kit_boxNumber > kit_boxNumberToDelete))
						{
							kit_box.Kit_boxNumber--;
						} //-> Finalemement non comment ca on ca rajoute et c tout on s'en fout de l'ordre on sait juste que c une autre kit_box

						// Mettre à jour le contenu du fichier JSON après la suppression
						string updatedJsonContent = JsonSerializer.Serialize(basketContent);
						File.WriteAllText(filePath, updatedJsonContent);

						// Mettre à jour l'affichage après la suppression
						RefreshBasketDisplay();

						return; // Sortir de la méthode après la suppression
					}
				}

				// Si l'kit_box n'est pas trouvée
				await DisplayAlert("Error", "Kitbox not found.", "OK");
			}
			else
			{
				await DisplayAlert("Error", "Invalid input. Please enter a valid kitbox number.", "OK");
			}
		}
	}


	private void RefreshBasketDisplay()
	{
		// Effacer le contenu actuel de l'affichage
		Kit_boxStackLayout.Children.Clear();

		// Afficher à nouveau le contenu mis à jour
		//DisplayBasketContent();

		Navigation.PopAsync();
	}

	private async void BuyButton_Clicked(object sender, EventArgs e)
{
    // Charger le contenu actuel du fichier JSON
    string jsonContent = await File.ReadAllTextAsync("basket_content.json");

    // Désérialiser le contenu JSON en objet BasketContent
    BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

    // Vérifier si la désérialisation a réussi
    if (basketContent != null && basketContent.Kit_boxs != null)
    {
        // Pour chaque kit_box dans le panier
        foreach (var kit_box in basketContent.Kit_boxs)
        {
            // Vérifier si cette kit_box contient des lockers
            if (kit_box.Lockers != null)
            {
                // Extraire le depth et le width de cette kit_box à partir du premier locker
                int depth = kit_box.Lockers[0].Depth;
                int width = kit_box.Lockers[0].Width;

                // Obtenir ou créer un nouvel ID de commande (idNewOrder) pour cette kit_box
                int idNewOrder = databaseManager.GetNextOrderId();

                // Créer un nouveau NewOrder pour cette kit_box avec le depth et le width récupérés
                NewOrder currentOrder = new NewOrder(depth, width);

                // Initialiser le numéro du locker à 1
                int lockerNumber = 1;

                // Pour chaque locker dans l'kit_box
                foreach (var locker in kit_box.Lockers)
                {
                    // Extraire les codes des composants du casier
                    string verticalBatten = locker.VerticalBatten;
                    string sideCrossbar = locker.SideCrossbar;
                    string frontCrossbar = locker.FrontCrossbar;
                    string backCrossbar = locker.BackCrossbar;
                    string horizontalPanel = locker.HorizontalPanel;
                    string sidePanel = locker.SidePanel;
                    string backPanel = locker.BackPanel;
                    string door = locker.Door;

                    // Utiliser la méthode SaveLockerComponents de DatabaseManager pour enregistrer les données dans la base de données
                    if (lockerNumber == 1){
                        databaseManager.SaveLockerComponents(idNewOrder, lockerNumber, verticalBatten, frontCrossbar, backCrossbar, sideCrossbar, horizontalPanel, sidePanel, backPanel, door);
                    }
                    else{
                        databaseManager.UpdateLockerComponents(idNewOrder, lockerNumber, verticalBatten, frontCrossbar, backCrossbar, sideCrossbar, horizontalPanel, sidePanel, backPanel, door);
                    }

                    // Incrémenter le numéro de locker pour le prochain locker
                    lockerNumber++;
                }

                // Ajouter l'idneworder à TotalOrder avec le même idClient
                databaseManager.AddIdNewOrderToTotalOrder(idClient, idNewOrder, kit_box.Kit_boxNumber);

				//Ici le récap affiche uniquement le numéro de commande
				int amountlocker = currentOrder.GetNumberOfLockers();
				string recap = $"Order Number: {idClient}";
				Console.WriteLine(recap);
				DisplayAlert("Recap",recap,"OK");
				
				int ContactForm = databaseManager.TestContact(idNewOrder, amountlocker);
				if(ContactForm == 0)
				{
					await Navigation.PushAsync(new ContactPage(idClient));
					await DisplayAlert("Out of stock :","Please complete the contact form","OK");
				}
				Console.WriteLine(ContactForm);
				
				// Attendre une courte période avant de réactiver le gestionnaire d'événements
				await Task.Delay(1000);

				string filePath = "basket_content.json";

				// Vérifier si le fichier existe
				if (File.Exists(filePath))
				{
					// Supprimer le fichier
					File.Delete(filePath);
				}

				// Afficher un message d'alerte et renvoyer l'utilisateur à la page d'accueil
				await DisplayAlert("See you soon", "Thank you for your purchase!", "OK");
				await Navigation.PopToRootAsync(); // Renvoyer à la page d'accueil
            }
        }
    }
		// //Ici le récap affiche uniquement le numéro de commande
		// int amountlocker = currentOrder.GetNumberOfLockers();
		// string recap = $"Order Number: {idClient}";
		// Console.WriteLine(recap);
		// DisplayAlert("Recap",recap,"OK");

		// int ContactForm = databaseManager.TestContact(idNewOrder, amountlocker);
		// if(ContactForm == 0)
		// {
		// 	await Navigation.PushAsync(new ContactPage(idClient));
		// 	await DisplayAlert("Out of stock :","Please complete the contact form","OK");
		// }
		// Console.WriteLine(ContactForm);
		
		// // Attendre une courte période avant de réactiver le gestionnaire d'événements
		// await Task.Delay(1000);

		// string filePath = "basket_content.json";

		// // Vérifier si le fichier existe
		// if (File.Exists(filePath))
		// {
		// 	// Supprimer le fichier
		// 	File.Delete(filePath);
		// }

		// // Afficher un message d'alerte et renvoyer l'utilisateur à la page d'accueil
		// await DisplayAlert("See you soon", "Thank you for your purchase!", "OK");
		// await Navigation.PopToRootAsync(); // Renvoyer à la page d'accueil
}

private void CalculateTotalPrice()
{
    string filePath = "basket_content.json";
    double totalPrice = 0.0; // Variable pour stocker le prix total de la commande

    if (File.Exists(filePath))
    {
        string jsonContent = File.ReadAllText(filePath);
        BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

        // Parcourir chaque kit_box dans le contenu du panier
        foreach (var kit_box in basketContent.Kit_boxs)
        {
            // Vérifier si cette kit_box contient des lockers
            if (kit_box.Lockers != null)
            {
                // Pour chaque locker dans l'kit_box
                foreach (var locker in kit_box.Lockers)
                {
                    // Liste des codes à considérer pour l'application des fonctions
                    List<string> relevantCodes = new List<string>
                    {
                        locker.VerticalBatten,
                        locker.SideCrossbar,
                        locker.FrontCrossbar,
                        locker.BackCrossbar,
                        locker.HorizontalPanel,
                        locker.SidePanel,
                        locker.BackPanel,
                        locker.Door
                    };

                    // Parcourir les codes pertinents et appliquer les fonctions si le code n'est pas vide
                    foreach (var code in relevantCodes)
                    {
                        if (!string.IsNullOrEmpty(code))
                        {
                            // Obtenir la quantité de lockers pour ce type d'élément
                            int lockerQuantity = databaseManager.GetComponentQuantity(code); // À remplacer par votre propre fonction GetLockerQuantity

                            // Obtenir le prix moyen pour ce type d'élément
                            double averagePrice = databaseManager.GetAveragePrice(code); // À remplacer par votre propre fonction GetAveragePrice

                            // Calculer le prix total en multipliant la quantité de lockers par le prix moyen
                            totalPrice += lockerQuantity * averagePrice;
                        }
                    }
                }
            }
        }
    }

    // Utilisez la variable totalPrice selon vos besoins, par exemple, affichez-la dans une étiquette
	totalPrice = Math.Round(totalPrice * 1.2, 2);
	//totalPrice = totalPrice * 1.2;
    TotalPriceLabel.Text = $"Price: {totalPrice} €"; // Remplacez TotalPriceLabel par le nom de votre étiquette d'affichage
	Console.WriteLine($"Total Price: {totalPrice}");
}
}