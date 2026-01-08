# Template Generator Demo Examples

This document shows examples of what each template type generates.

## Available Template Types

### 1. Background Templates
Generic spiritual backgrounds with sacred geometry and frames.
- **Formats**: US Letter, A4, A5, Square, Instagram Story
- **Use**: Canva backgrounds, social media templates

### 2. Angel Card Front
Oracle/tarot card front design with angel number and meaning.
- **Format**: Card Standard (2.5" x 3.5") or Card Large (3.5" x 5")
- **Content**: Number, title, emoji, soul meaning
- **Use**: Printable angel number cards

### 3. Angel Card Back
Universal back design for all angel cards.
- **Format**: Card Standard (2.5" x 3.5") or Card Large (3.5" x 5")
- **Content**: Brand name, edition, sacred geometry watermark
- **Use**: Card backs for double-sided printing

### 4. Book Page Spread
Two-page layout for angel numbers guide.
- **Format**: Book Spread (Two A5 pages side by side)
- **Left Page**: Spiritual meaning, energetic signature, divine message
- **Right Page**: Practical steps, affirmation, shadow work question
- **Use**: PDF guides, ebooks

### 5. Cover Pages
Front and back covers for guides and books.
- **Format**: US Letter or A4
- **Use**: PDF cover pages

## Color Schemes

### Shadow Awakening
- Background: Deep purple (#120A2A → #1E0E3E)
- Primary: Gold (#FFD700)
- Accent: Light purple (#8B5CF6)
- **Vibe**: Dark, mysterious, transformative

### Luminous Harmony
- Background: Lighter purple (#3E2B4D → #5A3D6F)
- Primary: Rose gold (#E6B8FF)
- Accent: Light gold (#FCEEAC)
- **Vibe**: Light, harmonious, uplifting

### Angel Numbers Deep
- Background: Deep violet (#2C0735 → #4A0E4E)
- Primary: Gold (#FFD700)
- Secondary: Purple (#9B59B6)
- **Vibe**: Mystical, powerful, cosmic

## Predefined Angel Numbers

The generator includes 3 pre-loaded angel numbers:

### 111 - Manifestation Gate Open ✨
Portal between thought and form is wide open.

### 222 - Divine Timing Active ⚖️
Everything is unfolding in perfect divine timing.

### 777 - Divine Jackpot 🎯
Perfect alignment with soul path achieved.

## Usage Examples

### Example 1: Creating Angel Cards Set
1. Select **Card Standard** format
2. Choose **Shadow Awakening** color scheme
3. Select **Card Front** template type
4. Choose angel number (111, 222, or 777)
5. Add **Flower of Life** geometry
6. Export as SVG
7. Repeat for **Card Back** template
8. Print double-sided on cardstock

### Example 2: Creating Angel Numbers PDF Guide
1. Select **Book Spread** format
2. Choose **Angel Numbers Deep** color scheme
3. Select **Book Spread** template type
4. Choose angel number
5. Export each number as separate SVG
6. Compile into PDF using design tool

### Example 3: Creating Social Media Templates
1. Select **Square** or **Instagram Story** format
2. Choose **Luminous Harmony** color scheme
3. Select **Background** template type
4. Add **Metatron's Cube** or **Sri Yantra** geometry
5. Export as SVG
6. Import to Canva and add text

## Technical Notes

- **SVG Format**: All templates export as scalable vector graphics
- **Print Quality**: Designs maintain quality at any size
- **Canva Compatible**: SVG files import directly into Canva
- **Customizable**: Edit colors, text, and geometry in code
- **Font Requirements**: Designs use Cinzel Decorative and Philosopher fonts

## File Naming Convention

Recommended naming:
- Cards: `AngelCard_{Number}_{Side}_{Edition}.svg`
  - Example: `AngelCard_111_Front_ShadowAwakening.svg`
- Books: `AngelNumbers_{Number}_Spread.svg`
  - Example: `AngelNumbers_777_Spread.svg`
- Backgrounds: `SpiritualBG_{Format}_{Scheme}.svg`
  - Example: `SpiritualBG_Square_LuminousHarmony.svg`

## Next Steps

To add more angel numbers:
1. Edit `Models/TemplateTypes.cs`
2. Add new `AngelNumberContent` entries
3. Include number, title, emoji, meanings, and practical steps
4. Recompile application
5. New numbers appear in generator

---

**Note**: This generator is part of the Acme WPF application suite.
To launch: Run application → Click "Spiritual Template Generator"
