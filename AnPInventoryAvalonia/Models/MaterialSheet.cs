using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;

namespace AnPInventoryApp.Models;

public class MaterialSheet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; private set; }

    public required string Material { get; set; } = string.Empty;
    public required string Location { get; set; } = string.Empty;
    public required float Thickness { get; set; }
    [NotMapped]
    public List<float> XValues { get; private set; } = [];

    [NotMapped]
    public List<float> YValues { get; private set; } = [];

    [NotMapped]
    public IEnumerable<PointF> Points
    {
        get => XValues.Zip(YValues).Select(z => new PointF(z.First, z.Second)).ToList();
        set
        {
            XValues = value.Select(p => p.X).ToList();
            YValues = value.Select(p => p.Y).ToList();
        }
    }

    internal string FormattedPoints => string.Join(", ", Points.Select(p => $"({p.X:0}, {p.Y:0})"));

    // For database storage
    public string SerializedXValues
    {
        get => JsonConvert.SerializeObject(XValues);
        set => XValues = JsonConvert.DeserializeObject<List<float>>(value) ?? [];
    }

    public string SerializedYValues
    {
        get => JsonConvert.SerializeObject(YValues);
        set => YValues = JsonConvert.DeserializeObject<List<float>>(value) ?? [];
    }

    public bool UpdateTo(MaterialSheet other)
    {
        if (other == null || other.Id != Id) return false;

        other.Material = Material;
        other.Location = Location;
        other.Thickness = Thickness;
        other.XValues = XValues;
        other.YValues = YValues;

        return true;
    }

    public SizeF Size => Points.Count() == 0 ? new(0,0) : new(XValues.Max(), YValues.Max());

    public static MaterialSheet GenerateRandom()
    {
        var materials = new string[] { "Plywood", "MDF", "Acrylic", "PVC", "Alupanel", "Polycarbonate" };
        var locations = new string[] { "A1", "A2", "A3", "B", "C" };

        var random = new Random();
        var i = random.Next(0, materials.Length);
        var j = random.Next(0, locations.Length);
        
        var material = materials[i];
        var location = locations[j];
        var thickness = random.NextSingle() * 1.5f;

        var points = GenerateRandomPoints(random);

        return new MaterialSheet
        {
            Location = location,
            Material = material,
            Thickness = thickness,
            Points = points
        };
    }

    private static PointF[] GenerateRandomPoints(Random random)
    {
        var len = random.Next(1, 7);

        var i = 0;

        var points = new PointF[len];

        while (i < len) {
            var x = random.Next(0, 48);
            var y = random.Next(0, 48);
            points[i++] = new PointF(x, y);
        }

        return points;
    }
}
