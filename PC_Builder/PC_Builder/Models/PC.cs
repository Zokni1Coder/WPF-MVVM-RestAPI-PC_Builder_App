using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_Builder.Interfaces;
using PC_Builder.ViewModels;

namespace PC_Builder.Models
{
    public class PC : IComputer
    {
        public MotherboardViewModel.MotherboardtoGrid motherboard { get; set; }
        public CPU cpu { get; set; }
        public CPU_Cooler cpu_Cooler { get; set; }
        public List<CPU_Cooler_Compatibility> cpu_Cooler_Compatibilities { get; set; }
        public GPU gpu { get; set; }
        public List<M2> m2_Compatibility { get; set; }
        public Power_Supply power_supply { get; set; }
        public RAM ram { get; set; }
        public ROM rom { get; set; }
        public List<USBHeader> usbHeaders { get; set; }
        public List<M2> m2s { get; set; }

        public PC()
        {
            
        }
    }
}
