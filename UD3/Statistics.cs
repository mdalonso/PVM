using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statistics
{


    //Indica el máximo de enemigos que se pueden crear en el juego
    private static int _maxEnemies=10;

    //Creamos una lista que contendrá todas las instancias de Enemigos.
    public static List<Enemy> enemies = new List<Enemy>();

    

    public static int MaxEnemies
    {
        get { return _maxEnemies; }
        set { _maxEnemies = Mathf.Max(0, value); }
    }
}
