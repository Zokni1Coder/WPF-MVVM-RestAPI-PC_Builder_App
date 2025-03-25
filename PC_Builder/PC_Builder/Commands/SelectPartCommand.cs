using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Models;
using PC_Builder.ViewModels;

namespace PC_Builder.Commands
{
    public class SelectPartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SelectPartCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = MainWindowViewModel.viewModel;
            var configViewModel = ConfigWindowViewModel.viewModel;
            switch (parameter)
            {
                case Motherboard motherboard:
                    viewModel.SetMotherboard(motherboard);
                    configViewModel.MotherboardModel = motherboard.Model + " " + motherboard.Chipset + " " + motherboard.Socket + " " + motherboard.Ram_type;
                    break;
                case CPU SelectedCPU:
                    viewModel.SetCPU(SelectedCPU);
                    configViewModel.CPUModel = SelectedCPU.Model + " " + SelectedCPU.Core_count + " " + SelectedCPU.Core_clock + "GHz " + SelectedCPU.Boost_core_clock + "GHz " + SelectedCPU.Microarchitecture;
                    break;
                case CPU_Cooler SelectedCPUCooler:
                    viewModel.SetCPUCooler(SelectedCPUCooler);
                    configViewModel.CPUCoolerModel = SelectedCPUCooler.Model + " " + SelectedCPUCooler.Fan_RPM + "RPM " + SelectedCPUCooler.Noise_level + "dB Water cooled: " + SelectedCPUCooler.WaterCooledToGrid + " ";
                    break;
                case GPU SelectedGPU:
                    viewModel.SetGPU(SelectedGPU);
                    configViewModel.GPUModel = SelectedGPU.Model + " " + SelectedGPU.Ram_type + " " + SelectedGPU.Vram + "GB " + SelectedGPU.Core_clock + "MHz " + SelectedGPU.INterface;
                    break;
                case RAM SelectedRAM:
                    viewModel.SetRAM(SelectedRAM);
                    configViewModel.RAMModel = SelectedRAM.Model + " " + SelectedRAM.Type + " " + SelectedRAM.Size + "GB " + SelectedRAM.Speed + "MHz " + SelectedRAM.Cas_latency;
                    break;
                case ROM SelectedROM:
                    viewModel.SetROM(SelectedROM);
                    configViewModel.ROMModel = SelectedROM.Model + " " + SelectedROM.Type + " " + SelectedROM.Form_factor + " " + SelectedROM.Capacity + "GB ";
                    break;
                case Power_Supply SelectedPS:
                    viewModel.SetPowerSupply(SelectedPS);
                    configViewModel.PSModel = SelectedPS.Model + " " + SelectedPS.Type + " " + SelectedPS.Wattage + "W " + SelectedPS.Rating + " " + SelectedPS.Modularity;
                    break;
                default:
                    break;
            }
        }
    }
}
