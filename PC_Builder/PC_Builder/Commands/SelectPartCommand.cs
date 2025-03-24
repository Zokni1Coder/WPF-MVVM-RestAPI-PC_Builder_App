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
                case MotherboardViewModel.MotherboardtoGrid motherboard:
                    viewModel.SetMotherboard(motherboard);
                    configViewModel.MotherboardModel = motherboard.Model + " " + motherboard.Chipset + " " + motherboard.Socket + " " + motherboard.Ram_type;
                    break;
                case CPUViewModel.CPUS SelectedCPU:
                    viewModel.SetCPU(SelectedCPU);
                    configViewModel.CPUModel = SelectedCPU.Model + " " + SelectedCPU.Core_Count + " " + SelectedCPU.Core_Clock + "GHz " + SelectedCPU.Boost_Clock + "GHz " + SelectedCPU.Microarchitecture;
                    break;
                case CPUCoolerViewModel.CPU_CoolerToView SelectedCPUCooler:
                    viewModel.SetCPUCooler(SelectedCPUCooler);
                    //compatibility
                    configViewModel.CPUCoolerModel = SelectedCPUCooler.Model + " " + SelectedCPUCooler.Fan_RPM + "RPM " + SelectedCPUCooler.Noise_level + "dB Water cooled: " + SelectedCPUCooler.Water_cooled + " ";
                    break;
                case GPUViewModel.GpuToView SelectedGPU:
                    viewModel.SetGPU(SelectedGPU);
                    configViewModel.GPUModel = SelectedGPU.Model + " " + SelectedGPU.Memory_Type + " " + SelectedGPU.Memory_Size + "GB " + SelectedGPU.Core_Clock + "MHz " + SelectedGPU.Slot;
                    break;
                case RAMViewModel.RAMToView SelectedRAM:
                    viewModel.SetRAM(SelectedRAM);
                    configViewModel.RAMModel = SelectedRAM.Model + " " + SelectedRAM.Slot_Type + " " + SelectedRAM.Memory_Size + "GB " + SelectedRAM.Speed + "MHz " + SelectedRAM.Cas_Latency;  
                    break;
                case ROMViewModel.ROMToView SelectedROM:
                    viewModel.SetROM(SelectedROM);
                    configViewModel.ROMModel = SelectedROM.Model + " " + SelectedROM.Type + " " + SelectedROM.Form_Factor + " " + SelectedROM.Capacity + "GB ";
                    break;
                case PowerSupplyViewModel.SupplyToView SelectedPS:
                    viewModel.SetPowerSupply(SelectedPS);
                    configViewModel.PSModel = SelectedPS.Model + " " + SelectedPS.Type + " " + SelectedPS.Wattage + "W " + SelectedPS.Efficiency_Rating + " " + SelectedPS.Modularity;
                    break;
                default:
                    break;
            }
        }
    }
}
