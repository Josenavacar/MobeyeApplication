using MobEye.Models;
using MobEye.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobEye.Services
{
    public class AlarmService
    {
        private HttpClient client;

        public AlarmService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
            this.CheckForAlarmsAsync();
        }

        public async Task<String> CheckForAlarmsAsync()
        {
            Uri uri = new Uri(String.Format("https://192.168.1.59:45455/api/messages/"));

            try
            {
                HttpResponseMessage response = null;

                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    string jsonString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                    Console.WriteLine(jsonString);

                    AlarmResponse alarm = JsonConvert.DeserializeObject<AlarmResponse>(jsonString);

                    Console.WriteLine(alarm.ToString());

                    return alarm.ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }
    }
}
