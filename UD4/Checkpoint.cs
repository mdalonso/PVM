using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour
{
    //El campo _addedTime permite configurar el tiempo que se amplía el juego cuando el jugador lo "coge"
    [SerializeField] int _addedTime = 10;

    
    //PROPIEDADES DE ACCESO A CAMPOS PRIVADOS
    public int AddedTime { get { return _addedTime; } set { _addedTime = value; } }

   
}
