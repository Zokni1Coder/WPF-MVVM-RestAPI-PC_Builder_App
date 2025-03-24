using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_Builder.Models;
using PC_Builder.ViewModels;

namespace PC_Builder.Interfaces
{
    public interface IComputer
    {
        MotherboardViewModel.MotherboardtoGrid motherboard { get; set; }
        CPUViewModel.CPUS cpu { get; set; }
        CPUCoolerViewModel.CPU_CoolerToView cpu_Cooler { get; set; }
        GPUViewModel.GpuToView gpu { get; set; }
        //List<M2> m2s { get; set; }
        PowerSupplyViewModel.SupplyToView power_supply { get; set; }
        RAMViewModel.RAMToView ram { get; set; }
        ROMViewModel.ROMToView rom { get; set; }
        //List<USBHeader> usbHeaders { get; set; }
    }
}
