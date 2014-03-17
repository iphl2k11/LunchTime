using System;

namespace LunchTime
{
	public class UidGenerator : IUidGenerator
	{
		public UidGenerator ()
		{

		}

		public string GenerateProviderId()
		{
			return Guid.NewGuid ().ToString ("N");
		}

		public string GenerateConsumerId()
		{
			return Guid.NewGuid ().ToString ("N");
		}

	}
}

