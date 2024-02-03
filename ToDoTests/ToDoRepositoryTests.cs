using Moq;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository;

namespace ToDoTests
{
    public class ToDoRepositoryTests
    {
        [Fact]
        public void Save_ShouldSaveChanges()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var repository = new ToDoRepository(dbContextMock.Object);

            // Act
            repository.Save();

            // Assert
            dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}