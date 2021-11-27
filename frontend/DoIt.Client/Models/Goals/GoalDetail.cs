using DoIt.Client.Models.Todos;
using System;
using System.Collections.Generic;

namespace DoIt.Client.Models.Goals
{
	public class GoalDetail
	{
		public int Id { get; set; }

		public GoalType Type { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime DueAt { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? FinishedAt { get; set; }

		public bool IsFinished { get; set; }

		public List<Todo> Tasks { get; set; }
	}
}
