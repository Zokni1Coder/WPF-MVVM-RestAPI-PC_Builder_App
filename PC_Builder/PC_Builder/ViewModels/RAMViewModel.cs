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

        public RAMViewModel()
        {
            getDatas();
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
                    Model = " " + ram.Model + " " + ram.Size.ToString() + "GB",
                    Memory_Size = ram.Size.ToString() + "GB",
                    Slot_Type = ram.Type,
                    Speed = ram.Speed.ToString() + "MHz",
                    Cas_Latency = ram.Cas_latency.ToString(),
                    Price = ram.Price.ToString() + "€"
                });
            }
        }

        public class RAMToView
        {
            public string Model { get; set; }
            public string Memory_Size { get; set; }
            public string Slot_Type { get; set; }
            public string Speed { get; set; }
            public string Cas_Latency { get; set; }
            public string Price { get; set; }
        }
    }
}
