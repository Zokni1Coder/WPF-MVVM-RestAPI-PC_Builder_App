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
        public CPUCoolerViewModel.CPU_CoolerToView cpu_Cooler { get; set; }
        //public List<CPU_Cooler_Compatibility> cpu_Cooler_Compatibilities { get; set; }
        public GPUViewModel.GpuToView gpu { get; set; }
        public List<M2> m2_Compatibility { get; set; }
        public PowerSupplyViewModel.SupplyToView power_supply { get; set; }
        public RAMViewModel.RAMToView ram { get; set; }
        public ROMViewModel.ROMToView rom { get; set; }
        public List<USBHeader> usbHeaders { get; set; }
        public List<M2> m2s { get; set; }
        public CPUViewModel.CPUS cpu { get; set; }

        public PC()
        {
            
        }
    }
}
