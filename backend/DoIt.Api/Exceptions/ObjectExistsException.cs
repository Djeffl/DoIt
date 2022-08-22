using System;

namespace DoIt.Api.Exceptions
{
    public class ObjectExistsException : Exception
    {
		public ObjectExistsException()
        {

        }

        public ObjectExistsException(string message) : base(message)
        {
        }
	}
}
