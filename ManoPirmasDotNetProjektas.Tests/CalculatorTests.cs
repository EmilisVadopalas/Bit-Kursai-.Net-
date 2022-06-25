using FluentAssertions;
using ManoPirmasDotNetProjektas.Paskaitos.UnitTest;
using NUnit.Framework;

namespace ManoPirmasDotNetProjektas.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Calculator();
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase(1, 2, 3)]
        [TestCase(-10, -20, -30)]
        [TestCase(10, -5, 5)]
        [TestCase(-20, 25, 5)]
        [TestCase(-10, 5, -5)]
        [TestCase(0, 0, 0)]
        [TestCase(12, -12, 0)]
        [TestCase(1000000000, 1000000000, 2000000000)]
        public void Add_ReturnSumOfTwoIntegerss_Integer(int a,int b, int resultShould)
        {
            var result = _sut.Add(a,b);

            result.Should().Be(resultShould);
        }

        [Test]
        [TestCase(4, 2, 2f)]
        [TestCase(3, 2, 3/2)]
        [TestCase(-10, -2, 5f)]
        [TestCase(-10, 2, -5f)]      
        [TestCase(100000000, -100000000, -1f)]
        public void Divide_ShouldReturnDivisionOfTwoIntegers_float(int a, int b, float resultShould)
        {
            var result = _sut.Divide(a, b);

            result.Should().Be(resultShould);
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void Divide_ShouldThrowDivideByZeroExecption_Execption(int a)
        {
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(a, 0));
        }

        
    }
}
