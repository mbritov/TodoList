namespace Todo.Core.UnitTests.Application.UserProfile
{
    using AutoMapper;
    using FluentAssertions;
    using global::Todo.Application;
    using global::Todo.Repository.Adapter;
    using global::Todo.Domain.Entity;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    using AutoFixture.Xunit2;

    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _todoRepositoryMock;
        private readonly TodoService _todoService;

        public TodoServiceTests()
        {
            _todoRepositoryMock = new Mock<ITodoRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            _todoService = new TodoService(_todoRepositoryMock.Object, mapper);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetAll_ReturnsAllTasks()
        {
            // Arrange
            IEnumerable<TaskEntity> tasks = new List<TaskEntity>
            {
                new TaskEntity
                {
                    Id = 1, Subject = "Name1", Description = "desc1", Status = 0
                },
                new TaskEntity
                {
                    Id = 2, Subject = "Name2", Description = "desc2", Status = 1
                }
            };

            _todoRepositoryMock.Setup(repository => repository.GetAll()).Returns(tasks);
            var expectedDepartments = new List<TodoDto>
            {
                new TodoDto
                {
                    Id = 1, Subject = "Name1", Description = "desc1", Status = Todo.Application.TaskStatus.Pending
                },
                new TodoDto
                {
                    Id = 2, Subject = "Name2", Description = "desc2", Status = Todo.Application.TaskStatus.Completed
                }
            };

            // Act
            var actualTasks = _todoService.GetAll();

            // Assert
            actualTasks.Should().BeEquivalentTo(expectedDepartments);
        }

        [Theory, AutoData]
        [Trait("Category", "Unit")]
        public void UpdateTodoTask_UpdatesExistingTask_WhentaskExists(TodoDto todoDto)
        {
            // Arrange
            var expectedTodoTask = new TaskEntity
            {
                Id = todoDto.Id, Subject = todoDto.Subject, Description = todoDto.Description, Status = (int)todoDto.Status
            };

            var existingTodoTask = new TaskEntity()
            {
                Id = todoDto.Id,
            };

            _todoRepositoryMock.Setup(repo => repo.GetTask(It.IsAny<int>()))
                .Returns(existingTodoTask);

            // Act
            _todoService.UpdateTask(todoDto);

            // Assert
            existingTodoTask.Should().BeEquivalentTo(expectedTodoTask, options =>
                options.Excluding(p => p.UpdatedDate));

            _todoRepositoryMock.Verify(repo => repo.GetTask(It.Is<int>(actualId => actualId == todoDto.Id)));
        }

        [Theory, AutoData]
        [Trait("Category", "Unit")]
        public void AddTodoTask_AddNewTask_WhenTaskDoesNotExist(TodoDto todoDto)
        {
            // Arrange
            var expectedTodoTask = new TaskEntity
            {
                Id = todoDto.Id,
                Subject = todoDto.Subject,
                Description = todoDto.Description,
                Status = (int)todoDto.Status
            };

            var newTask = new TaskEntity { Id = todoDto.Id };

            const TaskEntity nonExistingProperty = null;
            _todoRepositoryMock.Setup(repo => repo.GetTask(It.IsAny<int>()))
                .Returns(nonExistingProperty);

            _todoRepositoryMock.Setup(repo => repo.CreateTask())
                .Returns(newTask);

            // Act
            _todoService.AddTask(todoDto);

            // Assert
            newTask.Should().BeEquivalentTo(expectedTodoTask, options =>
                options.Excluding(p => p.UpdatedDate));
        }
    }
}
