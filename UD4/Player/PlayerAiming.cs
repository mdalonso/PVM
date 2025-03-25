using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] Transform _aim;
    Vector2 _facingDirection;

    [SerializeField] SpriteRenderer _spriteRenderer;
    // Update is called once per frame
    void Update()
    {
        Aiming();
    }

    void Aiming()
    {
        _facingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _aim.position = transform.position + (Vector3)_facingDirection.normalized;

        if (_aim.position.x > transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_aim.position.x < transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }

    }

    public Vector2 GetFacingDirection()
    {
        return _facingDirection;
    }
}
