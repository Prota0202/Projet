using Microsoft.Maui.Controls;

namespace Customer_app.Views;

public partial class OrderingPage : ContentPage
{
	public OrderingPage()
	{
		InitializeComponent();
	}

	private void basketclicked(object sender, EventArgs e)
	{

		Navigation.PushAsync(new BasketPage());
	}
}