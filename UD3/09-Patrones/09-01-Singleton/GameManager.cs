using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia única del Singleton.
    // Esta variable estática es de tipo GameManager.
    //Es una propiedad pública que creará automáticamente un campo private asociado.
    public static GameManager Instance { get; private set; }

    // Variable para almacenar un contador global
    public int globalCounter = 0;

    //Awake se ejecuta cada vez que el objeto al que pertenece el script es instanciado o activado en la escena.
    //Se ejecuta antes de Start. Start se ejecuta antes del primer frame..
    private void Awake()
    {
        // Si ya existe una instancia, destruir el nuevo objeto
        //Si instance != this es porque hay otra instancia de la clase GameManager.
        if (Instance != null && Instance != this)
        {
            //en el caso de que ya exista una instancia, el GameObject se destruye y terminamos la ejecución de Awake.
            //this.gameObject es el GameObject al que está asociado el script en ejecución.
            Destroy(gameObject);
            return;
        }

        // Asignar esta instancia y asegurarse de que no se destruya al cambiar de escena
        //Si no existe una instancia previa, la instancia será this, es decir, la instancia ejecutándose actualmente.
        Instance = this;
        //El método DontDestroyOnLoad evita que el gameobject se destruya al cambiar de escena,
        //que es el comportamiento habitual en Unity
        //Esto crea un nuevo grupo de objetos en la escena que permite desvincular el GameManager de la escena que se muestra
        DontDestroyOnLoad(gameObject);
    }

    // Método para incrementar el contador
    public void IncrementCounter()
    {
        globalCounter++;
        Debug.Log("Contador global: " + globalCounter);
    }
}
