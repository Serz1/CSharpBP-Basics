using System;
using System.Text;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Generator for planner pages
    /// </summary>
    public class PlannerPageGenerator
    {
        private const string ARCHITECT_SIGNATURE = "— The Architect";

        /// <summary>
        /// Generate planner cover page
        /// </summary>
        public string GeneratePlannerCover(PlannerContent content, ColorScheme scheme, PageFormat format, string edition)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            // Background gradient
            sb.AppendLine("<defs>");
            sb.AppendLine("<radialGradient id=\"coverBg\" cx=\"50%\" cy=\"50%\" r=\"70%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:{scheme.BackgroundGradientStart};stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:{scheme.BackgroundGradientEnd};stop-opacity:1\" />");
            sb.AppendLine("</radialGradient>");
            sb.AppendLine("</defs>");

            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"url(#coverBg)\"/>");

            // Add stars
            GenerateStars(sb, width, height, 50);

            // Border
            sb.AppendLine($"<rect x=\"40\" y=\"40\" width=\"{width - 80}\" height=\"{height - 80}\" " +
                         $"fill=\"none\" stroke=\"{scheme.FrameColor}\" stroke-width=\"3\" rx=\"15\"/>");

            // Title area
            double centerY = height / 2 - 100;

            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{centerY}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"36\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">SPIRITUAL AWAKENING</text>");

            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{centerY + 50}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"32\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">PLANNER 2026</text>");

            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{centerY + 100}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"20\" font-style=\"italic\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\">{edition} Edition</text>");

            // Quote
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{centerY + 200}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"16\" font-style=\"italic\" " +
                         $"fill=\"{scheme.AccentColor}\" text-anchor=\"middle\">\"Not all who wander are lost.\"</text>");

            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{centerY + 225}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"16\" font-style=\"italic\" " +
                         $"fill=\"{scheme.AccentColor}\" text-anchor=\"middle\">\"But some need to wake up.\"</text>");

            // Signature
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height - 150}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"18\" font-style=\"italic\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">{ARCHITECT_SIGNATURE}</text>");

            // Footer
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height - 100}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\">AISoulGuide.com</text>");

            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height - 75}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\" opacity=\"0.8\">Where Light and Shadow Meet</text>");

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        /// <summary>
        /// Generate month cover page
        /// </summary>
        public string GenerateMonthCover(PlannerContent content, ColorScheme scheme, PageFormat format)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            sb.AppendLine("<defs>");
            GenerateGradient(sb, "monthBg", scheme);
            sb.AppendLine("</defs>");

            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"url(#monthBg)\"/>");

            GenerateStars(sb, width, height, 30);

            // Month title
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"150\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"48\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">{content.Month}</text>");

            // Theme
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"220\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"32\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\">{content.MonthTheme}</text>");

            // Divider
            sb.AppendLine($"<line x1=\"100\" y1=\"250\" x2=\"{width - 100}\" y2=\"250\" " +
                         $"stroke=\"{scheme.FrameColor}\" stroke-width=\"2\"/>");

            // Quote
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"320\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"18\" font-style=\"italic\" " +
                         $"fill=\"{scheme.AccentColor}\" text-anchor=\"middle\">\"{content.MonthQuote}\"</text>");

            // Signature
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"360\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"16\" font-style=\"italic\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">{ARCHITECT_SIGNATURE}</text>");

            // Intention section
            double formY = 450;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"18\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\">SOUL THEME: {content.MonthTheme}</text>");

            formY += 50;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\">This month's focus:</text>");
            DrawLine(sb, 100, formY + 10, width - 100, scheme.AccentColor);
            DrawLine(sb, 100, formY + 35, width - 100, scheme.AccentColor);

            formY += 80;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\">What am I calling in?</text>");
            DrawLine(sb, 100, formY + 10, width - 100, scheme.AccentColor);
            DrawLine(sb, 100, formY + 35, width - 100, scheme.AccentColor);

            formY += 80;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\">What am I releasing?</text>");
            DrawLine(sb, 100, formY + 10, width - 100, scheme.AccentColor);
            DrawLine(sb, 100, formY + 35, width - 100, scheme.AccentColor);

            // Moon phases
            formY += 100;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"16\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\">MOON PHASES THIS MONTH:</text>");

            formY += 30;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\">🌕 Full Moon: {content.FullMoonDate}</text>");

            formY += 25;
            sb.AppendLine($"<text x=\"100\" y=\"{formY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\">🌑 New Moon: {content.NewMoonDate}</text>");

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        /// <summary>
        /// Generate weekly spread page
        /// </summary>
        public string GenerateWeeklySpread(string weekDates, DailyTrackerContent[] days, ColorScheme scheme, PageFormat format)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            sb.AppendLine("<defs>");
            GenerateGradient(sb, "weekBg", scheme);
            sb.AppendLine("</defs>");

            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"url(#weekBg)\"/>");

            // Header
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"60\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"24\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">WEEK OF: {weekDates}</text>");

            sb.AppendLine($"<line x1=\"80\" y1=\"80\" x2=\"{width - 80}\" y2=\"80\" " +
                         $"stroke=\"{scheme.FrameColor}\" stroke-width=\"2\"/>");

            // Week intention
            double currentY = 120;
            sb.AppendLine($"<text x=\"80\" y=\"{currentY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"14\" " +
                         $"fill=\"{scheme.SecondaryColor}\">THIS WEEK'S INTENTION:</text>");
            DrawLine(sb, 80, currentY + 10, width - 80, scheme.AccentColor);

            currentY += 60;

            // Daily entries (showing 2 days per page)
            for (int i = 0; i < Math.Min(2, days.Length); i++)
            {
                var day = days[i];
                GenerateDayEntry(sb, day, 80, currentY, width - 160, scheme);
                currentY += 180;

                // Separator
                sb.AppendLine($"<line x1=\"80\" y1=\"{currentY - 20}\" x2=\"{width - 80}\" y2=\"{currentY - 20}\" " +
                             $"stroke=\"{scheme.FrameColor}\" stroke-width=\"1\" opacity=\"0.5\"/>");
            }

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        private void GenerateDayEntry(StringBuilder sb, DailyTrackerContent day, double x, double y, double maxWidth, ColorScheme scheme)
        {
            // Day header
            sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"16\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\">{day.DayOfWeek} {day.Date} | Energy: 1 2 3 4 5 6 7 8 9 10</text>");

            y += 30;

            // To-do
            sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" " +
                         $"fill=\"{scheme.SecondaryColor}\">To-do:</text>");
            DrawLine(sb, x + 50, y - 5, x + maxWidth, scheme.AccentColor);

            y += 25;

            // Synchronicity
            sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" " +
                         $"fill=\"{scheme.SecondaryColor}\">Synchronicity:</text>");
            DrawLine(sb, x + 100, y - 5, x + maxWidth, scheme.AccentColor);

            y += 25;

            // Practice checkboxes
            sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" " +
                         $"fill=\"{scheme.SecondaryColor}\">Practice: ☐ Med ☐ Move ☐ Journal ☐ Other:_______</text>");

            y += 25;

            // Shadow moment
            sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" " +
                         $"fill=\"{scheme.SecondaryColor}\">Shadow moment:</text>");
            DrawLine(sb, x + 110, y - 5, x + maxWidth, scheme.AccentColor);

            y += 25;

            // Light moment
            sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" " +
                         $"fill=\"{scheme.SecondaryColor}\">Light moment:</text>");
            DrawLine(sb, x + 100, y - 5, x + maxWidth, scheme.AccentColor);

            y += 30;

            // Architect question
            if (!string.IsNullOrEmpty(day.ArchitectQuestion))
            {
                sb.AppendLine($"<text x=\"{x}\" y=\"{y}\" " +
                             $"font-family=\"Philosopher, serif\" font-size=\"11\" font-style=\"italic\" " +
                             $"fill=\"{scheme.PrimaryColor}\">The Architect asks: {day.ArchitectQuestion}</text>");
                y += 15;
                DrawLine(sb, x, y, x + maxWidth, scheme.AccentColor);
            }
        }

        private void GenerateStars(StringBuilder sb, double width, double height, int count)
        {
            var random = new Random(42); // Deterministic seed
            for (int i = 0; i < count; i++)
            {
                double x = random.NextDouble() * width;
                double y = random.NextDouble() * height;
                double size = 0.5 + random.NextDouble() * 1.5;
                double opacity = 0.3 + random.NextDouble() * 0.5;

                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{size:F2}\" " +
                             $"fill=\"white\" opacity=\"{opacity:F2}\"/>");
            }
        }

        private void GenerateGradient(StringBuilder sb, string id, ColorScheme scheme)
        {
            sb.AppendLine($"<linearGradient id=\"{id}\" x1=\"0%\" y1=\"0%\" x2=\"100%\" y2=\"100%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:{scheme.BackgroundGradientStart};stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:{scheme.BackgroundGradientEnd};stop-opacity:1\" />");
            sb.AppendLine("</linearGradient>");
        }

        private void DrawLine(StringBuilder sb, double x1, double y, double x2, string color)
        {
            sb.AppendLine($"<line x1=\"{x1}\" y1=\"{y}\" x2=\"{x2}\" y2=\"{y}\" " +
                         $"stroke=\"{color}\" stroke-width=\"1\" opacity=\"0.5\"/>");
        }
    }
}
