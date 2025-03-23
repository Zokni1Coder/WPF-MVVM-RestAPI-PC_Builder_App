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

namespace PC_Builder.ViewModels
{
    public class SelectedRAMViewModel : BaseSelectedViewModel
    {
        public SelectedRAMViewModel(int ID)
        {
            LoadDataAsync(ID);
            SelectViewCommand = new SelectViewCommand();
        }
        private RAMtoGrid selectedRAM;

        public RAMtoGrid SelectedRAM
        {
            get { return selectedRAM; }
            set
            {
                selectedRAM = value;
                OnPropertyChanged(nameof(SelectedRAM));
            }
        }
        public ICommand SelectViewCommand { get; }
        public async Task LoadDataAsync(int ID)
        {
            await getData(ID);
        }

        public async Task getData(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/rams/{id}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<RAM> ramList = JsonSerializer.Deserialize<List<RAM>>(response, option);
            if (ramList != null && ramList.Count > 0)
            {
                RAMtoGrid tempRAM = new RAMtoGrid();
                tempRAM.ID = ramList[0].Id;
                tempRAM.Manufacturer = ramList[0].Manufacturer;
                tempRAM.Model = ramList[0].Model;
                tempRAM.Price = ramList[0].Price;
                tempRAM.Size = ramList[0].Size;
                tempRAM.Speed = ramList[0].Speed;
                tempRAM.Type = ramList[0].Type;
                tempRAM.Modul = ramList[0].Modul;
                tempRAM.Cas_latency= ramList[0].Cas_latency;
                tempRAM.Voltage = ramList[0].Voltage;
                SelectedRAM = tempRAM;
            }
        }

        public class RAMtoGrid
        {
            public int ID { get; set; }
            public string Model { get; set; }
            public int Price { get; set; }
            public string Manufacturer { get; set; }
            public int Speed { get; set; }
            public string Type { get; set; }
            public int Modul { get; set; }
            public int Size { get; set; }
            public int Cas_latency { get; set; }
            public double Voltage { get; set; }
        }
    }
}
