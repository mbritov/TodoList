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
                ITodoRepository todoRepository,
                IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public void AddTask(TodoDto task)
        {
            var dbTask = _todoRepository.CreateTask();

            SetTask(dbTask, task);
        }

        public IEnumerable<TodoDto> GetAll()
        {
            return _mapper.Map<IEnumerable<TodoDto>>(_todoRepository.GetAll());
        }

        public TodoDto GetTask(int id)
        {
            return _mapper.Map<TodoDto>(_todoRepository.GetTask(id));
        }

        public void UpdateTask(TodoDto task)
        {
            var dbTask = _todoRepository.GetTask(task.Id);
            if (dbTask == null)
            {
                dbTask = _todoRepository.CreateTask();
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