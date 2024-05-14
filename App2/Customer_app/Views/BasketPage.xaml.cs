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
	public int armoireNumber;
	private int armoireCount = 0;
	private List<Label> armoireLabels = new List<Label>();


	// public BasketPage(NewOrder currentorder, int idclient, int armoirenumber)
	// {
	// 	databaseManager = new DatabaseManager();
	// 	currentOrder = currentorder;
	// 	idClient = idclient;
	// 	armoireNumber= armoirenumber;
    //     InitializeComponent();

	// 	// Dans le constructeur BasketPage
	// 	// string previousArmoireDetails = databaseManager.LoadPreviousArmoireDetails(idClient);
	// 	// YourKitboxLabel.Text += previousArmoireDetails;

	// 	// // Après avoir sauvegardé la commande dans SaveButton_Clicked
	// 	// string recap = databaseManager.Loadkitb(armoireNumber, idClient);
	// 	// Console.WriteLine(recap);

	// 	// // Splitter le recap en lignes
	// 	// string[] lines = recap.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

	// 	// // Créer un StringBuilder pour le nouveau texte
	// 	// StringBuilder labelText = new StringBuilder();
	// 	// labelText.AppendLine($"Kitbox number #{armoireNumber}");

	// 	// // Ajouter chaque ligne du recap au texte
	// 	// foreach (string line in lines)
	// 	// {
	// 	// 	labelText.AppendLine(line);
	// 	// }

	// 	// // Définir le texte final dans YourKitboxLabel
	// 	// YourKitboxLabel.Text = labelText.ToString();

	// 	// Après avoir sauvegardé la commande dans SaveButton_Clicked
    //     string recap = databaseManager.Loadkitb(armoirenumber, idclient);
    //     Console.WriteLine(recap);

    //     // Splitter le recap en lignes
    //     string[] lines = recap.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

    //     // Créer un StringBuilder pour le nouveau texte
    //     StringBuilder labelText = new StringBuilder();
    //     labelText.AppendLine($"Kitbox number #{armoirenumber}");

		

    //     // // Ajouter chaque ligne du recap au texte
    //     // foreach (string line in lines)
    //     // {
    //     //     labelText.AppendLine(line);
    //     // }

    //     // // Créer un label pour afficher les détails de l'armoire
    //     // var armoireLabel = new Label
    //     // {
    //     //     Text = labelText.ToString(),
    //     //     FontSize = 18,
    //     //     // TextDecorations = TextDecorations.Underline
    //     // };

	// 	// // Ajouter le label à la liste des labels d'armoire
    // 	// armoireLabels.Add(armoireLabel);

	// 	// // Ajouter chaque label d'armoire à ArmoireStackLayout.Children
	// 	// foreach (var label in armoireLabels)
	// 	// {
	// 	// 	ArmoireStackLayout.Children.Add(label);
	// 	// 	armoireCount++;
	// 	// }

	// 	// Charger les détails des armoires précédentes
	// 	string previousArmoireDetails = databaseManager.LoadPreviousArmoireDetails(idClient, armoireNumber);

	// 	// Créer un tableau de lignes en divisant la chaîne précédemment chargée
	// 	string[] previousArmoireLines = previousArmoireDetails.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

	// 	// Parcourir chaque ligne pour traiter les détails des armoires précédentes
	// 	foreach (string line in previousArmoireLines)
	// 	{
	// 		// Créer un label pour chaque ligne de détails d'armoire
	// 		var armoireLabel = new Label
	// 		{
	// 			Text = line,
	// 			FontSize = 18
	// 		};

	// 		// Ajouter le label à ArmoireStackLayout.Children
	// 		ArmoireStackLayout.Children.Add(armoireLabel);
	// 	}

	// 	// Ajouter une colonne pour chaque armoire
	// 	for (int i = 0; i < previousArmoireLines.Length; i++)
	// 	{
	// 		ArmoireGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
	// 	}

	// 	// Ajouter le contenu de chaque armoire dans la colonne correspondante
	// 	for (int i = 0; i < previousArmoireLines.Length; i++)
	// 	{
	// 		// Créer un label pour afficher le contenu de l'armoire
	// 		var armoireContentLabel = new Label
	// 		{
	// 			Text = previousArmoireLines[i], // Contenu de l'armoire
	// 			FontSize = 18
	// 		};

	// 		// Ajouter le label à la colonne correspondante dans la grille
	// 		Grid.SetColumn(armoireContentLabel, i);
	// 		ArmoireGrid.Children.Add(armoireContentLabel);
	// 	}
	// }

							public BasketPage(NewOrder currentorder, int idclient, int armoirenumber)
							{
								databaseManager = new DatabaseManager();
								currentOrder = currentorder;
								idClient = idclient;
								armoireNumber = armoirenumber;
								InitializeComponent();

								// Appel à la méthode DisplayBasketContent pour afficher le contenu du fichier JSON
    							DisplayBasketContent();

								CalculateTotalPrice();

								// Après avoir sauvegardé la commande dans SaveButton_Clicked
								List<List<string>> armoireDetailsList = databaseManager.Loadkitb(armoireNumber,idClient);

								// Ajouter une colonne pour chaque armoire dans la grille
								for (int i = 0; i < armoireDetailsList.Count; i++)
								{
									ArmoireGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
								}

								// Ajouter le contenu de chaque armoire dans la colonne correspondante
								for (int i = 0; i < armoireDetailsList.Count; i++)
								{
									// Créer un ScrollView pour cette colonne
									var scrollView = new ScrollView();
									Grid.SetColumn(scrollView, i); // Définir la colonne pour ce ScrollView
									ArmoireGrid.Children.Add(scrollView); // Ajouter le ScrollView à la grille

									// Créer un StackLayout pour contenir le contenu de l'armoire
									var stackLayout = new StackLayout();
									scrollView.Content = stackLayout; // Définir le StackLayout comme contenu du ScrollView

									// Enregistrer le contenu de l'armoire
									foreach (var armoireDetails in armoireDetailsList[i])
									{
										stackLayout.Children.Add(new Label { Text = armoireDetails, FontSize = 18 });
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

        public class ArmoireContent
        {
            public int ArmoireNumber { get; set; }
            public List<LockerContent> Lockers { get; set; }
        }

        public class BasketContent
        {
            public List<ArmoireContent> Armoires { get; set; }
        }
        private void DisplayBasketContent()
        {
            string filePath = "basket_content.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

                // Parcourir chaque armoire dans le contenu du panier
                foreach (var armoire in basketContent.Armoires)
                {
					int depth = armoire.Lockers.FirstOrDefault()?.Depth ?? 0;
					int width = armoire.Lockers.FirstOrDefault()?.Width ?? 0;

                    Label armoireLabel = new Label
                    {
                        Text = $"Kitbox n° {armoire.ArmoireNumber} [Depth : {depth} cm - Width : {width} cm]",
                        FontSize = 20,
						BackgroundColor = Color.FromRgb(53, 52, 55), 
						TextColor = Color.FromRgb(144, 102, 242),
                        HorizontalOptions = LayoutOptions.Center,
						WidthRequest = 2000 // Définit la largeur sur celle de la fenêtre
                    };

                    ArmoireStackLayout.Children.Add(armoireLabel);

					int lockerCounted = 1; // Initialisation du compteur de casier			
                    foreach (var locker in armoire.Lockers)
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

                        ArmoireStackLayout.Children.Add(lockerLayout);
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

                ArmoireStackLayout.Children.Add(noContentLabel);
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
		Navigation.PushAsync(new OrderPage(idClient, armoireNumber));
	}

	// private int GetLastArmoireNumber(BasketContent basketContent)
	// {
	// 	int lastArmoireNumber = 0;
	// 	foreach (var armoire in basketContent.Armoires)
	// 	{
	// 		if (armoire.ArmoireNumber > lastArmoireNumber)
	// 		{
	// 			lastArmoireNumber = armoire.ArmoireNumber;
	// 		}
	// 	}
	// 	return lastArmoireNumber;
	// }


	private async void Deleteakitbox(object sender, EventArgs e)
	{
		// Demander à l'utilisateur le numéro de l'armoire à supprimer
		string armoireNumberInput = await DisplayPromptAsync("Delete a kitbox", "Enter the kitbox number:");

		if (!string.IsNullOrEmpty(armoireNumberInput))
		{
			int armoireNumberToDelete;
			if (int.TryParse(armoireNumberInput, out armoireNumberToDelete))
			{
				// Lire le contenu du fichier JSON
				string filePath = "basket_content.json";
				string jsonContent = File.ReadAllText(filePath);
				BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

				// Parcourir la liste à l'envers pour pouvoir supprimer l'élément en toute sécurité
				for (int i = basketContent.Armoires.Count - 1; i >= 0; i--)
				{
					if (basketContent.Armoires[i].ArmoireNumber == armoireNumberToDelete)
					{
						// Supprimer l'armoire de la liste
						basketContent.Armoires.RemoveAt(i);
						
						//Décrémenter les numéros d'armoire pour les armoires suivantes
						foreach (var armoire in basketContent.Armoires.Where(a => a.ArmoireNumber > armoireNumberToDelete))
						{
							armoire.ArmoireNumber--;
						} //-> Finalemement non comment ca on ca rajoute et c tout on s'en fout de l'ordre on sait juste que c une autre armoire

						// Mettre à jour le contenu du fichier JSON après la suppression
						string updatedJsonContent = JsonSerializer.Serialize(basketContent);
						File.WriteAllText(filePath, updatedJsonContent);

						// Mettre à jour l'affichage après la suppression
						RefreshBasketDisplay();

						return; // Sortir de la méthode après la suppression
					}
				}

				// Si l'armoire n'est pas trouvée
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
		ArmoireStackLayout.Children.Clear();

		// Afficher à nouveau le contenu mis à jour
		//DisplayBasketContent();

		Navigation.PopAsync();
	}


	// private async void BuyButton_Clicked(object sender, EventArgs e) //Vient de la fonction SaveButton_Clicked
	// {
	// 	// Désactiver le gestionnaire d'événements pour éviter les enregistrements multiples
	// 	BuyButton.Clicked -= BuyButton_Clicked;

	// 	int depth = currentOrder.Depth;
	// 	int width = currentOrder.Width;
	// 	int idneworder = databaseManager.GetNextOrderId()+1;
	// 	Console.WriteLine("next order id : ");

	// 	int lockerNumber = 1; //Ici ca le fait pour chaque locker mais faudra surement changer pour que ça le fasse pour chaque kitbox
	// 	foreach (var locker in currentOrder.Lockers){
	// 	string verticalbatten = databaseManager.GetVerticalBattenCode(locker.Height);
	// 	string sidecrossbar = databaseManager.GetSideCrossbarCode(depth);
	// 	string frontcrossbar = databaseManager.GetFrontCrossbarCode(width);
	// 	string backcrossbar = databaseManager.GetBackCrossbarCode(width);
	// 	string horizontalpanel = databaseManager.GetHorizontalPanelCode(locker.PanelColor,width,depth);
	// 	string sidepanel = databaseManager.GetSidePanelCode(locker.PanelColor,locker.Height,depth);
	// 	string backpanel = databaseManager.GetBackPanelCode(locker.PanelColor, locker.Height, width);
	// 	string door = databaseManager.GetDoorCode(locker.PanelColor, locker.Height, width);
	// 	if(lockerNumber==1){
	// 			Console.WriteLine("avant");
	// 			//databaseManager.SaveLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
	// 			Console.WriteLine("après");
	// 	}
	// 	else{
	// 			databaseManager.UpdateLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
	// 	}
	// 	//databaseManager.AddIdNewOrderToTotalOrder(idClient, idneworder, armoireNumber);
	// 	lockerNumber++;
	// 	}

	// 	//Ici le récap affiche uniquement le numéro de commande
	// 	int amountlocker = currentOrder.GetNumberOfLockers();
	// 	string recap = $"Order Number: {idClient}";
	// 	Console.WriteLine(recap);
	// 	DisplayAlert("Recap",recap,"OK");


	// 	int ContactForm = databaseManager.TestContact(idneworder, amountlocker);
	// 	if(ContactForm == 0)
	// 	{
	// 		await Navigation.PushAsync(new ContactPage(idClient));
	// 		await DisplayAlert("Out of stock :","Please complete the contact form","OK");
	// 	}
	// 	Console.WriteLine(ContactForm);
		
	// 	// Attendre une courte période avant de réactiver le gestionnaire d'événements
	// 	await Task.Delay(1000);

	// 	string filePath = "basket_content.json";

	// 	// Vérifier si le fichier existe
	// 	if (File.Exists(filePath))
	// 	{
	// 		// Supprimer le fichier
	// 		File.Delete(filePath);
	// 	}

	// 	// Afficher un message d'alerte et renvoyer l'utilisateur à la page d'accueil
	// 	await DisplayAlert("See you soon", "Thank you for your purchase!", "BYE");
	// 	await Navigation.PopToRootAsync(); // Renvoyer à la page d'accueil


	// 	// Réactiver le gestionnaire d'événements après une courte période
	// 	BuyButton.Clicked += BuyButton_Clicked;
	// }

	//Il faut enregistrer dans NewOrder de la database les codes qu'il y a dans lockers
		//Ensuite une fois qu'une armoire à été enregistré il faut enregistré dans TotalOrder dans la db
		//LE numéro de l'armoire qui vient d'être créer (= le num du idNewOrder)
	private async void BuyButton_Clicked(object sender, EventArgs e)
{
    // Charger le contenu actuel du fichier JSON
    string jsonContent = await File.ReadAllTextAsync("basket_content.json");

    // Désérialiser le contenu JSON en objet BasketContent
    BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

    // Vérifier si la désérialisation a réussi
    if (basketContent != null && basketContent.Armoires != null)
    {
        // Pour chaque armoire dans le panier
        foreach (var armoire in basketContent.Armoires)
        {
            // Vérifier si cette armoire contient des lockers
            if (armoire.Lockers != null)
            {
                // Extraire le depth et le width de cette armoire à partir du premier locker
                int depth = armoire.Lockers[0].Depth;
                int width = armoire.Lockers[0].Width;

                // Obtenir ou créer un nouvel ID de commande (idNewOrder) pour cette armoire
                int idNewOrder = databaseManager.GetNextOrderId();

                // Créer un nouveau NewOrder pour cette armoire avec le depth et le width récupérés
                NewOrder currentOrder = new NewOrder(depth, width);

                // Initialiser le numéro du locker à 1
                int lockerNumber = 1;

                // Pour chaque locker dans l'armoire
                foreach (var locker in armoire.Lockers)
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
                databaseManager.AddIdNewOrderToTotalOrder(idClient, idNewOrder, armoire.ArmoireNumber);
            }
        }
    }

    // Supprimer le contenu du fichier JSON après l'avoir traité
    File.Delete("basket_content.json");
}

private void CalculateTotalPrice()
{
    string filePath = "basket_content.json";
    double totalPrice = 0.0; // Variable pour stocker le prix total de la commande

    if (File.Exists(filePath))
    {
        string jsonContent = File.ReadAllText(filePath);
        BasketContent basketContent = JsonSerializer.Deserialize<BasketContent>(jsonContent);

        // Parcourir chaque armoire dans le contenu du panier
        foreach (var armoire in basketContent.Armoires)
        {
            // Vérifier si cette armoire contient des lockers
            if (armoire.Lockers != null)
            {
                // Pour chaque locker dans l'armoire
                foreach (var locker in armoire.Lockers)
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
    //TotalPriceLabel.Text = $"Total Price: {totalPrice}"; // Remplacez TotalPriceLabel par le nom de votre étiquette d'affichage
	totalPrice = totalPrice*1.2;
	Console.WriteLine($"Total Price: {totalPrice}");
}

//A chaque fois qu'on appel la fonction CalculateTotalPrice il faut faire un truc du style assync
//Pouvoir aller sur la page meme si la fonction a pas fini

//Faut afficher le price sur la page

//Faut arrondire le prix

}