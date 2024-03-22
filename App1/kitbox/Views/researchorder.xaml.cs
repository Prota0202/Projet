namespace kitbox;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public partial class researchorder : ContentPage
{
	private DatabaseManager databaseManager;
	public researchorder()
	{
		InitializeComponent();
		databaseManager = new DatabaseManager();
	}
	private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            Element searchResult = await Task.Run(() => databaseManager.SearchElementCode(searchTerm));
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

}