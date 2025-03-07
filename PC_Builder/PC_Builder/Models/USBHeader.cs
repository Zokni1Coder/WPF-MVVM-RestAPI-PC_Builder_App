using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class USBHeader
    {
        private int motherboard_id;
        [JsonPropertyName("motherboard_id")]
        public int Motherboard_id
        {
            get { return motherboard_id; }
            set { motherboard_id = value; }
        }

        private string version;
        [JsonPropertyName("version")]
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        private int header_count;
        [JsonPropertyName("header_count")]
        public int Header_count
        {
            get { return header_count; }
            set { header_count = value; }
        }

    }
}