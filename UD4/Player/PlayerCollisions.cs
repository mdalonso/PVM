using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour
{
    //Estas variables nos van a permitir mantener referencias a los componentes del Player a los que necesitamos acceder
    PlayerHealth _playerHealth;
    PlayerShooting _playerShooting;
    PlayerMovement _playerMovement;

    //IMPLEMENTACI�N DE GAMEMANAGER CON SCRIPTABLE OBJECTS
    [SerializeField] GameStats _gameStats;

    //COMUNICACI�N MEDIANTE EVENTOS +++++++++++++++++
    //public event Action<int> OnCheckPointTime;
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // Start is called before the first frame update
    void Awake()
    {
        //Cuando se necesita acceder a un componente del mismo object de forma reiterada
        //lo m�s eficiente es mantener referencias a ellos que ser�n inicializadas en el Awake()�

        //Se hace en el Awake porque los componentes pertenecen al mismo gameObject.
        _playerHealth = GetComponent<PlayerHealth>();
        _playerShooting=GetComponent<PlayerShooting>();
        _playerMovement = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _playerHealth.TakeDamage();
        }

        //Cuando se produzca una colisi�n con un objeto Player...
        if (collision.CompareTag("CheckPoint"))
        {
            //COMUNICACI�N MEDIANTE EVENTOS ++++++++++++++++++++++++++
            //OnCheckPointTime.Invoke(collision.gameObject.GetComponent<Checkpoint>().AddedTime);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Se a�ade el tiempo y se destruye el checkPoint
            //UTTILIZANDO SINGLETON EN GAME MANAGER*****************
            //GameManager.Instance.Time += collision.gameObject.GetComponent<Checkpoint>().AddedTime;
            //*************************************************

            //UTTILIZANDO SCRIPTABLE OBJECTS EN GAME MANAGER*****************
            _gameStats.Time += collision.gameObject.GetComponent<Checkpoint>().AddedTime;
            //*************************************************
            Destroy(collision.gameObject, 0.2f);
        }

        if (collision.CompareTag("PowerUp")) 
        {
            switch (collision.GetComponent<PowerUp>().powerUpType)
            {
                //Accedo a los tipos de powerUp definidos en el enum para comprobar a qu� tipo concreto
                //pertenece el powerUp con el que se ha colisionado.
                case PowerUp.PowerUpType.FireRateIncrease:
                    //Si se trata de un FireRateIncrease, se incrementa el FireRate del Player.
                    _playerShooting.FireRate++;
                    break;
                case PowerUp.PowerUpType.PowerShot:
                    //Si se trata de un PowerShot Tenemos que indicarselo al componente encargado de instanciar los proyectiles
                    //para poder implementar la l�gica asociada.
                    _playerShooting.PowerShotEnabled = true;
                    break;
            }
            //Una vez recogido el PowerUp, se destruye.
            Destroy(collision.gameObject, 0.2f);
        }

        

    }

   

  

}
