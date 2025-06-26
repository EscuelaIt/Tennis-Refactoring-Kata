namespace Tennis;

internal struct Score
{
    public int PlayerOnePoints { get; private set; }
    public int PlayerTwoPoints { get; private set; }

    public static Score LoveAll()
    {
        return new Score ();
    }
    
    public void WonPointPlayerOne()
    {
        PlayerOnePoints++;
    }
    
    public void WonPointPlayerTwo()
    {
        PlayerTwoPoints++;
    }
}