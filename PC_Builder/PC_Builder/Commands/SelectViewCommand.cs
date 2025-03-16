using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.ViewModels;

namespace PC_Builder.Commands
{
    public class SelectViewCommand : ICommand
    {
        private SelectedPartViewModel viewModel;
        public SelectViewCommand(SelectedPartViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Motherboard":
                    viewModel.SelectedViewModel = new SelectedMotherboardViewModel();
                    break;
                case "CPU":
                    viewModel.SelectedViewModel = new SelectedCPUViewModel();
                    break;
                case "GPU":
                    viewModel.SelectedViewModel = new SelectedGPUViewModel();
                    break;
                case "CPU Cooler":
                    viewModel.SelectedViewModel = new SelectedCPUCoolerViewModel();
                    break;
                case "RAM":
                    viewModel.SelectedViewModel = new SelectedRAMViewModel();
                    break;
                case "ROM":
                    viewModel.SelectedViewModel = new SelectedROMViewModel();
                    break;
                case "PS":
                    viewModel.SelectedViewModel = new SelectedPowerSupplyViewModel();
                    break;
                default:
                    break;
            }
            SelectedPart selectedPartWindow = new SelectedPart();
            selectedPartWindow.DataContext = viewModel;
            selectedPartWindow.Show();
        }
    }
}
