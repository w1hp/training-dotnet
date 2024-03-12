using Cvl.Training.SmsEmailSender.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cvl.Training.SmsEmailSender.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NipController(
		ILogger<NipController> logger,
		INipService nipService
		) : ControllerBase
	{
		[HttpPost]
		[Route("check-NIP")]
		public async Task<SendNipResponse> CheckNIP(string nipNumber)
		{
			var response = await nipService.CheckNIP(nipNumber);
			return response;
		}
	}
}
