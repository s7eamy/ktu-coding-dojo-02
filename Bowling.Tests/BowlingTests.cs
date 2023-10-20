namespace Bowling.Tests
{
    public class BowlingTests
    {
        [Theory()]
        [InlineData("-- -- -- -- -- -- -- -- -- --", 0)]
        public void TestOnlyMiss(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);
        }

        [Theory()]
        [InlineData("11 11 11 11 11 11 11 11 11 11", 20)]
        public void TestNoSpareNoStrikeNoMiss(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }

        [Theory()]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]
        public void TestNoSpareNoStrikeMiss(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);
        }

        [Theory()]
        [InlineData("5/ 11 -- -- -- -- -- -- -- --", 13)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 54", 144)]
        [InlineData("5/ -- 5/ 5/ 5/ 5/ 5/ 5/ 5/ 54", 124)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)]
        public void TestSpares(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }


        [Theory()]
        [InlineData("X -- -- -- -- -- -- -- -- --", 10)]
        [InlineData("X 11 -- -- -- -- -- -- -- --", 14)]
        [InlineData("X X 11 -- -- -- -- -- -- --", 35)]
        [InlineData("X X X -- -- -- -- -- -- --", 60)]
        [InlineData("X X X X X X X X X X X X", 300)]
        [InlineData("-- -- -- -- -- -- -- -- -- XXX", 30)]
        [InlineData("-- -- -- -- -- -- -- -- -- XX1", 21)]
        [InlineData("-- -- -- -- -- -- -- -- -- X11", 12)]
        public void TestStrikes(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }

        [Theory()]
        [InlineData("2/ 52 -- -- -- -- -- -- -- --", 22)]
        [InlineData("-- -- -- -- -- -- -- -- -- X1/", 20)]
        public void TestStrikesSpares(string inp, int result)
        {
            Bowling b = new Bowling();

            b.CalculateScore(inp).Should().Be(result);

        }
    }
}