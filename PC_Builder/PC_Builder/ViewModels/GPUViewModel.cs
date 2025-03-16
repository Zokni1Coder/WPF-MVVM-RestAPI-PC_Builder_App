using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class GPUViewModel : BaseViewModel
    {
        private ObservableCollection<GpuToView> gpus = new ObservableCollection<GpuToView>();

        public ObservableCollection<GpuToView> Gpus
        {
            get { return gpus; }
            set { gpus = value; }
        }

        public ICommand SelectViewCommand { get; }
        public GPUViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand(new SelectedPartViewModel());
        }                                                                  

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/gpus");
            List<GPU> tempgpus = JsonSerializer.Deserialize<List<GPU>>(response);
            foreach (GPU gpu in tempgpus)
            {
                this.gpus.Add(new GpuToView
                {
                    Model =gpu.Manufacturer + " " + gpu.Info + " " + gpu.Model,
                    Memory_Size = gpu.Vram.ToString() + "GB",
                    Memory_Type = gpu.Ram_type,
                    Core_Clock = gpu.Core_clock.ToString() + "MHz", 
                    Slot = gpu.INterface,
                    Price = gpu.Price.ToString() + "€"
                });
            }
        }



        public class GpuToView
        {
            public string Model { get; set; }
            public string Memory_Size { get; set; }
            public string Memory_Type { get; set; }
            public string Core_Clock { get; set; }
            public string Slot { get; set; }
            public string Price { get; set; }
        }
    }
}
