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

	public BasketPage(NewOrder currentorder)
	{
		databaseManager = new DatabaseManager();
		currentOrder = currentorder;
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

		//Ici le récap affiche uniquement le numéro de commande
		int amountlocker = currentOrder.GetNumberOfLockers();
		string recap = $"Order Number: {idneworder}";
		Console.WriteLine(recap);
		DisplayAlert("Recap",recap,"OK");


		int ContactForm = databaseManager.TestContact(idneworder, amountlocker);
		if(ContactForm == 0)
		{
			await Navigation.PushAsync(new ContactPage());
			await DisplayAlert("Out of stock :","Please complete the contact form","OK");
		}
		Console.WriteLine(ContactForm);
		
		// Attendre une courte période avant de réactiver le gestionnaire d'événements
		await Task.Delay(1000);

		// Réactiver le gestionnaire d'événements après une courte période
		//BuyButton.Clicked += BuyButton_Clicked;
	}

}