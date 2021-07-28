using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0; 
    
    void Awake()
    {
        if (instance == null) { instance = this.transform.GetComponent<ScoreManager>(); }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        score += points; 
    }
}
