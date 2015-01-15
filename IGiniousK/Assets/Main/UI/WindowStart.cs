
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
        resultsText.text = gc.resultController.lastTime.ToString("00.00");
    }
}

