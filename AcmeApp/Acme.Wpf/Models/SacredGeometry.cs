namespace Acme.Wpf.Models
{
    /// <summary>
    /// Types of sacred geometry patterns
    /// </summary>
    public enum SacredGeometryType
    {
        None,
        FlowerOfLife,
        Metatron,
        SriYantra,
        Merkaba,
        SeedOfLife,
        VesicaPiscis,
        GoldenSpiral,
        TreeOfLife,
        HexagonGrid,
        PlatonicSolids
    }

    /// <summary>
    /// Frame/border styles for templates
    /// </summary>
    public enum FrameStyle
    {
        None,
        SimpleGold,
        OrnateGold,
        CelestialBorder,
        GeometricFrame,
        FloralFrame,
        ArtDecoFrame
    }

    /// <summary>
    /// Configuration for sacred geometry elements
    /// </summary>
    public class SacredGeometryConfig
    {
        public SacredGeometryType Type { get; set; }
        public double Size { get; set; } = 200;
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Opacity { get; set; } = 0.3;
        public string Color { get; set; } = "#FFD700";
        public double Rotation { get; set; } = 0;
        public double StrokeWidth { get; set; } = 2;
    }
}
