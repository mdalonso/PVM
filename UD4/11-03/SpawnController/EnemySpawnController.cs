using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [Range(1, 10)][SerializeField] float _spawnRate =1.0f;
    [SerializeField] GameObject[] enemyPrefab;

    GameObject[] _spawnPoints;
    [SerializeField] GameStats _gameStats;
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        StartCoroutine(SpawnNewEnemy());

        //GameManager.Instance.Difficulty
    }

   
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _spawnRate);

            int randomSpawnPoint=Random.Range(0,_spawnPoints.Length);

            float random=Random.Range(0.0f,1.0f);

             

            if (random < _gameStats.difficulty*0.1)
            {
                Instantiate(enemyPrefab[1], _spawnPoints[randomSpawnPoint].transform.position,Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab[0], _spawnPoints[randomSpawnPoint].transform.position,Quaternion.identity);
            }


        }
    }
}
