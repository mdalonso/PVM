
using UnityEngine;

//Este script simula la actualizaci�n de la puntuaci�n en un objeto gr�fico en pantalla.
public class UIManager : MonoBehaviour, IScoreObserver
{
    
    // M�todo llamado cuando cambia la puntuaci�n
    public void OnScoreChanged(int newScore)
    {
        Debug.Log("IU Manager Score: " + newScore);
    }
}
