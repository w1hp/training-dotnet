using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services
{
    [Obsolete]
    public interface ISmsSynchronousService
    {
        Task<SendSmsResponse> SendSms(string phoneNumber, string message, string applicationId);
    }
}
