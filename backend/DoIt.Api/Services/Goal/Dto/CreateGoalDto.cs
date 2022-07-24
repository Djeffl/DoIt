using System;

namespace DoIt.Api.Services.Goal.Dto
{
	public class CreateGoalDto
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public GoalType Type { get; set; }

		public DateTime DueAt{ get; set; }
        
        public string Location { get; set; }
        
        public string Reason { get; set; }
    }
}
