using System;
using System.Diagnostics;
using NetCoreProject.Interfaces;

namespace NetCoreProject.Services
{
    public class CloudMailService :ILocalMailService
    {
        private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService");
            Debug.WriteLine($"Subject {subject} ");
            Debug.WriteLine($"Message {message}");
        }
    }
}
