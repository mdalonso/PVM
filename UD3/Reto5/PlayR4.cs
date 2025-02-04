using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayR4 : MonoBehaviour
{
    PlayerR4 jugador;
    EnemyR4 enemigo;
    // Start is called before the first frame update
    void Start()
    {
        jugador = new PlayerR4("Jugador", 10, 0);
        //Se añade el jugador a la lista de observadores
        ObserverManager.Instance.AddObserver(jugador);

        enemigo = new EnemyR4("Enemigo", 20, 1);
        //Se añade el enemigo a la lista de observadores
        ObserverManager.Instance.AddObserver(enemigo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Atacando al enemigo");
            ObserverManager.Instance.NotifyAttackEvent();
            jugador.Attack(enemigo);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Enemigo Regenerándose");
            enemigo.Health += 10;
        }

    }
}
