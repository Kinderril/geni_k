
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class WindowEnd : BaseWindow
{
    public Text cureentResult;
    public Text bestResult;
    public Slider endSlider;
    private string send2fb = "";

    public void OnOkClicked()
    {
        GameController.OnEndConfirm();
    }

    public override void Init(GameController gc)
    {
        base.Init(gc);
        endSlider.value = gc.GetEndTime() / gc.MaxTime;
        cureentResult.text = gc.GetEndTime().ToString("00.00");
        string ss = "It's All You Can?";
        send2fb = "so-so";
        if (endSlider.value > 0.6f)
        {
            if (endSlider.value < 0.7f)
            {
                ss = "Good!";
                send2fb = "good";
            }
            else if (endSlider.value < 0.8f)
            {
                ss = "Excellent!!";
                send2fb = "excellent";
            }
            else if (endSlider.value < 0.9f)
            {
                ss = "Awesome!!!";
                send2fb = "awersome";
            }
            else
            {
                ss = "Godlike!!!!";
                send2fb = "Godlike";
            }
        }
        bestResult.text = ss;
    }

    public void OnFBClicked()
    {
        GameController.fbControls.SendImage(send2fb);
    }
}

