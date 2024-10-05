using AnPInventoryApp.Models;
using AnPInventoryAvalonia.Views;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace AnPInventoryAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ICommand GenerateRandomMaterialSheetCommand { get; } 
    public ObservableCollection<MaterialSheet> MaterialSheets { get; }

    public MainWindowViewModel()
    {
        using var context = new AppDbContext();

        MaterialSheets = [.. context.MaterialSheets.ToList()];

        GenerateRandomMaterialSheetCommand = new RelayCommand(
            () =>
            {
                AddSheet(MaterialSheet.GenerateRandom());
            });
    }

    public void AddSheet(MaterialSheet materialSheet, bool updateUi = true)
    {
        if (updateUi) MaterialSheets.Add(materialSheet);

        using var context = new AppDbContext();

        context.MaterialSheets.Add(materialSheet);
        context.SaveChanges();
    }

    public void UpdateMaterial(uint id, string newMaterial, bool updateUi = true)
    {
        if (updateUi) MaterialSheets.First(m => m.Id == id).Material = newMaterial;

        using var context = new AppDbContext();

        var materialSheet = context.MaterialSheets.Find(id);
        if (materialSheet == null) return;

        materialSheet.Material = newMaterial;
        context.SaveChanges();
    } 

    public void UpdateLocation(uint id, string newLocation, bool updateUi = true)
    {
        if (updateUi) MaterialSheets.First(m => m.Id == id).Location = newLocation;

        using var context = new AppDbContext();

        var materialSheet = context.MaterialSheets.Find(id);
        if (materialSheet == null) return;

        materialSheet.Location = newLocation;
        context.SaveChanges();
    }

    public void UpdateThickness(uint id, float newThickness, bool updateUi = true)
    {
        if (updateUi) MaterialSheets.First(m => m.Id == id).Thickness = newThickness;

        using var context = new AppDbContext();

        var materialSheet = context.MaterialSheets.Find(id);
        if (materialSheet == null) return;

        materialSheet.Thickness = newThickness;
        context.SaveChanges();
    }

    public void UpdatePoints(uint id, PointF[] points, bool updateUi = true)
    {
        if (updateUi) MaterialSheets.First(m => m.Id == id).Points = points;

        using var context = new AppDbContext();

        var materialSheet = context.MaterialSheets.Find(id);
        if (materialSheet == null) return;

        materialSheet.Points = points;
        context.SaveChanges();
    }

    public void Remove(uint id, bool updateUi = true)
    {
        for (var i = 0; i < MaterialSheets.Count; i++)
        {
            if (MaterialSheets[i].Id == id) MaterialSheets.RemoveAt(i);
        }

        using var context = new AppDbContext();

        var materialSheet = context.MaterialSheets.Find(id);
        if (materialSheet == null) return;

        context.MaterialSheets.Remove(materialSheet);
    }
}
