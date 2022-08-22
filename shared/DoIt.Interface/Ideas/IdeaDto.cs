using DoIt.Interface.IdeaCategory;

namespace DoIt.Interface.Ideas;

public class IdeaDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
}