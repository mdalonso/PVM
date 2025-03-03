using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [Range(1, 10)][SerializeField] float _spawnRate =1.0f;
    [SerializeField] GameObject enemyPrefab;

    GameObject[] _spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        StartCoroutine(SpawnNewEnemy());
    }

   
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _spawnRate);

            int randomSpawnPoint=Random.Range(0,_spawnPoints.Length);

            Instantiate(enemyPrefab, _spawnPoints[randomSpawnPoint].transform.position,Quaternion.identity);

        }
    }
}
