namespace DoIt.Interface.Ideas
{
	public class CreateIdeaDto
	{
		public string Title { get; set; }

		public string Description { get; set; }

        public IEnumerable<long> CategoryIds { get; set; }
	}
}
