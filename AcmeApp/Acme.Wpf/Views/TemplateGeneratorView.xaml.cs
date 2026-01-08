using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Acme.Wpf.ViewModels;

namespace Acme.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TemplateGeneratorView.xaml
    /// </summary>
    public partial class TemplateGeneratorView : Window
    {
        private TemplateGeneratorViewModel _viewModel;

        public TemplateGeneratorView()
        {
            InitializeComponent();
            _viewModel = DataContext as TemplateGeneratorViewModel;

            if (_viewModel != null)
            {
                _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            }
        }

        private void PreviewBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePreview();
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TemplateGeneratorViewModel.PreviewSvg))
            {
                Dispatcher.Invoke(() => UpdatePreview());
            }
        }

        private void UpdatePreview()
        {
            if (PreviewBrowser == null || _viewModel == null)
                return;

            try
            {
                // Navigate to SVG content
                string svgContent = _viewModel.PreviewSvg;
                if (!string.IsNullOrEmpty(svgContent))
                {
                    PreviewBrowser.NavigateToString(svgContent);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating preview: {ex.Message}");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
            }
            base.OnClosing(e);
        }
    }
}
