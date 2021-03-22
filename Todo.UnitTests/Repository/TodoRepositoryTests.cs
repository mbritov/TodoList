using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Todo.Application;
using Todo.Domain.Entity;
using Todo.Repository.Adapter;
using Xunit;

namespace Todo.Core.UnitTests.Domain
{
    public class TodoRepositoryTests
    {

        private readonly TodoRepository _todoRepository;
        
        List<TaskEntity> _todoTasks;

        public TodoRepositoryTests()
        {
            _todoRepository = new TodoRepository();
        }

        [Fact]
        [Trait("Category", "Component")]
        public async Task CreateTask_ReturnsNewTask()
        {
            // Arrange
            
            // Act
            var actualTask = _todoRepository.CreateTask();

            // Assert
            actualTask.Should().NotBeNull();
        }

        [Fact]
        [Trait("Category", "Component")]
        public async Task GetAll_ReturnsTasks()
        {
            // Arrange
            _todoRepository.CreateTask();
            _todoRepository.CreateTask();
            _todoRepository.CreateTask();

            // Act
            var actualTasks = _todoRepository.GetAll();

            // Assert
            actualTasks.Should().HaveCount(3);
        }

        [Fact]
        [Trait("Category", "Component")]
        public async Task GetTask_ReturnsTaskIfExists()
        {
            // Arrange
            var existingTask = _todoRepository.CreateTask();

            // Act
            var actualTask = _todoRepository.GetTask(existingTask.Id);

            // Assert
            actualTask.Should().BeEquivalentTo(existingTask);
        }

        [Fact]
        [Trait("Category", "Component")]
        public async Task GetTask_ReturnsNullIfDoesNotExist()
        {
            // Arrange

            // Act
            var actualTask = _todoRepository.GetTask(123);

            // Assert
            actualTask.Should().BeNull();
        }
    }
}
