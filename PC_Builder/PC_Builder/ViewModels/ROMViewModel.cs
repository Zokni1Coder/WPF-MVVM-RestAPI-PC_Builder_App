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
    public class ROMViewModel : BaseViewModel
    {
        private ObservableCollection<ROM> roms = new ObservableCollection<ROM>();

        public ObservableCollection<ROM> Roms
        {
            get { return roms; }
            set
            {
                roms = value;
            }
        }

        public ICommand SelectViewCommand { get; }
        public ROMViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/roms");
            List<ROM> tempRoms = JsonSerializer.Deserialize<List<ROM>>(response);

            foreach (var rom in tempRoms)
            {
                Roms.Add(rom);
            }
        }        
    }
}
