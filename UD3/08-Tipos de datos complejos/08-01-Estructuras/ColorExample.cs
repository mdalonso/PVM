using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorExample : MonoBehaviour
{
    float r, g, b;
   
    private void Update()
    {
        //El GameObject cambia de color aleatoriamente cada vez que se pulsa la tecla C.
        if (Input.GetKeyDown(KeyCode.C))
        {
            r = (float)new System.Random().NextDouble();
            g = (float)new System.Random().NextDouble();
            b = (float)new System.Random().NextDouble();

            //Generamos un color utilizando nuestro struct.
            CustomColor customColor = new CustomColor(r, g, b);

            //El componente Renderer forma parte de cualquier GameObject que no está vacío.
            Renderer renderer = GetComponent<Renderer>();
            //Accede al material del objeto, en este caso el material por defecto, y le asigna el color generado.
            renderer.material.color=customColor.ToUnityColor(); ;

        }

    }
}
