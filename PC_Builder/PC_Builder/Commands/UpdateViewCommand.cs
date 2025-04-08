using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.ViewModels;

namespace PC_Builder.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public UpdateViewCommand(MainWindowViewModel viewModel)
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
                case "Home":
                    viewModel.SelectedViewModel = new HomeViewModel();                    
                    break;
                case "Motherboard":
                    viewModel.SelectedViewModel = new MotherboardViewModel();
                    break;
                case "CPU":
                    viewModel.SelectedViewModel = new CPUViewModel();
                    break;
                case "GPU":
                    viewModel.SelectedViewModel = new GPUViewModel();
                    break;
                case "CPU Cooler":
                    viewModel.SelectedViewModel = new CPUCoolerViewModel();
                    break;
                case "RAM":
                    viewModel.SelectedViewModel = new RAMViewModel();
                    break;
                case "ROM":
                    viewModel.SelectedViewModel = new ROMViewModel();
                    break;
                case "PS":
                    viewModel.SelectedViewModel = new PowerSupplyViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
