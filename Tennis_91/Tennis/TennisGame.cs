using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame
    {
        private string firstPlayerName = string.Empty;
        private string secondPlayerName = string.Empty;

        private int firstPlayerScore = 0;
        private int secondPlayerScore = 0;
        private Dictionary<int, string> scoreMap = new Dictionary<int, string>() {
                {0,"Love" },
                {1,"Fifteen"},
                {2,"Thirty"},
                {3,"Forty"},
            };

        public TennisGame(string firstPlayer, string secondPlayer)
        {
            firstPlayerName = firstPlayer;
            secondPlayerName = secondPlayer;
        }

        public string GetScore()
        {
            if (ScoreDifferent())
            {
                if (IsGamePoint())
                {
                    return string.Format("{0} {1}",
                        firstPlayerScore > secondPlayerScore ? firstPlayerName : secondPlayerName,
                        PlayerAdv() ? "Adv" : "Win");

                }
                return string.Format("{0} {1}", scoreMap[firstPlayerScore], scoreMap[secondPlayerScore]);
            }

            if (Deuce())
            {
                return "Deuce";
            }

            return string.Format("{0} All", scoreMap[firstPlayerScore]);
        }

        private bool IsGamePoint()
        {
            return firstPlayerScore > 3 || secondPlayerScore > 3;
        }

        private bool PlayerAdv()
        {
            return Math.Abs(firstPlayerScore - secondPlayerScore) == 1;
        }

        private bool Deuce()
        {
            return firstPlayerScore == secondPlayerScore && firstPlayerScore >= 3;
        }

        private bool ScoreDifferent()
        {
            return firstPlayerScore != secondPlayerScore;
        }

        public void FirstPlayerScore()
        {
            firstPlayerScore++;
        }

        public void SecondPlayerScore()
        {
            secondPlayerScore++;
        }
    }
}