using System;
using System.IO;
using System.Text;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Service for generating complete template SVGs
    /// </summary>
    public class TemplateSvgGenerator
    {
        private readonly SacredGeometryService _geometryService;
        private readonly Random _random;

        public TemplateSvgGenerator()
        {
            _geometryService = new SacredGeometryService();
            _random = new Random();
        }

        public string GenerateTemplate(TemplateConfig config)
        {
            var sb = new StringBuilder();
            double width = config.PageFormat.Width;
            double height = config.PageFormat.Height;

            // SVG header
            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" " +
                         $"viewBox=\"0 0 {width} {height}\" " +
                         $"xmlns=\"http://www.w3.org/2000/svg\" " +
                         $"xmlns:xlink=\"http://www.w3.org/1999/xlink\">");

            // Definitions for gradients and patterns
            sb.AppendLine("<defs>");
            GenerateGradients(sb, config);
            GenerateStarPattern(sb);
            sb.AppendLine("</defs>");

            // Background with gradient
            GenerateBackground(sb, width, height, config);

            // Stars overlay
            if (config.ShowStars)
            {
                GenerateStarsOverlay(sb, width, height);
            }

            // Frame
            if (config.FrameStyle != FrameStyle.None)
            {
                GenerateFrame(sb, width, height, config);
            }

            // Sacred geometry elements
            foreach (var geom in config.GeometryElements)
            {
                sb.AppendLine(_geometryService.GenerateGeometrySvg(geom));
            }

            // Gradient overlay
            if (config.ShowGradientOverlay)
            {
                GenerateGradientOverlay(sb, width, height);
            }

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        private void GenerateGradients(StringBuilder sb, TemplateConfig config)
        {
            // Radial gradient for background
            sb.AppendLine("<radialGradient id=\"bgGradient\" cx=\"50%\" cy=\"50%\" r=\"50%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:{config.ColorScheme.BackgroundGradientStart};stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:{config.ColorScheme.BackgroundGradientEnd};stop-opacity:1\" />");
            sb.AppendLine("</radialGradient>");

            // Linear gradient for overlay
            sb.AppendLine("<linearGradient id=\"overlayGradient\" x1=\"0%\" y1=\"0%\" x2=\"0%\" y2=\"100%\">");
            sb.AppendLine("  <stop offset=\"0%\" style=\"stop-color:#000000;stop-opacity:0\" />");
            sb.AppendLine("  <stop offset=\"100%\" style=\"stop-color:#000000;stop-opacity:0.3\" />");
            sb.AppendLine("</linearGradient>");

            // Gold gradient for frame
            sb.AppendLine("<linearGradient id=\"goldGradient\" x1=\"0%\" y1=\"0%\" x2=\"100%\" y2=\"100%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:{config.ColorScheme.FrameColor};stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"50%\" style=\"stop-color:#FFF8DC;stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:{config.ColorScheme.FrameColor};stop-opacity:1\" />");
            sb.AppendLine("</linearGradient>");
        }

        private void GenerateStarPattern(StringBuilder sb)
        {
            sb.AppendLine("<symbol id=\"star\" viewBox=\"0 0 10 10\">");
            sb.AppendLine("  <circle cx=\"5\" cy=\"5\" r=\"1\" fill=\"white\" opacity=\"0.8\"/>");
            sb.AppendLine("  <circle cx=\"5\" cy=\"5\" r=\"0.5\" fill=\"white\" opacity=\"1\"/>");
            sb.AppendLine("</symbol>");
        }

        private void GenerateBackground(StringBuilder sb, double width, double height, TemplateConfig config)
        {
            sb.AppendLine($"<rect x=\"0\" y=\"0\" width=\"{width}\" height=\"{height}\" fill=\"url(#bgGradient)\"/>");
        }

        private void GenerateStarsOverlay(StringBuilder sb, double width, double height)
        {
            sb.AppendLine("<g id=\"stars\" opacity=\"0.6\">");

            // Generate random stars
            for (int i = 0; i < 100; i++)
            {
                double x = _random.NextDouble() * width;
                double y = _random.NextDouble() * height;
                double size = 0.5 + _random.NextDouble() * 2;
                double opacity = 0.3 + _random.NextDouble() * 0.7;

                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{size:F2}\" " +
                             $"fill=\"white\" opacity=\"{opacity:F2}\"/>");
            }

            sb.AppendLine("</g>");
        }

        private void GenerateFrame(StringBuilder sb, double width, double height, TemplateConfig config)
        {
            double thickness = config.FrameThickness;
            double innerMargin = config.FrameInnerMargin;

            switch (config.FrameStyle)
            {
                case FrameStyle.SimpleGold:
                    GenerateSimpleFrame(sb, width, height, thickness, config);
                    break;
                case FrameStyle.OrnateGold:
                    GenerateOrnateFrame(sb, width, height, thickness, config);
                    break;
                case FrameStyle.CelestialBorder:
                    GenerateCelestialFrame(sb, width, height, thickness, config);
                    break;
                case FrameStyle.GeometricFrame:
                    GenerateGeometricFrame(sb, width, height, thickness, config);
                    break;
            }
        }

        private void GenerateSimpleFrame(StringBuilder sb, double width, double height,
                                        double thickness, TemplateConfig config)
        {
            // Outer rectangle
            sb.AppendLine($"<rect x=\"{thickness}\" y=\"{thickness}\" " +
                         $"width=\"{width - 2 * thickness}\" height=\"{height - 2 * thickness}\" " +
                         $"fill=\"none\" stroke=\"url(#goldGradient)\" stroke-width=\"{thickness}\"/>");

            // Inner rectangle
            double innerThickness = thickness + config.FrameInnerMargin;
            sb.AppendLine($"<rect x=\"{innerThickness}\" y=\"{innerThickness}\" " +
                         $"width=\"{width - 2 * innerThickness}\" height=\"{height - 2 * innerThickness}\" " +
                         $"fill=\"none\" stroke=\"{config.ColorScheme.FrameColor}\" stroke-width=\"2\"/>");
        }

        private void GenerateOrnateFrame(StringBuilder sb, double width, double height,
                                        double thickness, TemplateConfig config)
        {
            // Base frame
            GenerateSimpleFrame(sb, width, height, thickness, config);

            // Corner ornaments
            double cornerSize = thickness * 2;
            var corners = new[]
            {
                (thickness, thickness),
                (width - thickness - cornerSize, thickness),
                (thickness, height - thickness - cornerSize),
                (width - thickness - cornerSize, height - thickness - cornerSize)
            };

            foreach (var (x, y) in corners)
            {
                // Corner decorative circles
                sb.AppendLine($"<circle cx=\"{x + cornerSize / 2}\" cy=\"{y + cornerSize / 2}\" " +
                             $"r=\"{cornerSize / 3}\" fill=\"none\" stroke=\"{config.ColorScheme.FrameColor}\" stroke-width=\"2\"/>");

                // Corner star pattern
                for (int i = 0; i < 4; i++)
                {
                    double angle = i * Math.PI / 2;
                    double sx = x + cornerSize / 2 + Math.Cos(angle) * cornerSize / 2;
                    double sy = y + cornerSize / 2 + Math.Sin(angle) * cornerSize / 2;
                    sb.AppendLine($"<circle cx=\"{sx:F2}\" cy=\"{sy:F2}\" r=\"2\" " +
                                 $"fill=\"{config.ColorScheme.FrameColor}\"/>");
                }
            }
        }

        private void GenerateCelestialFrame(StringBuilder sb, double width, double height,
                                           double thickness, TemplateConfig config)
        {
            // Base frame
            GenerateSimpleFrame(sb, width, height, thickness, config);

            // Add celestial symbols (moon phases, stars)
            double spacing = Math.Min(width, height) / 10;

            // Top border symbols
            for (double x = thickness * 3; x < width - thickness * 3; x += spacing)
            {
                sb.AppendLine($"<circle cx=\"{x}\" cy=\"{thickness / 2}\" r=\"5\" " +
                             $"fill=\"{config.ColorScheme.AccentColor}\" opacity=\"0.7\"/>");
            }

            // Bottom border symbols
            for (double x = thickness * 3; x < width - thickness * 3; x += spacing)
            {
                sb.AppendLine($"<circle cx=\"{x}\" cy=\"{height - thickness / 2}\" r=\"5\" " +
                             $"fill=\"{config.ColorScheme.AccentColor}\" opacity=\"0.7\"/>");
            }
        }

        private void GenerateGeometricFrame(StringBuilder sb, double width, double height,
                                           double thickness, TemplateConfig config)
        {
            // Multiple nested rectangles
            for (int i = 0; i < 3; i++)
            {
                double offset = thickness + i * 10;
                sb.AppendLine($"<rect x=\"{offset}\" y=\"{offset}\" " +
                             $"width=\"{width - 2 * offset}\" height=\"{height - 2 * offset}\" " +
                             $"fill=\"none\" stroke=\"{config.ColorScheme.FrameColor}\" " +
                             $"stroke-width=\"{2 - i * 0.5}\"/>");
            }

            // Corner triangles
            double triSize = thickness * 1.5;
            sb.AppendLine($"<polygon points=\"{thickness},{thickness} {thickness + triSize},{thickness} {thickness},{thickness + triSize}\" " +
                         $"fill=\"{config.ColorScheme.AccentColor}\" opacity=\"0.5\"/>");
            sb.AppendLine($"<polygon points=\"{width - thickness},{thickness} {width - thickness - triSize},{thickness} {width - thickness},{thickness + triSize}\" " +
                         $"fill=\"{config.ColorScheme.AccentColor}\" opacity=\"0.5\"/>");
            sb.AppendLine($"<polygon points=\"{thickness},{height - thickness} {thickness + triSize},{height - thickness} {thickness},{height - thickness - triSize}\" " +
                         $"fill=\"{config.ColorScheme.AccentColor}\" opacity=\"0.5\"/>");
            sb.AppendLine($"<polygon points=\"{width - thickness},{height - thickness} {width - thickness - triSize},{height - thickness} {width - thickness},{height - thickness - triSize}\" " +
                         $"fill=\"{config.ColorScheme.AccentColor}\" opacity=\"0.5\"/>");
        }

        private void GenerateGradientOverlay(StringBuilder sb, double width, double height)
        {
            sb.AppendLine($"<rect x=\"0\" y=\"0\" width=\"{width}\" height=\"{height}\" " +
                         $"fill=\"url(#overlayGradient)\" opacity=\"0.3\"/>");
        }

        public void SaveToFile(string svgContent, string filePath)
        {
            File.WriteAllText(filePath, svgContent);
        }
    }
}
