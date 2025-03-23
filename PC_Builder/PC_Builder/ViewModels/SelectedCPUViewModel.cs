using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class SelectedCPUViewModel : BaseSelectedViewModel
    {
        private CPUtoGrid selectedCPU;

        public CPUtoGrid SelectedCPU
        {
            get { return selectedCPU; }
            set
            {
                selectedCPU = value;
                OnPropertyChanged(nameof(selectedCPU));
            }
        }

        public ICommand SelectViewCommand { get; }

        public SelectedCPUViewModel(int ID)
        {
            SelectViewCommand = new SelectViewCommand();
            LoadDataAsync(ID);
        }

        public async Task LoadDataAsync(int ID)
        {
            await getData(ID);
        }

        public async Task getData(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/cpus/{id}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<CPU> cpuList = JsonSerializer.Deserialize<List<CPU>>(response, option);

            if (cpuList != null && cpuList.Count > 0)
            {
                CPU tempCPU = cpuList[0];
                this.SelectedCPU = new CPUtoGrid(
                    tempCPU.Id, tempCPU.Socket, tempCPU.Manufacturer, tempCPU.Series,
                    (tempCPU.Manufacturer + " " + tempCPU.Series), tempCPU.Tdp,
                    tempCPU.Integrated_graphics, tempCPU.Thread_count, tempCPU.Core_count,
                    tempCPU.L2_Cache, tempCPU.L3_Cache, tempCPU.Core_clock, tempCPU.Boost_core_clock,
                    tempCPU.Microarchitecture, tempCPU.Price
                );
            }
        }

        public class CPUtoGrid
        {
            public CPUtoGrid(int iD, string socket, string manufacturer, string series, string model, int tDP, string integrated_Graphics, int thread_Count, int core_Count, double l2_Cache, double l3_Cache, double core_Clock, double boost_Clock, string microarchitecture, int price)
            {
                ID = iD;
                Socket = socket;
                Manufacturer = manufacturer;
                Series = series;
                Model = model;
                TDP = tDP;
                Integrated_Graphics = integrated_Graphics;
                Thread_Count = thread_Count;
                Core_Count = core_Count;
                L2_Cache = l2_Cache;
                L3_Cache = l3_Cache;
                Core_Clock = core_Clock;
                Boost_Clock = boost_Clock;
                Microarchitecture = microarchitecture;
                Price = price;
            }

            public int ID { get; set; }
            public string Socket { get; set; }
            public string Manufacturer { get; set; }
            public string Series { get; set; }
            public string Model { get; set; }
            public int TDP { get; set; }
            public string Integrated_Graphics { get; set; }
            public int Thread_Count { get; set; }
            public int Core_Count { get; set; }
            public double L2_Cache { get; set; }
            public double L3_Cache { get; set; }
            public double Core_Clock { get; set; }
            public double Boost_Clock { get; set; }
            public string Microarchitecture { get; set; }
            public int Price { get; set; }
        }
    }
}
