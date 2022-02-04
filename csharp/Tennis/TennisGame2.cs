namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int P1Point { get; set; }
        private int P2Point { get; set; }

        private const int TieBreakMinimumPoint = 3;

        public string GetScore()
        {
            if (ArePointsEqual())
            {
                return GetScoreStatusWhenPointsAreEqual();
            }

            if (BothPlayersOnOrUnderTieBreakThreshold())
            {
                return GetScoreStatus(P1Point) + "-" + GetScoreStatus(P2Point);
            }

            return GetAdvantageAndWinScoreStatus();
        }

        private string GetAdvantageAndWinScoreStatus()
        {
            if (P1Point - P2Point == 1) return "Advantage player1";
            if (P1Point - P2Point >= 2) return "Win for player1";
            if (P2Point - P1Point == 1) return "Advantage player2";
            return "Win for player2";
        }

        private bool BothPlayersOnOrUnderTieBreakThreshold()
        {
            return OnOrUnderTieBreakThreshold(P1Point) && OnOrUnderTieBreakThreshold(P2Point);
        }

        private string GetScoreStatusWhenPointsAreEqual()
        {
            if (UnderTieBreakThreshold(P1Point))
            {
                return GetScoreStatus(P1Point) + "-All";
            }
            return "Deuce";
        }

        private bool OnOrUnderTieBreakThreshold(int point)
        {
            return point <= TieBreakMinimumPoint;
        }

        private bool UnderTieBreakThreshold(int point)
        {
            return point < TieBreakMinimumPoint;
        }

        private string GetScoreStatus(int points)
        {
            switch (points)
            {
                case 0: return "Love";
                case 1: return "Fifteen";
                case 2: return "Thirty";
                case 3: return "Forty";
                default: return "";
            }
        }

        private bool ArePointsEqual()
        {
            return P1Point == P2Point;
        }


        private void P1Score()
        {
            P1Point++;
        }

        private void P2Score()
        {
            P2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

