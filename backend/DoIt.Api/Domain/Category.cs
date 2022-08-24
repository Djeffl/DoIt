using System.Collections.Generic;

namespace DoIt.Api.Domain;

public class Category
{
    public long Id { get; set; }

    public string Name { get; set; }

    public ICollection<Idea> Ideas { get; set; }
    public List<IdeaCategory> IdeaCategories { get; set; }

}