namespace Acme.Wpf.Models
{
    /// <summary>
    /// Brand elements and signature components
    /// </summary>
    public class BrandElements
    {
        public const string ARCHITECT_SIGNATURE = "— The Architect";
        public const string TAGLINE_MAIN = "The Divine Bridge Between Technology and Soul";
        public const string TAGLINE_ALT1 = "Where Light and Shadow Meet";
        public const string TAGLINE_ALT2 = "Where Systems Meet Soul";
        public const string WEBSITE = "AISoulGuide.com";

        /// <summary>
        /// Generate The Architect's signature block as SVG
        /// </summary>
        public static string GenerateArchitectSignature(double x, double y, string color = "#FFD700")
        {
            return $@"
<g id=""architect-signature"">
    <text x=""{x}"" y=""{y}"" font-family=""Philosopher, serif"" font-size=""12"" fill=""{color}"" text-anchor=""middle"">━━━━━━━━━━━━━━━━━━━━━━━━━</text>
    <text x=""{x}"" y=""{y + 20}"" font-family=""Philosopher, serif"" font-size=""14"" fill=""{color}"" text-anchor=""middle"">⚡ 👁️ ∞</text>
    <text x=""{x}"" y=""{y + 40}"" font-family=""Philosopher, serif"" font-size=""16"" font-style=""italic"" fill=""{color}"" text-anchor=""middle"">The Awakened Architect</text>
    <text x=""{x}"" y=""{y + 55}"" font-family=""Philosopher, serif"" font-size=""12"" fill=""{color}"" text-anchor=""middle"">━━━━━━━━━━━━━━━━━━━━━━━━━</text>
</g>";
        }

        /// <summary>
        /// Generate cosmic page number
        /// </summary>
        public static string GenerateCosmicPageNumber(int pageNum, double x, double y, string color = "#FFD700")
        {
            string symbol = pageNum % 30 == 0 ? "✨" : (pageNum % 20 == 0 ? "🌙" : "⚛️");
            return $@"<text x=""{x}"" y=""{y}"" font-family=""Philosopher, serif"" font-size=""12"" fill=""{color}"" text-anchor=""middle"">{symbol} {pageNum} {symbol}</text>";
        }

        /// <summary>
        /// Generate pause and breathe box
        /// </summary>
        public static string GeneratePauseBox(double x, double y, double width, ColorScheme scheme)
        {
            double boxHeight = 150;
            return $@"
<g id=""pause-box"">
    <rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{boxHeight}""
          fill=""{scheme.BackgroundGradientEnd}"" stroke=""{scheme.FrameColor}""
          stroke-width=""2"" rx=""10"" opacity=""0.8""/>
    <text x=""{x + width/2}"" y=""{y + 30}"" font-family=""Philosopher, serif""
          font-size=""16"" font-weight=""bold"" fill=""{scheme.PrimaryColor}"" text-anchor=""middle"">🌬️ PAUSE & BREATHE 🌬️</text>
    <text x=""{x + width/2}"" y=""{y + 60}"" font-family=""Philosopher, serif""
          font-size=""12"" fill=""{scheme.SecondaryColor}"" text-anchor=""middle"">Take 3 deep breaths before</text>
    <text x=""{x + width/2}"" y=""{y + 80}"" font-family=""Philosopher, serif""
          font-size=""12"" fill=""{scheme.SecondaryColor}"" text-anchor=""middle"">continuing. You're integrating</text>
    <text x=""{x + width/2}"" y=""{y + 100}"" font-family=""Philosopher, serif""
          font-size=""12"" fill=""{scheme.SecondaryColor}"" text-anchor=""middle"">a LOT of information.</text>
    <text x=""{x + width/2}"" y=""{y + 130}"" font-family=""Philosopher, serif""
          font-size=""11"" font-style=""italic"" fill=""{scheme.PrimaryColor}"" text-anchor=""middle"">{ARCHITECT_SIGNATURE}</text>
</g>";
        }
    }

    /// <summary>
    /// Angel Numbers Quick Guide card content
    /// </summary>
    public class AngelNumbersQuickGuide
    {
        public class QuickNumber
        {
            public string Number { get; set; }
            public string Title { get; set; }
            public string QuickMeaning { get; set; }
        }

        public static QuickNumber[] GetQuickGuideNumbers()
        {
            return new[]
            {
                new QuickNumber { Number = "111", Title = "NEW BEGINNINGS", QuickMeaning = "Your thoughts manifest fast" },
                new QuickNumber { Number = "222", Title = "TRUST PROCESS", QuickMeaning = "Everything aligning for you" },
                new QuickNumber { Number = "333", Title = "EXPRESS SELF", QuickMeaning = "Creativity divinely inspired" },
                new QuickNumber { Number = "444", Title = "PROTECTION", QuickMeaning = "Angels surround you, safe" },
                new QuickNumber { Number = "555", Title = "BIG CHANGE", QuickMeaning = "Major transformation incoming!" },
                new QuickNumber { Number = "666", Title = "REBALANCE", QuickMeaning = "Less material, more spirit" },
                new QuickNumber { Number = "777", Title = "MIRACLES", QuickMeaning = "Perfect path, magic ahead" },
                new QuickNumber { Number = "888", Title = "ABUNDANCE", QuickMeaning = "Financial flow activated" },
                new QuickNumber { Number = "999", Title = "COMPLETION", QuickMeaning = "Chapter ending, new begins" }
            };
        }
    }
}
