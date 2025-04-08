using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Models;
using System.Windows.Input;
using System.Text.Json.Serialization;
using System.Windows.Media;
using PC_Builder.Commands;
using PC_Builder.Interfaces;

namespace PC_Builder.ViewModels
{
    public class SelectedCPUCoolerViewModel : BaseSelectedViewModel
    {
        public SelectedCPUCoolerViewModel(IComputerPart componenet)
        {
            SelectViewCommand = new SelectViewCommand();
            SelectPartCommand = new SelectPartCommand();
            this.SelectedCPUCooler = componenet as CPU_Cooler;
        }

        private CPU_Cooler selectedCPUCooler;

        public CPU_Cooler SelectedCPUCooler
        {
            get { return selectedCPUCooler; }
            set
            {
                selectedCPUCooler = value;
                OnPropertyChanged(nameof(SelectedCPUCooler));
            }
        }
        public ICommand SelectViewCommand { get; }        
        public ICommand SelectPartCommand { get; }

        public string Compatibilities
        {
            get => SelectedCPUCooler?.Compatibility != null
                ? string.Join(" ", SelectedCPUCooler.Compatibility.Select(c => c.Socket))
                : string.Empty;
        }        
    }
}
