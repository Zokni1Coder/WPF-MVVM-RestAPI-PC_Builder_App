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
            //MessageBox.Show(this.Computer.motherboard.Chipset);
        }

        public MotherboardViewModel.MotherboardtoGrid GetMotherboard()
        {
            return this.computer.motherboard;
        }

        public void SetCPU(CPU cpu)
        {
            this.computer.cpu = cpu;
        }

        public CPU GetCPU()
        {
            return this.computer.cpu;
        }

        public void SetCPUCooler(CPU_Cooler cooler)
        {
            this.computer.cpu_Cooler = cooler;
        }
        public CPU_Cooler getCPUCooler()
        {
            return this.computer.cpu_Cooler;
        }

        public void SetGPU(GPU gpu)
        {
            this.computer.gpu = gpu;
        }

        public GPU GetGPU()
        {
            return this.computer.gpu;
        }

        public List<M2> GetM2s()
        {
            return this.computer.m2s;
        }

        public void SetM2s(List<M2> m2s)
        {
            this.computer.m2s = m2s;
        }

        public void SetPowerSupply(Power_Supply powerSupply)
        {
            this.computer.power_supply = powerSupply;
        }

        public Power_Supply GetPower_Supply()
        {
            return this.computer.power_supply;
        }

        public void SetRAM(RAM ram)
        {
            this.computer.ram = ram;
        }

        public RAM GetRAM()
        {
            return this.computer.ram;
        }

        public void SetROM(ROM rom)
        {
            this.computer.rom = rom;
        }

        public ROM GetROM()
        {
            return this.computer.rom;
        }

        public void SetUSBHeaders(List<USBHeader> headers)
        {
            this.computer.usbHeaders = headers;
        }

        public List<USBHeader> GetUSBHeaders()
        {
            return this.computer.usbHeaders;
        }

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
