using AnPInventoryApp.Models;
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
using System.Windows.Shapes;

namespace AnPInventoryApp.Views;

/// <summary>
/// Interaction logic for AddMaterialSheetWindow.xaml
/// </summary>
public partial class AddMaterialSheetWindow : Window
{
    internal MaterialSheet? MaterialSheet { get; set; } = null;

    public AddMaterialSheetWindow()
    {
        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        MaterialSheet = new MaterialSheet
        {
            Material = MaterialInput.Text,
            Location = LocationInput.Text,
            Thickness = ThicknessInput.Text
        };
    }
}
