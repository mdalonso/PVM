using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] Transform _aim;
    Vector2 _facingDirection;
   
   
    // Update is called once per frame
    void Update()
    {
        Aiming();
    }

    void Aiming()
    {
        _facingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _aim.position = transform.position + (Vector3)_facingDirection.normalized;

    }

    public Vector2 GetFacingDirection()
    {
        return _facingDirection;
    }
}
