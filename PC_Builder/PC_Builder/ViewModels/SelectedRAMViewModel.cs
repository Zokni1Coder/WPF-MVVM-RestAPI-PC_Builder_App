using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Commands;
using PC_Builder.Models;
using System.Windows.Input;
using PC_Builder.Interfaces;

namespace PC_Builder.ViewModels
{
    public class SelectedRAMViewModel : BaseSelectedViewModel
    {
        public SelectedRAMViewModel(IComputerPart component)
        {
            SelectViewCommand = new SelectViewCommand();
            this.SelectedRAM = component as RAM;
        }
        private RAM selectedRAM;

        public RAM SelectedRAM
        {
            get { return selectedRAM; }
            set
            {
                selectedRAM = value;
                OnPropertyChanged(nameof(SelectedRAM));
            }
        }
        public ICommand SelectViewCommand { get; }            
    }
}
