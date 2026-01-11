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

        /// <summary>
        /// Получить месяцы планнера из импорта (если есть) или дефолтные
        /// </summary>
        public static PlannerContent[] GetMonths()
        {
            try
            {
                var importer = new Services.ContentImporter();
                return importer.LoadPlannerMonths();
            }
            catch
            {
                return GetSpiritualAwakeningMonths();
            }
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
                },
                new PlannerContent
                {
                    Month = "MARCH 2026",
                    MonthTheme = "AWAKENING",
                    MonthQuote = "What part of you is ready to wake up?",
                    NewMoonDate = "March 29",
                    FullMoonDate = "March 14 (Worm Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What old pattern is dissolving?",
                        "Where are you coming alive?",
                        "What truth just revealed itself?",
                        "How does your awakening feel in your body?",
                        "What no longer fits the new you?",
                        "What perspective shifted this week?",
                        "Who are you becoming?"
                    }
                },
                new PlannerContent
                {
                    Month = "APRIL 2026",
                    MonthTheme = "COURAGE",
                    MonthQuote = "What bold move is yours to make?",
                    NewMoonDate = "April 27",
                    FullMoonDate = "April 13 (Pink Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What conversation needs to happen?",
                        "Where are you playing small?",
                        "What boundary needs to be set?",
                        "How did you show up brave today?",
                        "What fear did you move through?",
                        "What was your bravest act this week?",
                        "What's on the other side of your fear?"
                    }
                },
                new PlannerContent
                {
                    Month = "MAY 2026",
                    MonthTheme = "BLOOM",
                    MonthQuote = "What beauty are you ready to express?",
                    NewMoonDate = "May 26",
                    FullMoonDate = "May 12 (Flower Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What gift wants to emerge?",
                        "How are you sharing your light?",
                        "What creative urge is stirring?",
                        "Where did you bloom today?",
                        "What expression feels authentic?",
                        "What beauty did you create this week?",
                        "Who witnesses your flowering?"
                    }
                },
                new PlannerContent
                {
                    Month = "JUNE 2026",
                    MonthTheme = "ILLUMINATE",
                    MonthQuote = "What truth are you being called to speak?",
                    NewMoonDate = "June 25",
                    FullMoonDate = "June 11 (Strawberry Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What's ready to be seen?",
                        "Where are you hiding your power?",
                        "What message wants to be shared?",
                        "How did you shine today?",
                        "What shadow are you integrating?",
                        "What truth emerged this week?",
                        "Who needs your light right now?"
                    }
                },
                new PlannerContent
                {
                    Month = "JULY 2026",
                    MonthTheme = "INTEGRATION",
                    MonthQuote = "How are you becoming whole?",
                    NewMoonDate = "July 24",
                    FullMoonDate = "July 10 (Buck Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What fragmented parts are reuniting?",
                        "Where are you healing division?",
                        "What paradox can you hold?",
                        "How did you practice wholeness today?",
                        "What did you integrate?",
                        "What became unified this week?",
                        "What's your next level of wholeness?"
                    }
                },
                new PlannerContent
                {
                    Month = "AUGUST 2026",
                    MonthTheme = "HARVEST",
                    MonthQuote = "What are you reaping from what you planted?",
                    NewMoonDate = "August 23",
                    FullMoonDate = "August 9 (Sturgeon Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What work is paying off?",
                        "What abundance surrounds you?",
                        "What fruit is your labor bearing?",
                        "How did you celebrate wins today?",
                        "What did you receive?",
                        "What reward arrived this week?",
                        "What's ready to be gathered?"
                    }
                },
                new PlannerContent
                {
                    Month = "SEPTEMBER 2026",
                    MonthTheme = "WISDOM",
                    MonthQuote = "What has experience taught you?",
                    NewMoonDate = "September 21",
                    FullMoonDate = "September 8 (Corn Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What lesson keeps repeating?",
                        "What truth did you finally understand?",
                        "Where are you the teacher now?",
                        "What wisdom did you embody today?",
                        "What mistake became medicine?",
                        "What insight crystallized this week?",
                        "What do you know for sure?"
                    }
                },
                new PlannerContent
                {
                    Month = "OCTOBER 2026",
                    MonthTheme = "DEATH & REBIRTH",
                    MonthQuote = "What must die for new life to emerge?",
                    NewMoonDate = "October 21",
                    FullMoonDate = "October 7 (Hunter's Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What are you composting?",
                        "What death are you grieving?",
                        "What's being born from the decay?",
                        "How did you honor endings today?",
                        "What did you let go of?",
                        "What transformation happened this week?",
                        "What phoenix is rising from your ashes?"
                    }
                },
                new PlannerContent
                {
                    Month = "NOVEMBER 2026",
                    MonthTheme = "GRATITUDE",
                    MonthQuote = "What blessings surround you right now?",
                    NewMoonDate = "November 20",
                    FullMoonDate = "November 6 (Beaver Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What miracle did you witness today?",
                        "Who/what are you grateful for?",
                        "What abundance do you take for granted?",
                        "How did you express thanks today?",
                        "What hidden blessing revealed itself?",
                        "What grace carried you this week?",
                        "What would you miss if it was gone?"
                    }
                },
                new PlannerContent
                {
                    Month = "DECEMBER 2026",
                    MonthTheme = "REFLECTION",
                    MonthQuote = "Who did you become this year?",
                    NewMoonDate = "December 19",
                    FullMoonDate = "December 6 (Cold Moon)",
                    WeeklyQuestions = new[]
                    {
                        "What chapter is complete?",
                        "What changed you forever?",
                        "What would you do differently?",
                        "What did you learn about yourself?",
                        "What surprised you most?",
                        "What are you proud of?",
                        "What's calling you into next year?"
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
