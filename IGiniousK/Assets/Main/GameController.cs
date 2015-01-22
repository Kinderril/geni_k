using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

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
    public FaceBookController fbControls;
    public AdvController advController;
    public ResultController resultController;
    public ItemsController itemsController;
    //public GameObject AdMobGameObject;
    public float MaxTime = 25f;
   // public Chartboost chartboost;
    public Text DebugText;
    public Vector2 LT = new Vector2(-5.324f, 6.04f);
    public Vector2 BR = new Vector2(6.69f, -5.91f);
    //public FadePanel fadePanel;
    public ItemType currentEffec;
    private WindowInGame windowInGame;
    private int points = 0;

    public WindowInGame WindowInGame
    {
        get
        {
            if (windowInGame == null)
                windowInGame = ((WindowInGame)WindowManager.GetCurrentWindow());
            return windowInGame;
        }
    }

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
        fbControls = new FaceBookController(this, DebugText);
        advController = new AdvController(this,DebugText);
        resultController = new ResultController();
    }

    public float GetEndTime()
    {
        return endTime - startTime;
    }

	void Start ()
	{
	    uiControls = GetComponent<UIControls>();
        uiControls.Init(ball);
        WindowManager.Init(allWindows,this);
        WindowManager.WindowOn(startCanvas);
	}
	
	// Update is called once per frame
	void Update () {
        inGameUi.SetTime(Time.time - startTime);
	    if (Game_Stage == GameStage.game)
	    {
	        itemsController.UpdateByGameController();
	    }
	}

    public void StartGame()
    {
        int i = 0;
        points = 0;
        foreach (var enemy in enemies)
        {
            enemy.Init(this);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = enemiesStartPositions[i];
            i++;
        }
        //ball.transform.position = startBallPos;
        ball.Init(this, startBallPos,LT,BR);
        itemsController.StartGame(this);
        Game_Stage = GameStage.game;
        startTime = Time.time;
        WindowInGame.SetPoints(points);
    //    AdMobGameObject.gameObject.SetActive(false);
    }

    public void EndGame()
    {
     //   AdMobGameObject.gameObject.SetActive(true);
        endTime = Time.time;
        Game_Stage = GameStage.end;
        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
        resultController.roundNumber++;
        resultController.lastTime = endTime - startTime;
        advController.AfterRoundAdv(resultController.roundNumber);
    
    }


    public void OnEndConfirm()
    {
        Game_Stage = GameStage.mainMenu;
    }


    public void LowSpeed(Vector3 pos)
    {
        foreach (var enemy in enemies)
        {
            enemy.LowSpped(itemsController.lowSpeedPeriod);
        }
        WindowInGame.LaunchPoints(pos,50);
        points += 50;
        WindowInGame.SetPoints(points);
    }

    public void LowScale(Vector3 pos,float effectDuration)
    {
        Utils1.Shuffle(enemies);

        int i = 0;
        int p = 15;
        foreach (var enemy in enemies)
        {
            points += p;
            WindowInGame.SetPoints(points);
            WindowInGame.LaunchPoints(enemy.transform.position, points);
            if (i < 2)
            {
                enemy.StartRotate();
            }
            else
            {
                enemy.StartRotate();
            }
            i++;
        }
        
    }


    public void GetLife(Vector3 pos,bool onlyPoints)
    {
        int val = 100;
        if (!onlyPoints)
        {
            WindowInGame.GetLife();
        }
        else
        {
            val *= 2;
        }
        points += val;
        WindowInGame.LaunchPoints(pos, val);
        WindowInGame.SetPoints(points);
    }

    public void SetHit()
    {
        WindowInGame.SetHit();
    }
}

