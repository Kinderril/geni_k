
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Vector2 direction;
    private GameController gc;
    public float acc = 1.0015f;

    void Start()
    {
    }

    void Update()
    {
        if (gc.Game_Stage == GameStage.game)
        {
            transform.position = new Vector2(transform.position.x + direction.x*Time.deltaTime,
                transform.position.y + direction.y*Time.deltaTime);
            direction *= acc;
        }
    }

    public void collider(SideCollide side)
    {
        switch (side)
        {
            case SideCollide.left:
                direction = new Vector2(-direction.x, direction.y);
                break;
            case SideCollide.right:
                direction = new Vector2(-direction.x, direction.y);
                break;
            case SideCollide.top:
                direction = new Vector2(direction.x, -direction.y);

                break;
            case SideCollide.bottom:

                direction = new Vector2(direction.x, -direction.y);
                break;
            default:
                throw new ArgumentOutOfRangeException("side");
        }
    }

    public void Init(GameController gc)
    {
        this.gc = gc;
        Vector2 v = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = v.normalized * 2;
    }
    
}

