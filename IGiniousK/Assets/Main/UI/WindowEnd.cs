
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
        endSlider.value = gc.GetEndTime() / gc.MaxTime;
        cureentResult.text = gc.GetEndTime().ToString("00.00");
        string ss = "";
        if (endSlider.value > 0.6f)
        {
            if (endSlider.value < 0.7f)
            {
                ss = "Good!";
            }
            else if (endSlider.value < 0.8f)
            {
                ss = "Excellent!!";
            }
            else if (endSlider.value < 0.9f)
            {
                ss = "Awesome!!!";
            }
            else
            {
                ss = "Godlike!!!!";
            }
        }
        bestResult.text = ss;
    }

    public void OnFBClicked()
    {
        GameController.fbControls.SendImage();
    }
}

