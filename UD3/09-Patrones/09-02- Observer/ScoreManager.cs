using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//En este ejemplo, cada vez que el jugador gane puntos habr� dos objetos que reciban
//Un mensaje y act�en en consecuencia.

//EStructura de la clase:
//1. Declaraci�n de la lista que almacenar� los observadores
//2. Implementaci�n de m�todos para a�adir y eliminar observadores de la lista.
//3. Implmementaci�n de m�todo para notificar a los observadores.
//4. Implementaci�n de m�todos con las acciones y cambios a los que deben reaccionar los observadores
//5. M�todos Start y Update para probar la clase

public class ScoreManager : MonoBehaviour
{
    //campo privado que almacena la puntuaci�n del player.
    private int score;

    //la lista observer almacena todos los objetos que est�n observando los cambios
    //en la puntuaci�n y deben reaccionar.
    //Estos objetos se caracterizan porque implementan la interfaz IScoreObserver
    //la cual define el comportamiento de los observadores cuando se produzca el cambio esperado
    private List<IScoreObserver> observers = new List<IScoreObserver>();

    // M�todo para agregar observadores a la lista
    public void AddObserver(IScoreObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    // M�todo para eliminar observadores de la lista
    public void RemoveObserver(IScoreObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // M�todo para notificar a todos los observadores
    //Cuando se invoque a este m�todo, se recorrer� la lista de observadores y para cada uno de ellos
    //se invocar� al m�todo declarado en la interfaz la cual define el comportamiento a realizar
    //cuando se produzca el cambio esperado. Todos los observadores deben implementar este m�todo para
    //responder a los cambios que queremos monitorizar.
    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnScoreChanged(score);
        }
    }

    // M�todo para incrementar la puntuaci�n
    public void AddScore(int points)
    {
        //El m�todo suma los puntos indicados a la cuenta de puntos y
        //notifica a los observadores.
        score += points;
        //Como lo que queremos es que los observadores reaccionen a la modificaci�n de los puntos
        //es en este punto en el que se notifica a los observadores del cambio que se ha producido.
        NotifyObservers(); // Notificar a los observadores del cambio
    }

    public void Start()
    {
        //A�adimos a la lista de observadores todos los objetos que implementan la interfaz IScoreManager
        AddObserver(FindAnyObjectByType<UIManager>());
        AddObserver(FindAnyObjectByType<Logger>());
    }
    public void Update()
    {
        //Cada vez que el usuario pulse espacio se suman 10 puntos.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(10);
        }
    }
}
