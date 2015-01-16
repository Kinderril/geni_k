using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowInGame : BaseWindow
{
    public Text TimeLabel;
    public GameObject hitPanel;
    public GameObject life;
    public GameObject lifeContainer;
    private List<StarContainer> lifes = new List<StarContainer>(); 

    public override void Init(GameController gc)
    {
        base.Init(gc);
        hitPanel.gameObject.SetActive(false);
        if (lifes.Count == 0)
        {
            for (int i = 0; i < gc.ball.maxLives; i++)
            {
                GameObject go = Instantiate(life);
                go.transform.parent = lifeContainer.transform;
                go.transform.localPosition = new Vector3(4, -300/2.5f +  i*60);
                lifes.Add(go.GetComponent<StarContainer>());
            }
        }
        foreach (var starContainer in lifes)
        {
            starContainer.Open();
        }
    }

    public void SetTime(float f)
    {
        TimeLabel.text = f.ToString("00.00");
    }

    public void SetHit()
    {
        lifes[GameController.ball.curLive-1].Close();
        hitPanel.gameObject.SetActive(true);
        StartCoroutine(hitWait());
    }

    private IEnumerator hitWait()
    {
        yield return new WaitForSeconds(0.2f);
        hitPanel.gameObject.SetActive(false);
    }
}
