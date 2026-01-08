using System.Text;

namespace Acme.Wpf.Models
{
    /// <summary>
    /// Decorative elements for templates: lines, dividers, ornaments
    /// </summary>
    public static class DecorativeElements
    {
        /// <summary>
        /// Generate horizontal decorative line with optional ornaments
        /// </summary>
        public static string GenerateDecorativeLine(double x1, double y, double x2,
            string color = "#FFD700", double strokeWidth = 1, bool withOrnaments = true)
        {
            var sb = new StringBuilder();

            // Main line
            sb.AppendLine($"<line x1=\"{x1}\" y1=\"{y}\" x2=\"{x2}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"{strokeWidth}\"/>");

            if (withOrnaments)
            {
                // Small decorative circles at ends
                sb.AppendLine($"<circle cx=\"{x1}\" cy=\"{y}\" r=\"3\" fill=\"{color}\"/>");
                sb.AppendLine($"<circle cx=\"{x2}\" cy=\"{y}\" r=\"3\" fill=\"{color}\"/>");

                // Center diamond
                double centerX = (x1 + x2) / 2;
                sb.AppendLine($"<circle cx=\"{centerX}\" cy=\"{y}\" r=\"4\" fill=\"{color}\"/>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generate ornamental divider with flourishes
        /// </summary>
        public static string GenerateOrnamentalDivider(double centerX, double y,
            double width, string color = "#FFD700")
        {
            var sb = new StringBuilder();
            double halfWidth = width / 2;

            // Center ornament (diamond shape)
            sb.AppendLine($"<path d=\"M {centerX} {y - 5} L {centerX + 5} {y} L {centerX} {y + 5} L {centerX - 5} {y} Z\" " +
                         $"fill=\"{color}\" opacity=\"0.8\"/>");

            // Left and right lines
            sb.AppendLine($"<line x1=\"{centerX - halfWidth}\" y1=\"{y}\" x2=\"{centerX - 15}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1\"/>");
            sb.AppendLine($"<line x1=\"{centerX + 15}\" y1=\"{y}\" x2=\"{centerX + halfWidth}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1\"/>");

            // Side dots
            sb.AppendLine($"<circle cx=\"{centerX - 10}\" cy=\"{y}\" r=\"2\" fill=\"{color}\"/>");
            sb.AppendLine($"<circle cx=\"{centerX + 10}\" cy=\"{y}\" r=\"2\" fill=\"{color}\"/>");

            return sb.ToString();
        }

        /// <summary>
        /// Generate vertical divider line
        /// </summary>
        public static string GenerateVerticalDivider(double x, double y1, double y2,
            string color = "#FFD700", double strokeWidth = 1, bool withOrnaments = false)
        {
            var sb = new StringBuilder();

            // Main line
            sb.AppendLine($"<line x1=\"{x}\" y1=\"{y1}\" x2=\"{x}\" y2=\"{y2}\" " +
                         $"stroke=\"{color}\" stroke-width=\"{strokeWidth}\" opacity=\"0.5\"/>");

            if (withOrnaments)
            {
                // Top and bottom circles
                sb.AppendLine($"<circle cx=\"{x}\" cy=\"{y1}\" r=\"3\" fill=\"{color}\"/>");
                sb.AppendLine($"<circle cx=\"{x}\" cy=\"{y2}\" r=\"3\" fill=\"{color}\"/>");

                // Center diamond
                double centerY = (y1 + y2) / 2;
                sb.AppendLine($"<circle cx=\"{x}\" cy=\"{centerY}\" r=\"4\" fill=\"{color}\"/>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generate corner ornament
        /// </summary>
        public static string GenerateCornerOrnament(double x, double y,
            string position = "top-left", double size = 30, string color = "#FFD700")
        {
            var sb = new StringBuilder();

            // Determine direction multipliers
            int xDir = position.Contains("right") ? -1 : 1;
            int yDir = position.Contains("bottom") ? -1 : 1;

            // Corner flourish
            sb.AppendLine($"<path d=\"M {x} {y} Q {x + xDir * size} {y} {x + xDir * size} {y + yDir * size/2}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1.5\" fill=\"none\" opacity=\"0.6\"/>");
            sb.AppendLine($"<path d=\"M {x} {y} Q {x} {y + yDir * size} {x + xDir * size/2} {y + yDir * size}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1.5\" fill=\"none\" opacity=\"0.6\"/>");

            // Small circle at corner
            sb.AppendLine($"<circle cx=\"{x}\" cy=\"{y}\" r=\"3\" fill=\"{color}\"/>");

            return sb.ToString();
        }

        /// <summary>
        /// Generate decorative border frame
        /// </summary>
        public static string GenerateBorderFrame(double x, double y, double width, double height,
            string color = "#FFD700", double strokeWidth = 2, double cornerRadius = 10)
        {
            var sb = new StringBuilder();

            // Main border
            sb.AppendLine($"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" " +
                         $"fill=\"none\" stroke=\"{color}\" stroke-width=\"{strokeWidth}\" rx=\"{cornerRadius}\"/>");

            // Inner shadow border
            double offset = 5;
            sb.AppendLine($"<rect x=\"{x + offset}\" y=\"{y + offset}\" " +
                         $"width=\"{width - 2 * offset}\" height=\"{height - 2 * offset}\" " +
                         $"fill=\"none\" stroke=\"{color}\" stroke-width=\"1\" rx=\"{cornerRadius}\" opacity=\"0.3\"/>");

            return sb.ToString();
        }

        /// <summary>
        /// Generate section separator with text
        /// </summary>
        public static string GenerateSectionSeparator(double centerX, double y,
            string text, double width, string color = "#FFD700", string textColor = "#FCEEAC")
        {
            var sb = new StringBuilder();
            double halfWidth = width / 2;

            // Text background (slight box for readability)
            double textWidth = text.Length * 8; // Approximate
            sb.AppendLine($"<rect x=\"{centerX - textWidth/2 - 5}\" y=\"{y - 12}\" " +
                         $"width=\"{textWidth + 10}\" height=\"20\" " +
                         $"fill=\"#120A2A\" opacity=\"0.8\"/>");

            // Lines on sides
            sb.AppendLine($"<line x1=\"{centerX - halfWidth}\" y1=\"{y}\" " +
                         $"x2=\"{centerX - textWidth/2 - 10}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1\"/>");
            sb.AppendLine($"<line x1=\"{centerX + textWidth/2 + 10}\" y1=\"{y}\" " +
                         $"x2=\"{centerX + halfWidth}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1\"/>");

            // Text
            sb.AppendLine($"<text x=\"{centerX}\" y=\"{y + 4}\" font-family=\"Cinzel Decorative, serif\" " +
                         $"font-size=\"11\" fill=\"{textColor}\" text-anchor=\"middle\">{text}</text>");

            // Decorative dots
            sb.AppendLine($"<circle cx=\"{centerX - textWidth/2 - 15}\" cy=\"{y}\" r=\"2\" fill=\"{color}\"/>");
            sb.AppendLine($"<circle cx=\"{centerX + textWidth/2 + 15}\" cy=\"{y}\" r=\"2\" fill=\"{color}\"/>");

            return sb.ToString();
        }

        /// <summary>
        /// Generate dotted line separator
        /// </summary>
        public static string GenerateDottedLine(double x1, double y, double x2,
            string color = "#FFD700", double dotSpacing = 5)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<line x1=\"{x1}\" y1=\"{y}\" x2=\"{x2}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1\" stroke-dasharray=\"2,{dotSpacing}\"/>");

            return sb.ToString();
        }

        /// <summary>
        /// Generate decorative brackets around text area
        /// </summary>
        public static string GenerateBrackets(double x, double y, double width, double height,
            string color = "#FFD700")
        {
            var sb = new StringBuilder();

            // Left bracket
            sb.AppendLine($"<path d=\"M {x + 10} {y} L {x} {y} L {x} {y + height} L {x + 10} {y + height}\" " +
                         $"stroke=\"{color}\" stroke-width=\"2\" fill=\"none\"/>");

            // Right bracket
            sb.AppendLine($"<path d=\"M {x + width - 10} {y} L {x + width} {y} L {x + width} {y + height} L {x + width - 10} {y + height}\" " +
                         $"stroke=\"{color}\" stroke-width=\"2\" fill=\"none\"/>");

            return sb.ToString();
        }

        /// <summary>
        /// Generate star decoration
        /// </summary>
        public static string GenerateStarDecoration(double x, double y, double size = 10,
            string color = "#FFD700", double opacity = 0.8)
        {
            var sb = new StringBuilder();

            // Simple 4-point star
            sb.AppendLine($"<path d=\"M {x} {y - size} L {x + size/3} {y - size/3} L {x + size} {y} " +
                         $"L {x + size/3} {y + size/3} L {x} {y + size} L {x - size/3} {y + size/3} " +
                         $"L {x - size} {y} L {x - size/3} {y - size/3} Z\" " +
                         $"fill=\"{color}\" opacity=\"{opacity}\"/>");

            return sb.ToString();
        }
    }
}
