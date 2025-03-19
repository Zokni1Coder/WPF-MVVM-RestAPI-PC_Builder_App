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
using System.Windows.Input;
using System.Windows.Interop;
using PC_Builder.Commands;
using PC_Builder.Models;


namespace PC_Builder.ViewModels
{
    public class MotherboardViewModel : BaseViewModel
    {     
        private ObservableCollection<MotherboardtoGrid> motherboardList = new ObservableCollection<MotherboardtoGrid>();

        public ObservableCollection<MotherboardtoGrid> Motherboards
        {
            get { return motherboardList; }
        }

        public ICommand SelectViewCommand { get; }
        public ICommand SelectPartCommand { get; }

        public MotherboardViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
            //SelectPartCommand = new SelectPartCommand();           
        }

        public async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/motherboards");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Structure structure = JsonSerializer.Deserialize<Structure>(response, option);

            if (structure?.motherboards != null)
            {
                foreach (var m in structure.motherboards)
                {
                    Motherboards.Add(new MotherboardtoGrid
                    {
                        ID = m.Id,
                        Model = m.Manufacturer + " " + m.Info,
                        Chipset = m.Chipset,
                        Socket = m.Socket,
                        Form_factor = m.Form_factor,
                        Ram_type = m.Ram_type,
                        Price = m.Price + "€"
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
            public int ID { get; set; }
            public string Model { get; set; }
            public string Chipset { get; set; }
            public string Socket { get; set; }
            public string Form_factor { get; set; }
            public string Ram_type { get; set; }
            public string Price { get; set; }

        }
    }
}
