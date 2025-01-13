
using UnityEngine;

//Este script simula la actualización de la puntuación en un objeto gráfico en pantalla.
public class UIManager : MonoBehaviour, IScoreObserver
{
    
    // Método llamado cuando cambia la puntuación
    public void OnScoreChanged(int newScore)
    {
        Debug.Log("IU Manager Score: " + newScore);
    }
}
