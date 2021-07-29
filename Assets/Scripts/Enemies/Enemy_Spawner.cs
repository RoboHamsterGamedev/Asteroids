using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[6];
    [SerializeField] float spawnRate;
    [SerializeField] int safetyDistance = 2;
    bool is2D = true;
    float screenWidth;
    float screenHeight;

    private void Start()
    {
        SetupEnemySpawner();
    }

    void SetupEnemySpawner()
    {
        screenWidth = GameMaster.instance.screenWidth;
        screenHeight = GameMaster.instance.screenHeight;
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
        GameMaster.onVisualChange += ChangeVisual;
    }
    
    void ChangeVisual()
    {
        is2D = !is2D;
    }
   
    void SpawnEnemy()
    {
        var spawnPosition = CalculatePosition();
        int randomIndex = Random.Range(0, enemies.Length);
       GameObject newEnemy =  Instantiate(enemies[randomIndex], spawnPosition, Quaternion.identity, this.transform);
        if (!is2D)
        {
            newEnemy.GetComponent<SwapVisualObject>().ChangeVisual();
        }
    }
    Vector3 CalculatePosition()
    {
        var randomX = Random.Range(-screenWidth, screenWidth);
        var randomY = Random.Range(-screenHeight, screenHeight);
        var spawnPosition = new Vector3(randomX, randomY);
        if (!Physics.CheckSphere(spawnPosition, safetyDistance, 8)) 
        { 
            return spawnPosition; 
        }
        else return CalculatePosition();
    }
}
