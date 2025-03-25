using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class CPUCoolerViewModel : BaseViewModel
    {
        private ObservableCollection<CPU_Cooler> coolers = new ObservableCollection<CPU_Cooler>();

        public ObservableCollection<CPU_Cooler> Coolers
        {
            get { return coolers; }
            set { coolers = value; }
        }

        public ICommand SelectViewCommand { get; }
        public CPUCoolerViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/cpu_coolers");
            Structure structure = JsonSerializer.Deserialize<Structure>(response);

            foreach (var cooler in structure.Coolers)
            {
                CPU_Cooler tempCooler = new CPU_Cooler();
                tempCooler = cooler;
                tempCooler.Compatibility = structure.compatibilities.Where(s=> s.Cooler_id == cooler.Id).ToList();
                Coolers.Add(tempCooler);
            }
        }       
        public class Structure
        {
            [JsonPropertyName("cpu_coolers")]
            public List<CPU_Cooler> Coolers { get; set; }
            [JsonPropertyName("compatibilities")]
            public List<CPU_Cooler_Compatibility> compatibilities { get; set; }
        }
    }
}
