namespace Todo.Repository.Adapter
{
    using System.Collections.Generic;
    using Todo.Domain.Entity;

    public interface ITodoRepository
    {
        IEnumerable<TaskEntity> GetAll();

        TaskEntity GetTask(int id);

        TaskEntity CreateTask();
    }
}
