
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowStart : BaseWindow
{
    public Text resultsText;

    public void OnStartClicked()
    {
        GameController.StartGame();
    }

    public void OnExitClick(){
        Application.Quit();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
        resultsText.text = "Last Result\n " + gc.resultController.TotalPoints().ToString("0");
    }
}

