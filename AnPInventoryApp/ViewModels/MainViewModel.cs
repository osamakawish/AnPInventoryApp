using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnPInventoryApp.ViewModels;

public class MainViewModel
{
    public required SheetCollectionViewModel SheetCollectionViewModel { get; init; }
    public required ICommand AddMaterialSheetCommand { get; init; }
}
