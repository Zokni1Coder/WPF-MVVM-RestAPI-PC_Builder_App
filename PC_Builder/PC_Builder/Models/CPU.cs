using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class CPU
    {
        private int id;
        [JsonPropertyName("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string series;
        [JsonPropertyName("series")]
        public string Series
        {
            get { return series; }
            set { series = value; }
        }

        private string microarchitecture;
        [JsonPropertyName("microarchitecture")]
        public string Microarchitecture
        {
            get { return microarchitecture; }
            set { microarchitecture = value; }
        }

        private string socket;
        [JsonPropertyName("socket")]
        public string Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        private int core_count;
        [JsonPropertyName("core_count")]
        public int Core_count
        {
            get { return core_count; }
            set { core_count = value; }
        }

        private int thread_count;
        [JsonPropertyName("thread_count")]
        public int Thread_count
        {
            get { return thread_count; }
            set { thread_count = value; }
        }

        private double core_clock;
        [JsonPropertyName("core_clock")]
        public double Core_clock
        {
            get { return core_clock; }
            set { core_clock = value; }
        }

        private double boost_core_clock;
        [JsonPropertyName("boost_core_clock")]
        public double Boost_core_clock
        {
            get { return boost_core_clock; }
            set { boost_core_clock = value; }
        }

        private double L2_cache;
        [JsonPropertyName("L2_cache")]
        public double L2_Cache
        {
            get { return L2_cache; }
            set { L2_cache = value; }
        }

        private double L3_cache;
        [JsonPropertyName("L3_cache")]
        public double L3_Cache
        {
            get { return L3_cache; }
            set { L3_cache = value; }
        }

        private int tdp;
        [JsonPropertyName("tdp")]
        public int Tdp
        {
            get { return tdp; }
            set { tdp = value; }
        }

        private string integrated_graphics;
        [JsonPropertyName("integrated_graphics")]
        public string Integrated_graphics
        {
            get
            {
                return integrated_graphics == null ? integrated_graphics : "None";
            }
            set { integrated_graphics = value; }
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