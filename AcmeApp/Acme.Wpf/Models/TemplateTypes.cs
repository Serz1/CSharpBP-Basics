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
                }
            };
        }
    }
}
