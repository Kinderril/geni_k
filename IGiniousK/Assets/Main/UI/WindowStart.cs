
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowStart : BaseWindow
{
    public Text resultsText;

    public void OnStartClicked()
    {
        //GameController.StartGame();//randomButton.isOn?-1:Convert.ToInt32(randomNumberText.text));
    }

    public void OnExitClick(){
        Application.Quit();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
    }
}

