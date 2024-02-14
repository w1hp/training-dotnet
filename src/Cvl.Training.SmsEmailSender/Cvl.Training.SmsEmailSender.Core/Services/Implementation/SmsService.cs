using Cvl.Training.SmsEmailSender.Core.Base;
using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services.Implementation
{
    
    internal class SmsService(
        IWriteEntities writeEntities,
        ISmsSenderService smsSenderService
        ) : ISmsService
    {        
        public async Task<SendSmsResponse> SendSmsSubmit(string phoneNumber, string message, string applicationId)
        {
            var sms = new Sms()
            {
                PhoneNumber = phoneNumber,
                Message = message,
                ApplicationId = applicationId
            };

            await writeEntities.Add(sms);
            await writeEntities.SaveChangesAsync();

            await SendSms(sms);

            return new SendSmsResponse()
            {
                Identifier = sms.Id,
                Status = SmsStatus.Submitted
            };
        }

        public async Task<SendSmsResponse> SendSmsGetStatus(long identifier)
        {
            var sms = await writeEntities.Find<Sms>(identifier);

            if (sms.Status != SmsStatus.Sent)
            {
                await SendSms(sms);
            }

            return new SendSmsResponse()
            {
                Identifier = sms.Id,
                Status = sms.Status
            };
        }

        private async Task SendSms(Sms sms)
        {
            sms.NumberOfSendingAttempts++;

            try
            {
                await smsSenderService.SendSms(sms.PhoneNumber, sms.Message);
            }
            catch (Exception ex)
            {
                sms.Status = SmsStatus.Error;
                sms.ErrorMesssage = "Błąd wysyłania";
                await writeEntities.SaveChangesAsync();
                return;
            }

            sms.Status = SmsStatus.Sent;
            await writeEntities.SaveChangesAsync();
        }
    }
}
