using AnPInventoryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public required MaterialSheet MaterialSheet { get; set; }

    public AddMaterialSheetWindow()
    {
        InitializeComponent();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (float.TryParse(ThicknessInput.Text, out var thickness))
        {
            MessageBox.Show("Thickness is not a valid float.");
            return;
        }

        var materialSheet = new MaterialSheet
        {
            Material = MaterialInput.Text,
            Location = LocationInput.Text,
            Thickness = thickness
        };

        base.OnClosing(e);
    }
}
