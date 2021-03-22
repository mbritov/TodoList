namespace Todo.Application
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Todo.Domain.Entity;
    using Todo.Repository.Adapter;

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(
                ITodoRepository userProfileRepository,
                IMapper mapper)
        {
            _todoRepository = userProfileRepository;
            _mapper = mapper;
        }

        public IEnumerable<TodoDto> GetAll(int userId)
        {
            return _mapper.Map<IEnumerable<TodoDto>>(_todoRepository.GetAll(userId));
        }

        public void UpdateTask(TodoDto task)
        {
            var dbTask = _todoRepository.GetTask(task.Id);
            if (dbTask == null)
            {
                dbTask = _todoRepository.CreateTask();
                dbTask.Id = task.Id;
            }

            SetTask(dbTask, task);
        }

        private void SetTask(TaskEntity dbTask, TodoDto task)
        {
            dbTask.Subject = task.Subject;
            dbTask.Description = task.Description;
            dbTask.Status = (int)task.Status;
            dbTask.UpdatedDate = DateTime.UtcNow;
        }
    }
}