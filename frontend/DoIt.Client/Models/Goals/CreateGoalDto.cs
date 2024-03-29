﻿using System;
using System.Collections.Generic;

namespace DoIt.Client.Models.Goals
{
    public class CreateGoalDto
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string Reason { get; set; }

        public DateTime DueAt { get; set; }

        public IEnumerable<long> CategoryIds { get; set; } = new List<long>();

        public List<string> CategoryNames { get; set; } = new();

        public DateTime CreatedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public bool IsFinished { get; set; }

        public long? IdeaId { get; set; }
    }
}
