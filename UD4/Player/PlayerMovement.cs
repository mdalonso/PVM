using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float h, v;

    Vector3 moveDirection;
    [SerializeField] float _speed = 5;

    [SerializeField] Animator _anim;


    Water[] _water;


    private void Start()
    {
        _water=FindObjectsOfType<Water>();
        //suscripción a eventos
        foreach (Water w in _water)
        {
            w.OnWater += DecreaseSpeed;
            w.OnGround += RecoverySpeed;

        }
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayerAxis();
    }

    void MovePlayerAxis()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        //transform.position += moveDirection*Time.deltaTime*_speed;
        transform.Translate(moveDirection.normalized * Time.deltaTime * _speed);
        _anim.SetFloat("Speed",moveDirection.magnitude);
    }

    //Métodos de respuesta a los eventos OnWater y OnGround
    void DecreaseSpeed(float penaltySpeed)
    {

        _speed*=penaltySpeed;
    }

    void RecoverySpeed(float penaltySpeed)
    {
        _speed/=penaltySpeed;
    }


}
