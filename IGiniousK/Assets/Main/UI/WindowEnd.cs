﻿
using UnityEngine.UI;

public class WindowEnd : BaseWindow
{
    public Text cureentResult;
    public Text bestResult;

    public void OnOkClicked()
    {
        GameController.OnEndConfirm();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
        cureentResult.text = gc.GetEndTime().ToString("00.00");
    }

    public void OnFBClicked()
    {
        //GameController.faceBook.SendImage();
    }
}
