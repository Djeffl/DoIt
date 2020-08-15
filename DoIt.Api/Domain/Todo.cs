﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Domain
{
	public class Todo
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? FinishedAt { get; set; }

		public bool IsFinished { get; set; }

		//public Routine Routine { get; set; }

		//public Goal Goal { get; set; }


		//#region foreign Keys

		//public int? RoutineId { get; set; }

		//public int? GoalId { get; set; }

		//#endregion
	}
}
