namespace Customer_app.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string? PanelColor { get; set; } // nullable
        public string? Door { get; set; } // nullable
        public string? AngleIronColor { get; set; } // nullable
      

        
        public Order(int id, int depth, int width, int height, string panelColor, string door, string angleIronColor)
        {
            Id = id;
            Depth = depth;
            Width = width;
            Height = height;
            PanelColor = panelColor;
            Door = door;
            AngleIronColor = angleIronColor;
            
        }
    }
}