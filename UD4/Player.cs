using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    float h,v;//eje de movimiento horizonal y vertical
    //Definimos el vector moveDirection como un Vector3 a pesar de estar en un mundo 2D porque 
    //las operaciones que realizaremos posteriormente con él para mover al player requieren que sea
    //de este tipo. ¿Por qué? Porque la propiedad position del componente transform
    //del player viene definido implícitamente com un vector3D (como
    //en cualquier GameObject). También podemos definirlo como un Vector2D y luego hacer un casting.
    Vector3 moveDirection;//Vector que determina la dirección del movimiento.
    Vector2 moveDirection2D;
    [SerializeField] float _speed=5; //[SerializedField] Permite serializar una variable sin tener que hacerla pública

    [SerializeField] Transform aim;//enlazamos una referencia a aim desde el inspector, por eso lo serializamos
   // [SerializeField] Camera camera;

    //El vector facingDirection es el vector trazado entre la posición del player y la mira
    Vector2 facingDirection;//Direcciión hacia donde apunta la mira

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
        //MovePlayerGetKey(); //Gestión del movimiento con la pulsación de teclas
        MovePlayerAxis();//Gestión del movimiento

        Aiming();//Método que permite mover la mira para apuntar al enemigo
       


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

        //Cambiamos la posición de nuestro player
        moveDirection.x = h;
        moveDirection.y = v;

        //transform.position=moveDirection;
        //Necesitamos incorporar el delltaTime para normalizar la velocidad del movimiento.
        //La variable _speed nos va a permitir configurar diferentes velocidades.

        transform.position += moveDirection * Time.deltaTime * _speed; //podemos aplicar el movimiento sobre position

        //transform.Translate(moveDirection*Time.deltaTime*_speed); //podemos aplicar el movimiento utilizando el método Translate
    }

    void Aiming()
    {
        //La mira tomará la posición del mouse, traducida desde un punto de la pantalla a un punto del mundo del juego
        //La diferencia entre la posición del ratón y la posición del player nos va a dar la dirección
        //hacia donde está apuntando el Player representada por un vector.
        facingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //camera.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        //Para que la mira orbite alrededor del Player a una distancia fija
        //Debemos establecer que la posición de la mira será la posición del Player + el vector hacia donde 
        //apunta el ratón desde el Player.  Lo normalizamos para que esa distancia sea siempre fija
        //a una distancia de 1 unidad
        //El método normalized devuelve un vector unitario que apunta en la misma dirección.
        aim.position = transform.position + (Vector3)facingDirection.normalized;
    }
    void ShootBullet()
    {
        gunLoaded = false;
        //El objetivo que perseguimos es la creación de un proyectil que tenga su origen en el player
        //Y se mueva en la dirección que indica la mira.

        //Para ello utilizaremos el método Instantiate (prefab,position,rotation)
        //prefab: el elemento que materializará el objeto que vamos a crear, en este caso el proyectil
        //position: la posición en la que se crea el objeto que en nuestro caso será la misma del jugador
        //ya que el movimiento del proyectil tiene su origen en el player.
        //rotation: Orientación en el espacio del proyectil. Esta orientación definirá la dirección en la
        //que se moverá el proyectil (recordemos que el proyectil siempre se mueve a la derecha, por tanto, para
        //moverlo en otra dirección necesitamos rotar el proyectil en el espacio)
        //Esta dirección viene definida por la posición de la mira en relación al player, es decir,
        //su vector direccional será aquel que tiene su origen
        //en la posición del player y apunta hacia la posición de la mira. 

        //Dado que el proyectil se mueve siempre hacia la derecha (eje x), utilizaremos el
        //arcotangente para calcular el ángulo entre esa dirección (eje x) y la posición de la mira.
        //Esa será la dirección en la que se tiene que desplazar el proyectil.

        //Para ello utilizamos el arcotangente (Atan2).
        //El arcotangente define el ángulo que forma un vector con respecto al eje X.
        // Así, una coordenadas x,y definen un vector que tiene origen en el punto 0,0 y el punto x,y. Ese punto
        //forma un ángulo con el eje X que se corresponde con el arcotangente

        //facingDirection es un vector que representa la dirección hacia la que apunta la mira desde
        //el player y por tanto, define la dirección hacia donde debe dirigirse el proyectil
        //y es este vector el que tomaremos de referencia para calcular la dirección que debe tomar
        //el proyectil en su movimiento

        //Atan2 devuelve el ángulo en radianes que deberemos pasar a grados.
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;

        //La rotación del proyectil en el momento de su instanciación es lo que se corresponde con este ángulo
        //La rotación debe expresarse en Quaterniones, por tanto, convertiremos este ángulo en 
        //un objeto de tipo Quaternion mediante el método AngleAxis.
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Instantiate nos permite crear un GameObject en tiempo de ejecución a partir de un prefab.
        //Podemos simplemente instanciar un objeto sin tener en cuenta su posición en la escena
        //o podemos indicarle un punto exacto (position) y una orientación en el espacio (rotation)
        //PAra la instanciación del prefab, necesitamos que el proyectil 
        Instantiate(bulletPrefab, transform.position, targetRotation);
        StartCoroutine(ReloadGun());//LLamamos a la corrutina de recarga del arma

    }
    //Esta corrutina nos permite recargar el arma.
    IEnumerator ReloadGun()
    {
        //Esta corrutina permite introducir un retardo de 1/fireRate antes de permitir volver
        //a instanciar un nuevo proyectil.
        //Dado que el parámetro de entrada que recibe WaitForSeconds representa los segundos de retardo...
        //...esto significa que podremos instanciar fireRate proyectiles en un segundo
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;//Cargamos el arma
    }
}
