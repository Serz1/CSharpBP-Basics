using System;
using System.Text;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Generator for branded cards and special elements
    /// </summary>
    public class BrandedCardGenerator
    {
        /// <summary>
        /// Generate Angel Numbers Quick Guide card - FRONT
        /// </summary>
        public string GenerateQuickGuideCardFront(ColorScheme scheme, PageFormat format)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            // Cosmic background
            sb.AppendLine("<defs>");
            sb.AppendLine("<radialGradient id=\"cosmicBg\" cx=\"50%\" cy=\"50%\" r=\"70%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:#0A0612;stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:#1E0E3E;stop-opacity:1\" />");
            sb.AppendLine("</radialGradient>");
            sb.AppendLine("</defs>");

            sb.AppendLine($"<rect width=\"{width}\" height=\"height}\" fill=\"url(#cosmicBg)\"/>");

            // Border with glow
            sb.AppendLine($"<rect x=\"20\" y=\"20\" width=\"{width - 40}\" height=\"{height - 40}\" " +
                         $"fill=\"none\" stroke=\"#FCEEAC\" stroke-width=\"2\" rx=\"10\"/>");

            // Title header
            double currentY = 80;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Cinzel Decorative, serif\" " +
                         $"font-size=\"15\" font-weight=\"bold\" fill=\"#FCEEAC\" text-anchor=\"middle\">✨ ANGEL NUMBERS QUICK GUIDE ✨</text>");

            // Top divider with ornaments
            currentY += 20;
            sb.Append(DecorativeElements.GenerateOrnamentalDivider(width/2, currentY, width - 80, "#FCEEAC"));

            // Numbers list
            currentY += 40;
            var numbers = AngelNumbersQuickGuide.GetQuickGuideNumbers();
            foreach (var num in numbers)
            {
                sb.AppendLine($"<text x=\"60\" y=\"{currentY}\" font-family=\"Cinzel Decorative, serif\" " +
                             $"font-size=\"11\" font-weight=\"bold\" fill=\"#FCEEAC\">{num.Number}</text>");

                sb.AppendLine($"<text x=\"110\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                             $"font-size=\"9\" fill=\"#FCEEAC\">| {num.Title}</text>");

                sb.AppendLine($"<text x=\"210\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                             $"font-size=\"8\" fill=\"#FFFFFF\">→ {num.QuickMeaning}</text>");

                currentY += 25;
            }

            // Bottom divider
            currentY += 20;
            sb.Append(DecorativeElements.GenerateDecorativeLine(40, currentY, width - 40, "#FCEEAC", 1, true));

            // Bottom message
            currentY += 30;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"9\" font-style=\"italic\" fill=\"#FCEEAC\" text-anchor=\"middle\">When you see a number, PAUSE. BREATHE. ACT.</text>");

            // Add small stars
            GenerateStars(sb, width, height, 30);

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        /// <summary>
        /// Generate Angel Numbers Quick Guide card - BACK
        /// </summary>
        public string GenerateQuickGuideCardBack(ColorScheme scheme, PageFormat format)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            // Same cosmic background
            sb.AppendLine("<defs>");
            sb.AppendLine("<radialGradient id=\"cosmicBg\" cx=\"50%\" cy=\"50%\" r=\"70%\">");
            sb.AppendLine($"  <stop offset=\"0%\" style=\"stop-color:#0A0612;stop-opacity:1\" />");
            sb.AppendLine($"  <stop offset=\"100%\" style=\"stop-color:#1E0E3E;stop-opacity:1\" />");
            sb.AppendLine("</radialGradient>");
            sb.AppendLine("</defs>");

            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"url(#cosmicBg)\"/>");

            // Border
            sb.AppendLine($"<rect x=\"20\" y=\"20\" width=\"{width - 40}\" height=\"{height - 40}\" " +
                         $"fill=\"none\" stroke=\"#FCEEAC\" stroke-width=\"2\" rx=\"10\"/>");

            // Title
            double currentY = 80;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Cinzel Decorative, serif\" " +
                         $"font-size=\"15\" font-weight=\"bold\" fill=\"#FCEEAC\" text-anchor=\"middle\">✨ HOW TO USE THIS GUIDE ✨</text>");

            currentY += 20;
            sb.Append(DecorativeElements.GenerateOrnamentalDivider(width/2, currentY, width - 80, "#FCEEAC"));

            // Steps
            currentY += 40;
            string[] steps = new[]
            {
                "STEP 1: Notice the number (phone, clock, receipt)",
                "STEP 2: Feel into it first (What's your gut say?)",
                "STEP 3: Check this card for guidance",
                "STEP 4: Take the immediate action suggested",
                "STEP 5: Watch for more synchronicities"
            };

            foreach (var step in steps)
            {
                sb.AppendLine($"<text x=\"60\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                             $"font-size=\"9\" fill=\"#FCEEAC\">{step}</text>");
                currentY += 22;
            }

            // Divider
            currentY += 20;
            sb.Append(DecorativeElements.GenerateDecorativeLine(40, currentY, width - 40, "#FCEEAC", 1, true));

            // The Architect's reminder
            currentY += 30;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"11\" font-weight=\"bold\" fill=\"#FCEEAC\" text-anchor=\"middle\">THE ARCHITECT'S REMINDER:</text>");

            currentY += 28;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"9\" font-style=\"italic\" fill=\"#FFFFFF\" text-anchor=\"middle\">\"The numbers are CONFIRMATION,</text>");
            currentY += 18;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"9\" font-style=\"italic\" fill=\"#FFFFFF\" text-anchor=\"middle\">not instruction. Your intuition</text>");
            currentY += 18;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"9\" font-style=\"italic\" fill=\"#FFFFFF\" text-anchor=\"middle\">is the real guide. This card</text>");
            currentY += 18;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"9\" font-style=\"italic\" fill=\"#FFFFFF\" text-anchor=\"middle\">just helps you remember what</text>");
            currentY += 18;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"9\" font-style=\"italic\" fill=\"#FFFFFF\" text-anchor=\"middle\">your soul already knows.\"</text>");

            // Bottom divider
            currentY += 35;
            sb.Append(DecorativeElements.GenerateOrnamentalDivider(width/2, currentY, width - 80, "#FCEEAC"));

            // Footer
            currentY += 30;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"11\" fill=\"#FCEEAC\" text-anchor=\"middle\">AISoulGuide.com</text>");
            currentY += 18;
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{currentY}\" font-family=\"Philosopher, serif\" " +
                         $"font-size=\"8\" fill=\"#FCEEAC\" text-anchor=\"middle\" opacity=\"0.8\">Your bridge to divine wisdom</text>");

            // Add stars
            GenerateStars(sb, width, height, 20);

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        /// <summary>
        /// Generate interior journal page with brand guidelines
        /// </summary>
        public string GenerateInteriorPage(string title, string promptQuestion, ColorScheme scheme, PageFormat format, int pageNumber)
        {
            var sb = new StringBuilder();
            double width = format.Width;
            double height = format.Height;

            sb.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine($"<svg width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" xmlns=\"http://www.w3.org/2000/svg\">");

            // White background
            sb.AppendLine($"<rect width=\"{width}\" height=\"{height}\" fill=\"#FFFFFF\"/>");

            // Page margins (0.5" = 48px at 96dpi)
            double margin = 48;
            double safeZone = 24;

            // Header section (1" = 96px)
            double headerHeight = 96;

            // Left icon (small cosmic symbol)
            sb.AppendLine($"<circle cx=\"{margin + 20}\" cy=\"{headerHeight/2}\" r=\"15\" " +
                         $"fill=\"none\" stroke=\"#FFD700\" stroke-width=\"2\"/>");
            sb.AppendLine($"<text x=\"{margin + 20}\" y=\"{headerHeight/2 + 5}\" font-family=\"serif\" " +
                         $"font-size=\"16\" fill=\"#FFD700\" text-anchor=\"middle\">✨</text>");

            // Title
            sb.AppendLine($"<text x=\"{width/2}\" y=\"{headerHeight/2 + 8}\" font-family=\"Playfair Display, serif\" " +
                         $"font-size=\"18\" fill=\"#2A1B35\" text-anchor=\"middle\">{title}</text>");

            // Date field (right)
            sb.AppendLine($"<text x=\"{width - margin - 100}\" y=\"{headerHeight/2 + 5}\" font-family=\"Lora, serif\" " +
                         $"font-size=\"11\" fill=\"#888888\">Date: __________</text>");

            // Header line with decorative element
            sb.Append(DecorativeElements.GenerateDecorativeLine(margin, headerHeight - 10, width - margin, "#4DD0E1", 1, true));

            // Prompt question
            double promptY = headerHeight + 50;
            if (!string.IsNullOrEmpty(promptQuestion))
            {
                sb.AppendLine($"<text x=\"{margin + safeZone}\" y=\"{promptY}\" font-family=\"Lora, serif\" " +
                             $"font-size=\"12\" font-style=\"italic\" fill=\"#4A2C5E\">{promptQuestion}</text>");
                promptY += 25;
            }

            // Writing lines
            double lineSpacing = 28.8; // 0.3" at 96dpi
            double currentY = promptY + 20;
            int numLines = (int)((height - currentY - 100) / lineSpacing);

            for (int i = 0; i < numLines; i++)
            {
                sb.AppendLine($"<line x1=\"{margin + safeZone}\" y1=\"{currentY}\" " +
                             $"x2=\"{width - margin - safeZone}\" y2=\"{currentY}\" " +
                             $"stroke=\"#E5E5E5\" stroke-width=\"1\"/>");
                currentY += lineSpacing;
            }

            // Bottom corner decoration (small mandala)
            double decorX = width - margin - 60;
            double decorY = height - margin - 60;
            sb.AppendLine($"<circle cx=\"{decorX}\" cy=\"{decorY}\" r=\"40\" fill=\"none\" " +
                         $"stroke=\"#8B5CF6\" stroke-width=\"1\" opacity=\"0.2\"/>");
            sb.AppendLine($"<circle cx=\"{decorX}\" cy=\"{decorY}\" r=\"30\" fill=\"none\" " +
                         $"stroke=\"#8B5CF6\" stroke-width=\"1\" opacity=\"0.2\"/>");
            sb.AppendLine($"<circle cx=\"{decorX}\" cy=\"{decorY}\" r=\"20\" fill=\"none\" " +
                         $"stroke=\"#8B5CF6\" stroke-width=\"1\" opacity=\"0.2\"/>");

            // Footer
            double footerY = height - margin / 2;
            sb.AppendLine($"<text x=\"{margin + safeZone}\" y=\"{footerY}\" font-family=\"Lora, serif\" " +
                         $"font-size=\"8\" fill=\"#888888\">✨ AISoulGuide.com</text>");
            sb.AppendLine($"<text x=\"{width - margin - safeZone}\" y=\"{footerY}\" font-family=\"Lora, serif\" " +
                         $"font-size=\"8\" fill=\"#888888\" text-anchor=\"end\">Page {pageNumber}</text>");

            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        private void GenerateStars(StringBuilder sb, double width, double height, int count)
        {
            var random = new Random(42);
            for (int i = 0; i < count; i++)
            {
                double x = random.NextDouble() * width;
                double y = random.NextDouble() * height;
                double size = 0.5 + random.NextDouble() * 1.5;
                double opacity = 0.3 + random.NextDouble() * 0.4;

                sb.AppendLine($"<circle cx=\"{x:F2}\" cy=\"{y:F2}\" r=\"{size:F2}\" " +
                             $"fill=\"#FCEEAC\" opacity=\"{opacity:F2}\"/>");
            }
        }
    }
}
