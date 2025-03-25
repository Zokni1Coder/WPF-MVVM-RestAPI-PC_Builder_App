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
    public class PowerSupplyViewModel : BaseViewModel
    {
        private ObservableCollection<Power_Supply> supplies = new ObservableCollection<Power_Supply>();

        public ObservableCollection<Power_Supply> Supplies
        {
            get { return supplies; }
            set { supplies = value; }
        }

        public ICommand SelectViewCommand { get; }
        public PowerSupplyViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/power_supplies");
            List<Power_Supply> tempSupplies = JsonSerializer.Deserialize<List<Power_Supply>>(response);

            foreach (var supply in tempSupplies)
            {
                Supplies.Add(supply);
            }
        }       
    }
}
