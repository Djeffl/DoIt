namespace DoIt.Interface.Goals
{
    public class GoalsDto
    {
        public GoalsDto()
        {
            Data = new List<GoalDto>();
        }
        public List<GoalDto> Data { get; set; }
    }
}
