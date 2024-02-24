namespace Customer_app.Views;

public partial class BasketPage : ContentPage
{
	public BasketPage()
	{
		InitializeComponent();
	}

	private void OrderBackbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}