namespace Todo.Application
{
    using System.Collections.Generic;

    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAll(int userId);

        void UpdateTask(TodoDto task);
    }
}
