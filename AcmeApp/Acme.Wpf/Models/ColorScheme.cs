namespace Acme.Wpf.Models
{
    /// <summary>
    /// Predefined color schemes for spiritual templates
    /// </summary>
    public class ColorScheme
    {
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string AccentColor { get; set; }
        public string BackgroundGradientStart { get; set; }
        public string BackgroundGradientEnd { get; set; }
        public string FrameColor { get; set; }

        public static ColorScheme[] GetSpiritualSchemes()
        {
            return new[]
            {
                new ColorScheme
                {
                    Name = "Divine Gold",
                    PrimaryColor = "#FFD700",
                    SecondaryColor = "#B8860B",
                    AccentColor = "#FFF8DC",
                    BackgroundGradientStart = "#1a1a2e",
                    BackgroundGradientEnd = "#16213e",
                    FrameColor = "#FFD700"
                },
                new ColorScheme
                {
                    Name = "Celestial Purple",
                    PrimaryColor = "#9B59B6",
                    SecondaryColor = "#8E44AD",
                    AccentColor = "#E8DAEF",
                    BackgroundGradientStart = "#2C3E50",
                    BackgroundGradientEnd = "#4A235A",
                    FrameColor = "#D4AF37"
                },
                new ColorScheme
                {
                    Name = "Mystical Blue",
                    PrimaryColor = "#3498DB",
                    SecondaryColor = "#2874A6",
                    AccentColor = "#AED6F1",
                    BackgroundGradientStart = "#0f2027",
                    BackgroundGradientEnd = "#203a43",
                    FrameColor = "#85C1E2"
                },
                new ColorScheme
                {
                    Name = "Sacred Rose",
                    PrimaryColor = "#E91E63",
                    SecondaryColor = "#AD1457",
                    AccentColor = "#F8BBD0",
                    BackgroundGradientStart = "#2C0735",
                    BackgroundGradientEnd = "#4A0E4E",
                    FrameColor = "#FFD700"
                },
                new ColorScheme
                {
                    Name = "Angelic White",
                    PrimaryColor = "#FFFFFF",
                    SecondaryColor = "#ECF0F1",
                    AccentColor = "#D4AF37",
                    BackgroundGradientStart = "#E8E8E8",
                    BackgroundGradientEnd = "#FFFFFF",
                    FrameColor = "#D4AF37"
                },
                new ColorScheme
                {
                    Name = "Emerald Wisdom",
                    PrimaryColor = "#2ECC71",
                    SecondaryColor = "#27AE60",
                    AccentColor = "#D5F4E6",
                    BackgroundGradientStart = "#0a3d26",
                    BackgroundGradientEnd = "#1e5f3e",
                    FrameColor = "#FFD700"
                },
                new ColorScheme
                {
                    Name = "Shadow Awakening",
                    PrimaryColor = "#FFD700",
                    SecondaryColor = "#FCEEAC",
                    AccentColor = "#8B5CF6",
                    BackgroundGradientStart = "#120A2A",
                    BackgroundGradientEnd = "#1E0E3E",
                    FrameColor = "#FFD700"
                },
                new ColorScheme
                {
                    Name = "Luminous Harmony",
                    PrimaryColor = "#E6B8FF",
                    SecondaryColor = "#D4AF37",
                    AccentColor = "#FCEEAC",
                    BackgroundGradientStart = "#3E2B4D",
                    BackgroundGradientEnd = "#5A3D6F",
                    FrameColor = "#D4AF37"
                },
                new ColorScheme
                {
                    Name = "Angel Numbers Deep",
                    PrimaryColor = "#FFD700",
                    SecondaryColor = "#9B59B6",
                    AccentColor = "#FFFFFF",
                    BackgroundGradientStart = "#2C0735",
                    BackgroundGradientEnd = "#4A0E4E",
                    FrameColor = "#FFD700"
                }
            };
        }
    }
}
