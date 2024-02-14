using Cvl.Training.SmsEmailSender.Core.Base;
using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services.Implementation
{
    
    internal class SmsSynchronousService(
        IWriteEntities writeEntities,
        ISmsSenderService smsSenderService
        ) : ISmsSynchronousService
    {
        public async Task<SendSmsResponse> SendSms(string phoneNumber, string message, string applicationId)
        {
            var sms = new Sms()
            {
                PhoneNumber = phoneNumber,
                Message = message,
                ApplicationId = applicationId,
                Status = SmsStatus.Sent
            };

            await writeEntities.Add(sms);
            await writeEntities.SaveChangesAsync();

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

                return new SendSmsResponse()
                {
                    Identifier = sms.Id,
                    Status = sms.Status,
                    ErrorMessage = sms.ErrorMesssage,
                };
            }

            sms.Status = SmsStatus.Sent;
            await writeEntities.SaveChangesAsync();

            return new SendSmsResponse()
            {
                Identifier = sms.Id,
                Status = SmsStatus.Submitted
            };
        }
    }
}
