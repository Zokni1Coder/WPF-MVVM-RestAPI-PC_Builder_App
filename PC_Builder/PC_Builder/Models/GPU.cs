using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PC_Builder.Interfaces;

namespace PC_Builder.Models
{
    public class GPU : IComputerPart
    {
        private int id;
        [JsonPropertyName("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string info;
        [JsonPropertyName("info")]
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        private string manufacturer;
        [JsonPropertyName("manufacturer")]
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private string brand;
        [JsonPropertyName("brand")]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private string technology;
        [JsonPropertyName("technology")]
        public string Technology
        {
            get { return technology; }
            set { technology = value; }
        }

        private string model;
        [JsonPropertyName("model")]
        public string Model
        {
            get { return this.Manufacturer + " " + this.Info + " " + this.model; }
            set { model = value; }
        }

        private int vram;
        [JsonPropertyName("vram")]
        public int Vram
        {
            get { return vram; }
            set { vram = value; }
        }

        private string ram_type;
        [JsonPropertyName("ram_type")]
        public string Ram_type
        {
            get { return ram_type; }
            set { ram_type = value; }
        }

        private int core_clock;
        [JsonPropertyName("core_clock")]
        public int Core_clock
        {
            get { return core_clock; }
            set { core_clock = value; }
        }

        private int boost_clock;
        [JsonPropertyName("boost_clock")]
        public int Boost_clock
        {
            get { return boost_clock; }
            set { boost_clock = value; }
        }

        private string Interface;
        [JsonPropertyName("interface")]
        public string INterface
        {
            get { return Interface; }
            set { Interface = value; }
        }

        private string frame_sync;
        [JsonPropertyName("frame_sync")]
        public string Frame_sync
        {
            get { return frame_sync; }
            set { frame_sync = value; }
        }

        private int tdp;
        [JsonPropertyName("tdp")]
        public int Tdp
        {
            get { return tdp; }
            set { tdp = value; }
        }

        private int hdmi_ouput;
        [JsonPropertyName("hdmi_ouput")]
        public int Hdmi_ouput
        {
            get { return hdmi_ouput; }
            set { hdmi_ouput = value; }
        }

        private int dp_port_output;
        [JsonPropertyName("dp_port_output")]
        public int Dp_port_output
        {
            get { return dp_port_output; }
            set { dp_port_output = value; }
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
            visitor.VisitGPU(this);
        }
    }
}
