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

        public void SetMotherboard(Motherboard motherboard)
        {
            this.Computer.motherboard = motherboard;
        }

        public Motherboard GetMotherboard()
        {
            return this.computer.motherboard;
        }

        public void SetCPU(CPU cpu)
        {
            this.Computer.cpu = cpu;
        }

        public CPU GetCPU()
        {
            return this.computer.cpu;
        }

        public void SetCPUCooler(CPU_Cooler cooler)
        {
            this.Computer.cpu_Cooler = cooler;
        }
        public CPU_Cooler getCPUCooler()
        {
            return this.Computer.cpu_Cooler;
        }

        public void SetGPU(GPU gpu)
        {
            this.Computer.gpu = gpu;
        }

        public GPU GetGPU()
        {
            return this.Computer.gpu;
        }

        public void SetPowerSupply(Power_Supply powerSupply)
        {
            this.Computer.power_supply = powerSupply;
        }

        public Power_Supply GetPower_Supply()
        {
            return this.Computer.power_supply;
        }

        public void SetRAM(RAM ram)
        {
            this.Computer.ram = ram;
        }

        public RAM GetRAM()
        {
            return this.Computer.ram;
        }

        public void SetROM(ROM rom)
        {
            this.Computer.rom = rom;
        }

        public ROM GetROM()
        {
            return this.Computer.rom;
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
        public ICommand TestCommand { get; set; }

        public MainWindowViewModel()
        {
            viewModel = this;
            UpdateViewCommand = new UpdateViewCommand(this);
            SelectPartCommand = new SelectPartCommand();
            SelectedViewModel = new MotherboardViewModel();
            TestCommand = new TestCommand();
        }
    }
}
