using UnityEngine;
using UnityEngine.EventSystems;

public class UIControls : MonoBehaviour , IPointerDownHandler , IPointerUpHandler , IDragHandler {

	// Use this for initialization
    private Ball ball;
    private Vector2 basePosition;
    private Vector2 baseballPosition;
    //private Vector2 curPower;
    public float distancePercent = 0.5f;
   // private float d;
    //public Image StartDragImage;
    private Vector2 offset;
    private Vector2 _r;
    public float scalefactor  = 1;

	void Start ()
	{
	    basePosition = new Vector2(Screen.width/2, Screen.height/2);
        //distancePercent
        //d = Mathf.Min(Screen.width / 2, Screen.height / 2) * distancePercent;
        //Debug.Log(basePosition);
	}

    public void Init(Ball ball)
    {
        this.ball = ball;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void OnPointerDown(PointerEventData eventData)
    {
        basePosition =  eventData.position;
       // basePosition = (Vector2)ball.transform.position - eventData.position;
        baseballPosition = ball.transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //curPower = Vector2.zero;
        ////StartDragImage.gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        offset = (eventData.position - basePosition) / scalefactor;
        ball.SetPos(baseballPosition + offset);
    }
}
