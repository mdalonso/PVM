using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  //La enumeraci�n PowerUpType define los distintos tipos de PowerUp que vamos a implementar.
  //el uso de una estructura de este tipo permite extender f�cilmente la funcionalidad solamente
  //incluyendo nuevos elementos en la enumeraci�n y creando nuevos prefabs por duplicaci�n de los
  //ya existentes
   public enum PowerUpType
    {
        FireRateIncrease,//Aumento de la cadencia de disparo
        PowerShot//Proyectil potente
    }

    //Esta variable nos va a permitir acceder a los elementos de la enumeraci�n.
    public PowerUpType powerUpType;




}
