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
using System.Net.Sockets;

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
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://localhost:3000/rams");
                List<Models.RAM> tempRams = JsonSerializer.Deserialize<List<Models.RAM>>(response);

                foreach (var ram in tempRams)
                {
                    Rams.Add(ram);
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
