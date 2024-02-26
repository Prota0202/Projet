namespace Customer_app.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string PanelColor { get; set; }
        public string Door { get; set; }
        public string AngleIronColor { get; set; }
        public string Comment { get; set; }
        
    }
}