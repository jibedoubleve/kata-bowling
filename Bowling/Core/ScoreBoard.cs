namespace bowling.Core
{
    internal class ScoreBoard
    {
        #region Fields

        private readonly IEnumerable<Frame> _frames;

        #endregion Fields

        #region Constructors

        public ScoreBoard(IEnumerable<Frame> frames)
        {
            _frames = frames ?? throw new ArgumentNullException(nameof(frames));
        }

        #endregion Constructors

        #region Properties

        public int Count => _frames.Count();

        #endregion Properties

        #region Methods

        internal int CalculateScore()
        {
            var score = 0;

            for (int i = 0; i < _frames.Count(); i++)
            {
                var frame = _frames.ElementAt(i);
                var nextFrame = Frame.Empty;

                if (i < _frames.Count() - 1) { nextFrame = _frames.ElementAt(i + 1); }

                if (frame.IsStrike)
                {
                    score += frame.Sum() + nextFrame.Sum();
                }
                else if (frame.IsSpare)
                {
                    score += frame.Sum() + nextFrame.FirstRoll;
                }
                else { score += frame.Sum(); }
            }
            return score;
        }

        #endregion Methods
    }
}