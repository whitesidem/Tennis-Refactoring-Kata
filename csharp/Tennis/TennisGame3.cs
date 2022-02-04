using System;
using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private readonly List<Player> _players;
        private readonly string[] _scoreStatus = {"Love", "Fifteen", "Thirty", "Forty"};

        public TennisGame3(string player1Name, string player2Name)
        {
            _players = new List<Player>
            {
                new Player(player1Name),
                new Player(player2Name)
            };
        }

        public string GetScore()
        {
            if (InEarlyScoringState())
            {
                if (ScoresAreEqual())
                {
                    return GetScoreStatusByPoints(_players[0].Points) + "-All";
                }
                return GetScoreStatusByPoints(_players[0].Points) + "-" + GetScoreStatusByPoints(_players[1].Points);
            }

            if (ScoresAreEqual())
                return "Deuce";

            return InAdvantageState() ? $"Advantage {GetLeadingPlayer().Name}" : $"Win for {GetLeadingPlayer().Name}";
        }

        private bool InAdvantageState()
        {
            return Math.Abs(PointDifference()) == 1;
        }

        private string GetScoreStatusByPoints(int points)
        {
            return _scoreStatus[points];
        }

        private bool InEarlyScoringState()
        {
            return ScoreOnOrUnderTieBreakThreshold(_players[0].Points) && ScoreOnOrUnderTieBreakThreshold(_players[1].Points) && !HasReachedDucePossibilityYet();
        }

        private int PointDifference()
        {
            return _players[0].Points - _players[1].Points;
        }

        private bool HasReachedDucePossibilityYet()
        {
            return _players[0].Points + _players[1].Points >= 6;
        }

        private Player GetLeadingPlayer()
        {
            return _players[0].Points > _players[1].Points  ? _players[0] : _players[1];
        }

        private bool ScoresAreEqual()
        {
            return _players[0].Points == _players[1].Points;
        }

        private bool ScoreOnOrUnderTieBreakThreshold(int score)
        {
            return score <= 3;
        }

        public void WonPoint(string playerName)
        {
            var player = _players.Single(x => x.Name == playerName);
            player.IncrementPoints();
        }

    }
}

