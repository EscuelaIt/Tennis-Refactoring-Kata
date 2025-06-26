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
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                current.WonPointPlayerOne();
            else
                current.WonPointPlayerTwo();
        }

        public string GetScore()
        {
            if (IsTie())
                return Tie();
            if (IsAfterDeuce())
                return AfterDeuce();
            return BeforeDeuce("");
        }

        bool IsAfterDeuce()
        {
            return current.PlayerOnePoints >= 4 || current.PlayerTwoPoints >= 4;
        }

        bool IsTie()
        {
            return current.PlayerOnePoints == current.PlayerTwoPoints;
        }

        string BeforeDeuce(string score)
        {
            int tempScore;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = current.PlayerOnePoints;
                else { score += "-"; tempScore = current.PlayerTwoPoints; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
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
            return current.PlayerOnePoints switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }
}

