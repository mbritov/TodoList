namespace Todo.Core.UnitTests.Web.Controller
{
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using global::Todo.Application;
    using Moq;
    using System.Collections.Generic;
    using Todo.Core.Web.Controller;
    using Xunit;

    public class TodoControllerTests
    {
        private readonly Mock<ITodoService> _todoServiceMock;
        private readonly TodoController _todoController;

        public TodoControllerTests()
        {
            _todoServiceMock = new Mock<ITodoService>();
            _todoController = new TodoController(_todoServiceMock.Object);
        }

        [Theory, AutoData]
        [Trait("Category", "Unit")]
        public void Get_ReturnsTasks(List<TodoDto> todos, int id)
        {
            // Arrange 
            _todoServiceMock
                .Setup(todoService => todoService.GetAll())
                .Returns(todos);

            // Act
            var actualResult = _todoController.GetAll();

            // Assert
            actualResult.Should().BeSameAs(todos);

            _todoServiceMock.Verify(userProfileService
                => userProfileService.GetAll());
        }

        [Theory, AutoData]
        [Trait("Category", "Unit")]
        public void Put_UpdatesTask(TodoDto todo)
        {
            // Arrange 
            TodoDto actualTask = new TodoDto();
            _todoServiceMock
                .Setup(todoService => todoService.UpdateTask(It.IsAny<TodoDto>()))
                .Callback((TodoDto calledTask) => { actualTask = calledTask; });
            
            // Act
            _todoController.Put(todo);

            // Assert
            actualTask.Should().BeSameAs(todo);
        }

    }
}
