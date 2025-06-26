using System;
using System.Diagnostics;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        Score current = Score.LoveAll();
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            Debug.Assert(player1Name != player2Name);
            
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            Debug.Assert(playerName == player1Name || playerName == player2Name, "Invalid player name");
            
            if (playerName == player1Name)
                current.WonPointPlayerOne();
            else if (playerName == player2Name)
                current.WonPointPlayerTwo();
        }

        public string GetScore()
        {
            if (current.IsTie)
                return Tie();
            if (current.IsAdvOrWin)
                return AfterDeuce();
            return BeforeDeuce("");
        }

        string BeforeDeuce(string score)
        {
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1) tempScore = current.PlayerOnePoints;
                else { score += "-"; tempScore = current.PlayerTwoPoints; }

                score += Score.NameOfPoints(tempScore);
            }

            return score;
        }

        string AfterDeuce()
        {
            string score;
            var minusResult = current.PlayerOnePoints - current.PlayerTwoPoints;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        string Tie()
        {
            return current.PlayerOnePoints <= 2
                ? $"{Score.NameOfPoints(current.PlayerOnePoints)}-All"
                : "Deuce";
        }
    }
}

