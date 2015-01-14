
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdvController
{
    private Text debugText;

    public AdvController(GameController gc, Text text)
    {
        debugText = text;
        Advertisement.Initialize("23042", true);
        Log("Advertisement " + Advertisement.isReady());
       // Chartboost.cacheMoreApps(CBLocation.GameOver);
    }

    public void ShowAdv()
    {
        Log("Advertisement " + Advertisement.isReady());
        if (Advertisement.isReady())
        {
            Advertisement.Show();
        }
    }

    public void ShowAdvCB()
    {
        Log("Chartboost " );
       // Chartboost.showInterstitial(CBLocation.GameOver);
    }

    private void Log(string s)
    {
        if (debugText != null)
            debugText.text = debugText.text + "\n " + s;
        Debug.Log(s);
    }

}

