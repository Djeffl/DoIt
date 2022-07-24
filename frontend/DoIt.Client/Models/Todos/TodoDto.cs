using System;
using System.ComponentModel.DataAnnotations;

namespace DoIt.Client.Models.Todos
{
	public class TodoDto
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsFinished { get; set; }

        public DateTime DueAt { get; set; }

	}
}
