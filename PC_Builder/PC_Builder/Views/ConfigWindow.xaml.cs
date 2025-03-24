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
using System.Windows.Shapes;
using PC_Builder.ViewModels;

namespace PC_Builder.Views
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow(double Left, double Height)
        {
            InitializeComponent();
            this.Left = Left + 950;
            this.Top = Height;
            DataContext = ConfigWindowViewModel.viewModel;
        }
    }
}
