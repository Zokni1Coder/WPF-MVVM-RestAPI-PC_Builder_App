using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class Motherboard
    {        
        private int id;

        [JsonPropertyName("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private string manufacturer;

        [JsonPropertyName("manufacturer")]
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private string info;

        [JsonPropertyName("info")]
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        private string socket;


        [JsonPropertyName("socket")]
        public string Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        private string form_factor;

        [JsonPropertyName("form_factor")]
        public string Form_factor
        {
            get { return form_factor; }
            set { form_factor = value; }
        }

        private string chipset;

        [JsonPropertyName("chipset")]
        public string Chipset
        {
            get { return chipset; }
            set { chipset = value; }
        }

        private int max_memory;

        [JsonPropertyName("memory_max")]
        public int Max_memory
        {
            get { return max_memory; }
            set { max_memory = value; }
        }

        private string ram_type;

        [JsonPropertyName("ram_type")]
        public string Ram_type
        {
            get { return ram_type; }
            set { ram_type = value; }
        }

        private int memory_slot_no;

        [JsonPropertyName("memory_slots_no")]
        public int Memory_slot_no
        {
            get { return memory_slot_no; }
            set { memory_slot_no = value; }
        }

        private int sata_60gbs_no;

        [JsonPropertyName("sata_60gbs_no")]
        public int Sata_60gbs_no
        {
            get { return sata_60gbs_no; }
            set { sata_60gbs_no = value; }
        }

        private int onboard_ethernet;

        [JsonPropertyName("onboard_ethernet")]
        public int Onboard_ethernet
        {
            get { return onboard_ethernet; }
            set { onboard_ethernet = value; }
        }

        private int wifi;

        [JsonPropertyName("wifi")]
        public int Wifi
        {
            get { return wifi; }
            set { wifi = value; }
        }

        private int raid_supp;

        [JsonPropertyName("raid_supp")]
        public int Raid_supp
        {
            get { return raid_supp; }
            set { raid_supp = value; }
        }

        private int price;

        [JsonPropertyName("price")]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
