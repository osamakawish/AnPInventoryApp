using AnPInventoryApp.Models;
using AnPInventoryApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnPInventoryApp.ViewModels;

public class MaterialSheetViewModel : INotifyPropertyChanged
{
    public static MaterialSheet? AddMaterialSheetDialog()
    {
        var addMaterialSheetWindow = new AddMaterialSheetWindow {
            Owner = Application.Current.MainWindow,
            MaterialSheet = new()
        };
        var dialogResult = addMaterialSheetWindow.ShowDialog();

        return dialogResult is true ? addMaterialSheetWindow.MaterialSheet : null;
    }

    public MaterialSheet MaterialSheet { get; init; } = new();

    public uint Id => MaterialSheet.Id;

    public string Material
    {
        get => MaterialSheet.Material;
        set
        {
            MaterialSheet.Material = value;

            OnPropertyChanged(nameof(Material));
        }
    }

    public string Location
    {
        get => MaterialSheet.Location;
        set
        {
            MaterialSheet.Location = value;

            OnPropertyChanged(nameof(Location));
        }
    }

    public float Thickness
    {
        get => MaterialSheet.Thickness;
        set
        {
            MaterialSheet.Thickness = value;

            OnPropertyChanged(nameof(Thickness));
        }
    }

    public PointF[] MaterialPoints
    {
        get => MaterialSheet.Points.ToArray();
        set {
            MaterialSheet.Points = value;

            OnPropertyChanged(nameof(MaterialPoints));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
