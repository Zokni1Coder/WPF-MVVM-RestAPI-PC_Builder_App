using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class Power_Supply
    {
        private int id;
        [JsonPropertyName("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string model1;
        [JsonPropertyName("model")]
        public string Model
        {
            get { return model1; }
            set { model1 = value; }
        }

        private string manufacturer;
        [JsonPropertyName("manufacturer")]
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private string type;
        [JsonPropertyName("type")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string rating;
        [JsonPropertyName("rating")]
        public string Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private int wattage;
        [JsonPropertyName("wattage")]
        public int Wattage
        {
            get { return wattage; }
            set { wattage = value; }
        }

        private string modularity;
        [JsonPropertyName("modularity")]
        public string Modularity
        {
            get { return modularity; }
            set { modularity = value; }
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
