namespace kitbox;

public class Supplier
{
    public string suppliername ;
    public string adress;
    public string mail;
    public int phonenumber;

    public Supplier(string suppliername, string adress, string mail, int phonenumber ){
        this.suppliername = suppliername;
        this.adress = adress;
        this.mail = mail;
        this.phonenumber = phonenumber;
    }

    public string DisplayName => $"{suppliername}";
    public string DisplaySupplier => $"{suppliername} - {adress} - {mail} - 0{phonenumber}";
}