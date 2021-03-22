namespace Todo.Application
{
    public enum TaskStatus
    {
        Pending,
        Completed,
    }

    public class TodoDto
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int UserId { get; set; }
    }
}
