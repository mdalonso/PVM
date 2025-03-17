using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int _addedTime = 10;

    public int AddedTime { get => _addedTime; set => _addedTime = value; }

    [SerializeField] GameStats _gameStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.Instance.Time += _addedTime;//Singleton
            _gameStats.time += _addedTime;//Scriptable object
            Destroy(gameObject,0.1f);
        }
    }
 

}
