using System;

namespace DoIt.Api.Domain
{
	public class Routine
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		public Repeater Repeater { get; set; }

		public int GoalId { get; set; }

		public Goal Goal { get; set; }

		public DateTime CreatedAt { get; set; }

		public int TodoTemplateId { get; set; }

		public TodoTemplate Template { get; set; }
	}
}