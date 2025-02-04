using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //_speed es un campo privado quue est� serializado para que aparezca en el inspector
    [SerializeField] float _speed = 5;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Start()
    {
        //Para que los proyectiles no existan eternamete en el caso de que no hagan blanco
        //los destruiremos a los 5 segundos en caso de que no hayan acertado a ning�n enemigo.
        Destroy(gameObject,5);
    }
    // Update is called once per frame
    void Update()
    {
        //Movimiento del proyectil
        //transform.right es un vector unitario (longitud 1) hacia la derech. Representa esa direcci�n.
        //tenemos vectores unitarios que definen las 3 direcciones en el espacio:

       //Con esta l�nea de c�digo aseguramos que el proyectil se mueva siempre hacia una direcci�n concreta
       //que en este caso es hacia la derecha.
       //(para gestionar el disparo en distintas direcciones aprovecharemos el momento de su instanciaci�n)
        transform.position += transform.right*_speed*Time.deltaTime;

        
    }

    //Manejo de la colisi�n entre el proyectil y el enemigo desde el proyectil
    //OnTriggerEnter2D es un evento que se dispara cuando dos colliders entran en contacto.
    //collision: Guarda el componente Collider2D del objeto con el que colisionar� Bullet (ser� un Enemy)
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
            
        //La acci�n s�lo se realizar� si el objto con el que se colisiona es un Enemy
        //Para ello se utilizar� el Tag del Enemy (se ha debido de asignar el Tag previamente en tiempo de dise�o)
        //Si no se hiciera esta comprobaci�n, se restar�a vida al enemigo cuando el bullet colisionara con cualquier objeto
        if (collision.CompareTag("Enemy"))
        {
            //En caso de que efectivamente se haya colisionado con un Enemigo, se ejecutar� el m�todo TakeDamage definidoo en el Enemy
            //collision contiene una referencia implicita al GameObject al cual est� asociado el Collider.
            //(Tambi�n se puede acceder de forma expl�cita a este GameObject mediante collision.gameObject.)

            //Para ell utiliamos GetComponent. ESta sentencia busca un componente de tipo Enemy (que es un script), asociado
            //al gameObject del collider y llama a TakeDamage que es un m�todo p�blico definido en ese script.
            collision.GetComponent<Enemy>().TakeDamage();
            //Destru�mos el proyectil.
            //gameObject es el GameObject al cual est� asociado este script.
            Destroy(gameObject);

        }

    }*/
}
