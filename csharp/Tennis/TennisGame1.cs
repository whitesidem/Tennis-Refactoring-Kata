namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {

        public int P1Score { get; set; }
        public int P2Score { get; set; }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                P1Score += 1;
            else
                P2Score += 1;
        }

        public string GetScore()
        {
            if (IsEqualScores()) return GetScoreStatusForEqualScores();
            if (IsPerformingTieBreaker()) return GetScoreStatusWithinTieBreaker();
            return GetGeneralCaseScoreStatus();
        }

        private bool IsEqualScores()
        {
            return P1Score == P2Score;
        }

        private string GetGeneralCaseScoreStatus()
        {
            string scoreStatus = "";
            scoreStatus += GetGeneralCaseScoreStatusForPlayer(P1Score);
            scoreStatus += "-";
            scoreStatus += GetGeneralCaseScoreStatusForPlayer(P2Score);
            return scoreStatus;
        }

        private string GetGeneralCaseScoreStatusForPlayer(int score)
        {
            switch (score)
            {
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return "Love";
            }
        }

        private string GetScoreStatusWithinTieBreaker()
        {
            var minusResult = P1Score - P2Score;
            if (IsPlayerOneAPointAhead()) return "Advantage player1";
            if (IsPlayerOneAPointBehind()) return "Advantage player2";
            if (IsPlayerOne2PointsAhead()) return "Win for player1";
            return "Win for player2";
        }


        private bool IsPlayerOneAPointAhead()
        {
            return (P1Score - P2Score) == 1;
        }

        private bool IsPlayerOneAPointBehind()
        {
            return (P1Score - P2Score) == -1;
        }
        private bool IsPlayerOne2PointsAhead()
        {
            return (P1Score - P2Score) >= 2;
        }


        private bool IsPerformingTieBreaker()
        {
            return P1Score >= 4 || P2Score >= 4;
        }

        private string GetScoreStatusForEqualScores()
        {
            switch (P1Score)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

    }
}

