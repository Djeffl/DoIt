namespace DoIt.Interface.Goals;

public class GoalTodoDto
{
    public long? Id { get; set; }
    public bool IsFinished { get; set; }
    public string Title { get; set; }
    public DateTime? DueAt { get; set; }
}