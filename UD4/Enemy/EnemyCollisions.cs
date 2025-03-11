using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    EnemyHealth _enemyHealth;
    // Start is called before the first frame update
    void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Es necesario comprobar que la colisi�n se produce con un proyectil ya que
        //si no se hace esta comprobaci�n, se restar� vida siempre que se produzca una
        //colisi�n independientemente de con qui�n se produzca

        //Para ello ha sido necesario asignar el Tag Bullet al prefab Bullet.
        if (collision.CompareTag("Bullet"))
        {
            //Se necesita acceder al componente Bullet del proyectil porque su comportamiento ser� diferente si se trata de un "superproyectil" o no.
            Bullet bullet = collision.GetComponent<Bullet>();
            //Si la colisi�n se produce con un proyectil, llamamos al m�todo TakeDamage para restarle vida
            _enemyHealth.TakeDamage();
            //Si no se trata de un superproyectil...
            if (!bullet.PowerShot)
            {
                //...lo destruimos
                Destroy(collision.gameObject);
            }
            else //Si se trata de un superproyectil
            {
                //...le quitamos vida a ese proyectil para permitirle seguir su recorrido
                bullet.Health--;
                if (bullet.Health <= 0)
                {
                    //Si choca con el n�mero m�ximo de enemigos permitido lo destruimos.
                    Destroy(collision.gameObject);
                }
            }

        }


    }
}
