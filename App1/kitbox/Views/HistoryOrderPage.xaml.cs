namespace kitbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

public partial class HistoryOrderPage : ContentPage
{
	DatabaseManager databaseManager = new DatabaseManager();
    public HistoryOrderPageViewModel ViewModel { get; set; }
	public HistoryOrderPage()
	{
		InitializeComponent();
        ViewModel = new HistoryOrderPageViewModel();
        BindingContext = ViewModel;
		DisplayHistoricOrders();
	}

	private void DisplayHistoricOrders(){
		var (codes, amounts) = databaseManager.GetHistoricOrderDetails();
		List<Element> elements = new List<Element>();
            foreach (var code in codes)
            {
                Element element = databaseManager.SearchElementCode(code);
                if (element != null)
                {
                    elements.Add(element);
                }
            }
             ViewModel.Elements = elements;
             ViewModel.Amounts = new Dictionary<string, int>();
                foreach (var amount in amounts)
                {
                    ViewModel.Amounts.Add("{i}", amount);
                }
			foreach (var element in elements)
            {
                string displayString = element.DisplayAll;
                Console.WriteLine(displayString);
            }
            foreach (var code in amounts)
            {
                Console.WriteLine(code);
            }
	}
    private void OnElementSelected(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter != null)
            {
                var selectedElement = button.CommandParameter as Element;
                if (selectedElement != null)
                {
                    // Utilisez selectedElement et le montant associé à cet élément
                    // Vous pouvez accéder au montant à partir de ViewModel.Amounts
                    int amount = ViewModel.Amounts[selectedElement.Code];
                    Console.WriteLine($"Selected Element: {selectedElement.Name}, Amount: {ViewModel.Amounts[selectedElement.Code]}");
                }
            }
        }
public class HistoryOrderPageViewModel : INotifyPropertyChanged
    {
        private List<Element> _elements;
        public List<Element> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                OnPropertyChanged(nameof(Elements));
            }
        }

        private Dictionary<string, int> _amounts;
        public Dictionary<string, int> Amounts
        {
            get { return _amounts; }
            set
            {
                _amounts = value;
                OnPropertyChanged(nameof(Amounts));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}

 public class AmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int amount)
            {
                return $"{amount} ordered";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }