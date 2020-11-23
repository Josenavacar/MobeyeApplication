using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestfulAPI.Services
{
    public class Registration : IRegistration
    {
        HttpClient client;
        public Registration()
        {
            client = new HttpClient();
        }

        public async Task<string> Register(string code, long imei)
        {
            Uri uri = new Uri(String.Format(Constants.RegistrationUrl));
            try
            {
                string[] dataToSend = { code, imei.ToString() };
                string json = JsonConvert.SerializeObject(dataToSend);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    return response.ToString();
                }
                return null;

            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }
    }
}