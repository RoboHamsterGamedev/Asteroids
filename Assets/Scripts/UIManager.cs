using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject[] weapons; 
    [SerializeField] Slider levelSlider = null;
    [SerializeField] Text scoreText = null;
    [SerializeField] GameObject gameOver = null;
    [SerializeField] Text totalScoreText = null;

    void Awake()
    {
        if (instance == null) { instance = this.transform.GetComponent<UIManager>(); }
    }

    void Update()
    {
        
    }
    public void LaserPowerUI(float currentLaserPower)
    {
        if (levelSlider != null)
        {
            levelSlider.value = currentLaserPower;
        }
    }

    public void ChangeWeapon(int index)
    {
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[index].SetActive(true);
    }

    public void ChangeScore(int amt)
    {
        scoreText.text = "Score: " + amt;
    }

    public void GameOverUI(int score)
    {
        totalScoreText.text = "Total Score: " + score;
        gameOver.SetActive(true);
    }
}
