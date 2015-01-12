
using UnityEngine.UI;

public class WindowEnd : BaseWindow
{
    public Text cureentResult;
    public Text bestResult;

    public void OnOkClicked()
    {
        //GameController.OnEndConfirm();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
    }

    public void OnFBClicked()
    {
        //GameController.faceBook.SendImage();
    }
}

