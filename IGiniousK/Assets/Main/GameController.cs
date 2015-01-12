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
    public List<Vector2> startPositions = new List<Vector2>();
    public List<Enemy> enemies;
    public WindowInGame inGameUi;
    public List<BaseWindow> allWindows;

    public GameStage GameStage
    {
        get { return gameStage; }
        set
        {
            switch (value)
            {
                case GameStage.mainMenu:
                    break;
                case GameStage.game:
                    break;
                case GameStage.end:
                    break;
            }
            gameStage = value;
            var curWindow = allWindows.FirstOrDefault(x => x.gameStage == value);
            if (curWindow != null)
                WindowManager.WindowOn(curWindow);
        }
    }
    // Use this for initialization
	void Start ()
	{
	    uiControls = GetComponent<UIControls>();
        uiControls.Init(ball);
	}
	
	// Update is called once per frame
	void Update () {
        inGameUi.SetTime(Time.time - startTime);
	}

    public void StartGame()
    {
        gameStage = GameStage.game;
        startTime = Time.time;
    }

    public void EndGame()
    {
        gameStage = GameStage.end;
        endTime = Time.time;
    }
}
