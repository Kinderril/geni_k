using UnityEngine;
using System.Collections;

public class FadePanel : MonoBehaviour {

    public void StopAnim()
    {
        gameObject.SetActive(false);
    }

    public void StartAnim(Transform par)
    {
        gameObject.SetActive(true);
        transform.parent = par;
        GetComponent<RectTransform>().sizeDelta = new Vector2(9999, 9999);
        transform.localScale = Vector3.one;
    }
}
