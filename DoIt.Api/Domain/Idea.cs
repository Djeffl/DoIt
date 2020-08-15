using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Domain
{
	public class Idea
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public Goal PromoteToGoal()
		{
			return new Goal()
			{
				CreatedAt = DateTime.UtcNow,
				Name = Name,
				Description = Description
			};
		}
	}
}
