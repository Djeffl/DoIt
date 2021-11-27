using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Exceptions
{
	public class ObjectNotFoundException : Exception
	{
		public ObjectNotFoundException()
		{

		}

		public ObjectNotFoundException(string message) : base(message)
		{
		}
	}
}
