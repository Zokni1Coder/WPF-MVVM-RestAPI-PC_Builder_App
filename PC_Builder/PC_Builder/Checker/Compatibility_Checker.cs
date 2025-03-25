using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PC_Builder.Interfaces;
using PC_Builder.Models;
using PC_Builder.ViewModels;
using static PC_Builder.ViewModels.CPUViewModel;

namespace PC_Builder.Checker
{
    public class Compatibility_Checker : IComputerPartVisitor
    {
        Motherboard selectedMotherboard;
        private int MinimumWattage = 0;
        private List<string> errors = new List<string>();
        public List<string> GetErrors()
        {
            return errors;
        }

        public void VisitCPU(CPU cpu)
        {
            MinimumWattage += cpu.Tdp;
            if (this.selectedMotherboard.Socket != cpu.Socket)
            {
                errors.Add($"The motherboard (socket: {selectedMotherboard.Socket}) and the CPU (socket: {cpu.Socket}) are not compatible!");
            }
        }

        public void VisitCPUCooler(CPU_Cooler cpuCooler)
        {
            bool found = false;
            foreach (var socket in cpuCooler.Compatibility)
            {
                if (socket.Socket == this.selectedMotherboard.Socket)
                {
                    found = true;
                }
            }
            if (!found)
            {
                errors.Add($"The CPU (socket: {selectedMotherboard.Socket}) and the Cooler (supported sockets: {string.Join(", ", cpuCooler.Compatibility.Select(s => s.Socket))} are not compatible!");
            }
        }

        public Compatibility_Checker()
        {

        }

        public void VisitGPU(GPU gpu)
        {
            MinimumWattage += gpu.Tdp;
            //throw new NotImplementedException();
        }

        public void VisitMotherboard(Motherboard motherboard)
        {
            selectedMotherboard = motherboard;
        }

        public void VisitPS(Power_Supply ps)
        {
            if (this.MinimumWattage > ps.Wattage)
            {
                errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required wattage: {this.MinimumWattage}W)!");
            }
            if (ps.Rating == "80 Plus" || ps.Rating == "Unrated")
            {
                errors.Add($"The power supply (efficiency rating: {ps.Rating}) is not recommended!");
            }
        }

        public void VisitRAM(RAM ram)
        {
            if (this.selectedMotherboard.Ram_type != ram.Type)
            {
                errors.Add($"The RAM (socket type: {ram.Type}) is not compatible with the motherboard (RAM socket type: {selectedMotherboard.Ram_type})!");
            }
            if (this.selectedMotherboard.Max_memory < ram.Size)
            {
                errors.Add($"The motherboard (max memory support: {selectedMotherboard.Max_memory}GB) and the RAM (memory size: {ram.Size}GB) are not compatible!");
            }
            //if(this.selectedMotherboard)
        }

        public void VisitROM(ROM rom)
        {
            bool found = false;
            if (rom.Type == "SSD" && rom.INterface == "M2")
            {
                foreach (var m2 in selectedMotherboard.M2Compatibilites)
                {
                    if (m2.Form_factor == rom.Form_factor)
                    {
                        found = true; break;
                    }
                }
                if (!found)
                {
                    errors.Add($"The ROM (form factor: {rom.Form_factor}) is not compatible with the motherboard (form factor: {selectedMotherboard.M2Compatibilites.Select(s => s.Form_factor)})!");
                }
            }
        }
    }
}
