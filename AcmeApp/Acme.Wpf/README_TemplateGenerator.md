# Spiritual Template Generator

## Overview

The Spiritual Template Generator is a WPF application designed to create beautiful, customizable backgrounds for spiritual and mystical content such as:

- Oracle card designs
- Tarot card layouts
- Shadow journals
- Angel cards
- Planners and visualizers
- Social media content

## Features

### Page Formats
Supports multiple standard page formats suitable for both European and American printing:

- **US Letter** (8.5" x 11") - 816 x 1056 px
- **US Legal** (8.5" x 14") - 816 x 1344 px
- **A4** (210mm x 297mm) - 794 x 1123 px
- **A5** (148mm x 210mm) - 559 x 794 px
- **Square** (1080 x 1080) - Perfect for Instagram posts
- **Instagram Story** (1080 x 1920) - Optimized for stories

### Color Schemes

Pre-configured spiritual color palettes:

1. **Divine Gold** - Classic mystical gold on dark navy
2. **Celestial Purple** - Deep purple with gold accents
3. **Mystical Blue** - Ocean-inspired cosmic blues
4. **Sacred Rose** - Feminine rose with gold
5. **Angelic White** - Pure white with gold touches
6. **Emerald Wisdom** - Mystical green tones

### Sacred Geometry Patterns

Multiple sacred geometry options:

- **Flower of Life** - Ancient symbol of creation
- **Metatron's Cube** - Contains all Platonic solids
- **Seed of Life** - Foundation pattern
- **Vesica Piscis** - Two overlapping circles
- **Merkaba** - Star tetrahedron
- **Sri Yantra** - Sacred Hindu geometry
- **Golden Spiral** - Fibonacci-based spiral
- **Tree of Life** - Kabbalistic diagram
- **Hexagon Grid** - Honeycomb pattern

### Frame Styles

- **Simple Gold** - Clean, elegant border
- **Ornate Gold** - Decorated corners and details
- **Celestial Border** - Moon phases and stars
- **Geometric Frame** - Multiple nested borders

### Effects

- **Stars Overlay** - Randomly placed celestial stars
- **Gradient Overlay** - Depth and dimension
- **Adjustable Opacity** - Fine-tune visibility
- **Rotation** - Rotate sacred geometry elements

## How to Use

### 1. Select Page Format
Choose the appropriate page size for your target medium (print or digital).

### 2. Choose Color Scheme
Select from pre-configured spiritual color palettes or use them as inspiration.

### 3. Configure Frame
- Select frame style
- Adjust frame thickness (10-100px)

### 4. Add Sacred Geometry
- Select geometry type
- Adjust size (50-500px)
- Set opacity (0.1-1.0)
- Click "Add Geometry" to add to the template
- Add multiple layers for complex designs

### 5. Configure Effects
- Toggle stars overlay
- Toggle gradient overlay

### 6. Generate and Export
- Click "Generate Preview" to see your design
- Click "Export SVG" to save as a vector file

## SVG Export

Templates are exported as SVG (Scalable Vector Graphics) files, which:

- **Scale infinitely** without quality loss
- **Import to Canva** and other design tools
- **Edit with vector software** like Adobe Illustrator, Inkscape
- **Print at any size** while maintaining quality
- **Small file size** for efficient storage

## Project Structure

```
Acme.Wpf/
├── Models/
│   ├── PageFormat.cs           # Page size definitions
│   ├── ColorScheme.cs          # Color palette configurations
│   ├── SacredGeometry.cs       # Geometry type enums
│   └── TemplateConfig.cs       # Complete template configuration
├── Services/
│   ├── SacredGeometryService.cs    # Generates geometry SVG paths
│   └── TemplateSvgGenerator.cs     # Creates complete template SVG
├── ViewModels/
│   └── TemplateGeneratorViewModel.cs   # UI logic and state management
└── Views/
    ├── TemplateGeneratorView.xaml      # UI layout
    └── TemplateGeneratorView.xaml.cs   # View code-behind
```

## Technical Details

### Architecture

The application follows the MVVM (Model-View-ViewModel) pattern:

- **Models** contain data structures and business logic
- **ViewModels** manage UI state and user interactions
- **Views** define the visual interface
- **Services** handle SVG generation and geometry calculations

### SVG Generation

All templates are generated as pure SVG code with:
- Embedded gradients for smooth color transitions
- Parametric sacred geometry using mathematical formulas
- Layered effects for professional results
- Optimized for both screen and print

## Use Cases

### For Digital Products
- Instagram carousel templates
- Story templates
- Pinterest graphics
- Digital oracle/tarot cards
- Screensavers and wallpapers

### For Physical Products
- Printed oracle decks
- Journal pages
- Planner backgrounds
- Notebook covers
- Art prints

### For Content Creators
- YouTube thumbnails (resize to 1920x1080)
- Course materials
- Ebook covers
- Meditation guides
- Workshop materials

## Tips for Best Results

1. **Layer Multiple Geometry** - Combine 2-3 different sacred geometry patterns at varying opacities for depth

2. **Match Your Brand** - Customize color schemes to match your brand palette

3. **Consider Your Medium** - Use appropriate page formats:
   - Print: US Letter, A4, A5
   - Instagram: Square, Story
   - General digital: Custom sizes

4. **Experiment with Opacity** - Lower opacity (0.2-0.4) works well for backgrounds where text will be added

5. **Save Variations** - Export multiple color/geometry combinations to have variety

6. **Import to Canva** - Use the exported SVG as a background in Canva, add text and additional elements

## Future Enhancements

Potential features for future versions:
- Custom color picker
- Text overlay editor
- Pattern presets
- Batch generation
- PNG/PDF export options
- Animation support
- Custom geometry drawing
- Template library/presets

## Building the Application

### Requirements
- Visual Studio 2015 or later
- .NET Framework 4.6
- Windows operating system

### Build Instructions
1. Open `AcmeApp.sln` in Visual Studio
2. Set `Acme.Wpf` as startup project
3. Build solution (Ctrl+Shift+B)
4. Run application (F5)

## License

This application is part of the Acme learning project.

## Support

For issues or questions, refer to the project documentation or repository.

---

**Created for spiritual content creators, designers, and mystics who want to create beautiful, professional templates with sacred geometry and mystical aesthetics.**
