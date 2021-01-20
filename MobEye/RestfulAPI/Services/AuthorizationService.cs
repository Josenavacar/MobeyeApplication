using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MobEye.Models;


namespace RestfulAPI.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        HttpClient client;
        User user;

        public AuthorizationService()
        {
            client = new HttpClient();
        }
        public async Task<User> getAuthorization()
        {
            user = new User();

            Uri uri = new Uri(String.Format(Constants.AuthUrl, String.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return user;
        }

        public async Task SendPrivateKeyAndImei(long imei, string privateKey)
        {
            
            Uri uri = new Uri(string.Format(Constants.AuthUrl, string.Empty));

            try
            {
                string[] dataToSend = { imei.ToString(), privateKey };
                string json = JsonConvert.SerializeObject(dataToSend);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                Debug.WriteLine(@"\tPrivate key and imei successfully sent.");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
