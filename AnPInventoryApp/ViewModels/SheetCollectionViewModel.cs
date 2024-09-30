using AnPInventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnPInventoryApp.ViewModels;

public class SheetCollectionViewModel : INotifyPropertyChanged
{
    public ObservableCollection<MaterialSheet> MaterialSheets { get; set; } = [];

    public SheetCollectionViewModel()
    {
        using var context = new AppDbContext();

        var sheets = context.MaterialSheets.ToList();
        sheets.ForEach(sheet => MaterialSheets.Add(sheet));
    }

    public void AddSheet(MaterialSheet sheet)
    {
        using var context = new AppDbContext();

        context.Add(sheet);
        context.SaveChanges();
        MaterialSheets.Add(sheet);
    }

    public void UpdateSheet(MaterialSheet sheet)
    {
        using var context = new AppDbContext();

        var sheetInDb = context.MaterialSheets.Find(sheet.Id);
        var sheetInList = MaterialSheets.First(sh => sh.Id == sheet.Id);
        if (sheetInDb == null || sheetInList == null) return;

        sheet.UpdateTo(sheetInDb); sheet.UpdateTo(sheetInList);
    }

    public void RemoveSheet(MaterialSheet sheet)
    {
        using var context = new AppDbContext();

        context.Remove(sheet);
        MaterialSheets.Remove(sheet);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
