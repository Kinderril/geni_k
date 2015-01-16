
    using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameController gamec;
    public int maxLives = 1;
    public int curLive = 0;
    public Vector3 startPos;
    public Vector2 LT = new Vector2(-5.324f, 6.04f);
    public Vector2 BR = new Vector2(6.69f, -5.91f);

    void Update()
    {
        
    }

    public void SetPos(Vector2 v)
    {
        transform.position = new Vector3(Mathf.Clamp(v.x, LT.x, BR.x), Mathf.Clamp(v.y, BR.y, LT.y), 0);        
    }

    public void Init(GameController gameController,Vector3 pos)
    {
        gamec = gameController;
        curLive = 0;
        startPos = pos;
        transform.position = pos;
    }

    public void BallGetHit()
    {
        curLive++;
        BaseWindow bw = WindowManager.GetCurrentWindow();
        if (curLive >= maxLives)
        {
            gamec.EndGame();
        }
        ((WindowInGame)bw).SetHit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var b = other.gameObject.GetComponent<ColliderObject>();
        if (b != null)
        {
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
    }
}

