using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] GameObject _checkPointPrefab;
    [SerializeField] int _checkPointSpawnDelay = 8;

    [SerializeField] float _spawnRadius = 10.0f;

    [SerializeField] GameObject[] _powerUpPrefab;
    [SerializeField] int _powerUpSpawnDelay = 5;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckPointCoroutine());
        StartCoroutine(SpawnPowerUpCoroutine());
    }

    IEnumerator SpawnCheckPointCoroutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(_checkPointSpawnDelay);

            Vector2 randomPosition=Random.insideUnitCircle*_spawnRadius;

            Instantiate(_checkPointPrefab,randomPosition,Quaternion.identity);

        }

    }

    IEnumerator SpawnPowerUpCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds (_powerUpSpawnDelay);

            Vector2 randomPosition=Random.insideUnitCircle*_spawnRadius;

            int random=Random.Range(0,_powerUpPrefab.Length);

            Instantiate(_powerUpPrefab[random],randomPosition,Quaternion.identity);

        }
    }
}
