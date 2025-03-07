using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class M2
    {
        private int motherboard;
        [JsonPropertyName("motherboard")]
        public int Motherboard
        {
            get { return motherboard; }
            set { motherboard = value; }
        }

        private string form_factor;
        [JsonPropertyName("form_factor")]
        public string Form_factor
        {
            get { return form_factor; }
            set { form_factor = value; }
        }
    }
}