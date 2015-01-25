
using UnityEngine;

public class ResultController
{
    public int roundNumber;
    public float lastTime = 0;
    public int lastPoints;
    public int level;
    public int Lastlevel;
    public int curLevel;

    private const string LEVEL_FIELD = "LEVEL_FIELD";
    private const string MAX_POINTS = "MAX_POINTS";

    public int TotalPoints()
    {
        return (int)(lastPoints + lastTime * 10);
    }

    public void Save()
    {
        PlayerPrefs.SetInt(LEVEL_FIELD,level);
        if (PlayerPrefs.GetInt(MAX_POINTS, 0) < TotalPoints())
            PlayerPrefs.SetInt(MAX_POINTS, TotalPoints());
    }

    public void Load()
    {
        level = PlayerPrefs.GetInt(LEVEL_FIELD, 1);
        if (level < 1)
            level = 1;
        lastPoints = PlayerPrefs.GetInt(MAX_POINTS, 0);
        Debug.Log("loaded " + level);
    }

    public void LevelUp()
    {
        if (curLevel == level)
        {
            if (TotalPoints() > 5000 && level < 6)
                level++;
        }
    }

}

