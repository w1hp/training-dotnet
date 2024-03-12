using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services
{
	public interface INipService
	{
		Task<SendNipResponse> CheckNIP(string nipNumber);
	}

	public class SendNipResponse
	{
		public string ErrorMessage { get; set; }
	}
}
