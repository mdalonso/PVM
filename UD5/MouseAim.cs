using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim: MonoBehaviour
{
    [SerializeField] float _sensitivity=500f; //Sensibilidad del movimiento de la mira.Nos permitirá ajustarlo a través del inspector.
    [SerializeField] float _xRotation = 0f;//Rotación de la mira en el eje X

    [SerializeField] Transform player; //Referencia al player

    public float Sensitivity { get => _sensitivity; set => _sensitivity = value; }
    public float XRotation { get => _xRotation; set => _xRotation = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;//bloquea el cursor al centro de la ventana de juego.
    }

    // Update is called once per frame
    void Update()
    {
        AimRotation();

    }

    void AimRotation()
    {
        //mouseX y mouseY sirven para detectar la cantidad de movimiento en los ejes X e Y
        //El movimiento en el eje X se asociará a la rotación sobre el eje Y.
        //El movimiento en el eje Y se asociará a la rotación en el eje X.
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        //Para aplicar el movimiento del ratón en el eje Y a la rotación en el eje X hay que restar
        //ya que el movimiento del ratón hacia abajo devuelve un valor negativo en GetAxis
        //y sin embargo, esto produce una rotación positiva (hacia adelante)
        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 75f);//Limita la rotación dentro de un intervalo.

        //Aplicamos rotación local de la cámara con respecto a su padre (player).
        //Quaternion.Euler permite obtener un quaternión a partir de ángulos en los ejes X, Y y Z.
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        //rotación del player en el eje Y para girar a derecha e izquierda.
        player.Rotate(Vector3.up * mouseX);
    }
}
