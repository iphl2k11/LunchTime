using System;

namespace LunchTime
{
	public interface IUidGenerator
	{
		string GenerateProviderId();
		string GenerateConsumerId();
	}
}

