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
using PC_Builder.Interfaces;
using PC_Builder.Models;


namespace PC_Builder.ViewModels
{
    public class MotherboardViewModel : BaseViewModel
    {
        private ObservableCollection<MotherboardtoGrid> motherboardList = new ObservableCollection<MotherboardtoGrid>();

        public ObservableCollection<MotherboardtoGrid> Motherboards
        {
            get { return motherboardList; }
            set { motherboardList = value; }
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
                    MotherboardtoGrid tempMotherboard = new MotherboardtoGrid();
                    tempMotherboard.ID = m.Id;
                    tempMotherboard.Model = m.Manufacturer + " " + m.Info;
                    tempMotherboard.Chipset = m.Chipset;
                    tempMotherboard.Socket = m.Socket;
                    tempMotherboard.Form_factor = m.Form_factor;
                    tempMotherboard.Ram_type = m.Ram_type;
                    tempMotherboard.Price = m.Price;
                    tempMotherboard.Manufacturer = m.Manufacturer;
                    tempMotherboard.Info = m.Info;
                    tempMotherboard.Memory_max = m.Max_memory;
                    tempMotherboard.Memory_slots_no = m.Memory_slot_no;
                    tempMotherboard.Sata_60gbs_no = m.Sata_60gbs_no;
                    tempMotherboard.Onboard_ethernet = m.Onboard_ethernet;
                    tempMotherboard.Wifi = m.Wifi;
                    tempMotherboard.Raid_supp = m.Raid_supp;
                    tempMotherboard.M2Compatibilites = structure.m2s;
                    tempMotherboard.USBHeaders = structure.usbHeaders;
                    Motherboards.Add(tempMotherboard);
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

        public class MotherboardtoGrid : IComputerPart
        {
            public List<M2> M2Compatibilites { get; set; }
            public List<USBHeader> USBHeaders { get; set; }
            public int ID { get; set; }
            public string Model { get; set; }
            public string Chipset { get; set; }
            public string Socket { get; set; }
            public string Form_factor { get; set; }
            public string Ram_type { get; set; }
            public int Price { get; set; }
            public string Manufacturer { get; set; }
            public string Info { get; set; }
            public int Memory_max { get; set; }
            public int Memory_slots_no { get; set; }
            public int Sata_60gbs_no { get; set; }
            public int Onboard_ethernet { get; set; }
            public int Wifi { get; set; }
            public int Raid_supp { get; set; }

            public void Accept(IComputerPartVisitor visitor)
            {
                visitor.VisitMotherboard(this);
            }
        }
    }
}
