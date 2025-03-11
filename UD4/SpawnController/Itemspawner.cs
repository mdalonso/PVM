using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Itemspawner : MonoBehaviour
{
    //Esta clase tiene el objetivo de spawnear diferen tes elementos en una posici�n aleatoria dentro de la escena

    //Variable que permite asociar el script con el prefab que queremos instanciar
    [SerializeField] GameObject checkPointPrefab;
    //Variable que establece cada cu�nto tiempo se spawnea un checkpoint
    [SerializeField] int checkpointSpawnDelay=5;

    //Array que contiene referencias a los prefabs que representan los powerUps.
    //Los elementos del array est�n asignados desde el inspector.
    [SerializeField] GameObject[] powerUpPrefab;
    //Indica cada cu�nto tiempo se va a spawnear un powerUp.
    [SerializeField] int powerUpSpawnDelay = 12;

    //Variable que determina el radio del �rea dentro
    //de la cual se genera la posici�n aleatoria donde se va a spawnear el item.
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
            //...Se genera una posici�n aleatoria en la escena dentro de un c�rculo con origen en el centro
            //de la escena.
            //insideUnitCircle permite generar una posici�n aleatoria dentro de un c�rculo de radio 1 con
            //centro en la posici�n (0,0) que es el centro de la escena.
            //Si queremos ampliar el radio de este c�rculo lo multiplicamos por el factor que queremos
            //Si multiplicamos por 5, ese c�rculo ser� de radio=5.
            Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * spawnRadius;
            //Instanciamos el checkpoint en la posici�n generada.
            //LA instanciaci�n en una posici�n concreta tambi�n requiere el paso de un Quaternion. Como
            //no necesitamos una rotaci�n espec�fica utilizamos Quaternion.identity (0,0,0).
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);


            //**************COMUNICACI�N MEDIANTE EVENTOS *************************
            //GameObject checkpointInstance=Instantiate(checkPointPrefab,randomPosition,Quaternion.identity);
            //Checkpoint checkpoint=checkpointInstance.GetComponent<Checkpoint>();

            //if (checkpoint != null) 
            //{
            //    checkpoint.OnCheckPointTime += GameManager.Instance.AddTime;
            //}
            //***********************************************************************




        }
    }
    //SpawnPowerUpRoutine -> Permitir� spawnear un PowerUp aleatorio en una posici�n aleatoria dentro de la escena.
    IEnumerator SpawnPowerUpRoutine()
    {
        //Durante todo el timpo de juego...
        while (true)
        {
            //...esperamos un tiempo en segundos determinado por la variable powerUpSpawnDelay...
            yield return new WaitForSeconds(powerUpSpawnDelay);

            //...Se genera una posici�n aleatoria dentro del radio especificado...
            Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * spawnRadius;
            //...Se selecciona un elemento aleatorio dentro de los array de prefabs de powerUps...
            int random = UnityEngine.Random.Range(0, powerUpPrefab.Length);
            //...se instancia el powerUp en la posici�n generada
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);

        }
    }
}
