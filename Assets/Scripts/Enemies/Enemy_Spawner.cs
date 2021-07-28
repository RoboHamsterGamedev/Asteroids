using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[6];
  //  Vector3 spawnPosition;
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
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Vector3 playerPos = Player.instance.transform.position;
        Gizmos.DrawSphere(playerPos, safetyDistance);
    }
    Vector3 CalculatePosition()
    {
        
        var randomX = Random.Range(-screenWidth, screenWidth);
        var randomY = Random.Range(-screenHeight, screenHeight);
        var spawnPosition = new Vector3(randomX, randomY);
        // var spawnPosition = new Vector3 (playerPos.x + Random.Range(safetyDistance, screenWidth), playerPos.y + Random.Range(safetyDistance, screenHeight),0);
       
        if (!Physics.CheckSphere(spawnPosition, safetyDistance, 8)) { return spawnPosition; }
        else return CalculatePosition();

    }
}
