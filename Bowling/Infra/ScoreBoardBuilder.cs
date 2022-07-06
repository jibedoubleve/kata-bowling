using bowling.Core;

namespace bowling.Infra
{
    internal class ScoreBoardBuilder
    {
        #region Methods

        internal ScoreBoard Build(string scoreCard)
        {
            var frames = scoreCard.Split('|', StringSplitOptions.RemoveEmptyEntries);

            if (frames.Length > 11) { throw new ApplicationException($"Too many frames ({frames.Length})"); }
            else
            {
                var list = new List<Frame>();
                foreach (var frame in frames)
                {
                    var opportunity = frame.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    
                    var first = int.Parse(opportunity[0]);
                    var second = int.Parse(opportunity[1]);
                    
                    var fr = new Frame(first, second);

                    list.Add(fr);
                }

                return new(list);
            }
        }

        #endregion Methods
    }
}