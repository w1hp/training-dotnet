using Cvl.Training.SmsEmailSender.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Entities
{
    public class Sms : BaseEntity
    {
        public string PhoneNumber {get;set;} = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ApplicationId { get; set; } = string.Empty;

        public int NumberOfSendingAttempts { get; set; } = 0;
        public SmsStatus Status { get; set; } = SmsStatus.Submitted;
        public string? ErrorMesssage { get; set; }
    }
}
