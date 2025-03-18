using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewGameStats",menuName="Settings/Stats")]

public class GameStats : ScriptableObject
{
    [SerializeField] int _initialTime = 30;
    [SerializeField] int _initialScore = 0;
    

    public int time = 30;
    [Range(1,10)] public int difficulty =1;

    [SerializeField] int _score = 0;//Acumula los puntos del player
    [SerializeField] int _scorePoints = 100;

    public int Score { get => _score; set => _score = value; }
    public int ScorePoints { get => _scorePoints; set => _scorePoints = value; }

    public void ResetState()
    {
        time=_initialTime;
        Score = _initialScore;
    }

}
