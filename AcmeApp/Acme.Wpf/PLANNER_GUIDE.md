# Planner Page Generator Guide

## Overview

The Planner Page Generator extends the Spiritual Template Generator to create complete planner pages for three types of planners:

1. **Spiritual Awakening Planner** - Daily spiritual practice tracking
2. **Business Visionary Planner** - Conscious entrepreneurship
3. **Creative Muse Planner** - Creative practice and inspiration

## Features

### Page Types Generated

- **Cover Page** - Professional planner cover with edition branding
- **Month Cover** - Monthly theme introduction with intentions
- **Monthly Calendar** - Calendar view with moon phases
- **Weekly Spread** - Daily tracking with energy scales
- **Monthly Integration** - End-of-month reflection
- **Year Review** - Annual transformation summary
- **Emergency Soul Care** - Crisis support pages
- **Affirmations** - Mantras and power statements

### Tracking Elements

Each daily entry includes:
- Energy level scale (1-10)
- To-do items
- Synchronicity logging
- Practice checkboxes (Meditation, Movement, Journal, Other)
- Shadow moment tracking
- Light moment tracking
- The Architect's daily question

### Monthly Themes

**Spiritual Awakening Planner:**
- January: Intention
- February: Foundation
- March: Expansion
- April: Purification
- May: Manifestation
- June: Relationship
- July: Power
- August: Integration
- September: Transformation
- October: Intuition
- November: Gratitude
- December: Integration & Rest

## Usage

### Generate Month Cover

```csharp
var generator = new PlannerPageGenerator();
var content = new PlannerContent
{
    Month = "JANUARY 2026",
    MonthTheme = "INTENTION",
    MonthQuote = "What foundation are you building this year?",
    FullMoonDate = "January 13 (Wolf Moon)",
    NewMoonDate = "January 29"
};

var scheme = ColorScheme.GetSpiritualSchemes()[6]; // Shadow Awakening
var format = PageFormat.GetStandardFormats()[0]; // US Letter

string svg = generator.GenerateMonthCover(content, scheme, format);
```

### Generate Weekly Spread

```csharp
var days = new DailyTrackerContent[]
{
    new DailyTrackerContent
    {
        DayOfWeek = "MON",
        Date = "1/1",
        ArchitectQuestion = "What are you grateful for AND what's challenging you today?"
    },
    new DailyTrackerContent
    {
        DayOfWeek = "TUE",
        Date = "1/2",
        ArchitectQuestion = "Where are you forcing instead of flowing?"
    }
};

string svg = generator.GenerateWeeklySpread("JANUARY 1-7, 2026", days, scheme, format);
```

### Generate Planner Cover

```csharp
string svg = generator.GeneratePlannerCover(content, scheme, format, "Shadow Awakening");
```

## Color Schemes

Two editions available:

### Shadow Awakening
- Background: Deep purple gradient (#120A2A → #1E0E3E)
- Primary: Gold (#FFD700)
- Secondary: Light gold (#FCEEAC)
- Accent: Purple (#8B5CF6)
- **Vibe**: Dark, mysterious, transformative

### Luminous Harmony
- Background: Lighter purple gradient (#3E2B4D → #5A3D6F)
- Primary: Rose purple (#E6B8FF)
- Secondary: Antique gold (#D4AF37)
- Accent: Light gold (#FCEEAC)
- **Vibe**: Light, uplifting, harmonious

## Page Specifications

### Planner Cover Page
- **Size**: US Letter (8.5" × 11") or A4
- **Elements**:
  - Cosmic gradient background
  - Title (Spiritual Awakening Planner 2026)
  - Edition name
  - The Architect's quote
  - Signature
  - Website footer

### Month Cover Page
- **Size**: US Letter or A4
- **Elements**:
  - Month name and year
  - Month theme
  - Themed quote
  - Intention prompts (3 fill-in areas)
  - Moon phases for the month
  - Spiritual practice priorities

### Weekly Spread
- **Size**: US Letter or A4
- **Elements**:
  - Week date range
  - Week intention
  - 2 daily entries per page (expandable to 7)
  - Each day includes all tracking elements
  - Unique Architect question per day

## The Architect's Questions

Each day features a unique question to prompt reflection:

**Week 1 Examples:**
1. "What are you grateful for AND what's challenging you today?"
2. "Where are you forcing instead of flowing?"
3. "What truth are you avoiding?"
4. "How did you honor your energy today?"
5. "What synchronicity appeared?"
6. "What did you release this week?"
7. "What's ready to be born?"

These rotate and adapt based on:
- Monthly theme
- Week of the month
- Seasonal energy

## Predefined Content

The generator includes predefined content for:

### Spiritual Awakening Months
- January (Intention)
- February (Foundation)
- [+ 10 more months with themes and quotes]

### Business Visionary Months
- January (Vision)
- February (Foundation - Systems)
- [+ 10 more months adapted for business]

### Creative Muse Months
- January (Inspiration)
- February (Foundation - Practice)
- [+ 10 more months adapted for creativity]

## Export Workflow

1. **Generate SVG** using PlannerPageGenerator
2. **Save to file** (.svg format)
3. **Import to Canva** or other design tool
4. **Add custom elements** if desired
5. **Export to PDF** for printing or digital delivery

## Planner Structure

### Front Matter (10 pages)
1. Cover
2. Welcome from The Architect
3. How to Use This Planner
4. 2026: Your Year of Awakening
5. Setting Your Soul Intentions
6. 12-Month Overview
7. Moon Phases & Spiritual Seasons
8. Practice Tracker Template
9. Emergency Soul Care Plan
10. Affirmations Reference

### Monthly Spreads (72 pages for 12 months)
- Month Cover (1 page)
- Monthly Calendar (1 page)
- Weekly Spreads (4 pages for 4 weeks)
- Monthly Integration (1 page)

**Total per month: 6 pages × 12 = 72 pages**

### Back Matter (13 pages)
1. Year in Review
2. Biggest Transformations
3. Synchronicities Log
4. Shadow Work Insights
5. Light Work Celebrations
6. Teachers & Resources
7. Books/Tools
8. 2027 Intentions
9. The Architect's Blessing
10. Emergency Numbers
11. Notes (3 pages)
12. Final Blessing

**Total Planner: 95 pages**

## Customization

You can customize:
- Monthly themes and quotes
- The Architect's questions
- Color schemes
- Page layouts
- Font sizes
- Sacred geometry overlays

## Integration with Main Generator

The PlannerPageGenerator integrates seamlessly with the main TemplateGenerator:

```csharp
// Use existing color schemes
var schemes = ColorScheme.GetSpiritualSchemes();
var shadowAwakening = schemes[6];
var luminousHarmony = schemes[7];

// Use existing page formats
var formats = PageFormat.GetStandardFormats();
var usLetter = formats[0];
var a4 = formats[2];

// Generate planner pages with same styling as other templates
var plannerGenerator = new PlannerPageGenerator();
var templateGenerator = new SpecializedTemplateGenerator();
```

## Future Enhancements

Potential additions:
- Habit tracker pages
- Gratitude journal pages
- Dream journal templates
- Tarot/Oracle spread recording pages
- Ritual planning pages
- Manifestation tracker pages
- Moon calendar for entire year
- Astrology tracking pages

## File Naming Convention

Recommended naming for generated pages:

```
Planner2026_SpiritualAwakening_ShadowEdition_Cover.svg
Planner2026_SpiritualAwakening_ShadowEdition_Jan_Cover.svg
Planner2026_SpiritualAwakening_ShadowEdition_Jan_Week1.svg
Planner2026_SpiritualAwakening_ShadowEdition_Jan_Integration.svg
```

## License

Part of the Spiritual Template Generator project.
For educational and commercial use in alignment with The Architect's mission.

---

**Created by The Architect**
**Where Light and Shadow Meet**
**AISoulGuide.com**
