using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PC_Builder.ViewModels
{
    public class ConfigWindowViewModel : INotifyPropertyChanged
    {
        public static ConfigWindowViewModel viewModel { get; private set; } = new ConfigWindowViewModel();

        public ConfigWindowViewModel()
        {

        }

        private string motherboardModel;

        public string MotherboardModel
        {
            get { return motherboardModel; }
            set
            {
                motherboardModel = value;
                OnPropertyChanged(nameof(MotherboardModel));
            }
        }

        private string cpuModel;

        public string CPUModel
        {
            get { return cpuModel; }
            set
            {
                cpuModel = value;
                OnPropertyChanged(nameof(CPUModel));
            }
        }

        private string cpuCoolerModel;

        public string CPUCoolerModel
        {
            get { return cpuCoolerModel; }
            set
            {
                cpuCoolerModel = value;
                OnPropertyChanged(nameof(CPUCoolerModel));
            }
        }

        private string ramModel;

        public string RAMModel
        {
            get { return ramModel; }
            set { ramModel = value; OnPropertyChanged(nameof(RAMModel)); }
        }

        private string romModel;

        public string ROMModel
        {
            get { return romModel; }
            set { romModel = value; OnPropertyChanged(nameof(ROMModel)); }
        }

        private string gpuModel;

        public string GPUModel
        {
            get { return gpuModel; }
            set { gpuModel = value; OnPropertyChanged(nameof(GPUModel)); }
        }

        private string psModel;

        public string PSModel
        {
            get { return psModel; }
            set { psModel = value; OnPropertyChanged(nameof(PSModel)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
