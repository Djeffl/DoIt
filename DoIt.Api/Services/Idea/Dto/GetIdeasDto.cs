using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Services.Idea.Dto
{
	public class GetIdeasDto
	{
		public List<GetIdeaDto> Ideas { get; set; }
	}
}
