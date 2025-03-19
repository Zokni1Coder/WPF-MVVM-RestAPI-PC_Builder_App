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
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class CPUCoolerViewModel : BaseViewModel
    {
        private ObservableCollection<CPU_CoolerToView> coolers = new ObservableCollection<CPU_CoolerToView>();

        public ObservableCollection<CPU_CoolerToView> Coolers
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
                Coolers.Add(new CPU_CoolerToView
                {
                    Model = cooler.Model,
                    Manufacturer = cooler.Manufacturer,
                    Fan_RPM = cooler.Fan_RPM.ToString(),
                    Noise_level = cooler.Noise_level.ToString() + "dB",
                    Water_cooled = cooler.GetWaterCooled(),
                    Price = cooler.Price.ToString() + "€"
                });
            }
        }

        public class CPU_CoolerToView
        {
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string Fan_RPM { get; set; }
            public string Noise_level { get; set; }
            public string Water_cooled { get; set; }
            public string Price { get; set; }
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
