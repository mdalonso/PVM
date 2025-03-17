using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton

    [SerializeField] int _time = 30;
    [Range(1,10)] [SerializeField] int _difficulty = 1;

    public int Time { get => _time; set => _time = value; }
    public int Difficulty { get => _difficulty; set => _difficulty = value; }

    
    
    //Implementación del Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(CountDownRoutine());
        
    }
 

    IEnumerator CountDownRoutine()
    {
        while (_time > 0) 
        {
            yield return new WaitForSeconds(1);
            _time--;
        }
        Debug.Log("Game over");
    }
}
