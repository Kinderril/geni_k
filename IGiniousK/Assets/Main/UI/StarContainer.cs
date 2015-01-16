using UnityEngine;
using System.Collections;

public class StarContainer : MonoBehaviour
{
    public GameObject closeStar;
    public GameObject openStar;
    public ParticleSystem openSystem;
    private bool isOpen = false;
    
    public bool Open()
    {
        if (isOpen)
            return false;
        closeStar.gameObject.SetActive(false);
        openStar.gameObject.SetActive(true);
        isOpen = true;
        if (openSystem != null)
            openSystem.Simulate(0.5f);
        return true;
    }

    public void Close()
    {
        closeStar.gameObject.SetActive(true);
        openStar.gameObject.SetActive(false);
        isOpen = false;
    }

}
