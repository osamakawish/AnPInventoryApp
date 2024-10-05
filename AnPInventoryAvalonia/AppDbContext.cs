using AnPInventoryApp.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnPInventoryAvalonia;
public class AppDbContext : DbContext
{
    public DbSet<MaterialSheet> MaterialSheets { get; set; }

    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var appDirectoryName = "AnP Inventory";
        var appName = "anp_inventory.db";
        var specialFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        var folderPath = Path.Combine(specialFolderPath, appDirectoryName);
        Directory.CreateDirectory(folderPath);

        var path = Path.Combine(folderPath, appName);
        var sqliteConnectionString = new SqliteConnectionStringBuilder { DataSource = path }.ConnectionString;

        optionsBuilder.UseSqlite(sqliteConnectionString);
    }
}
