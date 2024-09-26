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
    private SheetCollectionViewModel _viewModel;

    public SheetCollectionView()
    {
        InitializeComponent();
        _viewModel = new SheetCollectionViewModel();
        DataContext = _viewModel;

        foreach (var sheet in _viewModel.MaterialSheets)
        {
            ListView.Items.Add(sheet);
        }
    }

    public SheetCollectionView(SheetCollectionViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }
}
