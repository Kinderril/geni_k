
    using System;
    using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameController gamec;
    public int maxLives = 1;
    public int curLive = 0;
    public Vector3 startPos;
    public Vector2 LT;// = new Vector2(-5.324f, 6.04f);
    public Vector2 BR;// = new Vector2(6.69f, -5.91f);
    private Animator animator;
    public bool isHitWall = true;

    void Update()
    {
        
    }

    public void SetPos(Vector2 v)
    {
        transform.position = new Vector3(Mathf.Clamp(v.x, LT.x, BR.x), Mathf.Clamp(v.y, BR.y, LT.y), 0);        
    }

    public void Init(GameController gameController,Vector3 pos, Vector2 LT,Vector2 BR)
    {
        this.LT = LT;
        this.BR = BR;
        animator = GetComponent<Animator>();
        animator.SetBool("isHit", false);
        gamec = gameController;
        curLive = 0;
        startPos = pos;
        transform.position = pos;
    }

    public void BallGetHit()
    {
        animator.SetBool("isHit", true);
        curLive++;
        
        if (curLive >= maxLives)
        {
            gamec.EndGame();
        }
        gamec.SetHit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var b = other.gameObject.GetComponent<ColliderObject>();
        if (b != null)
        {
            if (isHitWall)
                BallGetHit();
        }
        else
        {
            var e = other.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                BallGetHit();
            }
        }
        var a = other.gameObject.GetComponent<BaseItem>();
//        Debug.Log("OnTriggerEnter2D " + a);
        if (a != null)
        {
            GetItem(a);
            Destroy(a.gameObject);
        }
    }

    private void GetItem(BaseItem item)
    {
        switch (item.type)
        {
            case ItemType.AccLow:
                gamec.LowSpeed(item.transform.position,item.EffectDuration);
                break;
            case ItemType.Life:
                if (curLive > 0)
                {
                    curLive--;
                    gamec.GetLife(item.transform.position, false);
                }
                else
                {
                    gamec.GetLife(item.transform.position, true);
                }
                break;
            case ItemType.Freez:
                break;
            case ItemType.SizeDown:
                gamec.BigBonus(item.transform.position,item.EffectDuration);
                break;
        }

    }

    public void HitEnd()
    {
        animator.SetBool("isHit",false);
    }
}

