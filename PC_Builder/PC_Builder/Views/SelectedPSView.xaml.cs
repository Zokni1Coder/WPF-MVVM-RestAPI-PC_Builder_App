﻿using System;
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
using PC_Builder.Interfaces;
using PC_Builder.ViewModels;

namespace PC_Builder.Views
{
    /// <summary>
    /// Interaction logic for SelectedPSView.xaml
    /// </summary>
    public partial class SelectedPSView : UserControl
    {
        public SelectedPSView(IComputerPart component)
        {
            InitializeComponent();
            DataContext = new SelectedPowerSupplyViewModel(component);
        }
    }
}
