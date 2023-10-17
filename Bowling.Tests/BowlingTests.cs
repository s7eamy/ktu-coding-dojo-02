namespace Bowling.Tests
{
    public class BowlingTests
    {
        [Theory()]
        [InlineData("-- -- -- -- -- -- -- -- -- --", 0)]
        [InlineData("11 11 11 11 11 11 11 11 11 11", 20)]
        public void TestSimple(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }

        [Theory()]
        [InlineData("5/ 11 -- -- -- -- -- -- -- --", 13)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 54", 144)]
        [InlineData("5/ -- 5/ 5/ 5/ 5/ 5/ 5/ 5/ 54", 124)]
        public void TestABitMoreDifficult(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }


        [Theory()]
        [InlineData("X -- -- -- -- -- -- -- -- --", 10)]
        [InlineData("X 11 -- -- -- -- -- -- -- --", 14)]
        [InlineData("X X 11 -- -- -- -- -- -- --", 35)]
        [InlineData("X X X -- -- -- -- -- -- --", 60)]
        [InlineData("-- -- -- -- -- -- -- -- -- XXX", 30)]
        [InlineData("-- -- -- -- -- -- -- -- -- XX1", 21)]
        [InlineData("-- -- -- -- -- -- -- -- -- X11", 12)]
        [InlineData("-- -- -- -- -- -- -- -- -- X1/", 20)]
        public void TestExtremeDif(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }
    }
}