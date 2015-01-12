using System.Linq;
using UnityEngine;

public enum SideCollide
{
    left,
    right,
    top,
    bottom,
}

public class ColliderObject : MonoBehaviour
{
    public SideCollide side;

    void OnTriggerEnter2D(Collider2D other)
    {

        var w = other.gameObject.GetComponent<Enemy>();
        if (w != null)
            w.collider(side);
    }
}
