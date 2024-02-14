using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services
{   

    public interface ISmsService
    {
        Task<SendSmsResponse> SendSmsSubmit(string phoneNumber, string message, string applicationId);
        Task<SendSmsResponse> SendSmsGetStatus(long identifier);
    }

    public class SendSmsResponse
    {
        public long Identifier { get; set; }
        public SmsStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
