using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services.Implementation
{
    

    internal class SmsSenderService : ISmsSenderService
    {
        public async Task SendSms(string number, string message)
        {
            //symuluje opóźnienie wywołania serwisu - na produkcji tu było by wywołanie prawdziwego serwisu
            await Task.Delay(500);


            //symuluje losowe wstąpienia błedu - na produkcji były by to błędy np timeout
            var rand = new Random(DateTime.Now.Millisecond);
            var propablity = rand.NextDouble();
            if (propablity > 0.5)
            {
                //symuluje zdarzenie losowe i powstanie błędu przy wysłaniu sms
                throw new Exception("Błąd wysłania sms");
            }
        }
    }
}
