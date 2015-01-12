using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Ball ball;
    private float startTime;
    private float endTime;
    private UIControls uiControls;
    public Transform EnemyContainer;
    private GameStage gameStage;
    private List<Vector2> enemiesStartPositions = new List<Vector2>();
    private Vector2 startBallPos;
    public List<Enemy> enemies;
    public WindowInGame inGameUi;
    public List<BaseWindow> allWindows;
    public BaseWindow startCanvas;

    public GameStage Game_Stage
    {
        get { return gameStage; }
        set
        {
            switch (value)
            {
                case GameStage.mainMenu:
                    uiControls.enabled = false;
                    break;
                case GameStage.game:
                    uiControls.enabled = true;
                    break;
                case GameStage.end:
                    uiControls.enabled = false;
                    break;
            }
            gameStage = value;
            var curWindow = allWindows.FirstOrDefault(x => x.gameStage == value);
            if (curWindow != null)
                WindowManager.WindowOn(curWindow);
        }
    }
    // Use this for initialization

    void Awake()
    {
        startBallPos = ball.transform.position;
        foreach (var enemy in enemies)
        {
            enemiesStartPositions.Add(enemy.transform.position);
        }
    }

    public float GetEndTime()
    {
        return endTime - startTime;
    }

	void Start ()
	{
	    uiControls = GetComponent<UIControls>();
        uiControls.Init(ball);
        Debug.Log("Init " + allWindows.Count);
        WindowManager.Init(allWindows,this);
        WindowManager.WindowOn(startCanvas);
	}
	
	// Update is called once per frame
	void Update () {
        inGameUi.SetTime(Time.time - startTime);
	}

    public void StartGame()
    {
        int i = 0;
        foreach (var enemy in enemies)
        {
            enemy.Init(this);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = enemiesStartPositions[i];
            i++;
        }
        ball.transform.position = startBallPos;
        ball.Init(this);
        Game_Stage = GameStage.game;
        startTime = Time.time;
    }

    public void EndGame()
    {
        endTime = Time.time;
        Game_Stage = GameStage.end;
        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    public void OnEndConfirm()
    {
        Game_Stage = GameStage.mainMenu;
    }
}
