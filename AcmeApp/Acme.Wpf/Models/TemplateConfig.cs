using System.Collections.Generic;

namespace Acme.Wpf.Models
{
    /// <summary>
    /// Complete template configuration
    /// </summary>
    public class TemplateConfig
    {
        public PageFormat PageFormat { get; set; }
        public ColorScheme ColorScheme { get; set; }
        public FrameStyle FrameStyle { get; set; }
        public TemplateType TemplateType { get; set; } = TemplateType.Background;
        public List<SacredGeometryConfig> GeometryElements { get; set; }
        public double FrameThickness { get; set; } = 30;
        public double FrameInnerMargin { get; set; } = 50;
        public bool ShowStars { get; set; } = true;
        public bool ShowGradientOverlay { get; set; } = true;
        public string CustomText { get; set; }
        public TemplateTextContent TextContent { get; set; }
        public AngelNumberContent AngelNumberContent { get; set; }
        public string CardEdition { get; set; } = "Shadow Awakening";

        public TemplateConfig()
        {
            GeometryElements = new List<SacredGeometryConfig>();
            PageFormat = PageFormat.GetStandardFormats()[0];
            ColorScheme = ColorScheme.GetSpiritualSchemes()[0];
            TextContent = new TemplateTextContent();
        }
    }
}
