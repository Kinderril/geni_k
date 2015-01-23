
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowStart : BaseWindow
{
    public Text resultsText;
    public Text levelField;
    private int curLevel = 1;
    
    public void OnStartClicked()
    {
        GameController.StartGame(curLevel);
    }

    public void OnExitClick(){
        Application.Quit();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
        curLevel = gc.resultController.level;
        levelField.text = curLevel.ToString();
        resultsText.text = "Last Result\n " + gc.resultController.TotalPoints().ToString("0");
    }

    public void OnHelpClicked()
    {
        GameController.HelpOn();
    }

    public void OnUpClicked()
    {
        if (curLevel < GameController.resultController.level)
        {
            curLevel++;
            levelField.text = curLevel.ToString();
        }
    }

    public void OnDownClicked()
    {
        if (curLevel > 1)
        {
            curLevel--;
            levelField.text = curLevel.ToString();
        }
    }

}

