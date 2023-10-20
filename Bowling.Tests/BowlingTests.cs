namespace Bowling.Tests
{
    public class BowlingTests
    {
        private Bowling b = new Bowling();
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
            b.CalculateScore(inp).Should().Be(result);

        }

        [Theory()]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]
        public void TestNoSpareNoStrikeMiss(string inp, int result)
        {
            b.CalculateScore(inp).Should().Be(result);
        }

        [Theory()]
        [InlineData("5/ 11 -- -- -- -- -- -- -- --", 13)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 54", 144)]
        [InlineData("5/ -- 5/ 5/ 5/ 5/ 5/ 5/ 5/ 54", 124)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)]
        public void TestSpares(string inp, int result)
        {
            b.CalculateScore(inp).Should().Be(result);
        }


        [Theory()]
        [InlineData("X -- -- -- -- -- -- -- -- --", 10)]
        [InlineData("X 11 -- -- -- -- -- -- -- --", 14)]
        [InlineData("X X 11 -- -- -- -- -- -- --", 35)]
        [InlineData("X X X -- -- -- -- -- -- --", 60)]
        [InlineData("X X X X X X X X X X X X", 300)]
        [InlineData("X X X -1 5- -- -- -- -- -- ", 67)]
        [InlineData("X X X 1- 5- -- -- -- -- -- ", 68)]
        [InlineData("X X X 11 5- -- -- -- -- -- ", 70)]
        [InlineData("-- -- -- -- -- -- -- -- -- XXX", 30)]
        [InlineData("-- -- -- -- -- -- -- -- -- XX1", 21)]
        [InlineData("-- -- -- -- -- -- -- -- -- X11", 12)]
        public void TestStrikes(string inp, int result)
        {
            b.CalculateScore(inp).Should().Be(result);

        }

        [Theory()]
        [InlineData("2/ 52 -- -- -- -- -- -- -- --", 22)]
        [InlineData("-- -- -- -- -- -- -- -- -- X1/", 20)]
        [InlineData("X 1/ -5 -- -- -- -- -- -- --", 35)]
        [InlineData("X 1/ 5- -- -- -- -- -- -- --", 40)]
        [InlineData("X 5/ -5 -- -- -- -- -- -- --", 35)]
        [InlineData("X X 1/ -5 -- -- -- -- -- --", 56)]
        [InlineData("X X 1/ 5- -- -- -- -- -- --", 61)]
        [InlineData("X X 5/ 5- -- -- -- -- -- --", 65)]
        [InlineData("1/ X -- -- -- -- -- -- -- --", 30)]
        [InlineData("1/ X X -- -- -- -- -- -- --", 50)]
        [InlineData("1/ X X X -- -- -- -- -- --", 80)]
        public void TestStrikesSpares(string inp, int result)
        {
            b.CalculateScore(inp).Should().Be(result);
        }

        [Theory()]
        [InlineData("-- -- -- -- -- -- -- -- -- 18", 9)]
        [InlineData("-- -- -- -- -- -- -- -- -- 2/1", 11)]
        [InlineData("-- -- -- -- -- -- -- -- -- 5/1", 11)]
        [InlineData("-- -- -- -- -- -- -- -- -- 2/-", 10)]
        [InlineData("-- -- -- -- -- -- -- -- -- 5/-", 10)]
        [InlineData("-- -- -- -- -- -- -- -- -- 2/X", 20)]
        [InlineData("-- -- -- -- -- -- -- -- -- X--", 10)]
        [InlineData("-- -- -- -- -- -- -- -- -- X5-", 15)]
        [InlineData("-- -- -- -- -- -- -- -- -- X51", 16)]
        [InlineData("-- -- -- -- -- -- -- -- -- X5/", 20)]
        [InlineData("-- -- -- -- -- -- -- -- -- XX-", 20)]
        [InlineData("-- -- -- -- -- -- -- -- -- XX1", 21)]
        [InlineData("-- -- -- -- -- -- -- -- -- XX5", 25)]
        [InlineData("-- -- -- -- -- -- -- -- -- XXX", 30)]
        [InlineData("-- -- -- -- -- -- -- -- 2/ -5", 15)]
        [InlineData("-- -- -- -- -- -- -- -- 2/ 5/5", 30)]
        [InlineData("-- -- -- -- -- -- -- -- 2/ 45", 23)]
        public void TestEnd(string inp, int result)
        {
            b.CalculateScore(inp).Should().Be(result);
        }

        //ChatGPT suggested test cases, verified by https://www.bowlinggenius.com/
        [Theory()]
        [InlineData("X X X X X X X X X -1", 242)] // this is a problem
        [InlineData("-- X 5/ -- X 5/ -- X 5/ --", 90)]
        [InlineData("-- -- -- -- -- -- -- -- -- X5/", 20)]
        [InlineData("-- -- -- -- -- -- -- -- -- 5/X", 20)]
        [InlineData("X 5/ X 5/ X 5/ X 5/ X 5/X", 200)]
        [InlineData("X -- 5/ -- -- -- -- -- -- --", 20)]
        [InlineData("5/ -- X -- -- -- -- -- -- --", 20)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/X", 155)]
        [InlineData("5/ X X X X X X X X 5/5", 260)]
        public void TestChatGPTSuggestions(string inp, int result)
        {
            b.CalculateScore(inp).Should().Be(result);
        }
    }
}