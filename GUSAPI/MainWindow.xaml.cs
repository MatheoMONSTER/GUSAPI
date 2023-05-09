using System.Windows;

namespace GUSAPI
{
    public partial class MainWindow : Window
    {
        private ObszaryTematyczneViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ObszaryTematyczneViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OdswiezCommand.Execute(null);
        }
    }
}
