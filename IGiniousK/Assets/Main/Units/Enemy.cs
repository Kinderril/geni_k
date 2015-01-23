
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Vector2 direction;
    private GameController gc;
    public float acc = 0.0015f;
    private Vector2 accv;
    private Vector3 baseScale;
    private Animator animator;

    public Animator Animator
    {
        get
        {
            if (animator == null)
                animator = GetComponent<Animator>();
            return animator;
        }
    }

    //private bool isScaled = false;
    //private float scaleEndTime;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        if (gc.Game_Stage == GameStage.game)
        {
            //set pos
            transform.position = new Vector2(transform.position.x + direction.x*Time.deltaTime,
                transform.position.y + direction.y*Time.deltaTime);
            //accelerate
            //direction *= (1 + acc*Time.deltaTime);
            //t2
            direction = new Vector2(direction.x + Mathf.Sign(direction.x) * acc * Time.deltaTime, direction.y + Mathf.Sign(direction.y) * acc * Time.deltaTime);
           /* if (isScaled)
            {
                if (Time.time > scaleEndTime)
                {
                    ChangeScale(0);
                }
            }*/
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
        animator = GetComponent<Animator>();
        this.gc = gc;
        Vector2 v = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        accv = new Vector2(acc, acc);
        direction = v.normalized * 2;
        EndRotate();
        transform.rotation = Quaternion.identity;
    }
    /*
    public void ChangeScale(float lenghtOfScale,float d = 1)
    {
        if (d != 1)
        {
            transform.localScale *= d;
            isScaled = true;
            scaleEndTime = Time.time + lenghtOfScale;
        }
        else
        {
            transform.localScale = baseScale;
            isScaled = false;
        }
    }
    */
    public void StartRotate()
    {
        Animator.SetBool("shallRotate", true);
        //animator.GetCurrentAnimatorStateInfo(0).
    }

    public void EndRotate()
    {
        Animator.SetBool("shallRotate",false);
    }

    public void LowSpped(float p)
    {
        //Debug.Log("Spped low " + p);
       // p *= 0.9f;
        direction = new Vector2(direction.x - Mathf.Sign(direction.x) * acc * p, direction.y - Mathf.Sign(direction.y) * acc * p);
    }
}

