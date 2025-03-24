using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Interfaces;

namespace PC_Builder.Commands
{
    public class TestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(IComputer parameter)
        {
            
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
