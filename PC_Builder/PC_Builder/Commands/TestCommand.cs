using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Exceptions;
using PC_Builder.Interfaces;
using PC_Builder.ViewModels;
using PC_Builder.Views;

namespace PC_Builder.Commands
{
    public class TestCommand : ICommand
    {        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public TestCommand()
        {

        }

        public void Execute(object parameter)
        {
            var checker = new PC_Builder.Checker.Compatibility_Checker();
            IComputer computer = parameter as IComputer;
            List<string> errors = checker.GetErrors();

            try
            {
                checker.VisitMotherboard(computer.motherboard);
                checker.VisitROM(computer.rom);
                checker.VisitRAM(computer.ram);
                checker.VisitGPU(computer.gpu);
                checker.VisitCPU(computer.cpu);
                checker.VisitCPUCooler(computer.cpu_Cooler);
                checker.VisitPS(computer.power_supply);

                TestResultPopupWindowViewModel result = new TestResultPopupWindowViewModel();
                if (errors.Any())
                {
                    result.ControlContent = new FailedTestResultPopupWindowView();
                    result.errors = string.Join("\n\n", errors);
                }
                else
                {
                    result.ControlContent = new TestResultPopupWindowView();
                }
                TestResultPopupWindow resultWindow = new TestResultPopupWindow
                {
                    DataContext = result
                };
                resultWindow.Show();
            }
            catch (EmptySelectedPartException ex)
            {
                ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                errorWindow.Show();
            }
            catch (Exception) { }            
        }
    }
}
