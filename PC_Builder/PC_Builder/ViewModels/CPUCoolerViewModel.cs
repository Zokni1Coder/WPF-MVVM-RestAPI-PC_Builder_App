using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class CPUCoolerViewModel : BaseViewModel
    {
        private ObservableCollection<CPU_Cooler> coolers = new ObservableCollection<CPU_Cooler>();

        public ObservableCollection<CPU_Cooler> Coolers
        {
            get { return coolers; }
            set { coolers = value; }
        }

        public ICommand SelectViewCommand { get; }
        public CPUCoolerViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://localhost:3000/cpu_coolers");
                Structure structure = JsonSerializer.Deserialize<Structure>(response);

                foreach (var cooler in structure.Coolers)
                {
                    CPU_Cooler tempCooler = new CPU_Cooler();
                    tempCooler = cooler;
                    tempCooler.Compatibility = structure.compatibilities.Where(s => s.Cooler_id == cooler.Id).ToList();
                    Coolers.Add(tempCooler);
                }
            }
            catch (HttpRequestException)
            {
                ErrorWindow errorMessage = new ErrorWindow("Connection error: Unable to retrieve parts data. Please check your internet connection.");
                errorMessage.Show();
            }
            catch (TaskCanceledException)
            {
                ErrorWindow errorMessage = new ErrorWindow("The request timed out. Please make sure the server is running.");
                errorMessage.Show();
            }
            catch (SocketException)
            {
                ErrorWindow errorMessage = new ErrorWindow("Unable to reach the server. Please ensure the server is running and try again.");
                errorMessage.Show();
            }
            catch (Exception)
            {
                ErrorWindow errorMessage = new ErrorWindow("An unexpected error occurred. Please restart the application and try again.");
                errorMessage.Show();
            }
        }
        public class Structure
        {
            [JsonPropertyName("cpu_coolers")]
            public List<CPU_Cooler> Coolers { get; set; }
            [JsonPropertyName("compatibilities")]
            public List<CPU_Cooler_Compatibility> compatibilities { get; set; }
        }
    }
}
