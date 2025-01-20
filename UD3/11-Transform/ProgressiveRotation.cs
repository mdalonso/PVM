using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ProgressiveRotation : MonoBehaviour
{

    private Quaternion _targetRotation;//La rotación que queremos conseguir
    private Quaternion _inicio;//La rotación de la que partimos
    private float _speed = 0.5f;//Velocidad de giro
    private float _t = 0.5f;//Factor de interporlación


    // Start is called before the first frame update
    void Start()
    {
        //Rotación que queremos conseguir: Giramos 60 grados en cada eje. El método Quaternion.Euler permite crear un Quaternion a partir de
        //3 ángulos en los ejes x, y, z
        _targetRotation = Quaternion.Euler(60, 60, 60);
        //_inicio contiene la rotación inicial del objeto
        _inicio = transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {

       RotarTransicion();
       //RotarContinuo();



    }


    //Interpolación lineal.
    //Es necesario ir incrementando el grado en cada llamada en Update para ir desde la posición inicial hasta la posición final.
    //En este caso la rotación inicial es siempre la rotación de partida inicial.
    void RotarTransicion()
    {
        _t += Time.deltaTime * _speed;
        ;

        _t = Mathf.Clamp01(_t);//Mantiene el valor en el rango 0-1
        transform.rotation = Quaternion.Lerp(_inicio, _targetRotation, _t);

    }
    //rotación continua.
    //Vamos desde la posición inicial hasta la posición final a una velocidad de _speedº por egundo.
    //En este caso la rotación inicial tiene que ser la rotación alcanzada en cada frame.
    void RotarContinuo()
    {

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _speed * Time.deltaTime);

    }


}
