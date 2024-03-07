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
        
        // Ajoutez une liste de composants pour représenter les composants de la commande
        public List<Element> Components { get; set; } // Liste des composants de la commande
        
      

        
        public Order(int id, int depth, int width, int height, string panelColor, string door, string angleIronColor)
        {
            Id = id;
            Depth = depth;
            Width = width;
            Height = height;
            PanelColor = panelColor;
            Door = door;
            AngleIronColor = angleIronColor;
            
            // Initialisez la liste des composants
            Components = new List<Element>(); // Initialiser la liste des composants
            
        }
    }
}