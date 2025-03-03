using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float h, v;

    Vector3 moveDirection;
    [SerializeField] int _speed = 5;


   

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
    }


}
