using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[6];
    [SerializeField] float spawnRate;
    [SerializeField] int safetyDistance = 10;
    bool is2D = true;
    float screenWidth;
    float screenHeight;
    Transform player;

    private void Start()
    {
        SetupEnemySpawner();
    }

    void SetupEnemySpawner()
    {
        screenWidth = GameMaster.instance.screenWidth;
        screenHeight = GameMaster.instance.screenHeight;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        var spawnPosition = new Vector3(randomX, randomY,0);
        Vector3 delta = spawnPosition - player.position;
        if (delta.x>safetyDistance|| delta.y > safetyDistance)
        {
            return spawnPosition;
        }
        else
        {
             return CalculatePosition();
        }

    }
}
