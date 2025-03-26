using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
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
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://localhost:3000/power_supplies");
                List<Power_Supply> tempSupplies = JsonSerializer.Deserialize<List<Power_Supply>>(response);

                foreach (var supply in tempSupplies)
                {
                    Supplies.Add(supply);
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
    }
}
