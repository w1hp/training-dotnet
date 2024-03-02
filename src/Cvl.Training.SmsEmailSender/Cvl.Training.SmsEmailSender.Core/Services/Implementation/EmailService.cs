using Cvl.Training.SmsEmailSender.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services.Implementation
{
    internal class EmailService(
        IWriteEntities writeEntities
        ) : IEmailService
    {
        public async Task<SendEmailResponse> SendEmailSubmit(string addressesTo, string addressesCc, string title, string message, string applicationId)
        {
            throw new NotImplementedException();
        }

        public async Task<SendEmailResponse> SendEmailGetStatus(long identifier)
        {
            throw new NotImplementedException();
        }

        
    }
}
