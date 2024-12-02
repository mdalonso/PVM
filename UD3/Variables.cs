using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Tipos de datos nativos más utilizados en Unity
    //El conjunto de variables definidas fuera de cualquier método (en el ámbito de la clase) son las propiedades que 
    //definen el estado de los objetos que se crean a partir de la clase.

    //Se pueden inicializar los campos directamente en la definición o en un método.

    int health;
    float speed;
    string namePlayer;
    int count = 1; //Los campos se pueden inicializar en la propia declaración.
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

        //Debug.Log(nameInTime); // Esta línea da error al descomentarla porque nameInTime es local al método Update.
        
    }

    // Update is called once per frame
    void Update()
    {
        //Las variables declaradas dentro de un método son locales al método, es decir, sólo son visibles dentro del método y se utilizan
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
