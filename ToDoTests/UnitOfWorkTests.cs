using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository;

namespace ToDoTests
{
    public class UnitOfWorkTests
    {
        [Fact]
        public void Save_ShouldCallDbContextSaveChanges()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var unitOfWork = new UnitOfWork(dbContextMock.Object);

            // Act
            unitOfWork.Save();

            // Assert
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}