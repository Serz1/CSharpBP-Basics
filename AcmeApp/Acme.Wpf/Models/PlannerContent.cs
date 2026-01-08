namespace Acme.Wpf.Models
{
    /// <summary>
    /// Planner-specific content and layouts
    /// </summary>
    public class PlannerContent
    {
        public string Month { get; set; }
        public string MonthTheme { get; set; }
        public string MonthQuote { get; set; }
        public string NewMoonDate { get; set; }
        public string FullMoonDate { get; set; }
        public string[] WeeklyQuestions { get; set; }
        public PlannerType PlannerType { get; set; }

        public PlannerContent()
        {
            WeeklyQuestions = new string[7];
        }

        public static PlannerContent[] GetSpiritualAwakeningMonths()
        {
            return new[]
            {
                new PlannerContent
                {
                    Month = "JANUARY 2026",
                    MonthTheme = "INTENTION",
                    MonthQuote = "What foundation are you building this year?",
                    NewMoonDate = "January 29",
                    FullMoonDate = "January 13 (Wolf Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What are you grateful for AND what's challenging you today?",
                        "Where are you forcing instead of flowing?",
                        "What truth are you avoiding?",
                        "How did you honor your energy today?",
                        "What synchronicity appeared?",
                        "What did you release this week?",
                        "What's ready to be born?"
                    }
                },
                new PlannerContent
                {
                    Month = "FEBRUARY 2026",
                    MonthTheme = "FOUNDATION",
                    MonthQuote = "What solid ground can you stand on?",
                    NewMoonDate = "February 27",
                    FullMoonDate = "February 12 (Snow Moon)",
                    WeeklyQuestions = new[]
                    {
                        "Is your foundation built on truth or fear?",
                        "What needs to be grounded today?",
                        "Where are you building on sand?",
                        "How stable do you feel?",
                        "What practice grounds you most?",
                        "What foundation cracked this week?",
                        "What's becoming solid?"
                    }
                }
            };
        }
    }

    public enum PlannerType
    {
        SpiritualAwakening,
        BusinessVisionary,
        CreativeMuse
    }

    public enum PlannerPageType
    {
        Cover,
        Welcome,
        HowToUse,
        MonthCover,
        MonthlyCalendar,
        WeeklySpread,
        MonthlyIntegration,
        YearReview,
        EmergencySoulCare,
        Affirmations
    }

    /// <summary>
    /// Daily tracker entry for planner
    /// </summary>
    public class DailyTrackerContent
    {
        public string DayOfWeek { get; set; }
        public string Date { get; set; }
        public string[] TodoItems { get; set; }
        public bool[] PracticeChecks { get; set; }
        public string ArchitectQuestion { get; set; }

        public DailyTrackerContent()
        {
            TodoItems = new string[3];
            PracticeChecks = new bool[4]; // Meditation, Movement, Journal, Other
        }
    }
}
