using System.Collections.Generic;

namespace DoIt.Api.Dto.Response.Goals
{
	public class GoalsResponseDto
	{
		public GoalsResponseDto()
		{
			Data = new List<GoalResponseDto>();
		}
		public List<GoalResponseDto> Data { get; set; }
	}
}
