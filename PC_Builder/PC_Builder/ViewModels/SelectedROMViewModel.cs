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
    public class SelectedROMViewModel : BaseSelectedViewModel
    {
        public SelectedROMViewModel(int ID)
        {
            LoadDataAsync(ID);
            SelectViewCommand = new SelectViewCommand();
        }

        private ROMtoGrid selectedROM;

        public ROMtoGrid SelectedROM
        {
            get { return selectedROM; }
            set
            {
                selectedROM = value;
                OnPropertyChanged(nameof(SelectedROM));
            }
        }
        public ICommand SelectViewCommand { get; }
        public async Task LoadDataAsync(int ID)
        {
            await getData(ID);
            OnPropertyChanged(nameof(NVMEText));
        }

        public async Task getData(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/roms/{id}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<ROM> romList = JsonSerializer.Deserialize<List<ROM>>(response, option);
            if (romList != null && romList.Count > 0)
            {
                ROMtoGrid tempROM = new ROMtoGrid();
                tempROM.ID = romList[0].Id;
                tempROM.Manufacturer = romList[0].Manufacturer;
                tempROM.Model = romList[0].Model;
                tempROM.Interface = romList[0].INterface;
                tempROM.Capacity = romList[0].Capacity;
                tempROM.Type = romList[0].Type;
                tempROM.Form_Factor = romList[0].Form_factor;
                tempROM.NVME = romList[0].Nvme;
                tempROM.RPM = (int)romList[0].Rpm;
                tempROM.Price = romList[0].Price;
                SelectedROM = tempROM;
            }
        }
        public string NVMEText => selectedROM != null && selectedROM.NVME == 1 ? "Yes" : "No";
        public class ROMtoGrid
        {
            public int ID { get; set; }
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string Interface { get; set; }
            public int Capacity { get; set; }
            public string Type { get; set; }
            public string Form_Factor { get; set; }
            public int NVME { get; set; }
            public int RPM { get; set; }
            public int Price { get; set; }
        }
    }
}
