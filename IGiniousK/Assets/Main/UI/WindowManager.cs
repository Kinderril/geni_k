using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class WindowManager
{
    private static List<BaseWindow> allWindows;
    private static BaseWindow curWindow;
    private static GameController gc;
    private static float scalefactor = 1;


    public static void Init(List<BaseWindow> allWindowsInc, GameController gc, float scalefactor)
    {
        WindowManager.scalefactor = scalefactor;
        allWindows = allWindowsInc;
        WindowManager.gc = gc;
        //fadePanel.GetComponent<Animator>().
    }

    public static void WindowOn(BaseWindow bw)
    {
        //gc.fadePanel.StartAnim(bw.transform);
        if (curWindow == bw)
            return;
        if (curWindow != null)
        {
            curWindow.Dispose();
            curWindow.gameObject.SetActive(false);
        }
        curWindow = bw;
        bw.gameObject.SetActive(true);
        bw.Init(gc);
        foreach (Transform child in bw.transform)
        {
            Debug.Log("Child: " + child.gameObject.name + "  " + scalefactor);
            child.transform.localScale = Vector3.one * scalefactor;
        }

        foreach (var item in allWindows.Where(x => x != bw && x != null))
        {
            item.Dispose();
            item.gameObject.SetActive(false);
        }
    }

    public static BaseWindow GetCurrentWindow()
    {
        return curWindow;
    }
}

