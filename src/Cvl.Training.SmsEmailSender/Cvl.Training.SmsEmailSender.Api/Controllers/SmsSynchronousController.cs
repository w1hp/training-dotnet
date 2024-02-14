using Cvl.Training.SmsEmailSender.Core.Services;
using Cvl.Training.SmsEmailSender.Core.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Cvl.Training.SmsEmailSender.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSynchronousController(
        ILogger<SmsController> logger,
        ISmsSynchronousService smsService
        ) : ControllerBase
    {
        [HttpPost]
        [Route("send-sms")]        
        public async Task<SendSmsResponse> SendSms(string phoneNumber, string message, string applicationId)
        {
            var response = await smsService.SendSms(phoneNumber, message, applicationId);
            return response;
        }       
    }
}
