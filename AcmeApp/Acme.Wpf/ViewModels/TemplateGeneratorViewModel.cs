using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
using Acme.Wpf.Models;
using Acme.Wpf.Services;

namespace Acme.Wpf.ViewModels
{
    /// <summary>
    /// ViewModel for the Template Generator
    /// </summary>
    public class TemplateGeneratorViewModel : INotifyPropertyChanged
    {
        private readonly TemplateSvgGenerator _svgGenerator;
        private TemplateConfig _currentConfig;
        private string _previewSvg;
        private PageFormat _selectedPageFormat;
        private ColorScheme _selectedColorScheme;
        private FrameStyle _selectedFrameStyle;
        private SacredGeometryType _selectedGeometryType;
        private double _geometrySize;
        private double _geometryOpacity;

        public TemplateGeneratorViewModel()
        {
            _svgGenerator = new TemplateSvgGenerator();
            _currentConfig = new TemplateConfig();
            _geometrySize = 200;
            _geometryOpacity = 0.3;

            // Initialize collections
            PageFormats = new ObservableCollection<PageFormat>(PageFormat.GetStandardFormats());
            ColorSchemes = new ObservableCollection<ColorScheme>(ColorScheme.GetSpiritualSchemes());
            FrameStyles = new ObservableCollection<FrameStyle>(Enum.GetValues(typeof(FrameStyle)).Cast<FrameStyle>());
            GeometryTypes = new ObservableCollection<SacredGeometryType>(
                Enum.GetValues(typeof(SacredGeometryType)).Cast<SacredGeometryType>());

            // Set defaults
            SelectedPageFormat = PageFormats[0];
            SelectedColorScheme = ColorSchemes[0];
            SelectedFrameStyle = FrameStyle.OrnateGold;
            SelectedGeometryType = SacredGeometryType.FlowerOfLife;

            // Initialize commands
            GeneratePreviewCommand = new RelayCommand(GeneratePreview);
            AddGeometryCommand = new RelayCommand(AddGeometry);
            ClearGeometryCommand = new RelayCommand(ClearGeometry);
            ExportSvgCommand = new RelayCommand(ExportSvg);

            // Generate initial preview
            GeneratePreview();
        }

        #region Properties

        public ObservableCollection<PageFormat> PageFormats { get; }
        public ObservableCollection<ColorScheme> ColorSchemes { get; }
        public ObservableCollection<FrameStyle> FrameStyles { get; }
        public ObservableCollection<SacredGeometryType> GeometryTypes { get; }

        public PageFormat SelectedPageFormat
        {
            get => _selectedPageFormat;
            set
            {
                if (_selectedPageFormat != value)
                {
                    _selectedPageFormat = value;
                    _currentConfig.PageFormat = value;
                    OnPropertyChanged();
                    GeneratePreview();
                }
            }
        }

        public ColorScheme SelectedColorScheme
        {
            get => _selectedColorScheme;
            set
            {
                if (_selectedColorScheme != value)
                {
                    _selectedColorScheme = value;
                    _currentConfig.ColorScheme = value;
                    OnPropertyChanged();
                    GeneratePreview();
                }
            }
        }

        public FrameStyle SelectedFrameStyle
        {
            get => _selectedFrameStyle;
            set
            {
                if (_selectedFrameStyle != value)
                {
                    _selectedFrameStyle = value;
                    _currentConfig.FrameStyle = value;
                    OnPropertyChanged();
                    GeneratePreview();
                }
            }
        }

        public SacredGeometryType SelectedGeometryType
        {
            get => _selectedGeometryType;
            set
            {
                if (_selectedGeometryType != value)
                {
                    _selectedGeometryType = value;
                    OnPropertyChanged();
                }
            }
        }

        public double GeometrySize
        {
            get => _geometrySize;
            set
            {
                if (Math.Abs(_geometrySize - value) > 0.01)
                {
                    _geometrySize = value;
                    OnPropertyChanged();
                }
            }
        }

        public double GeometryOpacity
        {
            get => _geometryOpacity;
            set
            {
                if (Math.Abs(_geometryOpacity - value) > 0.01)
                {
                    _geometryOpacity = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PreviewSvg
        {
            get => _previewSvg;
            set
            {
                if (_previewSvg != value)
                {
                    _previewSvg = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowStars
        {
            get => _currentConfig.ShowStars;
            set
            {
                if (_currentConfig.ShowStars != value)
                {
                    _currentConfig.ShowStars = value;
                    OnPropertyChanged();
                    GeneratePreview();
                }
            }
        }

        public bool ShowGradientOverlay
        {
            get => _currentConfig.ShowGradientOverlay;
            set
            {
                if (_currentConfig.ShowGradientOverlay != value)
                {
                    _currentConfig.ShowGradientOverlay = value;
                    OnPropertyChanged();
                    GeneratePreview();
                }
            }
        }

        public double FrameThickness
        {
            get => _currentConfig.FrameThickness;
            set
            {
                if (Math.Abs(_currentConfig.FrameThickness - value) > 0.01)
                {
                    _currentConfig.FrameThickness = value;
                    OnPropertyChanged();
                    GeneratePreview();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand GeneratePreviewCommand { get; }
        public ICommand AddGeometryCommand { get; }
        public ICommand ClearGeometryCommand { get; }
        public ICommand ExportSvgCommand { get; }

        private void GeneratePreview()
        {
            try
            {
                PreviewSvg = _svgGenerator.GenerateTemplate(_currentConfig);
            }
            catch (Exception ex)
            {
                // Log error (in production, use proper logging)
                System.Diagnostics.Debug.WriteLine($"Error generating preview: {ex.Message}");
            }
        }

        private void AddGeometry()
        {
            if (SelectedGeometryType == SacredGeometryType.None)
                return;

            var geometry = new SacredGeometryConfig
            {
                Type = SelectedGeometryType,
                Size = GeometrySize,
                Opacity = GeometryOpacity,
                CenterX = _currentConfig.PageFormat.Width / 2,
                CenterY = _currentConfig.PageFormat.Height / 2,
                Color = _currentConfig.ColorScheme.PrimaryColor
            };

            _currentConfig.GeometryElements.Add(geometry);
            GeneratePreview();
        }

        private void ClearGeometry()
        {
            _currentConfig.GeometryElements.Clear();
            GeneratePreview();
        }

        private void ExportSvg()
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "SVG files (*.svg)|*.svg",
                    DefaultExt = ".svg",
                    FileName = $"SpiritualTemplate_{DateTime.Now:yyyyMMdd_HHmmss}.svg"
                };

                if (saveDialog.ShowDialog() == true)
                {
                    _svgGenerator.SaveToFile(PreviewSvg, saveDialog.FileName);
                    System.Windows.MessageBox.Show(
                        $"Template exported successfully to:\n{saveDialog.FileName}",
                        "Export Complete",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error exporting template: {ex.Message}",
                    "Export Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    /// <summary>
    /// Simple RelayCommand implementation
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
