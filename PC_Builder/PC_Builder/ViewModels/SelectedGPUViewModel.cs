using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Commands;
using System.Windows.Input;
using System.Windows;
using static PC_Builder.ViewModels.SelectedCPUViewModel;
using PC_Builder.Models;
using PC_Builder.Interfaces;

namespace PC_Builder.ViewModels
{
    public class SelectedGPUViewModel : BaseSelectedViewModel
    {
        private GPU selectedGPU;

        public GPU SelectedGPU
        {
            get { return selectedGPU; }
            set
            {
                selectedGPU = value;
                OnPropertyChanged(nameof(SelectedGPU));
            }
        }
        public ICommand SelectViewCommand { get; }

        public SelectedGPUViewModel(IComputerPart component)
        {
            SelectViewCommand = new SelectViewCommand();
            this.SelectedGPU = component as GPU;
        }
    }
}
