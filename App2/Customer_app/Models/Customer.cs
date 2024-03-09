namespace Customer_app.Models;

public class Customer
{
	public string CustomerName;
	public string CustomerEmail;
	public int CustomerPhone;

	public Customer(string CustomerName, string CustomerEmail, int CustomerPhone)
	{
		this.CustomerName = CustomerName;
		this.CustomerEmail = CustomerEmail;
		this.CustomerPhone = CustomerPhone;
	}

	public string DisplayCustomer => $"{CustomerName} - {CustomerEmail} - {CustomerPhone}";
}
