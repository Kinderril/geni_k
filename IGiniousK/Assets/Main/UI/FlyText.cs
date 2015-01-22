
using UnityEngine;
using UnityEngine.UI;

public class FlyText : MonoBehaviour
{
    public Text text;

    public void SetText(string ss)
    {
        text.text = ss;
    }

    public void OnEnd()
    {
        Destroy(transform.parent.gameObject);
    }
}

