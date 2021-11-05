using System;

namespace DoIt.Client.Models.Goals
{
	public class GoalCreate
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public string Type { get; set; }

		public DateTime DueAt { get; set; }

		public long? IdeaId { get; set; }
	}
}
