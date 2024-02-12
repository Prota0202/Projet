namespace kitbox;
using System.Collections.ObjectModel;
public partial class secretary : ContentPage
{
	public ObservableCollection<Part> partsList {get; set;} = new ObservableCollection<Part>();
	public secretary()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void OnAddTheNewProductClicked(object sender, EventArgs e) {
		string product2add = NewProductEntry.Text;
		if(int.TryParse(PriceProductAddedEntry.Text, out int priceofproduct)){
			Part thenewpart = new Part(product2add, priceofproduct);
			partsList.Add(thenewpart);
			DisplayAlert("Succes","you created a new part","ok");
		}
	}
}