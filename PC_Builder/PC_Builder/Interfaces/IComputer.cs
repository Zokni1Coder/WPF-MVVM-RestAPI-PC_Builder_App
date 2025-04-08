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
        Motherboard motherboard { get; set; }
        CPU cpu { get; set; }
        CPU_Cooler cpu_Cooler { get; set; }
        GPU gpu { get; set; }
        Power_Supply power_supply { get; set; }
        RAM ram { get; set; }
        ROM rom { get; set; }
    }
}
