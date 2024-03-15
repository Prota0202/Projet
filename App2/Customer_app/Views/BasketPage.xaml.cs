using System.Collections.ObjectModel;
using Customer_app.Models;
using System.Text;
using MySql.Data.MySqlClient;
using System.Net.Cache;
namespace Customer_app.Views;

public partial class BasketPage : ContentPage
{
	private NewOrder currentOrder;
	private readonly DatabaseManager databaseManager;
	public ObservableCollection<Customer_app.Models.Element> elementsList { get; set; } =
            new ObservableCollection<Customer_app.Models.Element>();
	private int lockerCount = 0;
	private int depth = 0;
	private int width = 0;

	public BasketPage()
	{
		databaseManager = new DatabaseManager();
		currentOrder = new NewOrder(depth, width);
        InitializeComponent();
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
		int idneworder = databaseManager.GetNextOrderId();

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
				databaseManager.SaveLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
		}
		else{
				databaseManager.UpdateLockerComponents(idneworder,lockerNumber, verticalbatten, frontcrossbar, backcrossbar, sidecrossbar, horizontalpanel, sidepanel, backpanel, door);
		}
		lockerNumber++;
		}

		//Ici il faudra changer le recap pour juste qu'il affiche n° de commande + prix total
		int amountlocker = currentOrder.GetNumberOfLockers();
		string recap = databaseManager.LoadOrder(idneworder, amountlocker);
		Console.WriteLine(recap);
		DisplayAlert("Recap",recap,"OK");

		int ContactForm = databaseManager.TestContact(idneworder, amountlocker);
		if(ContactForm == 0)
		{
			await Navigation.PushAsync(new ContactPage());
			DisplayAlert("Out of stock :","Please complete the contact form","OK");
		}
		Console.WriteLine(ContactForm);

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
		//string action = await DisplayActionSheet("Out of stock : Please complete the contact form", "Cancel", null, "Contact Form");
		//Console.WriteLine(action);
		
		
		// Attendre une courte période avant de réactiver le gestionnaire d'événements
		await Task.Delay(1000);

		// Réactiver le gestionnaire d'événements après une courte période
		//BuyButton.Clicked += BuyButton_Clicked;
	}

}