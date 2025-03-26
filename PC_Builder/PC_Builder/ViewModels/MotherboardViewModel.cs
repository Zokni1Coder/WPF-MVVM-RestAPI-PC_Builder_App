using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using PC_Builder.Commands;
using PC_Builder.Exceptions;
using PC_Builder.Interfaces;
using PC_Builder.Models;


namespace PC_Builder.ViewModels
{
    public class MotherboardViewModel : BaseViewModel
    {
        private ObservableCollection<Motherboard> motherboardList = new ObservableCollection<Motherboard>();

        public ObservableCollection<Motherboard> Motherboards
        {
            get { return motherboardList; }
            set { motherboardList = value; }
        }

        public ICommand SelectViewCommand { get; }
        public ICommand SelectPartCommand { get; }

        public MotherboardViewModel()
        {
            GetDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        public async void GetDatas()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://localhost:3000/motherboards");
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Structure structure = JsonSerializer.Deserialize<Structure>(response, option);

                foreach (var m in structure.motherboards)
                {
                    Motherboard tempmotherboard = m;
                    tempmotherboard.Model = m.Manufacturer + " " + m.Info;
                    tempmotherboard.M2Compatibilites = structure.m2s.Where(s => s.Motherboard == m.Id).ToList();
                    tempmotherboard.USBHeaders = structure.usbHeaders.Where(s => s.Motherboard_id == m.Id).ToList();
                    Motherboards.Add(tempmotherboard);
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
            [JsonPropertyName("motherboards")]
            public List<Motherboard> motherboards { get; set; }
            [JsonPropertyName("usb_headers")]
            public List<USBHeader> usbHeaders { get; set; }
            [JsonPropertyName("m2types")]
            public List<M2> m2s { get; set; }
        }
    }
}
