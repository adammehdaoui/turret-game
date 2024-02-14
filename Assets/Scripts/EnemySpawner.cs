using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager;
    //a list that contains the differents enemies 
    public List<GameObject> EnemyPrefabs;
    public float MinSpawnTime = 0.5f;
    public float MaxSpawnTime = 1.5f;
    public float SpawnDistance = 10f;

    //create a new enemy
    public void SpawnRandomEnemy()
    {
        //choose randomly an enemy to create within EnemyPrefabs
        int enemyType = Random.Range(0,EnemyPrefabs.Count);
        //choose a random position on a 10f radius circle 
        Vector2 randomPositionInCircle = Random.insideUnitCircle;
        //create the enemy
        GameObject Enemy = Instantiate(EnemyPrefabs[enemyType], new Vector3(randomPositionInCircle.x, randomPositionInCircle.y,0f).normalized*SpawnDistance,Quaternion.identity);
        Enemy.GetComponent<EnemyLife>().gameManager = gameManager;
    }

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(WaitAndSpawnEnemy());
    }

    IEnumerator WaitAndSpawnEnemy()
    {
        //tant que la partie est en cours
        while (gameManager.isPlaying)
        {
            SpawnRandomEnemy();
            //wait a random time
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
        }
    }


}
