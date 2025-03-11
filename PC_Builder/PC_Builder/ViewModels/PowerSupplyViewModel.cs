using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class PowerSupplyViewModel : BaseViewModel
    {
        private ObservableCollection<SupplyToView> supplies = new ObservableCollection<SupplyToView>();

        public ObservableCollection<SupplyToView> Supplies
        {
            get { return supplies; }
            set { supplies = value; }
        }

        public PowerSupplyViewModel()
        {
            getDatas();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/power_supplies");
            List<Power_Supply> tempSupplies = JsonSerializer.Deserialize<List<Power_Supply>>(response);

            foreach (var supply in tempSupplies)
            {
                Supplies.Add(new SupplyToView
                {
                    Model = supply.Manufacturer + " " + supply.Model,
                    Type = supply.Type,
                    Efficiency_Rating = supply.Rating,
                    Wattage = supply.Wattage.ToString() + "W",
                    Modularity = supply.Modularity,
                    Price = supply.Price.ToString() + "€"
                });
            }
        }

        public class SupplyToView
        {
            public string Model { get; set; }
            public string Type { get; set; }
            public string Efficiency_Rating { get; set; }
            public string Wattage { get; set; }
            public string Modularity { get; set; }
            public string Price { get; set; }
        }
    }
}
