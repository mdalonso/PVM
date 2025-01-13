
using UnityEngine;
//Este script simula la actualizaci�n de la puntuaci�n en un archivo de estad�sticas.
public class Logger : MonoBehaviour, IScoreObserver
{
    public void OnScoreChanged(int newScore)
    {
        Debug.Log("Logger New Score: " + newScore);
    }
}
