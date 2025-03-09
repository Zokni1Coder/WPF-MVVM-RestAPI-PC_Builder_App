using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using PC_Builder.Models;


namespace PC_Builder.ViewModels
{
    public class MotherboardViewModel : BaseViewModel
    {

        //public string Id => motherboard.Id.ToString();
        //public string Manufacturer => motherboard.Manufacturer;
        //public string Chipset => motherboard.Chipset;
        //public string Socket => motherboard.Socket;
        //public string Form_factor => motherboard.Form_factor;
        //public string Ram_type => motherboard.Ram_type;
        //public string Price => motherboard.Price.ToString();


        private ObservableCollection<MotherboardtoGrid> motherboardList;

        public ObservableCollection<MotherboardtoGrid> Motherboards
        {
            get { return motherboardList; }
            set
            {
                motherboardList = value;
                OnPropertyChanged(nameof(Motherboards));
            }
        }



        public MotherboardViewModel()
        {
            motherboardList = new ObservableCollection<MotherboardtoGrid>();
            getDatas();
        }

        public async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/motherboards");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Structure structure = JsonSerializer.Deserialize<Structure>(response, option);

            if (structure?.motherboards != null)
            {
                Motherboards.Clear();

                foreach (var m in structure.motherboards)
                {
                    Motherboards.Add(new MotherboardtoGrid
                    {
                        Manufacturer = m.Manufacturer,
                        Chipset = m.Chipset,
                        Socket = m.Socket,
                        Form_factor = m.Form_factor,
                        Ram_type = m.Ram_type,
                        Price = m.Price
                    });
                }
               
            }
        }

        public class Structure
        {
            [JsonPropertyName("motherboards")]
            public List<Motherboard> motherboards { get; set; }
            [JsonPropertyName("usb_headers")]
            public List<USBHeader> usbHeaders { get; set; }
            [JsonPropertyName("m2types")]
            public List<M2> m2s { get; set; }
        }

        public class MotherboardtoGrid
        {
            public string Manufacturer { get; set; }
            public string Chipset { get; set; }
            public string Socket { get; set; }
            public string Form_factor { get; set; }
            public string Ram_type { get; set; }
            public int Price { get; set; }

        }
    }
}
