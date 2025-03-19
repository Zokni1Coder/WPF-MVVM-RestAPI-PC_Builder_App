using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Models;
using PC_Builder.ViewModels;

namespace PC_Builder.Commands
{
    public class SelectPartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SelectPartCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Bent van");
            var viewModel = MainWindowViewModel.viewModel;
            switch (parameter)
            {
                case Motherboard motherboard:
                    MessageBox.Show(motherboard.Manufacturer);
                    viewModel.SetMotherboard(parameter as Motherboard);
                    break;
                default:
                    break;
            }
        }
    }
}
