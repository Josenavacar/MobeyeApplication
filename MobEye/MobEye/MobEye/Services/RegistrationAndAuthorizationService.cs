using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MobEye.Requests;
using MobEye.Responses;
namespace MobEye.Services
{
    class RegistrationAndAuthorizationService
    {
        string result;
        HttpClient client;
        public RegistrationAndAuthorizationService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
            result = null;
        }

        public async Task<String> Register(String code, String imei)
        {
            Uri uri = new Uri(String.Format("https://www.api.mymobeye.com/api/registerphone"));
            try
            {
                RegistrationRequest registrationRequest = new RegistrationRequest(code, imei);

                // Debug.WriteLine("asdasd");
                Debug.WriteLine("https://www.api.mymobeye.com/api/registerphone");
                //string[] dataToSend = { code, imei };
                string json = JsonConvert.SerializeObject(registrationRequest);
                Debug.WriteLine(json + "123456");
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                // if (response.IsSuccessStatusCode)
                //{ 
                var contentt = response.Content;

                string jsonString = await contentt.ReadAsStringAsync().ConfigureAwait(false);

                //   return JsonConvert.DeserializeObject<Item>(jsonString);

                Debug.WriteLine(registrationRequest.ToString());
                Debug.WriteLine(JsonConvert.DeserializeObject<RegistrationResponse>(jsonString).PrivateKey);
                String privateKey = JsonConvert.DeserializeObject<RegistrationResponse>(jsonString).PrivateKey;
                return privateKey;
                //}
                // return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }

        

        // Authroziation

        /*  public void showDialog()
          {
              return showDialog(Register("12312", 123123));
          }*/
    }
}
