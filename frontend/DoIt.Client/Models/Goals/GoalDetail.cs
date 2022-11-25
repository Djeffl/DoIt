using DoIt.Client.Models.Todos;
using DoIt.Interface;
using DoIt.Interface.Todos;
using System;
using System.Collections.Generic;

namespace DoIt.Client.Models.Goals
{
	public class GoalDetail
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime DueAt { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? FinishedAt { get; set; }

		public bool IsFinished { get; set; }

        public List<TodoDto> ActionPlan { get; set; } = new List<TodoDto>();

        public string Location { get; set; }

        public string Reason { get; set; }

        public GoalType Type { get; set; }

		public State State { get; set; }
	}
}
