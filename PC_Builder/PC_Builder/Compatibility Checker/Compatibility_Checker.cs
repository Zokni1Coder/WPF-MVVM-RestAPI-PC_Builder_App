using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_Builder.Interfaces;
using PC_Builder.ViewModels;

namespace PC_Builder.Compatibility_Checker
{
    public class Compatibility_Checker : IComputerPartVisitor
    {
        MotherboardViewModel.MotherboardtoGrid selectedMotherboard;
        private int MinimumWattage = 0;

        public void VisitCPU(CPUViewModel.CPUS cpu)
        {
            MinimumWattage += cpu.TDP;
            if (this.selectedMotherboard.Socket != cpu.Socket)
            {
                throw new Exception();
            }
        }

        public void VisitCPUCooler(CPUCoolerViewModel.CPU_CoolerToView cpuCooler)
        {
            bool found = false;
            foreach (var socket in cpuCooler.Compatibilities)
            {
                if (socket.Socket == this.selectedMotherboard.Socket)
                {
                    found = true;
                }
            }
            if (!found)
            {
                throw new Exception();
            }
        }

        public Compatibility_Checker()
        {
            
        }

        public void VisitGPU(GPUViewModel.GpuToView gpu)
        {
            MinimumWattage += gpu.TDP;
            throw new NotImplementedException();
        }

        public void VisitMotherboard(MotherboardViewModel.MotherboardtoGrid motherboard)
        {
            selectedMotherboard = motherboard;
        }

        public void VisitPS(PowerSupplyViewModel.SupplyToView ps)
        {
            if (this.MinimumWattage > ps.Wattage) { throw new Exception(); }
        }

        public void VisitRAM(RAMViewModel.RAMToView ram)
        {
            if (this.selectedMotherboard.Ram_type != ram.Slot_Type)
            {
                throw new Exception();
            }
            if (this.selectedMotherboard.Memory_max < ram.Memory_Size)
            { throw new Exception(); }
            //if(this.selectedMotherboard)
        }

        public void VisitROM(ROMViewModel.ROMToView rom)
        {
            bool found = false;
            if (rom.Type == "SSD" && rom.Interface == "M2")
            {
                foreach (var m2 in selectedMotherboard.M2Compatibilites)
                {
                    if (m2.Form_factor == rom.Form_Factor)
                    {
                        found = true; break;
                    }
                }
            }
            if (!found)
            {
                throw new Exception();
            }
        }
    }
}
