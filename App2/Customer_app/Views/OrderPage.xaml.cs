namespace Customer_app.Views;


public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
	}
	
	
	
	private int lockerCount = 1; 

	private void AddLockerButton_Clicked(object sender, EventArgs e)
	{
		
		var newLockerLabel = new Label
		{
			Text = "Locker " + lockerCount, 
			HorizontalOptions = LayoutOptions.Center
		};

		
		lockerCount++;
		MainStackLayout.Children.Add(newLockerLabel);
	}


	private void basketclicked(object sender, EventArgs e)
	{

		Navigation.PushAsync(new BasketPage());
	}
}