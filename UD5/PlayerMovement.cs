using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;//Referencia al componente Character Controller del Player (inicializado en el inspector)

    [SerializeField] float _speed=20f;//Velocidad del movimiento

    Vector3 _velocity;//Vector para simular la fuerza de la gravedad y mantener el personaje en contacto con el suelo cuando se utiliza Move
    float _gravity = -9.81f;//Valor de la gravedad

    public float Speed { get => _speed; set => _speed = value; }


    // Update is called once per frame
    void Update()
    {
        //Utilizamos un método u otro.
        //SimpleMovement();
        Movement();
    }

    void Movement()
    {
        //Obtenemos la cantidad de movimiento en los ejes X y Z (plano horizontal)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Costruimos el vector de movimiento
        //transform.right y transform.forward determinan la dirección del movimiento en los ejes X y Z (vectores unitarios)
        //los multiplicamos por la cantidad de movimiento que hay que aplicar en ambos ejes
        Vector3 movement = transform.right * x + transform.forward * z;

        //El método Move permite aplicar un vector de movimiento a un objeto a través de su componente characterController.
        //Move no tiene encuenta el destaTime ni la gravedad, por lo que hay que controlar estos parámetros manualmente.
        characterController.Move(movement.normalized * Speed*Time.deltaTime);

        //La gravedad es necesario controlarla porque es posible que nos estemos desplazando con un terreno con desniveles lo que
        //puede hacer que nuestro player flote sobre el suelo en lugar de desplazarse pegado a él.


        //EFECTO SALTO

        //Si durante el movimiento, nuestro jugador se despega del suelo, hacemos que vuelva a él a una velocidad
        //proporcional a la fuerza de la gravedad
        if (!characterController.isGrounded)//Si al terminar el movimiento en este frame el personaje no está pegado al suelo...
        {
            //Construimos una fuerza de empuje hace abajo (recordamos que gravity es un valor negativo)
            _velocity.y += _gravity * Time.deltaTime;
        }
        else //Si está pegado al suelo
        {
            _velocity.y = -2f; //...reforzamos la gravedad para mantenerlo ahí
        }
        //Para probar el movimiento sin EFECTO SALTO comentar el ir y dejar sólo la línea _velociy.y=-2f

        characterController.Move(_velocity * Time.deltaTime); //Aplicamos ese empuje hacia abajo.

    }

    void SimpleMovement()
    {
        //Obtenemos la cantidad de movimiento en los ejes X y Z (plano horizontal)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Costruimos el vector de movimiento
        //transform.right y transform.forward determinan la dirección del movimiento en los ejes X y Z (vectores unitarios)
        //los multiplicamos por la cantidad de movimiento que hay que aplicar en ambos ejes
        Vector3 movement = transform.right * x + transform.forward * z;

        //Aplicamos el vector de movimiento mediante SimpleMove que controla automáticamente tanto la gravedad como el Time.deltaTime.
        characterController.SimpleMove(movement.normalized * Speed);


        

    }
}
