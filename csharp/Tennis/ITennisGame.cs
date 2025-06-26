using System;

namespace Tennis
{
    public interface ITennisGame
    {
        [Obsolete] void WonPoint(string playerName);
        string GetScore();
    }
}

