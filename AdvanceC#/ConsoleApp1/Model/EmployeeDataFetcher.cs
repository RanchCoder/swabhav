using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class EmployeeDataFetcher
    {
        public event Action<string> OnProcessingComplete;
        HttpClient client = new HttpClient();

        public async void ProcessData()
        {
            string responseFromClient = await client.GetStringAsync("https://swabhav-tech.firebaseapp.com/emp.txt");
            OnProcessingComplete(responseFromClient);
        }
    }
}
