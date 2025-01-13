using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    // Lista de enemigos activos en la escena
    private List<GameObject> enemigos = new List<GameObject>();
    //N�mero m�ximo de enemigos que puede haber en el juego
    private int _maxEnemies = 10;
    //N�mero de enemigos creados hasta el momento.
    private static int _nEnemy = 0;

    // M�todo para agregar un enemigo a la lista
    public void AgregarEnemigo(GameObject enemigo)
    {
        if (_nEnemy < _maxEnemies)
        {

            if (enemigo != null && !enemigos.Contains(enemigo))
            {
                enemigos.Add(enemigo);  // Agrega el enemigo a la lista
                _nEnemy++;
                Debug.Log($"Enemigo {enemigo.name} agregado a la lista.");
            }
        }
        else
        {
            Debug.Log("Se ha alcanzado el n�mero m�ximo de enemigos");
        }
    }

    // M�todo para eliminar un enemigo de la lista
    public void EliminarEnemigo(GameObject enemigo)
    {
        if (enemigos.Contains(enemigo))
        {
            enemigos.Remove(enemigo);  // Elimina el enemigo de la lista
            Debug.Log($"Enemigo {enemigo.name} eliminado de la lista.");
            _nEnemy--;
        }
    }

    // M�todo para actualizar todos los enemigos
    private void ActualizarEnemigos()
    {
        foreach (var enemigo in enemigos)
        {
            if (enemigo != null)
            {
                // L�gica de actualizaci�n de cada enemigo
                // Aqu� puedes hacer que cada enemigo realice una acci�n o comportamiento
                Debug.Log($"Actualizaci�n del enemigo");
            }
        }
    }


    private void Start()
    {
        
        AgregarEnemigo(new GameObject("Goblin"));
        AgregarEnemigo(new GameObject("Orco"));
    }
    // M�todo de Unity que se llama una vez por frame

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (enemigos.Count > 0)
            {
                string noumEnemy = enemigos[enemigos.Count - 1].name;
                EliminarEnemigo(enemigos[enemigos.Count - 1]);
            }
            else Debug.Log("Lista de enemigos vac�a");
            
        } 
        if (Input.GetKeyDown(KeyCode.U))
        {
            ActualizarEnemigos();  // Llamar al m�todo que actualiza los enemigos
            
        } 
        if (Input.GetKeyDown(KeyCode.A))
        {
            AgregarEnemigo(new GameObject("Enemigo"+(_nEnemy+1)));  // Llamar al m�todo que actualiza los enemigos
            
        }

    }

}
