using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  //La enumeración PowerUpType define los distintos tipos de PowerUp que vamos a implementar.
  //el uso de una estructura de este tipo permite extender fácilmente la funcionalidad solamente
  //incluyendo nuevos elementos en la enumeración y creando nuevos prefabs por duplicación de los
  //ya existentes
   public enum PowerUpType
    {
        FireRateIncrease,//Aumento de la cadencia de disparo
        PowerShot//Proyectil potente
    }

    //Esta variable nos va a permitir acceder a los elementos de la enumeración.
    public PowerUpType powerUpType;




}
