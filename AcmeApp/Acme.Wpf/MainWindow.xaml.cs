using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Acme.Wpf.Views;

namespace Acme.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchTemplateGenerator_Click(object sender, RoutedEventArgs e)
        {
            var templateGenerator = new TemplateGeneratorView();
            templateGenerator.Show();
        }

        private void LaunchVendorManagement_Click(object sender, RoutedEventArgs e)
        {
            var vendorView = new VendorDetailView();
            vendorView.Show();
        }
    }
}
