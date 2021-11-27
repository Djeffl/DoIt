using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Domain
{
	public class TodoTemplate
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int RoutineId { get; set; }

		public int UsageAmount { get; set; }
	}
}
