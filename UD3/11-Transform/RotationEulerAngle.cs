using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RotationEulerAngle : MonoBehaviour
{
    
      // Start is called before the first frame update
    void Start()
    {
       
        //Rotación en basa a un Quaternion definido mediante 3 ángulos en los ejes x,y,z
        //RotarEuler();

        //Rotación en base a un Quaternion definidio mediante en giro de un ángulo en un eje.
        RotarAngulo();

       
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    //Este método establece la rotación del GameObject en 60º en cada uno de los ejes.
    void RotarEuler()
    {
        transform.rotation = Quaternion.Euler(60, 90, 30);
    }

    //ESte método establece la rotación del objeto en 60º con respecto al eje y
    void RotarAngulo()
    {
        transform.rotation = Quaternion.AngleAxis(60, Vector3.up);
    }

    
}
