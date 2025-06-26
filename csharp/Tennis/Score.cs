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

    public int PointsDifference => PlayerOnePoints - PlayerTwoPoints;
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
        if (IsTie)
            return NameOfTie();
        if(IsAdvOrWin)
            return PointsDifference switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        
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