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
using PC_Builder.Exceptions;

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
            if (cpu == null)
            {
                throw new EmptySelectedPartException("CPU");
            }
            MinimumWattage += cpu.Tdp;
            if (this.selectedMotherboard.Socket != cpu.Socket)
            {
                errors.Add($"The motherboard (socket: {selectedMotherboard.Socket}) and the CPU (socket: {cpu.Socket}) are not compatible!");
            }
        }

        public void VisitCPUCooler(CPU_Cooler cpuCooler)
        {
            if (cpuCooler == null)
            {
                throw new EmptySelectedPartException("CPU Cooler");
            }
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
            CPUCoolerWattageUsage(cpuCooler.Water_cooled);
        }

        private void CPUCoolerWattageUsage(int water_cooler)
        {
            switch (water_cooler)
            {
                case 1:
                    this.MinimumWattage += 15;
                    break;
                case 0:
                    this.MinimumWattage += 5;
                    break;
                default: break;
            }
        }

        public Compatibility_Checker()
        {

        }

        public void VisitGPU(GPU gpu)
        {
            if (gpu == null)
            {
                throw new EmptySelectedPartException("Graphic Card");
            }
            MinimumWattage += gpu.Tdp;
        }

        public void VisitMotherboard(Motherboard motherboard)
        {
            if (motherboard == null)
            {
                throw new EmptySelectedPartException("Motherboard");
            }
            selectedMotherboard = motherboard;
            this.MinimumWattage += 45;
        }

        public void VisitPS(Power_Supply ps)
        {
            if (ps == null)
            {
                throw new EmptySelectedPartException("Power Supply");
            }
            if (ps.Rating == "Standard")
            {
                errors.Add($"The power supply (efficiency rating: {ps.Rating}) is not recommended!");
            }
            PSWattageCheck(ps);
        }

        private void PSWattageCheck(Power_Supply ps)
        {
            switch (ps.Rating)
            {
                case "Standard":
                    if (this.MinimumWattage > ps.Wattage * 0.8)
                    {
                        errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required netto wattage: {this.MinimumWattage}W)!");
                    }
                    break;
                case "Bronze":
                    if (this.MinimumWattage > ps.Wattage * 0.82)
                    {
                        errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required netto wattage: {this.MinimumWattage}W)!");
                    }
                    break;
                case "Silver":
                    if (this.MinimumWattage > ps.Wattage * 0.85)
                    {
                        errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required netto wattage: {this.MinimumWattage}W)!");
                    }
                    break;
                case "Gold":
                    if (this.MinimumWattage > ps.Wattage * 0.87)
                    {
                        errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required netto wattage: {this.MinimumWattage}W)!");
                    }
                    break;
                case "Platinum":
                    if (this.MinimumWattage > ps.Wattage * 0.9)
                    {
                        errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required netto wattage: {this.MinimumWattage}W)!");
                    }
                    break;
                case "Titanium":
                    if (this.MinimumWattage > ps.Wattage * 0.92)
                    {
                        errors.Add($"The power supply (wattage: {ps.Wattage}W) is not compatible with the configuration (minimum required netto wattage: {this.MinimumWattage}W)!");
                    }
                    break;
                default: break;
            }
        }

        public void VisitRAM(RAM ram)
        {
            if (ram == null)
            {
                throw new EmptySelectedPartException("RAM");
            }

            RAMWattageUsage(ram);

            if (this.selectedMotherboard.Ram_type != ram.Type)
            {
                errors.Add($"The RAM (socket type: {ram.Type}) is not compatible with the motherboard (RAM socket type: {selectedMotherboard.Ram_type})!");
            }
            if (this.selectedMotherboard.Max_memory < ram.Size)
            {
                errors.Add($"The motherboard (max memory support: {selectedMotherboard.Max_memory}GB) and the RAM (memory size: {ram.Size}GB) are not compatible!");
            }
        }

        private void RAMWattageUsage(RAM ram)
        {
            switch (ram.Type)
            {
                case "DDR1":
                    this.MinimumWattage += 5 * ram.Modul;
                    break;
                case "DDR2":
                    this.MinimumWattage += 4 * ram.Modul;
                    break;
                case "DDR3":
                    this.MinimumWattage += 3 * ram.Modul;
                    break;
                case "DDR4":
                    this.MinimumWattage += 2 * ram.Modul;
                    break;
                case "DDR5":
                    this.MinimumWattage += 3 * ram.Modul;
                    break;
                default:
                    break;
            }
        }

        public void VisitROM(ROM rom)
        {
            if (rom == null)
            {
                throw new EmptySelectedPartException("ROM");
            }
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
            ROMWattageUsage(rom);
        }

        private void ROMWattageUsage(ROM rom)
        {
            switch (rom.Type)
            {
                case "HDD":
                    MinimumWattage += rom.Form_factor == "3.5\"" ? 25 : 5;
                    break;
                case "SSD":
                    MinimumWattage += rom.INterface == "M.2" ? 8 : 4;
                    break;
                default: break;
            }
        }
    }
}
