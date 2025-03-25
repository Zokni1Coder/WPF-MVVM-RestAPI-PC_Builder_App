using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class GPUViewModel : BaseViewModel
    {
        private ObservableCollection<GPU> gpus = new ObservableCollection<GPU>();

        public ObservableCollection<GPU> Gpus
        {
            get { return gpus; }
            set { gpus = value; }
        }

        public ICommand SelectViewCommand { get; }
        public GPUViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }                                                                  

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/gpus");
            List<GPU> tempgpus = JsonSerializer.Deserialize<List<GPU>>(response);
            foreach (GPU gpu in tempgpus)
            {
                Gpus.Add(gpu);                
            }
        }
    }
}
