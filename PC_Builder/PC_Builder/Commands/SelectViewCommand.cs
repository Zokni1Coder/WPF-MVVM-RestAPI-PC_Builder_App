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
        public SelectViewCommand()
        {

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
                case "Motherboards":
                    return new SelectedMotherboardView(id);
                case "CpusToView":
                    return new SelectedCPUView(id);
                case "Gpus":
                    return new SelectedGPUView(id);
                case "Rams":
                    return new SelectedRAMView(id);
                case "Roms":
                    return new SelectedROMView(id);
                case "Supplies":
                    return new SelectedPSView(id);
                case "Coolers":
                    return new SelectedCPUCoolerView(id);
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
        }
    }
}
