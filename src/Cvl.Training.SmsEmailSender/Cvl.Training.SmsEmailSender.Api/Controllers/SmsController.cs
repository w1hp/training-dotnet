using Cvl.Training.SmsEmailSender.Core.Services;
using Cvl.Training.SmsEmailSender.Core.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cvl.Training.SmsEmailSender.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController (
        ILogger<SmsController> logger,
        ISmsService smsService
        ) : ControllerBase
    {
        [HttpPost]
        [Route("send-sms-submit")]
        public async Task<SendSmsResponse> SendSmsSubmit(string phoneNumber, string message, string applicationId)
        {
            var response = await smsService.SendSmsSubmit(phoneNumber, message, applicationId);
            return response;
        }

        [HttpGet]
        [Route("send-sms-get-status")]
        public async Task<SendSmsResponse> SendSmsGetStatus(long identifier)
        {
            var response = await smsService.SendSmsGetStatus(identifier);
            return response;
        }
    }
}
