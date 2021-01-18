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

        public async Task<String> Authorization(String phoneId, String pKey)
        {
            Uri uri = new Uri(String.Format("https://www.api.mymobeye.com/api/phoneauthorization"));
            try
            {
                AuthorizationRequest authorizationRequest = new AuthorizationRequest("aaaa1111", "pkaaaa1111");

                // Debug.WriteLine("asdasd");
                Debug.WriteLine("https://www.api.mymobeye.com/api/phoneauthorization");
                //string[] dataToSend = { code, imei };
                string json = JsonConvert.SerializeObject(authorizationRequest);
                Debug.WriteLine(json + "666666");
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                // if (response.IsSuccessStatusCode)
                //{ 
                var contentt = response.Content;

                string jsonString = await contentt.ReadAsStringAsync().ConfigureAwait(false);

                //   return JsonConvert.DeserializeObject<Item>(jsonString);

                Debug.WriteLine("content   "+ content.ToString());
                Debug.WriteLine(jsonString);
               // String privateKey = JsonConvert.DeserializeObject<RegistrationResponse>(jsonString).PrivateKey;
                return jsonString;
                //}
                // return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }
    }
}
