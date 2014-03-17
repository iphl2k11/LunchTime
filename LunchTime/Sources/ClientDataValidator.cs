using System;
using NLog;

namespace LunchTime
{
	public class ClientDataValidator : IClientDataValidator
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public ClientDataValidator ()
		{
		}

		public bool validateEmail(string email)
		{
			try {
				var addr = new System.Net.Mail.MailAddress(email);
				logger.Debug("Successfully validated email address: {0}", addr);
				return true;
			}
			catch {
				logger.Error("Error validating email : {0}", email);
				return false;
			}
		}
	}
}

