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
    public class SelectedROMViewModel : BaseSelectedViewModel
    {
        public SelectedROMViewModel(IComputerPart componenet)
        {
            SelectViewCommand = new SelectViewCommand();
            SelectPartCommand = new SelectPartCommand();
            this.SelectedROM = componenet as ROM;
        }

        private ROM selectedROM;

        public ROM SelectedROM
        {
            get { return selectedROM; }
            set
            {
                selectedROM = value;
                OnPropertyChanged(nameof(SelectedROM));
            }
        }
        public ICommand SelectViewCommand { get; }
        public ICommand SelectPartCommand { get; }

        public string NVMEText => SelectedROM != null && SelectedROM.Nvme == 1 ? "Yes" : "No";
    }
}
