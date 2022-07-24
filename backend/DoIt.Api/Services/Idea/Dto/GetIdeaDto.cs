using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Services.Idea.Dto
{
	public class GetIdeaDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
