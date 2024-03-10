namespace Customer_app;
public class NewOrder
{
    public int Depth { get; set; }
    public int Width { get; set; }
    public List<Locker> Lockers { get; set; }
    public string DisplayText { get; private set; } = "";

    public NewOrder(int depth, int width)
    {
        Depth = depth;
        Width = width;
        Lockers = new List<Locker>();
    }

    public void AddLocker(int height, string panelColor, string doorType, string angleIronColor)
    {
        Lockers.Add(new Locker(height, panelColor, doorType, angleIronColor));
        UpdateDisplayText();
    }

    public int GetNumberOfLockers()
        {
            return Lockers.Count;
        }
    private void UpdateDisplayText()
        {
            DisplayText = $"Depth: {Depth}, Width: {Width}\n";
            int lockerNumber = 1;

    foreach (var locker in Lockers)
    {
        DisplayText += $"Locker {lockerNumber} : Height: {locker.Height}, Panel Color: {locker.PanelColor}, Door Type: {locker.DoorType}, Angle Iron Color: {locker.AngleIronColor}\n";
        lockerNumber++;
    }
        }
    public string DisplayName => $"{Depth} and {Width}";
}