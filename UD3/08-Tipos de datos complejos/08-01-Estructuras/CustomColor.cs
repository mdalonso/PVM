using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//La estructura CustomColor permite almacenar información relativa a las componentes
//de un color como son sus componentes RGB + la transparencia
public struct CustomColor
{
    public float r;
    public float g;
    public float b;
    public float a;//opacidad

    // Constructor
    public CustomColor(float r, float g, float b, float a = 1f)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }

    // Convertir la información contenida en la estructura a un Color de Unity
    //Todos los componentes del color de Unity son valores float entre 0 y 1.
    public Color ToUnityColor()
    {
        return new Color(r, g, b, a);
    }

}
