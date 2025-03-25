using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class SelectedCPUViewModel : BaseSelectedViewModel
    {
        private CPU selectedCPU;

        public CPU SelectedCPU
        {
            get { return selectedCPU; }
            set
            {
                selectedCPU = value;
                OnPropertyChanged(nameof(selectedCPU));
            }
        }

        public ICommand SelectViewCommand { get; }

        public SelectedCPUViewModel(IComputerPart component)
        {
            SelectViewCommand = new SelectViewCommand();
            this.SelectedCPU = component as CPU;
        }               
    }
}
