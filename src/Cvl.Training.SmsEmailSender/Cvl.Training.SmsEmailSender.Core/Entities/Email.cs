using Cvl.Training.SmsEmailSender.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Entities
{
    public class Email : BaseEntity
    {
        public string AddressesTo { get; set; } = string.Empty;
        public string? AddressesCc { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public EmailStatus Status { get; set; } = EmailStatus.Submitted;
        public string? ErrorMesssage { get; set; }
    }
}
