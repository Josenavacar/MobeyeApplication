using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;

namespace RestfulAPI.Models
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        public Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://mobeyeapp.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=QQRATZQhKXCCm5LuHgZLC8BBIBsyzFYlNqvx1Guq5OM=",
                                                                            "MobeyeApp");
        }

        public async Task<HttpStatusCode> sendToAll()
        {
            var notif = " { \"notification\":{ \"title\":\"HI\", \"body\":\"test message\" }, \"data\":{ \"property1\":\"value1\", \"property2\":42 } }";
            NotificationOutcome outcome = await Instance.Hub.SendFcmNativeNotificationAsync(notif);
            HttpStatusCode ret = HttpStatusCode.InternalServerError;
            if (outcome != null)
            {
                if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
                    (outcome.State == NotificationOutcomeState.Unknown)))
                {
                    ret = HttpStatusCode.OK;
                }
            }
            return ret;

        }
    }
}
