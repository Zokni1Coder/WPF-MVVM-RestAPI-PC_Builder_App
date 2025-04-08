using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Interfaces;
using PC_Builder.Models;

namespace PC_Builder.ViewModels
{
    public class CPUViewModel : BaseViewModel
    {
        private ObservableCollection<CPU> cpusToView = new ObservableCollection<CPU>();

        public ObservableCollection<CPU> CpusToView
        {
            get { return cpusToView; }
            set { cpusToView = value; }
        }
        public ICommand SelectViewCommand { get; }
        public ICommand SelectPartCommand { get; }
        public CPUViewModel()
        {
            getDatas();
            SelectViewCommand = new SelectViewCommand();
        }

        private async void getDatas()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://localhost:3000/cpus");
                List<CPU> tempCPUS = JsonSerializer.Deserialize<List<CPU>>(response);
                foreach (CPU cpu in tempCPUS)
                {
                    cpusToView.Add(cpu);
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
