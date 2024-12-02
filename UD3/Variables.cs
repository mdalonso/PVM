using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Tipos de datos nativos m�s utilizados en Unity
    //El conjunto de variables definidas fuera de cualquier m�todo (en el �mbito de la clase) son las propiedades que 
    //definen el estado de los objetos que se crean a partir de la clase.

    //Se pueden inicializar los campos directamente en la definici�n o en un m�todo.

    int health;
    float speed;
    string namePlayer;
    int count = 1; //Los campos se pueden inicializar en la propia declaraci�n.
    bool damage;
    char confirm;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        //Cuando asignamos valor a una variable de tipo float es necesario poner la f.
        speed = 10.5f;
        namePlayer = "Jugador"; //Cadenas se encierran entre comillas dobles
        damage = false;
        confirm = 'y';//Caracter se encierra entre comillas simples.

        //Debug.Log(nameInTime); // Esta l�nea da error al descomentarla porque nameInTime es local al m�todo Update.
        
    }

    // Update is called once per frame
    void Update()
    {
        //Las variables declaradas dentro de un m�todo son locales al m�todo, es decir, s�lo son visibles dentro del m�todo y se utilizan
        //en tareas de procesamiento.
        string nameInTime;

        health++;
        speed++;
        count++;
        nameInTime = namePlayer+" "+ count;

        Debug.Log(nameInTime);
        Debug.Log(health+" "+speed);

    }
}
