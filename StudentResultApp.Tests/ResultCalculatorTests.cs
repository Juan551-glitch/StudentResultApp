using Xunit;

namespace StudentResultApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Mark_Above_50_Should_Return_Pass()
        {
            // Arrange
            int mark = 65;

            // Act
            string result = mark >= 50 ? "Pass" : "Fail";

            // Assert
            Assert.Equal("Pass", result);
        }

        [Fact]
        public void Mark_Below_50_Should_Return_Fail()
        {
            // Arrange
            int mark = 40;

            // Act
            string result = mark >= 50 ? "Pass" : "Fail";

            // Assert
            Assert.Equal("Fail", result);
        }
    }
}