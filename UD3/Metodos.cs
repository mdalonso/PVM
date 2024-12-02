using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metodos : MonoBehaviour
{
    //Tipos de datos nativos más utilizados en Unity
    //Las variables podemos inicializarlas en la declaración o bien en un método.
    int health;
    float speed;
    string namePlayer;
    int count = 1;
    bool damage;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        speed = 10.5f;
        namePlayer = "Jugador";
        damage = false;
        

    }

    //El método MoveForwart simula el movimiento hacia adelante. Lo invocaremos en el Update.
    void MoveForward()
    {
        Debug.Log("Player's moving forward");
    }
    void MoveBackward()
    {
        Debug.Log("Player's moving backward");
    }
    void MoveLeftward()
    {
        Debug.Log("Jugador se mueve a la izquierda");
    }
    void MoveRightward()
    {
        Debug.Log("El jugador se mueve a la derecha");
    }

    void IncreaseCounter()
    {
        //nameInTime contiene un nombre de jugador que depende de un contador que se incrementa en cada frame
        string nameInTime;

        count++;
        nameInTime = namePlayer + " " + count;
        Debug.Log(nameInTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeftward();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRightward();
        }

        health++;
        speed++;

        //Para invocar a un método basta con indicar su nombre.
        IncreaseCounter();

       

       Debug.Log(health + " " + speed);

    }
}
