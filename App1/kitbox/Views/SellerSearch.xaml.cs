using System;
using Microsoft.Maui.Controls;

namespace kitbox
{
    public partial class SellerSearch : ContentPage
    {
        DatabaseManager databaseManager = new DatabaseManager();

        public SellerSearch()
        {
            InitializeComponent();
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            if (int.TryParse(orderEntry.Text, out int orderId))
            {
                var orderIds = databaseManager.GetNumberOfAllOrderId();
                if (orderIds.Contains(orderId))
                {
                    await Navigation.PushAsync(new seller(orderId));
                }
                else
                {
                    await DisplayAlert("Order Not Found", "The order ID entered was not found.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Invalid Input", "Please enter a valid number for the order ID.", "OK");
            }
        }
    }
}
