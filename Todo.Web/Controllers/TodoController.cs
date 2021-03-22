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
            var userId = 1; // todo - send as an parameter
            return _service.GetAll(userId);
        }

        [HttpPut]
        [Route("Todo")]
        public void Put(TodoDto task)
        {
            _service.UpdateTask(task);
        }
    }
}