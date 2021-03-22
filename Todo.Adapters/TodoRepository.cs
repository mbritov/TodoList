namespace Todo.Repository.Adapter
{
    using System.Collections.Generic;
    using System.Linq;
    //using Microsoft.EntityFrameworkCore;
    using Todo.Domain.Entity;

    public class TodoRepository : ITodoRepository
    {
       // private Core.Db.DbContext _wellsFargoContext;
        private List<TaskEntity> _taskCollection;

        //public TodoRepository(Core.Db.DbContext wellsFargoContext)
        public TodoRepository()
        {
            _taskCollection = new List<TaskEntity>();
            //_wellsFargoContext = wellsFargoContext;
        }

        public TaskEntity CreateTask()
        {
            // var result = _wellsFargoContext.Tasks.CreateProxy();
            // _wellsFargoContext.Tasks.Add(result);
            var newTask = new TaskEntity() { };
            _taskCollection.Add(newTask);
            return newTask;
        }

        public IEnumerable<TaskEntity> GetAll(int userId)
        {
            return _taskCollection;
        }

        public TaskEntity GetTask(int id)
        {
            return _taskCollection.FirstOrDefault(t => t.Id == id); // TODO
        }
    }
}
