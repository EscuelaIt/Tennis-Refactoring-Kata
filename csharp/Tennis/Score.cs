namespace Tennis;

internal struct Score
{
    int playerOnePoints;
    int playerTwoPoints;

    public static Score LoveAll()
    {
        return new Score ();
    }
    
    public void WonPointPlayerOne()
    {
        playerOnePoints++;
    }
    
    public void WonPointPlayerTwo()
    {
        playerTwoPoints++;
    }

    public bool Is(int one, int two)
    {
        return playerOnePoints == one && playerTwoPoints == two;
    }
}