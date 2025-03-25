using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Models;
using PC_Builder.Commands;
using System.Windows.Input;
using PC_Builder.Interfaces;

namespace PC_Builder.ViewModels
{
    public class RAMViewModel : BaseViewModel
    {
        private ObservableCollection<RAMToView> rams = new ObservableCollection<RAMToView>();

        public ObservableCollection<RAMToView> Rams
        {
            get { return rams; }
            set { rams = value; }
        }

        public ICommand SelectViewCommand { get; }
        public RAMViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/rams");
            List<RAM> tempRams = JsonSerializer.Deserialize<List<RAM>>(response);

            foreach (var ram in tempRams)
            {
                Rams.Add(new RAMToView
                {
                    Model = ram.Manufacturer + " " + ram.Model + " " + ram.Size.ToString() + "GB",
                    Memory_Size = ram.Size,
                    Slot_Type = ram.Type,
                    Speed = ram.Speed,
                    Cas_Latency = ram.Cas_latency,
                    Price = ram.Price,
                    ID = ram.Id
                });
            }
        }

        public class RAMToView : IComputerPart
        {
            public int ID { get; set; }
            public string Model { get; set; }
            public int Memory_Size { get; set; }
            public string Slot_Type { get; set; }
            public int Speed { get; set; }
            public int Cas_Latency { get; set; }
            public int Price { get; set; }

            public void Accept(IComputerPartVisitor visitor)
            {
               visitor.VisitRAM(this);
            }
        }
    }
}
