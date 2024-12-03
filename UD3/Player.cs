using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : Character//, IInteractable
{
    public int strength = 8;

   

    public Player(string name, int health, int speed, int level, int strength)
        : base(name, health, speed, level)
    {
        this.strength = strength;
    }

   

    //Se redefine el mensaje ShowMessage para los objetos creados a partir de la clase Player.
    public override void ShowMessage()
    {
        Debug.Log("++++++++++++++++++ Informe de Player +++++++++++++++++++++++++++");
        //El campo health est� definido como private, por tanto no podemos acceder directamente a este campo
        //Debug.Log(this.health); //Esta l�nea dar� un error porque health est� definida como private en la clase base
        Debug.Log("Mi nombre es: " + this.playerName);
        Debug.Log("Mi vida es: " + this.Health);
        Debug.Log("Mi velocidad es: " + this.speed);
        //Como _level es PROTECTED s� es acceible desde la clase derivada
        Debug.Log("Mi puntuaci�n es: " + this._level);
        Debug.Log("Mi fuerza es: " + this.strength);
        Debug.Log("++++++++++++++++++ FIN DE INFORME DE PLAYER +++++++++++++++++++++++++++");


    }
    //Se define el m�todo st�tico AddScore que permite a�adir los puntos especificados al campo score.
   

    //public void Interact()
    //{
    //    Debug.Log("Jugador interactuando");
    //}


}
