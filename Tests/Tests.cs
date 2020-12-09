using Xunit;

namespace AdventOfCode.Days
{
    public class Tests
    {

        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }
    }
}
