using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField, Tooltip("Vida del enemigo")] int _health = 1; //vida


    [SerializeField] GameStats _gameStats;

    public void TakeDamage()
    {

        _health--;
        //Reto 2: Destruir el enemigo cuando se agota su vida
        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo destruido");
        //UTILIZANDO SCRIPTABLE OBJECTS EN EL GAME MANAGER*********************
        _gameStats.Score += _gameStats.ScorePoints;
        //UTILIZANDO SINGLETON EN EL GAME MANAGER ******************
        //GameManager.Instance.Score += GameManager.Instance.ScorePoints;

        Destroy(gameObject);
    }
}
