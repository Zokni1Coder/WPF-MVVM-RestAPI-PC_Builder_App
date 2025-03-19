using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using PC_Builder.ViewModels;
using PC_Builder.Views;

namespace PC_Builder.Commands
{
    public class SelectViewCommand : ICommand
    {
        //private BaseSelectedViewModel viewModel;
        public SelectViewCommand(SelectedPartViewModel viewModel)
        {
            //this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private System.Windows.Controls.UserControl CreateView(string viewName, int id)
        {
            switch (viewName)
            {
                case "Motherboard":
                    return new SelectedMotherboardView(id);
                case "CPU":
                    //return new SelectedCPUView(id); // Hozzáadhatod a többi nézetet is
                case "GPU":
                    //return new SelectedGPUView(id);
                default:
                    return null;
            }
        }

        public void Execute(object parameter)
        {
            Tuple<string, int> paramTuple = (Tuple<string, int>)parameter;
            string VM = paramTuple.Item1;
            int ID = paramTuple.Item2;
            var selectedView = CreateView(VM, ID);

            SelectedPart selectedPartWindow = new SelectedPart();
            selectedPartWindow.Content = selectedView;
            selectedPartWindow.Show();

            //switch (VM)
            //{
            //    case "Motherboard":
            //        var motherboardView = new SelectedMotherboardView(ID);

            //        SelectedPart selectedPartWindow = new SelectedPart();
            //        selectedPartWindow.Content = motherboardView; 
            //        selectedPartWindow.Show();
            //        break;
            //    case "CPU":
            //        viewModel.SelectedViewModel = new SelectedCPUViewModel();
            //        break;
            //    case "GPU":
            //        viewModel.SelectedViewModel = new SelectedGPUViewModel();
            //        break;
            //    case "CPU Cooler":
            //        viewModel.SelectedViewModel = new SelectedCPUCoolerViewModel();
            //        break;
            //    case "RAM":
            //        viewModel.SelectedViewModel = new SelectedRAMViewModel();
            //        break;
            //    case "ROM":
            //        viewModel.SelectedViewModel = new SelectedROMViewModel();
            //        break;
            //    case "PS":
            //        viewModel.SelectedViewModel = new SelectedPowerSupplyViewModel();
            //        break;
            //    default:
            //        break;
            //}
            //SelectedPart selectedPartWindow = new SelectedPart();
            //selectedPartWindow.DataContext = viewModel;
            //selectedPartWindow.Show();         
        }
    }
}
