using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IComputer computer;

        public IComputer Computer
        {
            get
            {
                if (computer == null)
                {
                    computer = new PC();
                }
                return computer;
            }
        }
        public static MainWindowViewModel viewModel { get; private set; }

        public void SetMotherboard(MotherboardViewModel.MotherboardtoGrid motherboard)
        {
            this.Computer.motherboard = motherboard;
        }

        public MotherboardViewModel.MotherboardtoGrid GetMotherboard()
        {
            return this.computer.motherboard;
        }

        public void SetCPU(CPUViewModel.CPUS cpu)
        {
            this.Computer.cpu = cpu;
        }

        public CPUViewModel.CPUS GetCPU()
        {
            return this.computer.cpu;
        }

        public void SetCPUCooler(CPUCoolerViewModel.CPU_CoolerToView cooler)
        {
            this.Computer.cpu_Cooler = cooler;
        }
        public CPUCoolerViewModel.CPU_CoolerToView getCPUCooler()
        {
            return this.Computer.cpu_Cooler;
        }

        public void SetGPU(GPUViewModel.GpuToView gpu)
        {
            this.Computer.gpu = gpu;
        }

        public GPUViewModel.GpuToView GetGPU()
        {
            return this.Computer.gpu;
        }

        //public List<M2> GetM2s()
        //{
        //    return this.Computer.m2s;
        //}

        //public void SetM2s(List<M2> m2s)
        //{
        //    this.Computer.m2s = m2s;
        //}

        public void SetPowerSupply(PowerSupplyViewModel.SupplyToView powerSupply)
        {
            this.Computer.power_supply = powerSupply;
        }

        public PowerSupplyViewModel.SupplyToView GetPower_Supply()
        {
            return this.Computer.power_supply;
        }

        public void SetRAM(RAMViewModel.RAMToView ram)
        {
            this.Computer.ram = ram;
        }

        public RAMViewModel.RAMToView GetRAM()
        {
            return this.Computer.ram;
        }

        public void SetROM(ROMViewModel.ROMToView rom)
        {
            this.Computer.rom = rom;
        }

        public ROMViewModel.ROMToView GetROM()
        {
            return this.Computer.rom;
        }

        //public void SetUSBHeaders(List<USBHeader> headers)
        //{
        //    this.computer.usbHeaders = headers;
        //}

        //public List<USBHeader> GetUSBHeaders()
        //{
        //    return this.computer.usbHeaders;
        //}

        private BaseViewModel selectedViewModel = new HomeViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand SelectPartCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            viewModel = this;
            UpdateViewCommand = new UpdateViewCommand(this);
            SelectPartCommand = new SelectPartCommand();
            SelectedViewModel = new MotherboardViewModel();
        }
    }
}
