using GUSAPI.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace GUSAPI.ViewModel
{
    public class SortowanieViewModel
    {
        private readonly ObservableCollection<ObszarTematyczny> _obszaryTematyczne;
        private readonly ICollectionView _widokObszarowTematycznych;

        public SortowanieViewModel(ObservableCollection<ObszarTematyczny> obszaryTematyczne)
        {
            _obszaryTematyczne = obszaryTematyczne;
            _widokObszarowTematycznych = CollectionViewSource.GetDefaultView(_obszaryTematyczne);
            _widokObszarowTematycznych.SortDescriptions.Add(new SortDescription(nameof(ObszarTematyczny.Id), ListSortDirection.Ascending));
        }

        public ICollectionView WidokObszarowTematycznych => _widokObszarowTematycznych;
    }

}
