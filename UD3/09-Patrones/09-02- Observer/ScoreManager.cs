using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//En este ejemplo, cada vez que el jugador gane puntos habrá dos objetos que reciban
//Un mensaje y actúen en consecuencia.

//EStructura de la clase:
//1. Declaración de la lista que almacenará los observadores
//2. Implementación de métodos para añadir y eliminar observadores de la lista.
//3. Implmementación de método para notificar a los observadores.
//4. Implementación de métodos con las acciones y cambios a los que deben reaccionar los observadores
//5. Métodos Start y Update para probar la clase

public class ScoreManager : MonoBehaviour
{
    //campo privado que almacena la puntuación del player.
    private int score;

    //la lista observer almacena todos los objetos que están observando los cambios
    //en la puntuación y deben reaccionar.
    //Estos objetos se caracterizan porque implementan la interfaz IScoreObserver
    //la cual define el comportamiento de los observadores cuando se produzca el cambio esperado
    private List<IScoreObserver> observers = new List<IScoreObserver>();

    // Método para agregar observadores a la lista
    public void AddObserver(IScoreObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    // Método para eliminar observadores de la lista
    public void RemoveObserver(IScoreObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // Método para notificar a todos los observadores
    //Cuando se invoque a este método, se recorrerá la lista de observadores y para cada uno de ellos
    //se invocará al método declarado en la interfaz la cual define el comportamiento a realizar
    //cuando se produzca el cambio esperado. Todos los observadores deben implementar este método para
    //responder a los cambios que queremos monitorizar.
    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnScoreChanged(score);
        }
    }

    // Método para incrementar la puntuación
    public void AddScore(int points)
    {
        //El método suma los puntos indicados a la cuenta de puntos y
        //notifica a los observadores.
        score += points;
        //Como lo que queremos es que los observadores reaccionen a la modificación de los puntos
        //es en este punto en el que se notifica a los observadores del cambio que se ha producido.
        NotifyObservers(); // Notificar a los observadores del cambio
    }

    public void Start()
    {
        //Añadimos a la lista de observadores todos los objetos que implementan la interfaz IScoreManager
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
