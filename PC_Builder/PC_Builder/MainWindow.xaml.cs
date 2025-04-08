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
using PC_Builder.ViewModels;
using PC_Builder.Views;

namespace PC_Builder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            double PositionLeft = SystemParameters.PrimaryScreenWidth * .1;
            double PositionTop = SystemParameters.PrimaryScreenHeight * .2;
            this.Left = PositionLeft;
            this.Top = PositionTop;
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            ConfigWindow configWindow = new ConfigWindow(PositionLeft, PositionTop);
            configWindow.Show();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();           
        }
    }
}
