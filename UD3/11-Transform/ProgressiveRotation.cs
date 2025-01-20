using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ProgressiveRotation : MonoBehaviour
{

    private Quaternion _targetRotation;//La rotaci�n que queremos conseguir
    private Quaternion _inicio;//La rotaci�n de la que partimos
    private float _speed = 0.5f;//Velocidad de giro
    private float _t = 0.5f;//Factor de interporlaci�n


    // Start is called before the first frame update
    void Start()
    {
        //Rotaci�n que queremos conseguir: Giramos 60 grados en cada eje. El m�todo Quaternion.Euler permite crear un Quaternion a partir de
        //3 �ngulos en los ejes x, y, z
        _targetRotation = Quaternion.Euler(60, 60, 60);
        //_inicio contiene la rotaci�n inicial del objeto
        _inicio = transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {

       RotarTransicion();
       //RotarContinuo();



    }


    //Interpolaci�n lineal.
    //Es necesario ir incrementando el grado en cada llamada en Update para ir desde la posici�n inicial hasta la posici�n final.
    //En este caso la rotaci�n inicial es siempre la rotaci�n de partida inicial.
    void RotarTransicion()
    {
        _t += Time.deltaTime * _speed;
        ;

        _t = Mathf.Clamp01(_t);//Mantiene el valor en el rango 0-1
        transform.rotation = Quaternion.Lerp(_inicio, _targetRotation, _t);

    }
    //rotaci�n continua.
    //Vamos desde la posici�n inicial hasta la posici�n final a una velocidad de _speed� por egundo.
    //En este caso la rotaci�n inicial tiene que ser la rotaci�n alcanzada en cada frame.
    void RotarContinuo()
    {

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _speed * Time.deltaTime);

    }


}
