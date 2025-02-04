using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    public static ObserverManager Instance { get; private set; }

   //Lista que mantendrá la lista de observadores.
    private List<IObserver> observers = new List<IObserver>();


    //Métodos para la suscripción a esta lista
    public void AddObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyAttackEvent()
    {
        foreach (var observer in observers){
           
            if (observer is EnemyR4)
            {
                observer.OnAttack();
            }
        }
    }

    public void NotifyLevelUpEvent()
    {
        foreach (var observer in observers)
        {
            if (observer is PlayerR4)
            {
                observer.OnLevelUp();
            }
        }
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    //Cuando el objeto ObserverManager se destruya, la instancia debe ser null.
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
