using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class CPUViewModel : BaseViewModel
    {
        private ObservableCollection<CPUS> cpusToView = new ObservableCollection<CPUS>();

        public ObservableCollection<CPUS> CpusToView
        {
            get { return cpusToView; }
            set { cpusToView = value; }
        }

        public ICommand SelectViewCommand { get; }
        public CPUViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand(new SelectedPartViewModel());
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/cpus");
            List<CPU> tempCPUS = JsonSerializer.Deserialize<List<CPU>>(response);
            foreach (CPU cpu in tempCPUS)
            {
                CpusToView.Add(new CPUS
                {
                    Model = cpu.Manufacturer + " " + cpu.Series,
                    Core_Count = cpu.Core_count.ToString(),
                    Boost_Clock = cpu.Boost_core_clock.ToString() + "GHz",
                    Core_Clock = cpu.Core_clock.ToString() + "GHz",
                    Microarchitecture = cpu.Microarchitecture,
                    Price = cpu.Price.ToString() + "€"
                });
            }
        }
    }

    public class CPUS
    {
        public string Model { get; set; }
        public string Core_Count { get; set; }
        public string Core_Clock { get; set; }
        public string Boost_Clock { get; set; }
        public string Microarchitecture { get; set; }
        public string Price { get; set; }
    }
}
