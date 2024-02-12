namespace kitbox;

public class Supplier
{
    public string suppliername;

    public Supplier(string suppliername){
        this.suppliername = suppliername;
    }

    public string DisplayName => $"{suppliername}";
}
