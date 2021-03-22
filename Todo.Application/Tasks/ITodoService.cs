namespace Todo.Application
{
    using System.Collections.Generic;

    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAll();

        TodoDto GetTask(int id);

        void AddTask(TodoDto task);

        void UpdateTask(TodoDto task);
    }
}
