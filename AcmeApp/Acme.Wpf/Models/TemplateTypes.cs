namespace Acme.Wpf.Models
{
    /// <summary>
    /// Types of template layouts
    /// </summary>
    public enum TemplateType
    {
        /// <summary>Generic spiritual background</summary>
        Background,
        /// <summary>Oracle/Tarot card front</summary>
        CardFront,
        /// <summary>Oracle/Tarot card back</summary>
        CardBack,
        /// <summary>Book page - left side (spiritual meaning)</summary>
        BookPageLeft,
        /// <summary>Book page - right side (practical application)</summary>
        BookPageRight,
        /// <summary>Book two-page spread</summary>
        BookSpread,
        /// <summary>Front cover for book/guide</summary>
        CoverFront,
        /// <summary>Back cover for book/guide</summary>
        CoverBack
    }

    /// <summary>
    /// Text content for templates
    /// </summary>
    public class TemplateTextContent
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string MainText { get; set; }
        public string FooterText { get; set; }
        public string[] BulletPoints { get; set; }
        public double TitleFontSize { get; set; } = 36;
        public double SubtitleFontSize { get; set; } = 20;
        public double BodyFontSize { get; set; } = 14;
        public double FooterFontSize { get; set; } = 12;
        public string TitleFont { get; set; } = "Cinzel Decorative";
        public string BodyFont { get; set; } = "Philosopher";

        public TemplateTextContent()
        {
            BulletPoints = new string[0];
        }
    }

    /// <summary>
    /// Angel number content
    /// </summary>
    public class AngelNumberContent
    {
        public string Number { get; set; }
        public string Title { get; set; }
        public string Emoji { get; set; }
        public string SoulMeaning { get; set; }
        public string EnergeticSignature { get; set; }
        public string DivineMessage { get; set; }
        public string[] PracticalSteps { get; set; }
        public string Affirmation { get; set; }
        public string ShadowWorkQuestion { get; set; }
        public string FrequencyNote { get; set; }

        public AngelNumberContent()
        {
            PracticalSteps = new string[0];
        }

        /// <summary>
        /// Получить Angel Numbers из импорта (если есть) или дефолтные
        /// </summary>
        public static AngelNumberContent[] GetNumbers()
        {
            try
            {
                var importer = new Services.ContentImporter();
                return importer.LoadAngelNumbers();
            }
            catch
            {
                // Если ошибка импорта - вернуть дефолтные
                return GetPredefinedNumbers();
            }
        }

        public static AngelNumberContent[] GetPredefinedNumbers()
        {
            return new[]
            {
                new AngelNumberContent
                {
                    Number = "111",
                    Title = "MANIFESTATION GATE OPEN",
                    Emoji = "✨",
                    SoulMeaning = "The portal between thought and form is WIDE OPEN. Your dominant vibration RIGHT NOW is crystallizing into physical experience within days or weeks.",
                    PracticalSteps = new[]
                    {
                        "IMMEDIATE PAUSE - Notice: What was I just thinking?",
                        "REALITY CHECK - Do I WANT this thought to manifest?",
                        "17-SECOND RULE - Hold desired thought with FEELING",
                        "PHYSICAL ACTION - Take ONE action toward desired outcome TODAY",
                        "RELEASE ATTACHMENT - Set intention, take action, then LET GO"
                    },
                    Affirmation = "My thoughts create my reality. I choose thoughts of abundance, love, possibility, and power."
                },
                new AngelNumberContent
                {
                    Number = "222",
                    Title = "DIVINE TIMING ACTIVE",
                    Emoji = "⚖️",
                    SoulMeaning = "You are in the PATIENCE INITIATION. Everything you planted is growing underground, invisible but VERY real.",
                    PracticalSteps = new[]
                    {
                        "RELEASE CONTROL - Stop forcing, pushing, manipulating",
                        "CONTINUE ALIGNED ACTION - Keep doing your part",
                        "LOOK FOR SMALL SIGNS - Document synchronicities",
                        "STRENGTHEN PARTNERSHIPS - Nurture connections",
                        "PRACTICE SURRENDER PRAYER - Trust divine timing"
                    },
                    Affirmation = "Everything is unfolding in perfect divine timing. I trust the invisible process."
                },
                new AngelNumberContent
                {
                    Number = "333",
                    Title = "ASCENDED MASTERS PRESENT",
                    Emoji = "👁️",
                    SoulMeaning = "Your spiritual team (guides, ancestors, ascended masters) is ACTIVELY working on your behalf. You are protected, guided, and SEEN.",
                    PracticalSteps = new[]
                    {
                        "ASK FOR HELP - Speak request aloud or write it down",
                        "WATCH FOR SIGNS - Guides communicate through synchronicity",
                        "CREATE RITUAL - Light candle, speak gratitude to your team",
                        "TRUST INTUITIVE HITS - First thought = divine download",
                        "AMPLIFY CREATIVE EXPRESSION - Sing, write, paint, dance NOW"
                    },
                    Affirmation = "I am surrounded by divine beings who love and support me. I trust their guidance completely."
                },
                new AngelNumberContent
                {
                    Number = "444",
                    Title = "FOUNDATION SOLIDIFYING",
                    Emoji = "🏛️",
                    SoulMeaning = "You are building something REAL that will last. This is the GRIND phase. Unsexy, unglamorous, absolutely essential.",
                    PracticalSteps = new[]
                    {
                        "RETURN TO BASICS - Systems, routines, discipline",
                        "STRENGTHEN FOUNDATION - Health, finances, relationships",
                        "ELIMINATE DISTRACTIONS - What's not essential? Cut it.",
                        "TRUST THE PROCESS - Slow progress is STILL progress",
                        "ASK: 'Will this matter in 5 years?' - If yes, prioritize it"
                    },
                    Affirmation = "I am building a solid foundation for my highest life. Every small step matters."
                },
                new AngelNumberContent
                {
                    Number = "555",
                    Title = "MAJOR TRANSFORMATION INCOMING",
                    Emoji = "🌀",
                    SoulMeaning = "The old version of your life is DISSOLVING. Uncomfortable? Yes. Necessary? ABSOLUTELY. You're being upgraded.",
                    PracticalSteps = new[]
                    {
                        "EMBRACE THE CHAOS - Resistance makes it harder",
                        "RELEASE WHAT'S LEAVING - Job, person, belief, habit",
                        "SAY YES TO THE NEW - Even if you don't feel ready",
                        "MOVE YOUR BODY - Walk, dance, shake to process energy",
                        "REPEAT: 'I trust the transformation. I am safe in change.'"
                    },
                    Affirmation = "I release the old with gratitude and welcome the new with excitement. Change is my ally."
                },
                new AngelNumberContent
                {
                    Number = "666",
                    Title = "EARTH INTEGRATION REQUIRED",
                    Emoji = "🌍",
                    SoulMeaning = "You've been too much in your HEAD or the SPIRITUAL realm. Come back to BODY. Come back to EARTH. Balance is needed NOW.",
                    PracticalSteps = new[]
                    {
                        "GET PHYSICAL - Exercise, intimacy, nature walk TODAY",
                        "HANDLE PRACTICAL MATTERS - Bills, emails, appointments",
                        "NOURISH YOUR BODY - Real food, water, rest",
                        "GROUND YOUR ENERGY - Bare feet on earth for 10 minutes",
                        "CHECK FINANCES - Money is spiritual. Balance your accounts."
                    },
                    Affirmation = "I honor my human experience. My body is sacred. The material world is my playground."
                },
                new AngelNumberContent
                {
                    Number = "777",
                    Title = "DIVINE JACKPOT",
                    Emoji = "🎯",
                    SoulMeaning = "You have achieved PERFECT ALIGNMENT with your soul path. Everything you've endured has been preparation for THIS moment.",
                    PracticalSteps = new[]
                    {
                        "CELEBRATE FIRST - Acknowledge: 'I did the work. I'm here.'",
                        "AUDIT CURRENT PATH - Whatever you're doing NOW = correct",
                        "MAKE BOLD MOVES - Launch business, have conversation, ask for what you want",
                        "CAPTURE SYNCHRONICITIES - Journal everything 'coincidental'",
                        "EXPECT MIRACLES - Set expectation: 'Miracles are my new normal'"
                    },
                    Affirmation = "I am in perfect alignment with my highest path. Divine favor flows through every area of my life."
                },
                new AngelNumberContent
                {
                    Number = "888",
                    Title = "ABUNDANCE OVERFLOW",
                    Emoji = "💰",
                    SoulMeaning = "You are entering a cycle of MASSIVE ABUNDANCE. Financial, emotional, relational, creative—it's ALL coming. Open your hands to RECEIVE.",
                    PracticalSteps = new[]
                    {
                        "DECLARE: 'I am ready to receive' - Say it aloud daily",
                        "CLEAR BLOCKS TO RECEIVING - Where do you deflect compliments/money/help?",
                        "GIVE GENEROUSLY - Tip extra, donate, share resources",
                        "UPGRADE ONE THING - Buy the nicer version (signals worthiness)",
                        "EXPECT UNEXPECTED MONEY - Check for refunds, rebates, forgotten accounts"
                    },
                    Affirmation = "Abundance is my natural state. I receive easily and joyfully from expected and unexpected sources."
                },
                new AngelNumberContent
                {
                    Number = "999",
                    Title = "COMPLETION & RELEASE",
                    Emoji = "🔚",
                    SoulMeaning = "A major life chapter is COMPLETE. Grief is appropriate. Honor what was. Then RELEASE IT to make space for what's coming.",
                    PracticalSteps = new[]
                    {
                        "RITUAL CLOSURE - Write goodbye letter, burn it, release it",
                        "FEEL YOUR FEELINGS - Cry, rage, laugh—all of it is valid",
                        "CLEAN HOUSE LITERALLY - Donate, delete, declutter",
                        "COMPLETE UNFINISHED BUSINESS - Have the conversation, send the email",
                        "DECLARE: 'I am complete with this chapter. I am ready for the new.'"
                    },
                    Affirmation = "I release the old with love and gratitude. I am complete. I am ready. The new is coming."
                }
            };
        }
    }
}
