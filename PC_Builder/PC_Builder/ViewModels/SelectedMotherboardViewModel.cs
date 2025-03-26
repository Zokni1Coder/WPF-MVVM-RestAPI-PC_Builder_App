using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class SelectedMotherboardViewModel : BaseSelectedViewModel
    {
        private Motherboard selectedMotherboard;

        public Motherboard SelectedMotherboard
        {
            get { return selectedMotherboard; }
            set
            {
                selectedMotherboard = value;
                OnPropertyChanged(nameof(SelectedMotherboard));
            }
        }
        public ICommand SelectViewCommand { get; }
        public ICommand SelectPartCommand { get; }

        public SelectedMotherboardViewModel(IComputerPart component)
        {
            SelectViewCommand = new SelectViewCommand();
            SelectPartCommand = new SelectPartCommand();
            SetHeaderAndM2s(component as Motherboard);
            this.SelectedMotherboard = component as Motherboard;
        }
        private void SetHeaderAndM2s(Motherboard component)
        {
            this.USBHeadersToView = string.Join(" ", component.USBHeaders.Select(u => $"{u.Version}({u.GetHeaderCount()})"));
            this.M2_ConnectionsToView = string.Join(" ", component.M2Compatibilites.Select(s => s.Form_factor));
        }

        public string USBHeadersToView { get; set; }
        public string M2_ConnectionsToView { get; set; }
    }
}
