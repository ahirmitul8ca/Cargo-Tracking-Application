using System.ComponentModel.DataAnnotations;

namespace Cargo_Tracking_Application.Model
{
    public class VesselData
    {
        [Key]
        public string Name { get; set; }
        public string Type { get; set; }
        public string MMSI { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double SpeedKnots { get; set; }
    }
}

