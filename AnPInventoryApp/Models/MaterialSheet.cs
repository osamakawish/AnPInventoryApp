using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;

namespace AnPInventoryApp.Models
{
    public record MaterialSheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; private set; }

        public string Material { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public float Thickness { get; set; }
        [NotMapped]
        public List<float> XValues { get; set; } = [];

        [NotMapped]
        public List<float> YValues { get; set; } = [];

        [NotMapped]
        public IEnumerable<PointF> Points
        {
            get => XValues.Zip(YValues).Select(z => new PointF(z.First, z.Second)).ToArray();
            set
            {
                XValues = value.Select(p => p.X).ToList();
                YValues = value.Select(p => p.X).ToList();
            }
        }

        // For database storage
        public string SerializedXValues
        {
            get => JsonConvert.SerializeObject(XValues);
            set => XValues = JsonConvert.DeserializeObject<List<float>>(value) ?? [];
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

        public string SerializedYValues
        {
            get => JsonConvert.SerializeObject(YValues);
            set => YValues = JsonConvert.DeserializeObject<List<float>>(value) ?? [];
        }

        public SizeF Size => new(XValues.Max(), YValues.Max());
    }
}
