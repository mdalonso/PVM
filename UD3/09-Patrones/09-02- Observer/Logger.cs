
using UnityEngine;
//Este script simula la actualización de la puntuación en un archivo de estadísticas.
public class Logger : MonoBehaviour, IScoreObserver
{
    public void OnScoreChanged(int newScore)
    {
        Debug.Log("Logger New Score: " + newScore);
    }
}
