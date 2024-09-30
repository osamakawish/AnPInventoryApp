using AnPInventoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnPInventoryApp.Views;

/// <summary>
/// Interaction logic for SheetCollectionView.xaml
/// </summary>
public partial class SheetCollectionView : UserControl
{
    public SheetCollectionViewModel ViewModel
    {
        get => (SheetCollectionViewModel)DataContext;
        init => DataContext = value;
    }

    public SheetCollectionView()
    {
        InitializeComponent();
        ViewModel = new SheetCollectionViewModel();

        foreach (var sheet in ViewModel.MaterialSheets)
        {
            ListView.Items.Add(sheet);
        }
    }

    public SheetCollectionView(SheetCollectionViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = ViewModel;
    }
}
