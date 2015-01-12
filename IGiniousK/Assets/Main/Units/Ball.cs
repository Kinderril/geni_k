
    using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameController gamec;

    void Update()
    {
        
    }

    public void Init(GameController gameController)
    {
        gamec = gameController;
    }

    public void EndGame()
    {
        Debug.Log("End");
        gamec.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        var b = other.gameObject.GetComponent<ColliderObject>();
        if (b != null)
        {
            EndGame();
        }
        else
        {
            var e = other.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                EndGame();
            }
        }
    }
}

