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
    public class ROMViewModel : BaseViewModel
    {
        private ObservableCollection<ROMToView> roms = new ObservableCollection<ROMToView>();

        public ObservableCollection<ROMToView> Roms
        {
            get { return roms; }
            set { roms = value; }
        }

        public ROMViewModel()
        {
            getDatas();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/roms");
            List<ROM> tempRoms = JsonSerializer.Deserialize<List<ROM>>(response);

            foreach (var rom in tempRoms)
            {
                Roms.Add(new ROMToView
                {
                    Model = rom.Model,
                    Capacity = rom.Capacity.ToString() + "GB",
                    Type = rom.Type,
                    Form_Factor = rom.Form_factor,
                    //Manufacturer = ,
                    Price = rom.Price.ToString() + "€"
                });
            }
        }

        public class ROMToView
        {
            public string Model { get; set; }
            public string Capacity { get; set; }
            public string Type { get; set; }
            public string Form_Factor { get; set; }
            public string Manufacturer { get; set; }
            public string Price { get; set; }
        }
    }
}
