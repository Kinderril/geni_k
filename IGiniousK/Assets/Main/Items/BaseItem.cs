using UnityEngine;

public enum ItemType
{
    AccLow,
    Life,
    Freez,
    SizeDown,
    Points,
}

public class BaseItem : MonoBehaviour
{
    public ItemType type;
    public float EffectDuration;
    public float ItemLifeTime;
    private float endTime;

    void Start()
    {
        endTime = Time.time + ItemLifeTime;
    }

    void Update()
    {
        if (endTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

}

