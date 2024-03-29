﻿using System;

namespace DoIt.Api.Services.Todo.Dto
{
    public class GetTodoDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public long? GoalId { get; set; }

        public DateTime? DueAt { get; set; }

        public DateTime? PlannedAt { get; set; }
    }
}
