using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    float h,v;//eje de movimiento horizonal y vertical
    //Definimos el vector moveDirection como un Vector3 a pesar de estar en un mundo 2D porque 
    //las operaciones que realizaremos posteriormente con �l para mover al player requieren que sea
    //de este tipo. �Por qu�? Porque la propiedad position del componente transform
    //del player viene definido impl�citamente com un vector3D (como
    //en cualquier GameObject). Tambi�n podemos definirlo como un Vector2D y luego hacer un casting.
    Vector3 moveDirection;//Vector que determina la direcci�n del movimiento.
    Vector2 moveDirection2D;
    [SerializeField] float _speed=5; //[SerializedField] Permite serializar una variable sin tener que hacerla p�blica

    [SerializeField] Transform aim;//enlazamos una referencia a aim desde el inspector, por eso lo serializamos
   // [SerializeField] Camera camera;

    //El vector facingDirection es el vector trazado entre la posici�n del player y la mira
    Vector2 facingDirection;//Direccii�n hacia donde apunta la mira

    //LA variable bulletPrefab permite asociar el prefab correspondiente al proyectil
    //con la clase player, que debe instanciarlo.
    [SerializeField] Transform bulletPrefab;

    bool gunLoaded = true;

    [SerializeField] int fireRate = 5;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //MovePlayerGetKey(); //Gesti�n del movimiento con la pulsaci�n de teclas
        MovePlayerAxis();//Gesti�n del movimiento

        Aiming();//M�todo que permite mover la mira para apuntar al enemigo
       


        if (Input.GetMouseButtonDown(0) && gunLoaded)//Ratio de disparo configurable
        //if (Input.GetMouseButtonDown(0))//Ratio de disparo fija
        {
            ShootBullet();
            
        }
    }

    void MovePlayerGetKey()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector2.left*_speed*Time.deltaTime);
        }
       

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right*_speed*Time.deltaTime);
 
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }
       
    }

    void MovePlayerAxis()
    {
        //Devuelve un valor entre -1 y 1 que se corresponde con la magnitud de la entrada de teclado
        //en el eje horizontal
        h = Input.GetAxis("Horizontal");//letras ad o flechas <- ->
        Debug.Log(h);
        v = Input.GetAxis("Vertical"); //letras ws o flechas arriba y abajo
        Debug.Log(v);

        //Cambiamos la posici�n de nuestro player
        moveDirection.x = h;
        moveDirection.y = v;

        //transform.position=moveDirection;
        //Necesitamos incorporar el delltaTime para normalizar la velocidad del movimiento.
        //La variable _speed nos va a permitir configurar diferentes velocidades.

        transform.position += moveDirection * Time.deltaTime * _speed; //podemos aplicar el movimiento sobre position

        //transform.Translate(moveDirection*Time.deltaTime*_speed); //podemos aplicar el movimiento utilizando el m�todo Translate
    }

    void Aiming()
    {
        //La mira tomar� la posici�n del mouse, traducida desde un punto de la pantalla a un punto del mundo del juego
        //La diferencia entre la posici�n del rat�n y la posici�n del player nos va a dar la direcci�n
        //hacia donde est� apuntando el Player representada por un vector.
        facingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //camera.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        //Para que la mira orbite alrededor del Player a una distancia fija
        //Debemos establecer que la posici�n de la mira ser� la posici�n del Player + el vector hacia donde 
        //apunta el rat�n desde el Player.  Lo normalizamos para que esa distancia sea siempre fija
        //a una distancia de 1 unidad
        //El m�todo normalized devuelve un vector unitario que apunta en la misma direcci�n.
        aim.position = transform.position + (Vector3)facingDirection.normalized;
    }
    void ShootBullet()
    {
        gunLoaded = false;
        //El objetivo que perseguimos es la creaci�n de un proyectil que tenga su origen en el player
        //Y se mueva en la direcci�n que indica la mira.

        //Para ello utilizaremos el m�todo Instantiate (prefab,position,rotation)
        //prefab: el elemento que materializar� el objeto que vamos a crear, en este caso el proyectil
        //position: la posici�n en la que se crea el objeto que en nuestro caso ser� la misma del jugador
        //ya que el movimiento del proyectil tiene su origen en el player.
        //rotation: Orientaci�n en el espacio del proyectil. Esta orientaci�n definir� la direcci�n en la
        //que se mover� el proyectil (recordemos que el proyectil siempre se mueve a la derecha, por tanto, para
        //moverlo en otra direcci�n necesitamos rotar el proyectil en el espacio)
        //Esta direcci�n viene definida por la posici�n de la mira en relaci�n al player, es decir,
        //su vector direccional ser� aquel que tiene su origen
        //en la posici�n del player y apunta hacia la posici�n de la mira. 

        //Dado que el proyectil se mueve siempre hacia la derecha (eje x), utilizaremos el
        //arcotangente para calcular el �ngulo entre esa direcci�n (eje x) y la posici�n de la mira.
        //Esa ser� la direcci�n en la que se tiene que desplazar el proyectil.

        //Para ello utilizamos el arcotangente (Atan2).
        //El arcotangente define el �ngulo que forma un vector con respecto al eje X.
        // As�, una coordenadas x,y definen un vector que tiene origen en el punto 0,0 y el punto x,y. Ese punto
        //forma un �ngulo con el eje X que se corresponde con el arcotangente

        //facingDirection es un vector que representa la direcci�n hacia la que apunta la mira desde
        //el player y por tanto, define la direcci�n hacia donde debe dirigirse el proyectil
        //y es este vector el que tomaremos de referencia para calcular la direcci�n que debe tomar
        //el proyectil en su movimiento

        //Atan2 devuelve el �ngulo en radianes que deberemos pasar a grados.
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;

        //La rotaci�n del proyectil en el momento de su instanciaci�n es lo que se corresponde con este �ngulo
        //La rotaci�n debe expresarse en Quaterniones, por tanto, convertiremos este �ngulo en 
        //un objeto de tipo Quaternion mediante el m�todo AngleAxis.
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Instantiate nos permite crear un GameObject en tiempo de ejecuci�n a partir de un prefab.
        //Podemos simplemente instanciar un objeto sin tener en cuenta su posici�n en la escena
        //o podemos indicarle un punto exacto (position) y una orientaci�n en el espacio (rotation)
        //PAra la instanciaci�n del prefab, necesitamos que el proyectil 
        Instantiate(bulletPrefab, transform.position, targetRotation);
        StartCoroutine(ReloadGun());//LLamamos a la corrutina de recarga del arma

    }
    //Esta corrutina nos permite recargar el arma.
    IEnumerator ReloadGun()
    {
        //Esta corrutina permite introducir un retardo de 1/fireRate antes de permitir volver
        //a instanciar un nuevo proyectil.
        //Dado que el par�metro de entrada que recibe WaitForSeconds representa los segundos de retardo...
        //...esto significa que podremos instanciar fireRate proyectiles en un segundo
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;//Cargamos el arma
    }
}
