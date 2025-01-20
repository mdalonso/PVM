using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RotationEulerAngle : MonoBehaviour
{
    
      // Start is called before the first frame update
    void Start()
    {
       
        //Rotaci�n en basa a un Quaternion definido mediante 3 �ngulos en los ejes x,y,z
        //RotarEuler();

        //Rotaci�n en base a un Quaternion definidio mediante en giro de un �ngulo en un eje.
        RotarAngulo();

       
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    //Este m�todo establece la rotaci�n del GameObject en 60� en cada uno de los ejes.
    void RotarEuler()
    {
        transform.rotation = Quaternion.Euler(60, 90, 30);
    }

    //ESte m�todo establece la rotaci�n del objeto en 60� con respecto al eje y
    void RotarAngulo()
    {
        transform.rotation = Quaternion.AngleAxis(60, Vector3.up);
    }

    
}
