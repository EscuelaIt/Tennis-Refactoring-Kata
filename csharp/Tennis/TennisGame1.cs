using System;
using System.Diagnostics;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        Score delegated = Score.LoveAll();
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
                delegated.WonPointPlayerOne();
            else if (playerName == player2Name)
                delegated.WonPointPlayerTwo();
        }

        public string GetScore()
        {
            return delegated.NameOfPoints();
        }
    }
}

