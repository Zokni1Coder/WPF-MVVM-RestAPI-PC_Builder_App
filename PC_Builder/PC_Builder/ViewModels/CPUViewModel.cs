using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class CPUViewModel : BaseViewModel
    {
        private ObservableCollection<CPU> cpusToView = new ObservableCollection<CPU>();

        public ObservableCollection<CPU> CpusToView
        {
            get { return cpusToView; }
            set { cpusToView = value; }
        }
        public ICommand SelectViewCommand { get; }
        public ICommand SelectPartCommand { get; }
        public CPUViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/cpus");
            List<CPU> tempCPUS = JsonSerializer.Deserialize<List<CPU>>(response);
            foreach (CPU cpu in tempCPUS)
            {
                cpusToView.Add(cpu);
            }            
        }        
    }
}
