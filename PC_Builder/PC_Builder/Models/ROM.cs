using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PC_Builder.Interfaces;
using static PC_Builder.ViewModels.ROMViewModel;

namespace PC_Builder.Models
{
    public class ROM : IComputerPart
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
            get { return this.Manufacturer + " " + this.model; }
            set { model = value; }
        }

        private string manufacturer;
        [JsonPropertyName("name")]
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private int capacity;
        [JsonPropertyName("capacity")]
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        private string type;
        [JsonPropertyName("type")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string form_factor;
        [JsonPropertyName("form_factor")]
        public string Form_factor
        {
            get { return form_factor; }
            set { form_factor = value; }
        }

        private int nvme;
        [JsonPropertyName("nvme")]
        public int Nvme
        {
            get { return nvme; }
            set { nvme = value; }
        }

        private int? rpm;
        [JsonPropertyName("rpm")]
        public int? Rpm
        {
            get
            {                
                return rpm;
            }
            set { rpm = value; }
        }

        private string Interface;
        [JsonPropertyName("interface")]
        public string INterface
        {
            get { return Interface; }
            set { Interface = value; }
        }

        private int price;
        [JsonPropertyName("price")]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public void Accept(IComputerPartVisitor visitor)
        {
            visitor.VisitROM(this);
        }

        public string Name()
        {
            return "ROM";
        }
    }
}
