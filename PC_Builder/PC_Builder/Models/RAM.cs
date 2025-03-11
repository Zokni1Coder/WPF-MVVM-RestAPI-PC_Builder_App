using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class RAM
    {
        private int id;
        [JsonPropertyName("id")]            
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string model;
        [JsonPropertyName("model")]
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private string name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int speed;
        [JsonPropertyName("speed")]
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private string type;
        [JsonPropertyName("type")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private int modul;
        [JsonPropertyName("modul")]
        public int Modul
        {
            get { return modul; }
            set { modul = value; }
        }

        private int size;
        [JsonPropertyName("size")]
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        private int cas_latency;
        [JsonPropertyName("cas_latency")]
        public int Cas_latency
        {
            get { return cas_latency; }
            set { cas_latency = value; }
        }

        private double voltage;
        [JsonPropertyName("voltage")]
        public double Voltage
        {
            get { return voltage; }
            set { voltage = value; }
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
