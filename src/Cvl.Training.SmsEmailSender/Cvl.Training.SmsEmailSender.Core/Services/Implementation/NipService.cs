using Cvl.Training.SmsEmailSender.Core.Base;
using Cvl.Training.SmsEmailSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Core.Services.Implementation
{
	internal class NipService : INipService
	{
		public Task<SendNipResponse> CheckNIP(string nipNumber)
		{
			var blackList = new List<long>
							{
								7615842964,
								4179427729,
								5230409988
							};

			if (blackList.Contains(long.Parse(nipNumber)))
			{
				return Task.FromResult(new SendNipResponse()
				{
					ErrorMessage = "NIP is blacklisted"
				});
			}
			else
			{
				return Task.FromResult(new SendNipResponse()
				{
					ErrorMessage = "NIP isn't blacklisted"
				});
			}
		}
	}
}
