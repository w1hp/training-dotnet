using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services
{
    public interface IEmailService
    {
        Task<SendEmailResponse> SendEmailSubmit(string addressesTo, string addressesCc, string title, string message, string applicationId);
        Task<SendEmailResponse> SendEmailGetStatus(long identifier);
    }

    public class SendEmailResponse
    {
        public long Identifier { get; set; }
        public SmsStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
