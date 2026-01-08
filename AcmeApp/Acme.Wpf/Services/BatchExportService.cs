using System;
using System.IO;
using System.Text;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Service for batch exporting all templates at once
    /// </summary>
    public class BatchExportService
    {
        private readonly SpecializedTemplateGenerator _specializedGen;
        private readonly BrandedCardGenerator _brandedGen;
        private readonly PlannerPageGenerator _plannerGen;
        private readonly TemplateSvgGenerator _templateGen;

        public BatchExportService()
        {
            _specializedGen = new SpecializedTemplateGenerator();
            _brandedGen = new BrandedCardGenerator();
            _plannerGen = new PlannerPageGenerator();
            _templateGen = new TemplateSvgGenerator();
        }

        /// <summary>
        /// Export all Angel Number cards (front and back) for all 9 numbers
        /// </summary>
        public int ExportAllAngelCards(string outputFolder, ColorScheme scheme)
        {
            int count = 0;
            var numbers = AngelNumberContent.GetPredefinedNumbers();
            var cardFormat = PageFormat.GetFormat(PageFormatType.CardStandard);

            foreach (var number in numbers)
            {
                // Front card
                var frontSvg = _specializedGen.GenerateAngelCardFront(
                    number, scheme, cardFormat, SacredGeometryType.Metatron);

                string frontPath = Path.Combine(outputFolder, $"angel-card-{number.Number}-front.svg");
                File.WriteAllText(frontPath, frontSvg, Encoding.UTF8);
                count++;

                // Back card
                var backSvg = _specializedGen.GenerateAngelCardBack(
                    scheme, cardFormat, "Shadow Awakening Edition");

                string backPath = Path.Combine(outputFolder, $"angel-card-{number.Number}-back.svg");
                File.WriteAllText(backPath, backSvg, Encoding.UTF8);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Export all Angel Number book spreads (2-page) for all 9 numbers
        /// </summary>
        public int ExportAllBookSpreads(string outputFolder, ColorScheme scheme)
        {
            int count = 0;
            var numbers = AngelNumberContent.GetPredefinedNumbers();
            var spreadFormat = PageFormat.GetFormat(PageFormatType.BookSpread);

            foreach (var number in numbers)
            {
                var spreadSvg = _specializedGen.GenerateBookSpread(number, scheme, spreadFormat);

                string path = Path.Combine(outputFolder, $"book-spread-{number.Number}.svg");
                File.WriteAllText(path, spreadSvg, Encoding.UTF8);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Export Quick Guide cards (front and back)
        /// </summary>
        public int ExportQuickGuideCards(string outputFolder, ColorScheme scheme)
        {
            int count = 0;
            var cardFormat = PageFormat.GetFormat(PageFormatType.CardStandard);

            // Front card
            var frontSvg = _brandedGen.GenerateQuickGuideCardFront(scheme, cardFormat);
            string frontPath = Path.Combine(outputFolder, "quick-guide-card-front.svg");
            File.WriteAllText(frontPath, frontSvg, Encoding.UTF8);
            count++;

            // Back card
            var backSvg = _brandedGen.GenerateQuickGuideCardBack(scheme, cardFormat);
            string backPath = Path.Combine(outputFolder, "quick-guide-card-back.svg");
            File.WriteAllText(backPath, backSvg, Encoding.UTF8);
            count++;

            return count;
        }

        /// <summary>
        /// Export all planner month covers for the year
        /// </summary>
        public int ExportAllPlannerMonths(string outputFolder, ColorScheme scheme)
        {
            int count = 0;
            var months = PlannerContent.GetSpiritualAwakeningMonths();
            var pageFormat = PageFormat.GetFormat(PageFormatType.USLetter);

            foreach (var month in months)
            {
                var monthSvg = _plannerGen.GenerateMonthCover(month, scheme, pageFormat);

                string monthName = month.Month.Split(' ')[0].ToLower();
                string path = Path.Combine(outputFolder, $"planner-month-{monthName}.svg");
                File.WriteAllText(path, monthSvg, Encoding.UTF8);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Export sample journal interior pages
        /// </summary>
        public int ExportSampleJournalPages(string outputFolder, ColorScheme scheme, int pageCount = 5)
        {
            int count = 0;
            var pageFormat = PageFormat.GetFormat(PageFormatType.USLetter);

            string[] prompts = new[]
            {
                "What truth revealed itself to you today?",
                "Where did you witness magic in the ordinary?",
                "What are you being called to release?",
                "What part of you is ready to emerge?",
                "What gratitude fills your heart right now?"
            };

            string[] titles = new[]
            {
                "Today's Truth",
                "Magic Moments",
                "Release & Let Go",
                "Emergence",
                "Gratitude Flow"
            };

            for (int i = 0; i < Math.Min(pageCount, prompts.Length); i++)
            {
                var pageSvg = _brandedGen.GenerateInteriorPage(
                    titles[i], prompts[i], scheme, pageFormat, i + 1);

                string path = Path.Combine(outputFolder, $"journal-page-{i + 1:D2}.svg");
                File.WriteAllText(path, pageSvg, Encoding.UTF8);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Export background templates with different sacred geometry
        /// </summary>
        public int ExportBackgroundTemplates(string outputFolder, ColorScheme scheme)
        {
            int count = 0;
            var pageFormat = PageFormat.GetFormat(PageFormatType.Square);

            var geometryTypes = new[]
            {
                SacredGeometryType.FlowerOfLife,
                SacredGeometryType.Metatron,
                SacredGeometryType.SriYantra,
                SacredGeometryType.VesicaPiscis,
                SacredGeometryType.SeedOfLife
            };

            foreach (var geomType in geometryTypes)
            {
                var config = new TemplateConfig
                {
                    PageFormat = pageFormat,
                    ColorScheme = scheme,
                    TemplateType = TemplateType.Background,
                    GeometryElements = new[] { geomType }
                };

                var bgSvg = _templateGen.GenerateTemplate(config);

                string geomName = geomType.ToString().ToLower();
                string path = Path.Combine(outputFolder, $"background-{geomName}.svg");
                File.WriteAllText(path, bgSvg, Encoding.UTF8);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Export EVERYTHING - complete product collection
        /// </summary>
        public BatchExportResult ExportCompleteCollection(string baseFolder, ColorScheme scheme)
        {
            var result = new BatchExportResult();

            try
            {
                // Create subfolders
                string cardsFolder = Path.Combine(baseFolder, "Angel-Cards");
                string spreadsFolder = Path.Combine(baseFolder, "Book-Spreads");
                string quickGuideFolder = Path.Combine(baseFolder, "Quick-Guide");
                string plannerFolder = Path.Combine(baseFolder, "Planner-Months");
                string journalFolder = Path.Combine(baseFolder, "Journal-Pages");
                string backgroundsFolder = Path.Combine(baseFolder, "Backgrounds");

                Directory.CreateDirectory(cardsFolder);
                Directory.CreateDirectory(spreadsFolder);
                Directory.CreateDirectory(quickGuideFolder);
                Directory.CreateDirectory(plannerFolder);
                Directory.CreateDirectory(journalFolder);
                Directory.CreateDirectory(backgroundsFolder);

                // Export all content
                result.AngelCardsExported = ExportAllAngelCards(cardsFolder, scheme);
                result.BookSpreadsExported = ExportAllBookSpreads(spreadsFolder, scheme);
                result.QuickGuideExported = ExportQuickGuideCards(quickGuideFolder, scheme);
                result.PlannerMonthsExported = ExportAllPlannerMonths(plannerFolder, scheme);
                result.JournalPagesExported = ExportSampleJournalPages(journalFolder, scheme, 10);
                result.BackgroundsExported = ExportBackgroundTemplates(backgroundsFolder, scheme);

                result.TotalExported = result.AngelCardsExported + result.BookSpreadsExported +
                                      result.QuickGuideExported + result.PlannerMonthsExported +
                                      result.JournalPagesExported + result.BackgroundsExported;

                result.Success = true;
                result.Message = $"Successfully exported {result.TotalExported} files to {baseFolder}";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Export failed: {ex.Message}";
            }

            return result;
        }
    }

    /// <summary>
    /// Result of batch export operation
    /// </summary>
    public class BatchExportResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int TotalExported { get; set; }
        public int AngelCardsExported { get; set; }
        public int BookSpreadsExported { get; set; }
        public int QuickGuideExported { get; set; }
        public int PlannerMonthsExported { get; set; }
        public int JournalPagesExported { get; set; }
        public int BackgroundsExported { get; set; }

        public string GetSummary()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"📦 EXPORT COMPLETE - {TotalExported} files total");
            sb.AppendLine();
            sb.AppendLine($"📇 Angel Cards: {AngelCardsExported} files");
            sb.AppendLine($"📖 Book Spreads: {BookSpreadsExported} files");
            sb.AppendLine($"✨ Quick Guide: {QuickGuideExported} files");
            sb.AppendLine($"📅 Planner Months: {PlannerMonthsExported} files");
            sb.AppendLine($"📝 Journal Pages: {JournalPagesExported} files");
            sb.AppendLine($"🎨 Backgrounds: {BackgroundsExported} files");
            return sb.ToString();
        }
    }
}
