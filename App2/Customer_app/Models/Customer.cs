namespace Customer_app.Models;

public class Customer
{
	public string CustomerName;
	public string FirstCustomerName;
	public string CustomerEmail;
	public int CustomerPhone;

	public Customer(string CustomerName,string FirstcustomerName, string CustomerEmail, int CustomerPhone)
	{
		this.CustomerName = CustomerName;
		this.CustomerEmail = CustomerEmail;
		this.CustomerPhone = CustomerPhone;
		this.FirstCustomerName = FirstcustomerName;
	}

	public string DisplayCustomer => $"{CustomerName} - {CustomerEmail} - {CustomerPhone}";
}
