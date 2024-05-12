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

			public int Height { get; set; }
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
                    Label armoireLabel = new Label
                    {
                        Text = $"Armoire {armoire.ArmoireNumber}",
                        FontSize = 20,
						BackgroundColor = Color.FromRgb(53, 52, 55), 
						TextColor = Color.FromRgb(144, 102, 242),
                        HorizontalOptions = LayoutOptions.Center,
						WidthRequest = Application.Current.MainPage.Width, // Définit la largeur sur celle de la fenêtre
                    };

                    ArmoireStackLayout.Children.Add(armoireLabel);

                    foreach (var locker in armoire.Lockers)
                    {
                        StackLayout lockerLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(10),
                            //BackgroundColor = Color.FromRgb(200, 0, 0),
                            Spacing = 5
                        };


                        // Ajouter chaque propriété du locker à une label
						AddLockerProperty(lockerLayout, "Height", locker.Height.ToString());
                        AddLockerProperty(lockerLayout, "PanelColor", locker.PanelColor);
                        AddLockerProperty(lockerLayout, "DoorType", locker.DoorType);
                        AddLockerProperty(lockerLayout, "AngleIronColor", locker.AngleIronColor);
                        AddLockerProperty(lockerLayout, "Vertical Batten", locker.VerticalBatten);
                        AddLockerProperty(lockerLayout, "Front Crossbar", locker.FrontCrossbar);
                        AddLockerProperty(lockerLayout, "Back Crossbar", locker.BackCrossbar);
                        AddLockerProperty(lockerLayout, "Side Crossbar", locker.SideCrossbar);
                        AddLockerProperty(lockerLayout, "Horizontal Panel", locker.HorizontalPanel);
                        AddLockerProperty(lockerLayout, "Side Panel", locker.SidePanel);
                        AddLockerProperty(lockerLayout, "Back Panel", locker.BackPanel);
                        AddLockerProperty(lockerLayout, "Door", locker.Door);

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
                Text = $"{propertyName}: {propertyValue}",
                FontSize = 16,
                //TextColor = Color.Black
            };

            lockerLayout.Children.Add(propertyLabel);
        }



	private void OrderBackbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private async void BuyButton_Clicked(object sender, EventArgs e) //Vient de la fonction SaveButton_Clicked
	{
		// Désactiver le gestionnaire d'événements pour éviter les enregistrements multiples
		//BuyButton.Clicked -= BuyButton_Clicked;

		int depth = currentOrder.Depth;
		int width = currentOrder.Width;
		int idneworder = databaseManager.GetNextOrderId()+1;
		Console.WriteLine("next order id : ");

		int lockerNumber = 1; //Ici ca le fait pour chaque locker mais faudra surement changer pour que ça le fasse pour chaque kitbox
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
				Console.WriteLine("avant");
				//databaseManager.SaveLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
				Console.WriteLine("après");
		}
		else{
				databaseManager.UpdateLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
		}
		lockerNumber++;
		}

		//Ici le récap affiche uniquement le numéro de commande
		int amountlocker = currentOrder.GetNumberOfLockers();
		string recap = $"Order Number: {idClient}";
		Console.WriteLine(recap);
		DisplayAlert("Recap",recap,"OK");


		int ContactForm = databaseManager.TestContact(idneworder, amountlocker);
		if(ContactForm == 0)
		{
			await Navigation.PushAsync(new ContactPage(idClient));
			await DisplayAlert("Out of stock :","Please complete the contact form","OK");
		}
		Console.WriteLine(ContactForm);
		
		// Attendre une courte période avant de réactiver le gestionnaire d'événements
		await Task.Delay(1000);

		// Réactiver le gestionnaire d'événements après une courte période
		//BuyButton.Clicked += BuyButton_Clicked;
	}
	

}