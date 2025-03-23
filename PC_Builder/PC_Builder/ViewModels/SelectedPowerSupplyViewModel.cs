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

namespace PC_Builder.ViewModels
{
    public class SelectedPowerSupplyViewModel : BaseSelectedViewModel
    {
        public SelectedPowerSupplyViewModel(int ID)
        {
            LoadDataAsync(ID);
            SelectViewCommand = new SelectViewCommand();
        }

        private PStoGrid selectedPS;

        public PStoGrid SelectedPS
        {
            get { return selectedPS; }
            set
            {
                selectedPS = value;
                OnPropertyChanged(nameof(SelectedPS));
            }
        }
        public ICommand SelectViewCommand { get; }
        public async Task LoadDataAsync(int ID)
        {
            await getData(ID);
            OnPropertyChanged(nameof(SelectedPS));
        }

        public async Task getData(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/power_supplies/{id}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Power_Supply> psList = JsonSerializer.Deserialize<List<Power_Supply>>(response, option);
            if (psList != null && psList.Count > 0)
            {
                PStoGrid tempPS = new PStoGrid();
                tempPS.ID = psList[0].Id;
                tempPS.Manufacturer = psList[0].Manufacturer;
                tempPS.Model = psList[0].Model;
                tempPS.Type = psList[0].Type;
                tempPS.Price = psList[0].Price;
                tempPS.Rating = psList[0].Rating;
                tempPS.Modularity = psList[0].Modularity;
                tempPS.Wattage = psList[0].Wattage;
                SelectedPS = tempPS;
            }
        }
        public class PStoGrid
        {
            public int ID { get; set; }
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string Rating { get; set; }
            public string Type { get; set; }
            public string Modularity { get; set; }
            public int Wattage { get; set; }
            public int Price { get; set; }
        }
    }
}
