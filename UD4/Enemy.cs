using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int _health = 1;
    Transform _player;

    private void Start()
    {

        _player=FindObjectOfType<Player>().transform;
    }


    private void Update()
    {
        Vector2 direction = _player.position - transform.position;


        transform.position += (Vector3)direction * Time.deltaTime;
    }
    //REduce la vida del enemigo en 1 unidad.
    public void TakeDamage()
    {
        _health --;
    }

    //Manejo de la colisión entre el proyectil y el enemigo desde el enemigo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Es necesario comprobar que la colisión se produce con un proyectil ya que
        //si no se hace esta comprobación, se restará vida siempre que se produzca una
        //colisión independientemente de con quién se produzca

        //Para ello ha sido necesario asignar el Tag Bullet al prefab Bullet.
        if (collision.CompareTag("Bullet"))
        {
            //Si la colisión se produce con un proyectil, llamamos al método TakeDamage para restarle vida
            TakeDamage();
            //Y destruimos el proyectil
            Destroy(collision.gameObject);

        }

    }
}
