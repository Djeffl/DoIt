using System.Collections.Generic;

namespace DoIt.Client.Pages.Ideas.Detail
{
    public class IdeaDtoIdeaDetailPage
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<long> CategoryIds { get; set; }

        public List<string> CategoryNames { get; set; } = new();
    }
}

