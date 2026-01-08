using System;
using System.Text;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Service for generating sacred geometry SVG paths
    /// </summary>
    public class SacredGeometryService
    {
        public string GenerateGeometrySvg(SacredGeometryConfig config)
        {
            switch (config.Type)
            {
                case SacredGeometryType.FlowerOfLife:
                    return GenerateFlowerOfLife(config);
                case SacredGeometryType.Metatron:
                    return GenerateMetatronsCube(config);
                case SacredGeometryType.SeedOfLife:
                    return GenerateSeedOfLife(config);
                case SacredGeometryType.VesicaPiscis:
                    return GenerateVesicaPiscis(config);
                case SacredGeometryType.Merkaba:
                    return GenerateMerkaba(config);
                case SacredGeometryType.SriYantra:
                    return GenerateSriYantra(config);
                case SacredGeometryType.GoldenSpiral:
                    return GenerateGoldenSpiral(config);
                case SacredGeometryType.TreeOfLife:
                    return GenerateTreeOfLife(config);
                case SacredGeometryType.HexagonGrid:
                    return GenerateHexagonGrid(config);
                default:
                    return string.Empty;
            }
        }

        private string GenerateFlowerOfLife(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double radius = config.Size / 4;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Center circle
            sb.AppendLine($"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{radius}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            // Six circles around center
            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                double x = cx + radius * Math.Cos(angle);
                double y = cy + radius * Math.Sin(angle);
                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{radius}\" " +
                             $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            // Outer ring of circles
            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                double x = cx + 2 * radius * Math.Cos(angle);
                double y = cy + 2 * radius * Math.Sin(angle);
                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{radius}\" " +
                             $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateSeedOfLife(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double radius = config.Size / 3;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Center circle
            sb.AppendLine($"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{radius}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            // Six circles around center
            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                double x = cx + radius * Math.Cos(angle);
                double y = cy + radius * Math.Sin(angle);
                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{radius}\" " +
                             $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateMetatronsCube(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double radius = config.Size / 3;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Calculate points for 13 circles
            var points = new System.Collections.Generic.List<(double x, double y)>();
            points.Add((cx, cy)); // Center

            // Inner ring (6 points)
            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                points.Add((cx + radius * Math.Cos(angle), cy + radius * Math.Sin(angle)));
            }

            // Outer ring (6 points)
            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3 + Math.PI / 6;
                points.Add((cx + radius * 1.732 * Math.Cos(angle), cy + radius * 1.732 * Math.Sin(angle)));
            }

            // Draw all circles
            foreach (var point in points)
            {
                sb.AppendLine($"<circle cx=\"{point.x:F2}\" cy=\"{point.y:F2}\" r=\"{radius / 4}\" " +
                             $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            // Connect all points to create Metatron's Cube
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    sb.AppendLine($"<line x1=\"{points[i].x:F2}\" y1=\"{points[i].y:F2}\" " +
                                 $"x2=\"{points[j].x:F2}\" y2=\"{points[j].y:F2}\" " +
                                 $"stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth * 0.5}\"/>");
                }
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateVesicaPiscis(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double radius = config.Size / 2;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            double offset = radius * 0.866; // sqrt(3)/2
            sb.AppendLine($"<circle cx=\"{cx - offset:F2}\" cy=\"{cy}\" r=\"{radius}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            sb.AppendLine($"<circle cx=\"{cx + offset:F2}\" cy=\"{cy}\" r=\"{radius}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateMerkaba(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double size = config.Size / 2;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Upward triangle
            double h = size * Math.Sqrt(3) / 2;
            sb.AppendLine($"<polygon points=\"{cx},{cy - h * 0.67:F2} " +
                         $"{cx - size / 2},{cy + h * 0.33:F2} {cx + size / 2},{cy + h * 0.33:F2}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            // Downward triangle
            sb.AppendLine($"<polygon points=\"{cx},{cy + h * 0.67:F2} " +
                         $"{cx - size / 2},{cy - h * 0.33:F2} {cx + size / 2},{cy - h * 0.33:F2}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            // Center circle
            sb.AppendLine($"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{size / 4}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateSriYantra(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double size = config.Size / 2;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Outer square
            sb.AppendLine($"<rect x=\"{cx - size:F2}\" y=\"{cy - size:F2}\" " +
                         $"width=\"{size * 2:F2}\" height=\"{size * 2:F2}\" " +
                         $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");

            // Circles
            for (int i = 0; i < 3; i++)
            {
                double r = size * (0.9 - i * 0.25);
                sb.AppendLine($"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{r:F2}\" " +
                             $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            // Nine triangles (simplified representation)
            for (int i = 0; i < 9; i++)
            {
                double angle = i * Math.PI / 4.5;
                double r = size * 0.6;
                bool upward = i % 2 == 0;

                if (upward)
                {
                    double x1 = cx + r * Math.Cos(angle);
                    double y1 = cy + r * Math.Sin(angle);
                    double x2 = cx + r * Math.Cos(angle + Math.PI / 5);
                    double y2 = cy + r * Math.Sin(angle + Math.PI / 5);
                    double x3 = cx + r * Math.Cos(angle - Math.PI / 5);
                    double y3 = cy + r * Math.Sin(angle - Math.PI / 5);

                    sb.AppendLine($"<polygon points=\"{x1:F2},{y1:F2} {x2:F2},{y2:F2} {x3:F2},{y3:F2}\" " +
                                 $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
                }
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateGoldenSpiral(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double size = config.Size;
            double cx = config.CenterX;
            double cy = config.CenterY;
            double phi = 1.618033988749895; // Golden ratio

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Generate Fibonacci spiral
            double x = cx;
            double y = cy;
            double currentSize = size / 10;

            for (int i = 0; i < 8; i++)
            {
                double nextSize = currentSize * phi;

                // Draw quarter circle arc
                int direction = i % 4;
                switch (direction)
                {
                    case 0: // Right-Down
                        sb.AppendLine($"<path d=\"M {x:F2},{y:F2} Q {x + currentSize:F2},{y:F2} " +
                                     $"{x + currentSize:F2},{y + currentSize:F2}\" " +
                                     $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
                        x += currentSize;
                        y += currentSize;
                        break;
                    case 1: // Down-Left
                        sb.AppendLine($"<path d=\"M {x:F2},{y:F2} Q {x:F2},{y + currentSize:F2} " +
                                     $"{x - currentSize:F2},{y + currentSize:F2}\" " +
                                     $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
                        x -= currentSize;
                        break;
                    case 2: // Left-Up
                        sb.AppendLine($"<path d=\"M {x:F2},{y:F2} Q {x - currentSize:F2},{y:F2} " +
                                     $"{x - currentSize:F2},{y - currentSize:F2}\" " +
                                     $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
                        y -= currentSize;
                        break;
                    case 3: // Up-Right
                        sb.AppendLine($"<path d=\"M {x:F2},{y:F2} Q {x:F2},{y - currentSize:F2} " +
                                     $"{x + currentSize:F2},{y - currentSize:F2}\" " +
                                     $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
                        x += currentSize;
                        break;
                }

                currentSize = nextSize;
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateTreeOfLife(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double size = config.Size / 3;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // 10 Sephiroth positions (simplified layout)
            var sephiroth = new[]
            {
                (cx, cy - size * 2),           // Kether
                (cx - size, cy - size),        // Chokmah
                (cx + size, cy - size),        // Binah
                (cx - size, cy),               // Chesed
                (cx + size, cy),               // Geburah
                (cx, cy),                      // Tiphareth
                (cx - size, cy + size),        // Netzach
                (cx + size, cy + size),        // Hod
                (cx, cy + size),               // Yesod
                (cx, cy + size * 2)            // Malkuth
            };

            // Draw paths between sephiroth
            var connections = new[]
            {
                (0, 1), (0, 2), (1, 2), (1, 3), (2, 4),
                (3, 4), (3, 5), (4, 5), (5, 6), (5, 7),
                (6, 7), (6, 8), (7, 8), (8, 9), (3, 6), (4, 7)
            };

            foreach (var (from, to) in connections)
            {
                sb.AppendLine($"<line x1=\"{sephiroth[from].Item1:F2}\" y1=\"{sephiroth[from].Item2:F2}\" " +
                             $"x2=\"{sephiroth[to].Item1:F2}\" y2=\"{sephiroth[to].Item2:F2}\" " +
                             $"stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            // Draw circles for each sephirah
            foreach (var (x, y) in sephiroth)
            {
                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{size / 3:F2}\" " +
                             $"fill=\"none\" stroke=\"{config.Color}\" stroke-width=\"{config.StrokeWidth}\"/>");
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private string GenerateHexagonGrid(SacredGeometryConfig config)
        {
            var sb = new StringBuilder();
            double size = config.Size / 6;
            double cx = config.CenterX;
            double cy = config.CenterY;

            sb.AppendLine($"<g transform=\"rotate({config.Rotation} {cx} {cy})\" opacity=\"{config.Opacity}\">");

            // Generate hexagon grid
            for (int row = -2; row <= 2; row++)
            {
                for (int col = -2; col <= 2; col++)
                {
                    double xOffset = col * size * 1.5;
                    double yOffset = row * size * Math.Sqrt(3) + (col % 2 == 0 ? 0 : size * Math.Sqrt(3) / 2);

                    GenerateHexagon(sb, cx + xOffset, cy + yOffset, size, config.Color, config.StrokeWidth);
                }
            }

            sb.AppendLine("</g>");
            return sb.ToString();
        }

        private void GenerateHexagon(StringBuilder sb, double cx, double cy, double size,
                                    string color, double strokeWidth)
        {
            var points = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                double x = cx + size * Math.Cos(angle);
                double y = cy + size * Math.Sin(angle);
                points.Append($"{x:F2},{y:F2} ");
            }

            sb.AppendLine($"<polygon points=\"{points}\" " +
                         $"fill=\"none\" stroke=\"{color}\" stroke-width=\"{strokeWidth}\"/>");
        }
    }
}
