﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Dto.Request.Idea
{
	public class CreateIdeaRequestDto
	{
		public string Title { get; set; }

		public string Description { get; set; }
	}
}