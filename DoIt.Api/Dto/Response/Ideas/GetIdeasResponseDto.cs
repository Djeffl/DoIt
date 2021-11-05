using System.Collections.Generic;

namespace DoIt.Api.Dto.Response.Ideas
{
	public class GetIdeasResponseDto
	{
		public GetIdeasResponseDto()
		{
			Data = new List<GetIdeaResponseDto>();
		}
		public List<GetIdeaResponseDto> Data { get; set; }
	}
}
