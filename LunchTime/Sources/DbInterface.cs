using System;

namespace LunchTime
{
	public class DbInterface : IDbInterface
	{
		public DbInterface ()
		{
		}

		public bool InsertConsumer(string uid, string email, string appUid)
		{
			throw new NotImplementedException ();
		}

		public bool InsertProvider(string uid, string email, string appUid)
		{
			throw new NotImplementedException ();
		}
	}
}