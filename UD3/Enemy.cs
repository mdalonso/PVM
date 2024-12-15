using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IInteractable
{

    //Propiedad pública con el número de proyectiles del enemigo
    public int bulletCount = 100;

    //El campo estático nEnemies almacenará el número de instancias de la clase Enemy.
    //Nos servirá para controlar que no se creen más del número máximo de enemigos.
    public static int nEnemies = 0;


    public Enemy(string name, int health, int speed, int level, int nBullet)
       : base(name, health, speed, level)
    {
        this.bulletCount = nBullet;

        //CLASES ESTÁTICAS: Cada vez que creamos un enemigo se incrementa para tener constancia de cuántos enemigos se han creado.
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

    
    public void Interact()
    {
        Debug.Log("Enemigo interactuando");
    }

}
