using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_Builder.Models;
using PC_Builder.ViewModels;

namespace PC_Builder.Interfaces
{
    public interface IComputerPartVisitor
    {
        void VisitMotherboard(Motherboard motherboard);
        void VisitCPUCooler(CPU_Cooler cpuCooler);
        void VisitCPU(CPU cpu);
        void VisitGPU(GPU gpu);
        void VisitPS(Power_Supply ps);
        void VisitRAM(RAM ram);
        void VisitROM(ROM rom);
    }
}
