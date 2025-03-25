using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using PC_Builder.Models;
using PC_Builder.Commands;
using System.Windows.Input;
using PC_Builder.Interfaces;

namespace PC_Builder.ViewModels
{
    public class RAMViewModel : BaseViewModel
    {
        private ObservableCollection<RAM> rams = new ObservableCollection<RAM>();

        public ObservableCollection<RAM> Rams
        {
            get { return rams; }
            set { rams = value; }
        }

        public ICommand SelectViewCommand { get; }
        public RAMViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/rams");
            List<Models.RAM> tempRams = JsonSerializer.Deserialize<List<Models.RAM>>(response);

            foreach (var ram in tempRams)
            {
                Rams.Add(ram);               
            }
        }        
    }
}
