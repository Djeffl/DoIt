using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;
using System.Collections.Generic;
using System;
using DoIt.Interface.Goals;
using DoIt.Api.Domain;
using System.Linq;
using DoIt.Api.Services.Idea;
using DoIt.Api.Services.Todo;

namespace DoIt.Api.Services.Goal
{
    public static class GoalMapper
    {
        public static Domain.Goal ToDomain(this CreateGoalDto obj, Domain.Idea idea, IEnumerable<Domain.Category> categories)
        {
            if (obj == null)
                return null;

            return new Domain.Goal()
            {
                Title = obj.Title,
                Description = obj.Description,
                CreatedAt = obj.CreatedAt ?? DateTime.UtcNow,
                Location = obj.Location,
                Reason = obj.Reason,
                DueAt = obj.DueAt,
                Idea = idea,
                Categories = categories.ToList(),
                State = State.Idle,
            };
        }

        public static Domain.Goal ToDomain(this GoalDto obj, Domain.Idea idea, IEnumerable<Domain.Category> categories, IEnumerable<Domain.Todo> todos)
        {
            if (obj == null)
                return null;

            return new Domain.Goal()
            {
                Title = obj.Title,
                Description = obj.Description,
                CreatedAt = obj.CreatedAt,
                Location = obj.Location,
                Reason = obj.Reason,
                DueAt = obj.DueAt,
                Idea = idea,
                Categories = categories.ToList(),
                Todos = todos.ToList(),
                FinishedAt = obj.FinishedAt,
                IsFinished = obj.IsFinished,
                Id = obj.Id,
                State = obj.State.ToDomain(),
            };
        }

        public static GoalDto ToDto(this Domain.Goal obj)
        {
            if (obj == null)
                return null;

            return new GoalDto()
            {
                Title = obj.Title,
                Description = obj.Description,
                CreatedAt = obj.CreatedAt,
                Location = obj.Location,
                Reason = obj.Reason,
                DueAt = obj.DueAt,
                Categories = obj.Categories.Select(category => category.ToDto()).ToList(),
                Idea = obj.Idea.ToDto(),
                ActionPlan = obj.Todos.Select(x => x.ToDto()).ToList(),
                IsFinished = obj.IsFinished,
                FinishedAt = obj.FinishedAt,
                Id = obj.Id,
                State = obj.State.ToDto(),
                CompletionPercentage = obj.CompletionPercentage,
            };
        }
    }
}
