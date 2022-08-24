namespace DoIt.Api.Domain
{
    public class IdeaCategory
    {
        public long IdeaId { get; set; }
        public Idea Idea { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
