using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Domain
{
	public class Goal
	{
		public Goal()
		{
			this.Todos = new List<Todo>();
		}

		public long Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime DueAt { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? FinishedAt { get; set; }

		public bool IsFinished { get; set; }

		public ICollection<Todo> Todos { get; set; }
        
        public string Location { get; set; }
        
        public string Reason { get; set; }
    }
}
