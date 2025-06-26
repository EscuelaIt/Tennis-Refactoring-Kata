using System;
using System.Diagnostics;

namespace Tennis;

internal struct Score
{
    public int PlayerOnePoints { get; private set; }
    public int PlayerTwoPoints { get; private set; }

    public static Score LoveAll()
    {
        return new Score ();
    }

    public bool IsTie => PlayerOnePoints == PlayerTwoPoints;
    public bool IsAdvOrWin => PlayerOnePoints >= 4 || PlayerTwoPoints >= 4;

    public void WonPointPlayerOne()
    {
        PlayerOnePoints++;
    }
    
    public void WonPointPlayerTwo()
    {
        PlayerTwoPoints++;
    }

    public string NameOfTie()
    {
        Debug.Assert(IsTie);
        return PlayerOnePoints <= 2
            ? $"{NameOfPoints(PlayerOnePoints)}-All"
            : "Deuce";
    }

    public string NameOfPoints()
    {
        return NameOfPoints(PlayerOnePoints)
               + "-"
               + NameOfPoints(PlayerTwoPoints);
    }

    static string NameOfPoints(int howManyPoints)
    {
        return howManyPoints switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => throw new ArgumentOutOfRangeException(nameof(howManyPoints), howManyPoints, "Invalid number of points")
        };
    }
}