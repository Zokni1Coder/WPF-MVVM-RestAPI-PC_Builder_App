using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_Builder.Models
{
    public class CPU_Cooler_Compatibility
    {
		private int cooler_id;
		[JsonPropertyName("cooler_id")]
		public int Cooler_id
        {
			get { return cooler_id; }
			set { cooler_id = value; }
		}

		private string socket;
		[JsonPropertyName("name")]
		public string Socket
		{
			get { return socket; }
			set { socket = value; }
		}

	}
}
