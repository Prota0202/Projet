using Customer_app.Database;
using Customer_app.Models;
using MySql.Data.MySqlClient;
using Microsoft.Maui.Controls;

namespace Customer_app.Views
{
    public partial class OrderingPage : ContentPage
    {
        public OrderingPage()
        {
            InitializeComponent();
        }

        private void basketclicked(object sender, EventArgs e)
        {
            Order newOrder = new Order
            {
                Depth = Convert.ToInt32(DepthPicker.SelectedItem),
                Width = Convert.ToInt32(WidthPicker.SelectedItem),
                Height = Convert.ToInt32(HeightPicker.SelectedItem),
                PanelColor = PanelColorPicker.SelectedItem.ToString(),
                Door = DoorPicker.SelectedItem.ToString(),
                AngleIronColor = AngleIronColorPicker.SelectedItem.ToString(),
                Comment = CommentEntry.Text
            };

            using (MySqlConnection connection = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                string query = "INSERT INTO kitbox.order (depth, width, height, panel_color, door_type, angle_iron_color, comment) " +
                               "VALUES (@Depth, @Width, @Height, @PanelColor, @Door, @AngleIronColor, @Comment)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Depth", newOrder.Depth);
                command.Parameters.AddWithValue("@Width", newOrder.Width);
                command.Parameters.AddWithValue("@Height", newOrder.Height);
                command.Parameters.AddWithValue("@PanelColor", newOrder.PanelColor);
                command.Parameters.AddWithValue("@Door", newOrder.Door);
                command.Parameters.AddWithValue("@AngleIronColor", newOrder.AngleIronColor);
                command.Parameters.AddWithValue("@Comment", newOrder.Comment);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Navigation.PushAsync(new BasketPage());
        }
    }
}
