using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 moveDirection;

    //Propiedad para acceder al campo _speed
    public float Speed { get { return _speed; } set { _speed = value; } }

    //La variable water contendrá un array con todos los elementos agua que hay enla escena
    //con el fin de suscribir el player a los eventos declarados en todos los elementos Water de la escena.
    Water[] water;

    private void Start()
    {
        //SUSCRIBIMOS EL PLAYER A LOS EVENTOS QUE CONTROLAN EL EFECTO DEL AGUA SOBRE LA VELOCIDAD DEL PLAYER*************

        //Inicializamos water localizando todos los elementos Water que hay en la escena, los cuales tienen definidos los eventos
        //de respuesta del player
        water=FindObjectsOfType<Water>();
        //Recorremos el array para suscirbirnos a los eventos de todos los elementos Water.
        foreach(Water w in water)
        {
            //La suscripción indica que cuando se produzca el evento OnWater, responderemos con el método DecreaseSpeed
            w.OnWater += DecreaseSpeed;

            //La suscripción indica que cuando se produzca el evento OnGround, responderemos con el método RecoverSpeed
            w.OnGround += RecoverSpeed;
        }
    }
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        transform.position += (Vector3)moveDirection * Time.deltaTime * _speed;
    }

    /*** Los siguientes métodos definen la respuesta del player a los evento OnWater y OnGround
     que se han definido en el script Water*/
    void DecreaseSpeed(float penaltySpeed)
    {
        _speed*=penaltySpeed;
    }void RecoverSpeed(float penaltySpeed)
    {
        _speed/=penaltySpeed;
    }
}
