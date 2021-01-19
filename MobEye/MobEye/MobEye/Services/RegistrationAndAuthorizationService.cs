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

        public async Task<String> Register(String phoneID, String code)
        {
            Uri uri = new Uri(String.Format("https://www.api.mymobeye.com/api/registerphone"));

            try
            {
                RegistrationRequest registrationRequest = new RegistrationRequest(phoneID, code);

                string json = JsonConvert.SerializeObject(registrationRequest);

                StringContent registrationContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, registrationContent);

                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine(await SecureStorage.GetAsync("phone_id") + await SecureStorage.GetAsync("private_key"));

                    var responseContent = response.Content;

                    string jsonString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                    String privateKey = JsonConvert.DeserializeObject<RegistrationResponse>(jsonString).PrivateKey;

                    await SecureStorage.SetAsync("private_key", privateKey);

                    //await this.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                    return privateKey;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }



        // Authroziation
        public async Task<String> Authorization(String phoneId, String privateKey)
        {
            Uri uri = new Uri(String.Format("https://www.api.mymobeye.com/api/phoneauthorization"));

            try
            {
                AuthorizationRequest authorizationRequest = new AuthorizationRequest(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                string json = JsonConvert.SerializeObject(authorizationRequest);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var c = response.Content;
                    var jsonString = await c.ReadAsStringAsync().ConfigureAwait(false);
                    List<Device> devices = new List<Device>();
                    JObject jObject = JObject.Parse(jsonString);
                    String urole = (string)jObject["UserRole"];
                    await SecureStorage.SetAsync("role", urole);
                    String pk = (string)jObject["PrivateKey"];
                    Device dev = new Device();

                    if (jObject["Devices"].First["DeviceId"] != null)
                    {
                        
                        dev.ID = (int)jObject["Devices"].First["DeviceId"];
                        dev.DeviceName = (string)jObject["Devices"].First["DeviceName"];
                        dev.CommandText = (string)jObject["Devices"].First["CommandText"];

                        if ((String)jObject["Devices"].First["Command"] == Command.DO1.ToString())
                        {
                            dev.Command = Command.DO1;
                        }

                        await SecureStorage.SetAsync("device", dev.ID.ToString());
                        devices.Add(dev);
                    }

                    //Console.WriteLine(dev.ToString());

                    AuthorizationResponse response1 = new AuthorizationResponse(urole, pk, devices);

                    return response1.ToString();
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
