
public class ResultController
{
    public int roundNumber;
    public float lastTime;
    public float lastPoints;

    public int TotalPoints()
    {
        return (int)(lastPoints + lastTime * 10);
    }
}

