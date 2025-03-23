using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Commands;
using System.Windows.Input;
using System.Windows;
using static PC_Builder.ViewModels.SelectedCPUViewModel;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class SelectedGPUViewModel : BaseSelectedViewModel
    {
        private GPUtoGrid selectedGPU;

        public GPUtoGrid SelectedGPU
        {
            get { return selectedGPU; }
            set
            {
                selectedGPU = value;
                OnPropertyChanged(nameof(SelectedGPU));
            }
        }
        public ICommand SelectViewCommand { get; }

        public SelectedGPUViewModel(int ID)
        {
            LoadDataAsync(ID);
            SelectViewCommand = new SelectViewCommand();
        }
        public async Task LoadDataAsync(int ID)
        {
            await getData(ID);
        }

        public async Task getData(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/gpus/{id}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<GPU> gpuList = JsonSerializer.Deserialize<List<GPU>>(response, option);
            if (gpuList != null && gpuList.Count > 0)
            {
                GPUtoGrid tempGPU = new GPUtoGrid();
                tempGPU.ID = gpuList[0].Id;
                tempGPU.Manufacturer = gpuList[0].Manufacturer;
                tempGPU.Brand = gpuList[0].Brand;
                tempGPU.Technology = gpuList[0].Technology;
                tempGPU.Model = gpuList[0].Brand + " " + gpuList[0].Model + " " + gpuList[0].Technology;
                tempGPU.VRAM = gpuList[0].Vram;
                tempGPU.RAM_Type = gpuList[0].Ram_type;
                tempGPU.Core_clock = gpuList[0].Core_clock;
                tempGPU.Boost_clock = gpuList[0].Boost_clock;
                tempGPU.Interface = gpuList[0].INterface;
                tempGPU.Frame_sync = gpuList[0].Frame_sync;
                tempGPU.TDP = gpuList[0].Tdp;
                tempGPU.Hdmi_ouput = gpuList[0].Hdmi_ouput;
                tempGPU.Price = gpuList[0].Price;
                tempGPU.Info = gpuList[0].Info;
                tempGPU.Dp_port_output = gpuList[0].Dp_port_output;
                SelectedGPU = tempGPU;
            }
        }

        public class GPUtoGrid
        {
            public int ID { get; set; }
            public string Info { get; set; }
            public string Manufacturer { get; set; }
            public string Brand { get; set; }
            public string Technology { get; set; }
            public string Model { get; set; }
            public int VRAM { get; set; }
            public string RAM_Type { get; set; }
            public int Core_clock { get; set; }
            public int Boost_clock { get; set; }
            public string Interface { get; set; }
            public string Frame_sync { get; set; }
            public int TDP { get; set; }
            public int Hdmi_ouput { get; set; }
            public int Dp_port_output { get; set; }
            public int Price { get; set; }
        }
    }
}
