using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowInGame : BaseWindow
{
    public GameObject starsParent;
    public Text levelIdLabel;
    public Text TimeLabel;
    public Text spendLabel;
    public Button buttonScale;
    public Button buttonExit;
    
    public override void Init(GameController gc)
    {
        base.Init(gc);
       
    }

    public void SetTime(float f)
    {
        TimeLabel.text = f.ToString("00.00");
    }

}
