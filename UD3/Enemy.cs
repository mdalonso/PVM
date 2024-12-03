using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character//, IInteractable
{

    //Propiedad p�blica con el n�mero de proyectiles del enemigo
    public int bulletCount = 100;

    //El campo est�tico nEnemies almacenar� el n�mero de instancias de la clase Enemy.
    //Nos servir� para controlar que no se creen m�s del n�mero m�ximo de enemigos.
    public static int nEnemies = 0;


    public Enemy(string name, int health, int speed, int level, int nBullet)
       : base(name, health, speed, level)
    {
        this.bulletCount = nBullet;

        //CLASES EST�TICAS: Cada vez que creamos un enemigo se incrementa para tener constancia de cu�ntos enemigos se han creado.
        nEnemies++;

    }

    public void Shoot()
    {
        bulletCount--;
        if (bulletCount <= 0)
        {
            Debug.Log("No ammunition");
        }
    }

    
    //public void Interact()
    //{
    //    Debug.Log("Enemigo interactuando");
    //}

}
