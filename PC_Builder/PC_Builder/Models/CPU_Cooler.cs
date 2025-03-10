using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class CPU_Cooler
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
        private string manufacturer;
        [JsonPropertyName("name")]
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private int fan_RPM;
        [JsonPropertyName("fan_rpm")]
        public int Fan_RPM
        {
            get { return fan_RPM; }
            set { fan_RPM = value; }
        }


        private double noise_level;
        [JsonPropertyName("noise_level")]
        public double Noise_level
        {
            get { return noise_level; }
            set { noise_level = value; }
        }

        private int height;
        [JsonPropertyName("height")]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int water_cooled;
        [JsonPropertyName("water_cooled")]
        public int Water_cooled
        {
            get { return water_cooled; }
            set { water_cooled = value; }
        }

        public string GetWaterCooled()
        {
            return water_cooled == 1 ? "Yes" : "No";
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