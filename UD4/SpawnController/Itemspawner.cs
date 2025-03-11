using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Itemspawner : MonoBehaviour
{
    //Esta clase tiene el objetivo de spawnear diferen tes elementos en una posición aleatoria dentro de la escena

    //Variable que permite asociar el script con el prefab que queremos instanciar
    [SerializeField] GameObject checkPointPrefab;
    //Variable que establece cada cuánto tiempo se spawnea un checkpoint
    [SerializeField] int checkpointSpawnDelay=5;

    //Array que contiene referencias a los prefabs que representan los powerUps.
    //Los elementos del array están asignados desde el inspector.
    [SerializeField] GameObject[] powerUpPrefab;
    //Indica cada cuánto tiempo se va a spawnear un powerUp.
    [SerializeField] int powerUpSpawnDelay = 12;

    //Variable que determina el radio del área dentro
    //de la cual se genera la posición aleatoria donde se va a spawnear el item.
    [SerializeField] float spawnRadius=10.0f ;

    [SerializeField] GameStats _gameStats;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    private void Update()
    {
        //if (_gameStats.GameOver) StopAllCoroutines();
    }

    //Corrutina que se ejecuta durante todo el tiempo de juego que se encarga de spawnear los checkpoints
    IEnumerator SpawnCheckpointRoutine()
    {
        while (true) {//Durante todo el tiempo de juego...
            //...cada X segundos (definidos por checkpointSpawnDelay)...
            yield return new WaitForSeconds(checkpointSpawnDelay);
            //...Se genera una posición aleatoria en la escena dentro de un círculo con origen en el centro
            //de la escena.
            //insideUnitCircle permite generar una posición aleatoria dentro de un círculo de radio 1 con
            //centro en la posición (0,0) que es el centro de la escena.
            //Si queremos ampliar el radio de este círculo lo multiplicamos por el factor que queremos
            //Si multiplicamos por 5, ese círculo será de radio=5.
            Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * spawnRadius;
            //Instanciamos el checkpoint en la posición generada.
            //LA instanciación en una posición concreta también requiere el paso de un Quaternion. Como
            //no necesitamos una rotación específica utilizamos Quaternion.identity (0,0,0).
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);


            //**************COMUNICACIÓN MEDIANTE EVENTOS *************************
            //GameObject checkpointInstance=Instantiate(checkPointPrefab,randomPosition,Quaternion.identity);
            //Checkpoint checkpoint=checkpointInstance.GetComponent<Checkpoint>();

            //if (checkpoint != null) 
            //{
            //    checkpoint.OnCheckPointTime += GameManager.Instance.AddTime;
            //}
            //***********************************************************************




        }
    }
    //SpawnPowerUpRoutine -> Permitirá spawnear un PowerUp aleatorio en una posición aleatoria dentro de la escena.
    IEnumerator SpawnPowerUpRoutine()
    {
        //Durante todo el timpo de juego...
        while (true)
        {
            //...esperamos un tiempo en segundos determinado por la variable powerUpSpawnDelay...
            yield return new WaitForSeconds(powerUpSpawnDelay);

            //...Se genera una posición aleatoria dentro del radio especificado...
            Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * spawnRadius;
            //...Se selecciona un elemento aleatorio dentro de los array de prefabs de powerUps...
            int random = UnityEngine.Random.Range(0, powerUpPrefab.Length);
            //...se instancia el powerUp en la posición generada
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);

        }
    }
}
