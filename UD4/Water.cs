using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //El campo _speedPenalty define la penalizaci�n que se aplicar� sobre la velocidad del player
    //cuando �ste se est� desplazando dentro del agua.
    [SerializeField] float _speedPenalty = 0.5f;

    // Start is called before the first frame update
   public float SpeedPenalty { get { return _speedPenalty; } set { _speedPenalty = value; } }

    //Estos campos sirven para gestionar el efecto del agua sobre la velocidad del player
    //sin utilizar eventos

   //PlayerMovement _player;
   //float originalSpeed;


    /***
     * Ejemplo de comunicaci�n mediane eventos. **/
    //Definimos dos eventos que se disparar�n bajo determinadas circunstancias
    //El m�todo de respuesta a este evento requiere de un par�metro float (penalizaci�n sobre la velocidad del player)
    public event Action<float> OnWater;//Se disparar� cuando el player entre en el agua
    public event Action<float> OnGround;//Se disparar� cuando el player salga del agua

    private void Start()
    {
        //MANEJO DE LA INTERACCI�N ENTRE EL PLAYER Y EL AGUA SIN UTILIZAR EVENTOS
        //como se puede cmprobar, si no utilizamos eventos, aqu� necesitamos conocer tanto la velocidad del player
        //y almacenar tanto la velocidad original como acceder a la velocidad actual para modificarla.
        //Si utilizamos eventos como alternativa ninguna de las dos clases necesita conocer detalles internos
        //de la implementaci�n de la clase salvo los eventos propiamente dichos para la suscripci�n a los mismos
        //por parte del player.

        //Guardamos la referencia al player en el Start para no tener que  volver a buscar el objeto.
        //Si realizaramos la b�squeda en los eventos que gestionan la colisi�n, se tendr�a que buscar
        //el player cada vez que se produce la colisi�n con el agua, que puede ser muchas veces, disminuyendo el rendimiento.
        //_player = FindObjectOfType<PlayerMovement>();
        //originalSpeed=_player.Speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //** si el player entra en el agua invocamos al evento para que se disparen
            //la respuesta en los sucriptores */
            //(el signo de interrogaci�n permite comprobar si el evento est� declarado, en cuyo caso se invocar�.
            //Si no lo est�, no se realizar� la invocaci�n.
            OnWater?.Invoke(_speedPenalty);

            //Esta l�nea sirve para aplicar la penalizaci�n sobre la velocidad del player sin usar eventos.
            //_player.Speed *= _speedPenalty;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //** si el player sale del agua invocamos al evento correspondiente para que se disparen
        //la respuesta en el player como suscriptor.
        if (collision.CompareTag("Player"))
        {
            OnGround?.Invoke(_speedPenalty);
            //Esta l�nea sirve para deshacer la penalizaci�n sobre la velocidad del player sin usar eventos.
            // _player.Speed = originalSpeed;
        }
    }
}
