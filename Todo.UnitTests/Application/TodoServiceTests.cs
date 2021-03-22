namespace Todo.Core.UnitTests.VOM.Application.UserProfile
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
    using System.Collections.ObjectModel;
    using System.Linq;
    //using System.Text.Json;

    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _todoRepositoryMock;
        private readonly TodoService _userProfileService;

        public TodoServiceTests()
        {
            _todoRepositoryMock = new Mock<ITodoRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            _userProfileService = new TodoService(_todoRepositoryMock.Object, mapper);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetUserProfile_ReturnsExpectedDto_WithEmptyVOMFields_IfVOMProfileNotExits()
        {
            // Arrange
            var userId = 5;
            //var dbProfile = new SharedUserProfile
            //{
            //    FirstName = "firstName1",
            //    LastName = "lastName1",
            //    Roles = new List<ViewUserRoles>()
            //};

            //var expected = new TodoDto
            //{
            //    FirstName = "firstName1",
            //    LastName = "lastName1",
            //    Roles = new List<string>(),
            //    EligibleCreationReferals = new List<int>(),
            //    EligibleReviewReferals = new List<int>(),
            //    EligibleAreas = new List<CoverageAreaDto>()
            //};

            //_todoRepositoryMock
            //    .Setup(repo => repo.GetSharedUserProfileAsync(It.IsAny<int>()))
            //    .Returns(System.Threading.Tasks.Task.FromResult(dbProfile));

            //// Act
            //var actualCollection = await _userProfileService.GetUserProfile(userId);

            //// Assert
            //actualCollection.Should().BeEquivalentTo(expected);

            //_todoRepositoryMock
            //    .Verify(repo => repo.GetSharedUserProfileAsync(It.Is<int>(actualUserId => actualUserId == userId)));
        }        
    }
}
