using Customer_app.Views;
using MauiApp1;

namespace Customer_app;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void Orderbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OrderPage()); 
	}

}

