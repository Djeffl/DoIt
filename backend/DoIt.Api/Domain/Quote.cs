using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Domain
{
	public class Quote
	{
		public int Id { get; set; }

		public string QuoteString { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Author { get; set; }
	}
}
