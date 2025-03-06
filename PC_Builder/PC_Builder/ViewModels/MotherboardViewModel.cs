using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PC_Builder.Models;


namespace PC_Builder.ViewModels
{
    public class MotherboardViewModel : BaseViewModel
    {
        public MotherboardViewModel()
        {
            getMotherboards();
        }
        public async void getMotherboards()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:3000/motherboards");
            List<Motherboard> motherboards = JsonSerializer.Deserialize<List<Motherboard>>(response);
        }
    }
}
