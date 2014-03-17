using System;

namespace LunchTime
{
	public interface IDbInterface
	{
		bool InsertConsumer(string uid, string email, string appUid);
		bool InsertProvider(string uid, string email, string appUid);
	}
}

