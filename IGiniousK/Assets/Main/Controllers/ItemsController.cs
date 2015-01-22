using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ItemsController : MonoBehaviour
{
    public BaseItem LowSpeed;
    public List<BaseItem> randomItems;
    private float nextLowSpeedAccure = 0;
    private float nextRandomAccure = 0;
    public float lowSpeedPeriod =10f;
    public float randomPeriod = 10f;
    private GameController gameController;

	public void StartGame(GameController gameController)
    {
        this.gameController = gameController;
        nextLowSpeedAccure = Time.time + lowSpeedPeriod;
        nextRandomAccure = Time.time + randomPeriod;
	    ClearElements();
    }

    private void ClearElements()
    {
        var list = GetComponentsInChildren<BaseItem>();
        Debug.Log("list " + list.Length);
        foreach (var baseItem in list)
        {
            Destroy(baseItem.gameObject);
        }
    }

    public void UpdateByGameController () {
	    if (nextLowSpeedAccure < Time.time)
	    {
            DoItem(LowSpeed);
            nextLowSpeedAccure = Time.time + Random.Range(lowSpeedPeriod * 0.75f, lowSpeedPeriod * 1.25f);
            //Debug.Log("nextLowSpeedAccure " + nextLowSpeedAccure + "   " + Time.time);
	    }
        
        if (nextRandomAccure < Time.time)
        {
            DoRandom();
            nextRandomAccure = Time.time +  Random.Range(randomPeriod * 0.75f, randomPeriod * 1.25f);
        }
	}

    private void DoRandom()
    {
        int index = Random.Range(0, randomItems.Count);
        DoItem(randomItems[index]);
    }

    private void DoItem(BaseItem baseItem)
    {
        float xRnd = Random.Range(gameController.LT.x, gameController.BR.x);
        float yRnd = Random.Range(gameController.BR.y, gameController.LT.y);
        GameObject go = Instantiate(baseItem.gameObject);// as GameObject;
        go.transform.localPosition = new Vector3(xRnd, yRnd);
        go.transform.parent = transform;
    }
}
