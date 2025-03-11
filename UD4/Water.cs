using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //El campo _speedPenalty define la penalización que se aplicará sobre la velocidad del player
    //cuando éste se esté desplazando dentro del agua.
    [SerializeField] float _speedPenalty = 0.5f;

    // Start is called before the first frame update
   public float SpeedPenalty { get { return _speedPenalty; } set { _speedPenalty = value; } }

    //Estos campos sirven para gestionar el efecto del agua sobre la velocidad del player
    //sin utilizar eventos

   //PlayerMovement _player;
   //float originalSpeed;


    /***
     * Ejemplo de comunicación mediane eventos. **/
    //Definimos dos eventos que se dispararán bajo determinadas circunstancias
    //El método de respuesta a este evento requiere de un parámetro float (penalización sobre la velocidad del player)
    public event Action<float> OnWater;//Se disparará cuando el player entre en el agua
    public event Action<float> OnGround;//Se disparará cuando el player salga del agua

    private void Start()
    {
        //MANEJO DE LA INTERACCIÓN ENTRE EL PLAYER Y EL AGUA SIN UTILIZAR EVENTOS
        //como se puede cmprobar, si no utilizamos eventos, aquí necesitamos conocer tanto la velocidad del player
        //y almacenar tanto la velocidad original como acceder a la velocidad actual para modificarla.
        //Si utilizamos eventos como alternativa ninguna de las dos clases necesita conocer detalles internos
        //de la implementación de la clase salvo los eventos propiamente dichos para la suscripción a los mismos
        //por parte del player.

        //Guardamos la referencia al player en el Start para no tener que  volver a buscar el objeto.
        //Si realizaramos la búsqueda en los eventos que gestionan la colisión, se tendría que buscar
        //el player cada vez que se produce la colisión con el agua, que puede ser muchas veces, disminuyendo el rendimiento.
        //_player = FindObjectOfType<PlayerMovement>();
        //originalSpeed=_player.Speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //** si el player entra en el agua invocamos al evento para que se disparen
            //la respuesta en los sucriptores */
            //(el signo de interrogación permite comprobar si el evento está declarado, en cuyo caso se invocará.
            //Si no lo está, no se realizará la invocación.
            OnWater?.Invoke(_speedPenalty);

            //Esta línea sirve para aplicar la penalización sobre la velocidad del player sin usar eventos.
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
            //Esta línea sirve para deshacer la penalización sobre la velocidad del player sin usar eventos.
            // _player.Speed = originalSpeed;
        }
    }
}
