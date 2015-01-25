
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdvController
{
    private Text debugText;
    private bool isAdv = true;

    public AdvController(GameController gc, Text text)
    {
        debugText = text;
        Advertisement.Initialize("23042", false);
        HeyzapAds.start("47205add69ea9390660aa634f662514f", HeyzapAds.FLAG_NO_OPTIONS);
    }

    private void ShowAdv()
    {
        Log("Advertisement " + Advertisement.isReady());
        if (Advertisement.isReady())
        {
            Advertisement.Show();
            
        }
    }

    private void ShowAdvCb()
    {
        Log("HZInterstitialAd " + HZInterstitialAd.isAvailable());
        if (HZInterstitialAd.isAvailable())
        {
            //HZInterstitialAd.fetch();
            HZInterstitialAd.show();
        }
    }

    private void Log(string s)
    {
        if (debugText != null)
            debugText.text = debugText.text + "\n " + s;
        Debug.Log(s);
    }


    public bool AfterRoundAdv(int round)
    {
        bool shallShow = (int)(round / 100) > 0;
        //Debug.Log("shallShow " + shallShow);
        if (shallShow)
        {
            if (isAdv)
            {
                ShowAdv();
            }
            else
            {
                ShowAdvCb();
            }
            isAdv = !isAdv;
            return true;
        }
        return false;
    }
}

