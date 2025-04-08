using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Interfaces;
using PC_Builder.ViewModels;
using PC_Builder.Views;

namespace PC_Builder.Commands
{
    public class SelectViewCommand : ICommand
    {
        public SelectViewCommand()
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private System.Windows.Controls.UserControl CreateView(IComputerPart viewName)
        {
            switch (viewName.Name())
            {
                case "Motherboard":
                    return new SelectedMotherboardView(viewName);
                case "CPU":
                    return new SelectedCPUView(viewName);
                case "GPU":
                    return new SelectedGPUView(viewName);
                case "RAM":
                    return new SelectedRAMView(viewName);
                case "ROM":
                    return new SelectedROMView(viewName);
                case "PS":
                    return new SelectedPSView(viewName);
                case "Cooler":
                    return new SelectedCPUCoolerView(viewName);
                default:
                    return null;
            }
        }

        public void Execute(object parameter)
        {
            var selectedView = CreateView(parameter as IComputerPart);

            SelectedPart selectedPartWindow = new SelectedPart();
            selectedPartWindow.Content = selectedView;
            selectedPartWindow.Show();
        }
    }
}
