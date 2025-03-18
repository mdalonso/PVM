using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float _speedPenalty = 0.5f;

    public float SpeedPenalty { get => _speedPenalty; set => _speedPenalty = value; }

    //Declaración de eventos
    public event Action<float> OnWater;
    public event Action<float> OnGround;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnWater?.Invoke(SpeedPenalty);//Disparamos el evento OnWater cuando el Player entre en el collider del Water
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnGround?.Invoke(SpeedPenalty);//Disparamos el evento OnGround cuando el Player salga del collider del Water
        }
    }
}
