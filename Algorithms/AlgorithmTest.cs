using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void NegativeInputReturnsNegativeOne()
        {
            Assert.Equal(-1, Algorithms.GetFactorial(-4));
        }

        [Fact]
        public void ZeroInputReturnsOne()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
        }

        [Fact]
        public void LargeValueThrowsOverflowException()
        {
            Assert.Throws<System.OverflowException>(() => Algorithms.GetFactorial(int.MaxValue));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

        [Fact]
        public void CanFormatTwoItems()
        {
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
        }

        [Fact]
        public void CanFormatOneItem()
        {
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
        }

        [Fact]
        public void CannotFormatZeroArguments()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators());
        }

        [Fact]
        public void CannotFormatNull()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators(null));
        }

        [Fact]
        public void CanFormatManyItems()
        {
            Assert.Equal("a, b, c, d, e, f, g, h, i, j and k", Algorithms.FormatSeparators("a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k"));
        }
    }
}
