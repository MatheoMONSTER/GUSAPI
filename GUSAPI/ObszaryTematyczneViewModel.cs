using GalaSoft.MvvmLight.Command;
using GUSAPI.Model;
using GUSAPI.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace GUSAPI
{
    public class ObszaryTematyczneViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ObszarTematyczny> _obszaryTematyczne;
        private SortowanieViewModel _sortowanie;

        public ObszaryTematyczneViewModel()
        {
            _obszaryTematyczne = new ObservableCollection<ObszarTematyczny>();
            OdswiezCommand = new RelayCommand(Odswiez);
            EdytujCommand = new RelayCommand(Edytuj, CanEdytuj);
            PobierzObszaryTematyczne();
        }

        public ObservableCollection<ObszarTematyczny> ObszaryTematyczne
        {
            get { return _obszaryTematyczne; }
            set
            {
                _obszaryTematyczne = value;
                OnPropertyChanged("ObszaryTematyczne");
            }
        }

        public ICommand OdswiezCommand { get; set; }
        public ICommand EdytujCommand { get; set; }

        public SortowanieViewModel Sortowanie
        {
            get { return _sortowanie; }
            set
            {
                _sortowanie = value;
                OnPropertyChanged("Sortowanie");
            }
        }

        private async void PobierzObszaryTematyczne()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonSerializerSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var obszaryTematyczne = JsonConvert.DeserializeObject<List<ObszarTematyczny>>(content, jsonSerializerSettings);
                    ObszaryTematyczne = new ObservableCollection<ObszarTematyczny>(obszaryTematyczne);
                    Sortowanie = new SortowanieViewModel(ObszaryTematyczne);
                }
                else
                {
                    MessageBox.Show($"Wystąpił błąd podczas pobierania danych. Kod błędu: {response.StatusCode}");
                }
            }
        }

        private void Odswiez()
        {
            PobierzObszaryTematyczne();
        }

        private void Edytuj()
        {
            // kod do edytowania wybranego obszaru tematycznego
        }

        private bool CanEdytuj()
        {
            // kod sprawdzający, czy wybrany obszar tematyczny może być edytowany
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
