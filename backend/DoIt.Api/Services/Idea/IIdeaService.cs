﻿using DoIt.Api.Services.Idea.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Services.Idea
{
	public interface IIdeaService
	{
		Task<GetIdeasDto> GetIdeasAsync();
		Task<GetIdeaDto> CreateGoalAsync(CreateIdeaDto createGoalDto);
		Task<GetIdeaDto> GetIdeaAsync(long id);
		Task DeleteIdeaAsync(long id);
        Task<GetIdeaDto> UpdateIdeaAsync(long id, UpdateIdeaDto updateIdeaDto);

	}
}
