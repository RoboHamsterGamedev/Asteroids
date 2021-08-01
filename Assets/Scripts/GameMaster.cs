using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    private int score = 0;
    public delegate void ChangeVisual();
    public static event ChangeVisual onVisualChange;
    public delegate void GameOverEvent(int score);
    public static event GameOverEvent onGameOver;
    bool IsGameOver = false;
    public float screenWidth;
    public float screenHeight;


    void Awake()
    {
        if (instance == null) { instance = this.transform.GetComponent<GameMaster>(); }
        CalculateScreenSize();
    }

    void CalculateScreenSize()
    {
        var screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenWidth = screenBoundaries.x;
        screenHeight = screenBoundaries.y;
    }
    public void AddScore(int amt)
    {
        if (!IsGameOver)
        {
            score += amt;
            UIManager.instance.ChangeScore(score);
        }
    }
   
    public void VisualChangeButoon() 
    { 
        if (onVisualChange != null)
        { 
            onVisualChange(); 
        }
    }
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver(score);
        }
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
