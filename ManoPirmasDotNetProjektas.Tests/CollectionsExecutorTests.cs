using FluentAssertions;
using ManoPirmasDotNetProjektas.Paskaitos.Colections;
using NUnit.Framework;

namespace ManoPirmasDotNetProjektas.Tests
{
    
    [TestFixture]
    public class CollectionsExecutorTests
    {
        private CollectionsExecutor _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CollectionsExecutor();
        }

        [Test]
        [Category("LongRunning")]
        public void ForTest_returnsStringWithAddedTest_String()
        {
            //AAA Pattern

            //Arrange
            var teststring = "Mano pirmas";

            //Act
            var result = _sut.ForTest(teststring);

            //Assert
            result.Should().BeEquivalentTo("Mano pirmas test");
        }

        [Test]
       
        [TestCase("mano", "mano test")]
        public void ForTest_ReturnsStringWithAddedTest2_String(string parameter, string expectedResult)
        {
            var result = _sut.ForTest(parameter);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [Category("LongRunning")]

        public void Square_ReturnsSquaredInteger_Integer()
        {
            //patter AAA

            //Arrange
            var testParameter = 2;            

            //Act
            var result = _sut.Square(testParameter);

            //Assert
            result.Should().Be(4);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 4)]
        [TestCase(3, 9)]
        [TestCase(4, 16)]
        [TestCase(0, 0)]
        [TestCase(-1, 1)]
        [TestCase(20, 400)]
        public void Square_ReturnsSquaredInteger2_Integer(int root, int square)
        {
            var result = _sut.Square(root);

            result.Should().Be(square);
        }
    }
}