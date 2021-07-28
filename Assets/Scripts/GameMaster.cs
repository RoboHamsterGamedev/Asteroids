using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    private int score = 0;
    public delegate void ChangeVisual();
    public static event ChangeVisual onVisualChange; //создаем событие
    public float screenWidth;
    public float screenHeight;


    void Awake()
    {
        if (instance == null) { instance = this.transform.GetComponent<GameMaster>(); }
        CalculateScreenSize();
    }

    public void AddScore(int amt)
    {
        score += amt;
        UIManager.instance.ChangeScore(score);
    }
    public void GameOver()
    {
        UIManager.instance.GameOverUI(score);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void VisualChangeButoon() 
    { 
        if (onVisualChange != null)
        { 
            onVisualChange(); 
        }
    }

    void CalculateScreenSize()
    {
        var screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenWidth = screenBoundaries.x;
        screenHeight = screenBoundaries.y;

        Debug.Log(" width " + screenWidth + " heigh" + screenHeight);
    }

}
