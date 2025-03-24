﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;
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
                Supplies.Add(new SupplyToView
                {
                    Model = supply.Manufacturer + " " + supply.Model,
                    Type = supply.Type,
                    Efficiency_Rating = supply.Rating,
                    Wattage = supply.Wattage,
                    Modularity = supply.Modularity,
                    ID = supply.Id,
                    Price = supply.Price
                });
            }
        }

        public class SupplyToView
        {
            public int ID { get; set; }
            public string Model { get; set; }
            public string Type { get; set; }
            public string Efficiency_Rating { get; set; }
            public int Wattage { get; set; }
            public string Modularity { get; set; }
            public int Price { get; set; }
        }
    }
}
