using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewGameStats",menuName="Settings/Stats")]

public class GameStats : ScriptableObject
{
    [SerializeField] int _initialTime = 30;
    [SerializeField] int _initialScore = 0;
    

    [SerializeField] int _time = 30;
    [Range(1,10)] public int difficulty =1;

    [SerializeField] int _score = 0;//Acumula los puntos del player
    [SerializeField] int _scorePoints = 100;

    public int Score { get => _score; 
        set
        {
            _score = value;
            //Actualización del HUD
            UIManager.Instance.UpdateUIScore(value);
        }
    }
    public int ScorePoints { get => _scorePoints; set => _scorePoints = value; }
    public int Time { get => _time; 
        set {
            _time = value; 
            //Actualizamos el HUD
            UIManager.Instance.UpdateUITime(value);
        }
    }

    public void ResetState()
    {
        Time=_initialTime;
        Score = _initialScore;
    }

}
