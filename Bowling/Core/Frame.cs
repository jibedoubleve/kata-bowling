using System.Diagnostics;

namespace bowling.Core
{
    [DebuggerDisplay("First: {FirstRoll} - Second: {SecondRoll}")]
    internal class Frame
    {
        #region Constructors

        public Frame(int first, int second)
        {
            FirstRoll = first;
            SecondRoll = second;
        }

        #endregion Constructors

        #region Properties

        public static Frame Empty => new(0, 0);

        public int FirstRoll { get; }
        public bool IsSpare => FirstRoll < 10 && Sum() == 10;
        public bool IsStrike => FirstRoll == 10;
        public int SecondRoll { get; }

        #endregion Properties

        #region Methods

        public int Sum() => FirstRoll + SecondRoll;

        #endregion Methods
    }
}