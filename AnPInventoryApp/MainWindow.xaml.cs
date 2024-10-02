using AnPInventoryApp.ViewModels;
using AnPInventoryApp.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnPInventoryApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainViewModel MainViewModel { get; }

    public MainWindow()
    {
        InitializeComponent();

        MainViewModel = new MainViewModel() {
            SheetCollectionViewModel = SheetCollectionView.ViewModel
        };

        MainViewModel.AddMaterialSheetCommand = new RelayCommand(() =>
        {
            var materialSheet = MaterialSheetViewModel.AddMaterialSheetDialog();
            if (materialSheet is null) return;

            MainViewModel.SheetCollectionViewModel.AddSheet(materialSheet);
        });

        DataContext = MainViewModel;
    }
}