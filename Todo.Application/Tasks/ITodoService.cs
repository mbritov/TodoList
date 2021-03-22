namespace Todo.Application
{
    using System.Collections.Generic;

    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAll();

        void UpdateTask(TodoDto task);
    }
}
