namespace Customer_app.Views;
public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
	}

	private void OrderBackbuttonclicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}
