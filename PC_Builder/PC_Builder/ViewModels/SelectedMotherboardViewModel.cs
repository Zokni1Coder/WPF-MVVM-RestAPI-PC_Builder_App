﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class SelectedMotherboardViewModel : BaseSelectedViewModel
    {
        private MotherboardtoGrid selectedMotherboard;

        public MotherboardtoGrid SelectedMotherboard
        {
            get { return selectedMotherboard; }
        }

        private int motherboardID;

        public SelectedMotherboardViewModel(int ID)
        {
             getData();
            this.motherboardID = ID;
        }
        public SelectedMotherboardViewModel()
        {
            
        }

        public async void getData()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://localhost:3000/motherboards/{motherboardID}");
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Structure structure = JsonSerializer.Deserialize<Structure>(response, option);
            MotherboardtoGrid motherboardtoGrid = new MotherboardtoGrid(structure.motherboard);
            this.selectedMotherboard = motherboardtoGrid;           
        }
        public class Structure
        {
            [JsonPropertyName("motherboard")]
            public Motherboard motherboard { get; set; }
            [JsonPropertyName("usb_headers")]
            public List<USBHeader> usbHeaders { get; set; }
            [JsonPropertyName("m2types")]
            public List<M2> m2s { get; set; }
        }

        public class MotherboardtoGrid
        {
            public MotherboardtoGrid(Motherboard motherboard)
            {
                Model = motherboard.Manufacturer + " " + motherboard.Info;
                Chipset = motherboard.Chipset;
                Socket = motherboard.Socket;
                Form_factor = motherboard.Form_factor;
                Ram_type = motherboard.Ram_type;
                Manufacturer = motherboard.Manufacturer;
                Price = motherboard.Price.ToString();
                Memory_Max = motherboard.Max_memory.ToString();
                Memory_Slots_No = motherboard.Memory_slot_no.ToString();
                Sata_60gbs_no = motherboard.Sata_60gbs_no.ToString();
                Onboard_Ethernet = motherboard.GetOnboardEthernet();
                Wifi = motherboard.GetWifi();
                Raid_Supp = motherboard.GetRaidSupport();
            }
            public string Model { get; set; }
            public string Chipset { get; set; }
            public string Socket { get; set; }
            public string Form_factor { get; set; }
            public string Ram_type { get; set; }
            public string Manufacturer { get; set; }
            public string Price { get; set; }
            public string Memory_Max { get; set; }
            public string Memory_Slots_No { get; set; }
            public string Sata_60gbs_no { get; set; }
            public string Onboard_Ethernet { get; set; }
            public string Wifi { get; set; }
            public string Raid_Supp { get; set; }
        }
    }
}
