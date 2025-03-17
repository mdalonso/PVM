using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewGameStats",menuName="Settings/Stats")]

public class GameStats : ScriptableObject
{
    [SerializeField] int _initialTime = 30;
    

    public int time = 30;
    [Range(1,10)] public int difficulty =1;

    public void ResetState()
    {
        time=_initialTime;
    }

}
