using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Acme.Wpf.Models;

namespace Acme.Wpf.Services
{
    /// <summary>
    /// Импортер контента из текстовых файлов
    /// Читает файлы из папки CONTENT_IMPORT
    /// </summary>
    public class ContentImporter
    {
        private readonly string _contentFolder;

        public ContentImporter()
        {
            // Путь к папке с контентом (на уровень выше от проекта)
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            _contentFolder = Path.GetFullPath(Path.Combine(projectPath, "..", "..", "..", "..", "CONTENT_IMPORT"));
        }

        /// <summary>
        /// Загрузить Angel Numbers из текстового файла
        /// </summary>
        public AngelNumberContent[] LoadAngelNumbers()
        {
            string filePath = Path.Combine(_contentFolder, "angel_numbers_content.txt");

            // Если файл не существует или пустой - вернуть дефолтные
            if (!File.Exists(filePath) || !HasUserContent(filePath))
            {
                return AngelNumberContent.GetPredefinedNumbers();
            }

            try
            {
                var numbers = new List<AngelNumberContent>();
                string content = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

                // Разделяем на секции по [NUMBER:xxx] ... [END]
                var sections = content.Split(new[] { "[NUMBER:" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var section in sections)
                {
                    if (!section.Contains("[END]"))
                        continue;

                    var angelNumber = ParseAngelNumber(section);
                    if (angelNumber != null)
                        numbers.Add(angelNumber);
                }

                // Если ничего не загрузилось - вернуть дефолтные
                return numbers.Count > 0 ? numbers.ToArray() : AngelNumberContent.GetPredefinedNumbers();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading Angel Numbers: {ex.Message}");
                return AngelNumberContent.GetPredefinedNumbers();
            }
        }

        /// <summary>
        /// Загрузить контент планнера из текстового файла
        /// </summary>
        public PlannerContent[] LoadPlannerMonths()
        {
            string filePath = Path.Combine(_contentFolder, "planner_months_content.txt");

            if (!File.Exists(filePath) || !HasUserContent(filePath))
            {
                return PlannerContent.GetSpiritualAwakeningMonths();
            }

            try
            {
                var months = new List<PlannerContent>();
                string content = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

                var sections = content.Split(new[] { "[MONTH:" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var section in sections)
                {
                    if (!section.Contains("[END]"))
                        continue;

                    var month = ParsePlannerMonth(section);
                    if (month != null)
                        months.Add(month);
                }

                return months.Count > 0 ? months.ToArray() : PlannerContent.GetSpiritualAwakeningMonths();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading Planner Months: {ex.Message}");
                return PlannerContent.GetSpiritualAwakeningMonths();
            }
        }

        /// <summary>
        /// Проверить есть ли пользовательский контент в файле
        /// </summary>
        private bool HasUserContent(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            string content = File.ReadAllText(filePath);
            // Проверяем что файл не пустой и содержит секции
            return content.Contains("[NUMBER:") || content.Contains("[MONTH:");
        }

        /// <summary>
        /// Парсинг секции Angel Number
        /// </summary>
        private AngelNumberContent ParseAngelNumber(string section)
        {
            try
            {
                var lines = section.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Первая строка содержит номер
                string numberLine = lines[0];
                string number = numberLine.Split(']')[0].Trim();

                var angelNumber = new AngelNumberContent { Number = number };
                var practicalSteps = new List<string>();

                foreach (var line in lines.Skip(1))
                {
                    if (line.Trim() == "[END]")
                        break;

                    if (!line.Contains(":"))
                        continue;

                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length != 2)
                        continue;

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "Title":
                            angelNumber.Title = value;
                            break;
                        case "Emoji":
                            angelNumber.Emoji = value;
                            break;
                        case "SoulMeaning":
                            angelNumber.SoulMeaning = value;
                            break;
                        case "EnergeticSignature":
                            angelNumber.EnergeticSignature = value;
                            break;
                        case "DivineMessage":
                            angelNumber.DivineMessage = value;
                            break;
                        case "PracticalStep1":
                        case "PracticalStep2":
                        case "PracticalStep3":
                        case "PracticalStep4":
                        case "PracticalStep5":
                            if (!string.IsNullOrWhiteSpace(value))
                                practicalSteps.Add(value);
                            break;
                        case "Affirmation":
                            angelNumber.Affirmation = value;
                            break;
                        case "ShadowWorkQuestion":
                            angelNumber.ShadowWorkQuestion = value;
                            break;
                        case "FrequencyNote":
                            angelNumber.FrequencyNote = value;
                            break;
                    }
                }

                angelNumber.PracticalSteps = practicalSteps.ToArray();

                // Валидация - если нет основных полей, пропускаем
                if (string.IsNullOrWhiteSpace(angelNumber.Title) ||
                    string.IsNullOrWhiteSpace(angelNumber.SoulMeaning))
                    return null;

                return angelNumber;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error parsing Angel Number: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Парсинг секции месяца планнера
        /// </summary>
        private PlannerContent ParsePlannerMonth(string section)
        {
            try
            {
                var lines = section.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                string monthLine = lines[0];
                string monthName = monthLine.Split(']')[0].Trim();

                var month = new PlannerContent();
                var questions = new List<string>();

                foreach (var line in lines.Skip(1))
                {
                    if (line.Trim() == "[END]")
                        break;

                    if (!line.Contains(":"))
                        continue;

                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length != 2)
                        continue;

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "Theme":
                            month.MonthTheme = value;
                            month.Month = $"{monthName.ToUpper()} 2026";
                            break;
                        case "Quote":
                            month.MonthQuote = value;
                            break;
                        case "NewMoon":
                            month.NewMoonDate = value;
                            break;
                        case "FullMoon":
                            month.FullMoonDate = value;
                            break;
                        case "Question1":
                        case "Question2":
                        case "Question3":
                        case "Question4":
                        case "Question5":
                        case "Question6":
                        case "Question7":
                            if (!string.IsNullOrWhiteSpace(value))
                                questions.Add(value);
                            break;
                    }
                }

                month.WeeklyQuestions = questions.ToArray();

                // Валидация
                if (string.IsNullOrWhiteSpace(month.MonthTheme))
                    return null;

                return month;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error parsing Planner Month: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Получить путь к папке с контентом (для информации пользователю)
        /// </summary>
        public string GetContentFolderPath()
        {
            return _contentFolder;
        }

        /// <summary>
        /// Проверить доступна ли папка с контентом
        /// </summary>
        public bool IsContentFolderAvailable()
        {
            return Directory.Exists(_contentFolder);
        }
    }
}
