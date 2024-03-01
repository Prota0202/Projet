namespace Customer_app.Views;

public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
	}

	private void basketclicked(object sender, EventArgs e)
	{

		Navigation.PushAsync(new BasketPage());
	}
}