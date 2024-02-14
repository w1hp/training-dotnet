using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services
{
    public interface ISmsSenderService
    {
        Task SendSms(string number, string message);
    }
}
