using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class FaceBookController  {

    // Use this for initialization
    Facebook.FacebookDelegate fbDelegate;
    public Text debugt;
    private GameController gameController;
    private string msg;

    void Awake()
    {
        FB.Init(onComplete);
	}

    private void onComplete()
    {
        Log("FB inited");
    }
	
	// Update is called once per frame
	void Update () {

    }

    public FaceBookController(GameController gameController, Text debugt)
    {
        this.debugt = debugt;
        this.gameController = gameController;
        FB.Init(onComplete);
    }

    public void SendImage(string msg)
    {
        this.msg = msg;
        SetInit();
    }

    private void SetInit()
    {
        Log("FB IsLoggedIn " + FB.IsLoggedIn);
        if (FB.IsLoggedIn)
        {
           // Util.Log("Already logged in");
            OnLoggedIn();
        }
        else
        {
            Log("NOT !!! Logged in. ID: " + FB.UserId);
            CallFBLogin();

        }
    }

    private void Log(string s)
    {
        if (debugt != null)
            debugt.text += "\n " + s;
        Debug.Log(s);
    }

    private void OnHideUnity(bool isGameShown)
    {
       // Util.Log("OnHideUnity");
        if (!isGameShown)
        {
            // pause the game - we will need to hide                                             
            Time.timeScale = 0;
        }
        else
        {
            // start the game back up - we're getting focus again                                
            Time.timeScale = 1;
        }
    }

    void OnLoggedIn()
    {
        Log("Logged in. ID: " + FB.UserId);
        MyPictureCallback();
        fbDelegate = cb;
    }
    private void CallFBLogin()
    {
        FB.Login("email,publish_actions", LoginCallback);
    }

    void LoginCallback(FBResult result)
    {
        if (result.Error != null)
            Log("Error Response:" + result.Error);
        else if (!FB.IsLoggedIn)
        {
            Log("Login cancelled by Player");
        }
        else
        {
            Log("Login was successful!");
            MyPictureCallback();
        }
    }

    private void cb(FBResult result)
    {
        Debug.Log("FBResult  " + result);
    }


    void MyPictureCallback()
    {
        FB.Feed(
            linkCaption: "",
            picture: "https://fbcdn-photos-f-a.akamaihd.net/hphotos-ak-xfp1/t39.2081-0/p128x128/10935991_1402239463405550_579798466_n.png",
            linkName: "My time is:" + gameController.GetEndTime().ToString("00.00") + " \n I am " + msg + " Gin!",
            link: "http://apps.facebook.com/" + FB.AppId ,//+ "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest"),
            callback: fbDelegate
            ); 


    }

    public string FeedToId = "";
    public string FeedLink = "";
    public string FeedLinkName = "";
    public string FeedLinkCaption = "";
    public string FeedLinkDescription = "";
    public string FeedPicture = "";
    public string FeedMediaSource = "";
    public string FeedActionName = "";
    public string FeedActionLink = "";
    public string FeedReference = "";
    public bool IncludeFeedProperties = false;
    private Dictionary<string, string[]> FeedProperties = new Dictionary<string, string[]>();

    private void CallFBFeed()
    {
        Dictionary<string, string[]> feedProperties = null;
        if (IncludeFeedProperties)
        {
            feedProperties = FeedProperties;
        }
        FB.Feed(
            toId: FeedToId,
            link: FeedLink,
            linkName: FeedLinkName,
            linkCaption: FeedLinkCaption,
            linkDescription: FeedLinkDescription,
            picture: FeedPicture,
            mediaSource: FeedMediaSource,
            actionName: FeedActionName,
            actionLink: FeedActionLink,
            reference: FeedReference,
            properties: feedProperties,
            callback: Callback
        );
    }

    protected void Callback(FBResult result)
    {
        string lastResponse; 
        //lastResponseTexture = null;
        // Some platforms return the empty string instead of null.
        if (!String.IsNullOrEmpty(result.Error))
        {
            lastResponse = "Error Response:\n" + result.Error;
        }
        else if (!String.IsNullOrEmpty(result.Text))
        {
            lastResponse = "Success Response:\n" + result.Text;
        }
        else if (result.Texture != null)
        {
            //lastResponseTexture = result.Texture;
            lastResponse = "Success Response: texture\n";
        }
        else
        {
            lastResponse = "Empty Response\n";
        }
    }


}
