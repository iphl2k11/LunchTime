using System;
using NLog;

namespace LunchTime
{
	public class Main
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		private IUidGenerator uidGenerator;
		private IDbInterface dbInterface;
		private IClientDataValidator clientDataValidator;

		public Main(IUidGenerator newUidGenerator, IDbInterface newDbInterface, IClientDataValidator newClientDataValidator)
		{
			uidGenerator = newUidGenerator;
			dbInterface = newDbInterface;
			clientDataValidator = newClientDataValidator;
		}

		public string RegisterProvider(string appUid, string email)
		{
			if (!clientDataValidator.validateEmail (email)) 
			{
				return null;
			}

			string providerId = uidGenerator.GenerateProviderId ();
			if (!dbInterface.InsertProvider (providerId, email, appUid)) 
			{
				return null;
			}

			return providerId;
		}

		public string RegisterConsumer(string appUid, string email)
		{
			return null;
		}

		public void InformConsumers(string providerId, string eventId, string msg)
		{

		}

		public void RegisterForInfo(string consumerId, string providerId, string eventId)
		{

		}
	}
}

