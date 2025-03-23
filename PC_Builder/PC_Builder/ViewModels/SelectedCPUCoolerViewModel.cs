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

namespace PC_Builder.ViewModels
{
    public class SelectedCPUCoolerViewModel : BaseSelectedViewModel
    {
        public SelectedCPUCoolerViewModel(int ID)
        {
            LoadDataAsync(ID);
            SelectViewCommand = new SelectViewCommand();
        }

        private CPUCoolertoGrid selectedCPUCooler;

        public CPUCoolertoGrid SelectedCPUCooler
        {
            get { return selectedCPUCooler; }
            set
            {
                selectedCPUCooler = value;
                OnPropertyChanged(nameof(SelectedCPUCooler));
                OnPropertyChanged(nameof(Compatibilities));
                OnPropertyChanged(nameof(water_cooled));
            }
        }
        public ICommand SelectViewCommand { get; }
        public async Task LoadDataAsync(int ID)
        {
            await getData(ID);
            OnPropertyChanged(nameof(Compatibilities));
            OnPropertyChanged(nameof(water_cooled));
        }

        public async Task getData(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/cpu_coolers/{id}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Structure structure = JsonSerializer.Deserialize<Structure>(response);
            CPUCoolertoGrid tempCooler = new CPUCoolertoGrid();
            tempCooler.ID = structure.Coolers[0].Id;
            tempCooler.Model = structure.Coolers[0].Model;
            tempCooler.Manufacturer = structure.Coolers[0].Manufacturer;
            tempCooler.Fan_RPM = structure.Coolers[0].Fan_RPM;
            tempCooler.Noise_level = structure.Coolers[0].Noise_level;
            tempCooler.Water_cooled = structure.Coolers[0].Water_cooled;
            tempCooler.Price = structure.Coolers[0].Price;
            tempCooler.Height = structure.Coolers[0].Height;
            tempCooler.Compatibilities = structure.compatibilities;
            SelectedCPUCooler = tempCooler;
        }

        public string Compatibilities
        {
            get => SelectedCPUCooler?.Compatibilities != null
                ? string.Join(" ", SelectedCPUCooler.Compatibilities.Select(c => c.Socket))
                : string.Empty;
        }

        public string water_cooled => selectedCPUCooler != null && selectedCPUCooler.Water_cooled == 1 ? "Yes" : "No";

        public class CPUCoolertoGrid
        {
            public int ID { get; set; }
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public int Fan_RPM { get; set; }
            public double Noise_level { get; set; }
            public int Height { get; set; }
            public int Water_cooled { get; set; }
            public int Price { get; set; }
            public List<CPU_Cooler_Compatibility> Compatibilities { get; set; }
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
