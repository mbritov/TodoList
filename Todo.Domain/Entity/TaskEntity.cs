namespace Todo.Domain.Entity
{
    using System;

    public class TaskEntity
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
