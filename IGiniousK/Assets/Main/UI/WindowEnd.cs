
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class WindowEnd : BaseWindow
{
    public Text cureentResult;
    public Text bestResult;
    public Slider endSlider;

    public void OnOkClicked()
    {
        GameController.OnEndConfirm();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
        endSlider.value = gc.GetEndTime()/20f;
        cureentResult.text = gc.GetEndTime().ToString("00.00");

    }

    public void OnFBClicked()
    {
        GameController.fbControls.SendImage();
    }
}

