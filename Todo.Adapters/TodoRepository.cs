namespace Todo.Repository.Adapter
{
    using System.Collections.Generic;
    using System.Linq;
    //using Microsoft.EntityFrameworkCore;
    using Todo.Domain.Entity;

    public class TodoRepository : ITodoRepository
    {
        private List<TaskEntity> _taskCollection;

        // private Core.Db.DbContext _context;
        //public TodoRepository(Core.Db.DbContext context)
        public TodoRepository()
        {
            _taskCollection = new List<TaskEntity>();
        }

        public TaskEntity CreateTask()
        {
            var newTask = new TaskEntity() { };
            newTask.Id = _taskCollection.Count();
            _taskCollection.Add(newTask);
            return newTask;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _taskCollection;
        }

        public TaskEntity GetTask(int id)
        {
            return _taskCollection.FirstOrDefault(t => t.Id == id);
        }
    }
}
