﻿namespace kitbox;

public class Part
{
	private string partname ;
	private int quantity;
	private int price ;

	public Part(string partname, int price) {
		this.partname = partname;
		this.price = price;
		this.quantity = 0;
	}

	public Part(string partname, int price, int quantity) {
		this.partname = partname;
		this.price = price;
		this.quantity = quantity;
	} // just in case, not useful for the moment

	public int Add(int amountadded){
		quantity += amountadded;
		return quantity;
	}

	public int Remove(int amountremoved){
		quantity -= amountremoved;
		return quantity;
	}

	public int NewPrice(int changedprice){
		price = changedprice;
		return price;
	}
	public string DisplayNameAndPrice => $"{partname} : {price}$";
}