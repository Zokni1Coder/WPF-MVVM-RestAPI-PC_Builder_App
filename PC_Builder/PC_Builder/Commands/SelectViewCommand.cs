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
        }
    }
}
