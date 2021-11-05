using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Dto.Request
{
	public class CreateGoalRequest
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public string Type { get; set; }

		public DateTime DueAt { get; set; }

		public long IdeaId { get; set; }
	}
}
