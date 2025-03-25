using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Models;
using static PC_Builder.ViewModels.SelectedROMViewModel;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;

namespace PC_Builder.ViewModels
{
    public class SelectedPowerSupplyViewModel : BaseSelectedViewModel
    {
        public SelectedPowerSupplyViewModel(IComputerPart component)
        {
            SelectViewCommand = new SelectViewCommand();
            this.SelectedPS = component as Power_Supply;
        }

        private Power_Supply selectedPS;

        public Power_Supply SelectedPS
        {
            get { return selectedPS; }
            set
            {
                selectedPS = value;
                OnPropertyChanged(nameof(SelectedPS));
            }
        }
        public ICommand SelectViewCommand { get; }                     
    }
}
