using AnPInventoryApp.Models;
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
/// Interaction logic for MaterialSheetView.xaml
/// </summary>
public partial class MaterialSheetView : UserControl
{
    public MaterialSheetView()
    {
        InitializeComponent();
    }

    public MaterialSheetView(MaterialSheet materialSheet)
        => DataContext = new MaterialSheetViewModel { MaterialSheet = materialSheet };

    public MaterialSheetView(MaterialSheetViewModel viewModel)
    {
        DataContext = viewModel;
    }
}
