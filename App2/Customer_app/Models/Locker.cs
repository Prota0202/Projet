namespace Customer_app;
public class Locker
{
    public int Height { get; set; }
    public string PanelColor { get; set; }
    public string DoorType { get; set; }
    public string AngleIronColor { get; set; }

    public Locker(int height, string panelColor, string doorType, string angleIronColor)
    {
        Height = height;
        PanelColor = panelColor;
        DoorType = doorType;
        AngleIronColor = angleIronColor;
    }
}