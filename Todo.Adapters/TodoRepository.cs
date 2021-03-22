namespace Todo.Repository.Adapter
{
    using System.Collections.Generic;
    using System.Linq;
    //using Microsoft.EntityFrameworkCore;
    using Todo.Domain.Entity;

    public class TodoRepository : ITodoRepository
    {
       // private Core.Db.DbContext _context;
        private List<TaskEntity> _taskCollection;

        //public TodoRepository(Core.Db.DbContext context)
        public TodoRepository()
        {
            _taskCollection = new List<TaskEntity>();
            //_context = context;
        }

        public TaskEntity CreateTask()
        {
            var newTask = new TaskEntity() { };
            _taskCollection.Add(newTask);
            return newTask;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _taskCollection;
        }

        public TaskEntity GetTask(int id)
        {
            return _taskCollection.FirstOrDefault(t => t.Id == id); // TODO
        }
    }
}
