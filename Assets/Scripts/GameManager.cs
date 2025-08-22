using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private string playerName = "Player";
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    private int highScore = 0;
    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }

    private string highScoreName = "";
    public string HighScoreName
    {
        get { return highScoreName; }
        set { highScoreName = value; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadData();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SaveData();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
            SaveData();
    }

    void OnDestroy()
    {
        if (instance == this)
            SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetString("HighScoreName", highScoreName);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
        }
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        if (PlayerPrefs.HasKey("HighScoreName"))
        {
            highScoreName = PlayerPrefs.GetString("HighScoreName");
        }
    }
}