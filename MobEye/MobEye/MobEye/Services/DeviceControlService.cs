using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MobEye.Requests;
using MobEye.Responses;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using MobEye.Models;

namespace MobEye.Services
{
    class DeviceControlService
    {
        private HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeviceControlService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }

        /// <summary>
        /// Post method to register 
        /// </summary>
        /// <param name="phoneID"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<String> SendCommand(String phoneID, String deviceId, String privateKey, String command )
        {
            Uri uri = new Uri(String.Format("https://www.api.mymobeye.com/api/control"));

            try
            {
                SendCommandRequest sendCommandRequest = new SendCommandRequest(phoneID, deviceId, privateKey, command);

                string json = JsonConvert.SerializeObject(sendCommandRequest);

                StringContent sendCommandContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, sendCommandContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    string jsonString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                    return jsonString;
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
