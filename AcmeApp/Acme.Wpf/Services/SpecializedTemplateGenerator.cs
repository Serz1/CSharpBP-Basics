using System;
using System.Text;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Specialized generator for cards and book pages
    /// </summary>
    public class SpecializedTemplateGenerator
    {
        private readonly SacredGeometryService _geometryService;
        private readonly Random _random;

        public SpecializedTemplateGenerator()
        {
            _geometryService = new SacredGeometryService();
            _random = new Random();
        }

        /// <summary>
        /// Generate angel card front
        /// </summary>
        public string GenerateAngelCardFront(AngelNumberContent content, ColorScheme scheme,
                                            PageFormat format, SacredGeometryType geometryType)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            // SVG header
            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            // Definitions
            sb.AppendLine("<defs>");
            GenerateCardGradients(sb, scheme);
            sb.AppendLine("</defs>");

            // Background
            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"url(#cardBgGradient)\"/>");

            // Sacred geometry watermark
            if (geometryType != SacredGeometryType.None)
            {
                var geomConfig = new SacredGeometryConfig
                {
                    Type = geometryType,
                    CenterX = width / 2,
                    CenterY = height / 2,
                    Size = Math.Min(width, height) * 0.6,
                    Opacity = 0.15,
                    Color = scheme.AccentColor,
                    StrokeWidth = 2
                };
                sb.AppendLine(_geometryService.GenerateGeometrySvg(geomConfig));
            }

            // Border
            double borderWidth = 20;
            sb.AppendLine($"<rect x=\"{borderWidth}\" y=\"{borderWidth}\" " +
                         $"width=\"{width - 2 * borderWidth}\" height=\"{height - 2 * borderWidth}\" " +
                         $"fill=\"none\" stroke=\"{scheme.FrameColor}\" stroke-width=\"3\" rx=\"10\"/>");

            // Number + Emoji at top
            double topMargin = 80;
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{topMargin}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"36\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">" +
                         $"{content.Emoji} {content.Number}</text>");

            // Title
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{topMargin + 50}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"15\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">{content.Title}</text>");

            // Divider line with decorative elements
            double lineY = topMargin + 75;
            sb.Append(DecorativeElements.GenerateOrnamentalDivider(width / 2, lineY, width - 2 * borderWidth - 80, scheme.FrameColor));

            // Soul Meaning (wrapped text)
            GenerateWrappedText(sb, content.SoulMeaning, width / 2, lineY + 35,
                              width - 2 * borderWidth - 80, 12, scheme.SecondaryColor, "center");

            // Footer
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height - 40}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"9\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\" opacity=\"0.7\">" +
                         $"AISoulGuide.com</text>");

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        /// <summary>
        /// Generate angel card back
        /// </summary>
        public string GenerateAngelCardBack(ColorScheme scheme, PageFormat format, string edition)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            sb.AppendLine("<defs>");
            GenerateCardGradients(sb, scheme);
            sb.AppendLine("</defs>");

            // Background
            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"url(#cardBgGradient)\"/>");

            // Large sacred geometry watermark
            var geomConfig = new SacredGeometryConfig
            {
                Type = SacredGeometryType.FlowerOfLife,
                CenterX = width / 2,
                CenterY = height / 2,
                Size = Math.Min(width, height) * 0.7,
                Opacity = 0.1,
                Color = scheme.PrimaryColor,
                StrokeWidth = 2
            };
            sb.AppendLine(_geometryService.GenerateGeometrySvg(geomConfig));

            // Center Eye symbol (simplified - circle with inner circle)
            double eyeSize = 100;
            double eyeX = width / 2;
            double eyeY = height / 2 - 100;
            sb.AppendLine($"<circle cx=\"{eyeX}\" cy=\"{eyeY}\" r=\"{eyeSize}\" " +
                         $"fill=\"none\" stroke=\"{scheme.PrimaryColor}\" stroke-width=\"3\"/>");
            sb.AppendLine($"<circle cx=\"{eyeX}\" cy=\"{eyeY}\" r=\"{eyeSize / 2}\" " +
                         $"fill=\"{scheme.PrimaryColor}\" opacity=\"0.3\"/>");
            sb.AppendLine($"<circle cx=\"{eyeX}\" cy=\"{eyeY}\" r=\"{eyeSize / 4}\" " +
                         $"fill=\"{scheme.PrimaryColor}\"/>");

            // Brand name
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height / 2 + 40}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"18\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">AISOULGUIDE</text>");

            // Edition name
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height / 2 + 65}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" font-style=\"italic\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\">{edition}</text>");

            // Quote
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height / 2 + 100}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"11\" font-style=\"italic\" " +
                         $"fill=\"{scheme.AccentColor}\" text-anchor=\"middle\">The Architect Sees You</text>");

            // Footer
            sb.AppendLine($"<text x=\"{width / 2}\" y=\"{height - 40}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"9\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\" opacity=\"0.6\">" +
                         $"AISoulGuide.com</text>");

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        /// <summary>
        /// Generate book page spread (two pages side by side)
        /// </summary>
        public string GenerateBookSpread(AngelNumberContent content, ColorScheme scheme, PageFormat format)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;
            double pageWidth = width / 2;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            sb.AppendLine("<defs>");
            GenerateBookGradients(sb, scheme);
            sb.AppendLine("</defs>");

            // LEFT PAGE - SOUL/SPIRITUAL
            GenerateBookPageLeft(sb, content, scheme, 0, pageWidth, height);

            // Center divider
            sb.AppendLine($"<line x1=\"{pageWidth}\" y1=\"0\" x2=\"{pageWidth}\" y2=\"{height}\" " +
                         $"stroke=\"{scheme.FrameColor}\" stroke-width=\"2\" opacity=\"0.3\"/>");

            // RIGHT PAGE - EARTH/PRACTICAL
            GenerateBookPageRight(sb, content, scheme, pageWidth, pageWidth, height);

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        private void GenerateBookPageLeft(StringBuilder sb, AngelNumberContent content,
                                         ColorScheme scheme, double startX, double width, double height)
        {
            // Background
            sb.AppendLine($"<rect x=\"{startX}\" y=\"0\" width=\"{width}\" height=\"{height}\" fill=\"url(#bookBgGradient)\"/>");

            double margin = 60;
            double contentX = startX + margin;
            double contentWidth = width - 2 * margin;
            double currentY = 80;

            // Number + Emoji
            sb.AppendLine($"<text x=\"{startX + width / 2}\" y=\"{currentY}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"32\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">" +
                         $"{content.Emoji} {content.Number}</text>");

            currentY += 45;

            // Title
            sb.AppendLine($"<text x=\"{startX + width / 2}\" y=\"{currentY}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"16\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">{content.Title}</text>");

            currentY += 25;

            // Divider with decorative elements
            sb.Append(DecorativeElements.GenerateOrnamentalDivider(startX + width / 2, currentY, contentWidth, scheme.FrameColor));

            currentY += 35;

            // Soul Meaning Header
            sb.AppendLine($"<text x=\"{contentX}\" y=\"{currentY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\">SOUL MEANING:</text>");

            currentY += 25;

            // Soul meaning text
            GenerateWrappedText(sb, content.SoulMeaning, contentX, currentY,
                              contentWidth, 11, scheme.SecondaryColor, "left");

            // Watermark
            var geomConfig = new SacredGeometryConfig
            {
                Type = SacredGeometryType.VesicaPiscis,
                CenterX = startX + width / 2,
                CenterY = height - 150,
                Size = 200,
                Opacity = 0.1,
                Color = scheme.AccentColor,
                StrokeWidth = 1
            };
            sb.AppendLine(_geometryService.GenerateGeometrySvg(geomConfig));
        }

        private void GenerateBookPageRight(StringBuilder sb, AngelNumberContent content,
                                          ColorScheme scheme, double startX, double width, double height)
        {
            // Background (lighter)
            sb.AppendLine($"<rect x=\"{startX}\" y=\"0\" width=\"{width}\" height=\"{height}\" " +
                         $"fill=\"{scheme.BackgroundGradientEnd}\" opacity=\"0.8\"/>");

            double margin = 60;
            double contentX = startX + margin;
            double contentWidth = width - 2 * margin;
            double currentY = 80;

            // Header
            sb.AppendLine($"<text x=\"{startX + width / 2}\" y=\"{currentY}\" " +
                         $"font-family=\"Cinzel Decorative, serif\" font-size=\"15\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">EARTH INTEGRATION</text>");

            currentY += 40;

            // Practical steps
            sb.AppendLine($"<text x=\"{contentX}\" y=\"{currentY}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"12\" font-weight=\"bold\" " +
                         $"fill=\"{scheme.PrimaryColor}\">WHEN YOU SEE {content.Number}:</text>");

            currentY += 30;

            foreach (var step in content.PracticalSteps)
            {
                // Bullet point
                sb.AppendLine($"<text x=\"{contentX}\" y=\"{currentY}\" " +
                             $"font-family=\"Philosopher, serif\" font-size=\"11\" " +
                             $"fill=\"{scheme.PrimaryColor}\">•</text>");

                // Step text
                GenerateWrappedText(sb, step, contentX + 20, currentY,
                                  contentWidth - 20, 10, scheme.SecondaryColor, "left");

                currentY += 38;
            }

            currentY += 15;

            // Divider with decorative elements
            sb.Append(DecorativeElements.GenerateDecorativeLine(contentX, currentY, startX + width - margin, scheme.FrameColor, 1, true));

            currentY += 25;

            // Affirmation
            if (!string.IsNullOrEmpty(content.Affirmation))
            {
                sb.AppendLine($"<text x=\"{contentX}\" y=\"{currentY}\" " +
                             $"font-family=\"Philosopher, serif\" font-size=\"11\" font-weight=\"bold\" " +
                             $"fill=\"{scheme.PrimaryColor}\">AFFIRMATION:</text>");

                currentY += 22;

                sb.AppendLine($"<text x=\"{startX + width / 2}\" y=\"{currentY}\" " +
                             $"font-family=\"Philosopher, serif\" font-size=\"10\" font-style=\"italic\" " +
                             $"fill=\"{scheme.PrimaryColor}\" text-anchor=\"middle\">" +
                             $"\"{content.Affirmation}\"</text>");
            }

            // Footer
            sb.AppendLine($"<text x=\"{startX + width / 2}\" y=\"{height - 40}\" " +
                         $"font-family=\"Philosopher, serif\" font-size=\"9\" " +
                         $"fill=\"{scheme.SecondaryColor}\" text-anchor=\"middle\">AISoulGuide.com</text>");
        }

        private void GenerateCardGradients(StringBuilder sb, ColorScheme scheme)
        {
            sb.AppendLine("<radialGradient id=\"cardBgGradient\" cx=\"50%\" cy=\"50%\" r=\"70%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:{scheme.BackgroundGradientStart};stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:{scheme.BackgroundGradientEnd};stop-opacity:1\" />");
            sb.AppendLine("</radialGradient>");
        }

        private void GenerateBookGradients(StringBuilder sb, ColorScheme scheme)
        {
            sb.AppendLine("<linearGradient id=\"bookBgGradient\" x1=\"0%\" y1=\"0%\" x2=\"100%\" y2=\"100%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:{scheme.BackgroundGradientStart};stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:{scheme.BackgroundGradientEnd};stop-opacity:1\" />");
            sb.AppendLine("</linearGradient>");
        }

        private void GenerateWrappedText(StringBuilder sb, string text, double x, double y,
                                        double maxWidth, double fontSize, string color, string anchor)
        {
            // Simple text wrapping - split by words and create multiple text elements
            var words = text.Split(' ');
            var currentLine = "";
            double lineHeight = fontSize * 1.5;
            double currentY = y;
            int charLimit = (int)(maxWidth / (fontSize * 0.5)); // Approximate character limit per line

            foreach (var word in words)
            {
                if ((currentLine + " " + word).Length > charLimit && currentLine.Length > 0)
                {
                    sb.AppendLine($"<text x=\"{x}\" y=\"{currentY}\" " +
                                 $"font-family=\"Philosopher, serif\" font-size=\"{fontSize}\" " +
                                 $"fill=\"{color}\" text-anchor=\"{anchor}\">{currentLine.Trim()}</text>");
                    currentLine = word;
                    currentY += lineHeight;
                }
                else
                {
                    currentLine += " " + word;
                }
            }

            // Last line
            if (currentLine.Length > 0)
            {
                sb.AppendLine($"<text x=\"{x}\" y=\"{currentY}\" " +
                             $"font-family=\"Philosopher, serif\" font-size=\"{fontSize}\" " +
                             $"fill=\"{color}\" text-anchor=\"{anchor}\">{currentLine.Trim()}</text>");
            }
        }
    }
}
