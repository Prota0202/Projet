namespace kitbox;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public partial class researchorder : ContentPage
{
	private DatabaseManager databaseManager;
    private Element searchResult;
	public researchorder()
	{
		InitializeComponent();
		databaseManager = new DatabaseManager();
	}
	private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            searchResult = await Task.Run(() => databaseManager.SearchElementCode(searchTerm));
            List<Element> searchResultsList = new List<Element>(); // Convertir le résultat unique en liste pour la ListView
            if (searchResult != null)
            {
                searchResultsList.Add(searchResult);
            }
            resultsListView.ItemsSource = searchResultsList;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Element selectedElement = (Element)e.SelectedItem;
                // Faites quelque chose avec l'élément sélectionné, par exemple afficher les détails dans une autre page
                DisplayAlert("Détails de l'élément", $"Nom: {selectedElement.Name}\nCode: {selectedElement.Code}\nPrix: {selectedElement.Quantityordered}\nQuantité: {selectedElement.Quantity}", "OK");
                resultsListView.SelectedItem = null; // Déselectionne l'élément après affichage des détails
            }
        }

        private void OnButtonPlusClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Element element = searchResult;
			Console.WriteLine(element.Name);
			Console.WriteLine(element.Code);
            if (element != null)
            {
				Console.WriteLine("it works");
                int quantityToAdd = Convert.ToInt32(((Entry)button.Parent.FindByName("QuantityToChangeEntry")).Text);
				Console.WriteLine(quantityToAdd);
				element.OrderToSupplier(quantityToAdd);
                databaseManager.SaveToHistoricOrder(element,quantityToAdd);
				databaseManager.OpenConnection();
                databaseManager.UpdateElement(element);
                databaseManager.CloseConnection();
                element.OrderToSupplier(quantityToAdd);
                string added = "you just added "+quantityToAdd+" "+element.Name+" ("+element.Code+")";
                DisplayAlert("Succesfully ordered !",added,"ok");
                RefreshListView();
            }
            else
            {
                Console.WriteLine("Invalid quantity entered.");
            }
        }

        private void OnSeePrevioursOrderClicked(object sender, EventArgs e){
            Navigation.PushAsync(new HistoryOrderPage());
        }

        private void RefreshListView(){
            string searchTerm = searchBar.Text;
            searchResult =  databaseManager.SearchElementCode(searchTerm);
            List<Element> searchResultsList = new List<Element>();
            if (searchResult != null)
            {
                searchResultsList.Add(searchResult);
            }
            resultsListView.ItemsSource = searchResultsList;
}
}