using System.Collections.ObjectModel;
using Customer_app.Models;
using System.Text;
using MySql.Data.MySqlClient;
using System.Net.Cache;
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


	public BasketPage(NewOrder currentorder, int idclient, int armoirenumber)
	{
		databaseManager = new DatabaseManager();
		currentOrder = currentorder;
		idClient = idclient;
		armoireNumber= armoirenumber;
        InitializeComponent();

		// Dans le constructeur BasketPage
		// string previousArmoireDetails = databaseManager.LoadPreviousArmoireDetails(idClient);
		// YourKitboxLabel.Text += previousArmoireDetails;

		// // Après avoir sauvegardé la commande dans SaveButton_Clicked
		// string recap = databaseManager.Loadkitb(armoireNumber, idClient);
		// Console.WriteLine(recap);

		// // Splitter le recap en lignes
		// string[] lines = recap.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

		// // Créer un StringBuilder pour le nouveau texte
		// StringBuilder labelText = new StringBuilder();
		// labelText.AppendLine($"Kitbox number #{armoireNumber}");

		// // Ajouter chaque ligne du recap au texte
		// foreach (string line in lines)
		// {
		// 	labelText.AppendLine(line);
		// }

		// // Définir le texte final dans YourKitboxLabel
		// YourKitboxLabel.Text = labelText.ToString();

		// Après avoir sauvegardé la commande dans SaveButton_Clicked
        string recap = databaseManager.Loadkitb(armoirenumber, idclient);
        Console.WriteLine(recap);

        // Splitter le recap en lignes
        string[] lines = recap.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        // Créer un StringBuilder pour le nouveau texte
        StringBuilder labelText = new StringBuilder();
        labelText.AppendLine($"Kitbox number #{armoirenumber}");

		

        // // Ajouter chaque ligne du recap au texte
        // foreach (string line in lines)
        // {
        //     labelText.AppendLine(line);
        // }

        // // Créer un label pour afficher les détails de l'armoire
        // var armoireLabel = new Label
        // {
        //     Text = labelText.ToString(),
        //     FontSize = 18,
        //     // TextDecorations = TextDecorations.Underline
        // };

		// // Ajouter le label à la liste des labels d'armoire
    	// armoireLabels.Add(armoireLabel);

		// // Ajouter chaque label d'armoire à ArmoireStackLayout.Children
		// foreach (var label in armoireLabels)
		// {
		// 	ArmoireStackLayout.Children.Add(label);
		// 	armoireCount++;
		// }

		// Charger les détails des armoires précédentes
		string previousArmoireDetails = databaseManager.LoadPreviousArmoireDetails(idClient,armoireNumber);

		// Créer un tableau de lignes en divisant la chaîne précédemment chargée
		string[] previousArmoireLines = previousArmoireDetails.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

		// Parcourir chaque ligne pour traiter les détails des armoires précédentes
		foreach (string line in previousArmoireLines)
		{
			// Créer un label pour chaque ligne de détails d'armoire
			var armoireLabel = new Label
			{
				Text = line,
				FontSize = 18
			};

			// Ajouter le label à ArmoireStackLayout.Children
			ArmoireStackLayout.Children.Add(armoireLabel);
		}





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