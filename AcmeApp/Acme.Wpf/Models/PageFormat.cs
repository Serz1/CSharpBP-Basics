namespace Acme.Wpf.Models
{
    /// <summary>
    /// Standard page formats for printing
    /// </summary>
    public enum PageFormatType
    {
        /// <summary>US Letter format (8.5 x 11 inches)</summary>
        USLetter,
        /// <summary>US Legal format (8.5 x 14 inches)</summary>
        USLegal,
        /// <summary>A4 European format (210 x 297 mm)</summary>
        A4,
        /// <summary>A5 European format (148 x 210 mm)</summary>
        A5,
        /// <summary>Square format for social media (1080 x 1080 px)</summary>
        Square,
        /// <summary>Instagram Story format (1080 x 1920 px)</summary>
        InstagramStory
    }

    /// <summary>
    /// Page format dimensions and settings
    /// </summary>
    public class PageFormat
    {
        public PageFormatType Type { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Unit { get; set; }
        public string DisplayName { get; set; }

        public static PageFormat[] GetStandardFormats()
        {
            return new[]
            {
                new PageFormat
                {
                    Type = PageFormatType.USLetter,
                    Width = 816,
                    Height = 1056,
                    Unit = "px",
                    DisplayName = "US Letter (8.5\" x 11\")"
                },
                new PageFormat
                {
                    Type = PageFormatType.USLegal,
                    Width = 816,
                    Height = 1344,
                    Unit = "px",
                    DisplayName = "US Legal (8.5\" x 14\")"
                },
                new PageFormat
                {
                    Type = PageFormatType.A4,
                    Width = 794,
                    Height = 1123,
                    Unit = "px",
                    DisplayName = "A4 (210mm x 297mm)"
                },
                new PageFormat
                {
                    Type = PageFormatType.A5,
                    Width = 559,
                    Height = 794,
                    Unit = "px",
                    DisplayName = "A5 (148mm x 210mm)"
                },
                new PageFormat
                {
                    Type = PageFormatType.Square,
                    Width = 1080,
                    Height = 1080,
                    Unit = "px",
                    DisplayName = "Square (1080 x 1080)"
                },
                new PageFormat
                {
                    Type = PageFormatType.InstagramStory,
                    Width = 1080,
                    Height = 1920,
                    Unit = "px",
                    DisplayName = "Instagram Story (1080 x 1920)"
                }
            };
        }
    }
}
