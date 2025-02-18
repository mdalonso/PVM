using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
//Atributos del Enemy
    [SerializeField] int _health = 1; //vida
    [SerializeField] int _speed = 1;//velocidad del movimiento

    Transform _player;//Almacenará la posición del player

    private void Start()
    {
        //Para hacer que el enemigo se dirija hacia el player de forma automatizada
        //necesitamos conocer en todo momento la ubicación del player para
        //definir un vector direccional entre su posición y la posición del Enemigo
        //Este vector definirá el movimiento del enemigo.
        //Necesitamos conocer la posición del enemigo desde el principio, por eso lo
        //incluimos en el método Start
        //_player=FindObjectOfType<Player>().transform;//Localizar un objeto con FindOBjectOfType
        _player = GameObject.Find("Player").GetComponent<Transform>();//Localizar un objeto con GameOBject.Find

        
    }


    private void Update()
    {
        //movimiento automático del Enemy hacia el Player.
        MoveToPlayer();
    }
    //REduce la vida del enemigo en 1 unidad.
    void TakeDamage()
    {
        _health --;
        //Reto 2: Destruir el enemigo cuando se agota su vida
        if (_health <= 0) {
            Die();
            
        }
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
    //Este método define el movimiento automático del Enemigo en dirección al Player.
    private void MoveToPlayer()
    {

        //Obtenemos el vector de dirección (destino - origen, si no se moverá en dirección contraria)
        Vector2 direction = _player.position - transform.position;

        //Aplicamos el vector de dirección a la posición del Enemy
        //Hay que hacer Casting porque el vector de dirección se ha definido como un Vector2 y necesitamos
        //un Vector3
        transform.position += (Vector3)direction * Time.deltaTime * _speed;
    }

    private void Die()
    {
        Debug.Log("Enemigo destruido");
        Destroy(gameObject);
    }
}

