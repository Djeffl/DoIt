using System;

namespace DoIt.Api.Dto.Response.Ideas
{
	public class GetIdeaResponseDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
