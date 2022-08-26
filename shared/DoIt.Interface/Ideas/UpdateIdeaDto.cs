using System.ComponentModel.DataAnnotations;

namespace DoIt.Interface.Ideas
{
    public class UpdateIdeaDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; } = "";

        public IEnumerable<long> CategoryIds { get; set; } = new List<long>();
    }
}
