using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_Builder.ViewModels;

namespace PC_Builder.Interfaces
{
    public interface IComputerPartVisitor
    {
        void VisitMotherboard(MotherboardViewModel.MotherboardtoGrid motherboard);
        void VisitCPUCooler(CPUCoolerViewModel.CPU_CoolerToView cpuCooler);
        void VisitCPU(CPUViewModel.CPUS cpu);
        void VisitGPU(GPUViewModel.GpuToView gpu);
        void VisitPS(PowerSupplyViewModel.SupplyToView ps);
        void VisitRAM(RAMViewModel.RAMToView ram);
        void VisitROM(ROMViewModel.ROMToView rom);

    }
}
