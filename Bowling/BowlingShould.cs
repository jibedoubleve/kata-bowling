using bowling.Core;
using bowling.Infra;
using FluentAssertions;
using Xunit;

namespace Bowling
{
    public class BowlingShould
    {
        #region Methods

        [Fact]
        public void BeTrue()
        {
            true.Should().BeTrue();
        }

        [Theory]
        [InlineData("0,0|5,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|", 5)]
        [InlineData("5,4|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|", 9)]
        [InlineData("10,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|", 10)]
        [InlineData("10,0|1,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|", 12)]
        [InlineData("10,0|1,5|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|", 22)]
        [InlineData("5,5|5,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|", 20)]
        [InlineData("1,1|1,1|1,1|1,1|1,1|1,1|1,1|1,1|1,1|1,1|", 20)]
        [InlineData("1,1|1,1|1,1|1,1|1,1|1,1|1,1|1,1|1,1|1,1|0,1|", 21)]
        public void CalculateScore(string scoreCard, int score)
        {
            var builder = new ScoreBoardBuilder();
            var scoreBoard = builder.Build(scoreCard);

            scoreBoard
                .CalculateScore()
                .Should().Be(score);
        }

        [Theory]
        [InlineData(5, 5, true)]
        [InlineData(6, 4, true)]
        [InlineData(6, 3, false)]
        [InlineData(10, 0, false)]
        public void FindSpare(int first, int second, bool expected)
        {
            var frame = new Frame(first, second);

            frame.IsSpare
                 .Should().Be(expected);
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(9, false)]
        public void FindStrike(int first, bool expected)
        {
            var frame = new Frame(first, 0);

            frame.IsStrike
                 .Should().Be(expected);
        }

        [Theory]
        [InlineData("0,0|5,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|")]
        public void GetScoreBoardOf10Frames(string scoreCard)
        {
            var builder = new ScoreBoardBuilder();
            var scoreBoard = builder.Build(scoreCard);

            scoreBoard
                .Count
                .Should().Be(10);
        }

        [Fact]
        public void ThrowIfEmptyScoreBoard()
        {
            Assert.Throws<ArgumentNullException>(() => new ScoreBoard(null));
        }

        #endregion Methods
    }
}