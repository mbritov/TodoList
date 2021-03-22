namespace Todo.Core.Web.Controller
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Todo.Application;

    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Todo")]
        public IEnumerable<TodoDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPut]
        [Route("Todo")]
        public void Put(TodoDto task)
        {
            _service.UpdateTask(task);
        }
    }
}