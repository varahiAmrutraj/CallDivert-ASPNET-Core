using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallDivert.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CallDivert.AdditionalClasses
{
    public class SendMessages
    {
        public static void SendMessage(string messageText)
        {
            var accountSid = "ACa2d415f883ff334fd86f0596fce02eba";
            var authToken = "05fccca9350f73f6652b7973d4dc7c6f";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("whatsapp:+918275654510"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = messageText;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
    }
}